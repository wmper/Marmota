using Marmota.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marmota.Middleware
{
    public class MapUrlHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public MapUrlHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IOptions<MarmotaOptions> options)
        {
            var url = string.Empty;
            var path = context.Request.Path.Value.ToLower();

            foreach (var route in options.Value.Routes)
            {
                var scheme = route.Scheme;
                var host = route.Host;
                var port = route.Port;
                url = $"{scheme}://{host}:{port}";

                var up = route.Path.Up.ToLower();

                if (up == "/*" || up == path)
                {
                    url += $"{path}";

                    break;
                }

                if (up.EndsWith("*"))
                {
                    var tempUp = up.Substring(0, up.Length - up.LastIndexOf("*") - 1);
                    if (path.StartsWith(tempUp))
                    {
                        url += $"{path}";

                        break;
                    }
                }
            }

            if (url != string.Empty)
            {
                var httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = new HttpMethod(context.Request.Method),
                    Content = await MapContentAsync(context)
                };

                foreach (var item in context.Request.Headers)
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation(item.Key, item.Value.ToArray());
                }

                context.Items.Add(MarmotaHttpContextItems.Requetst, httpRequestMessage);
            }

            await _next(context);
        }

        private HttpContent CheckHeaders(HttpContent content, HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.ContentType))
            {
                content.Headers.TryAddWithoutValidation("Content-Type", new[] { context.Request.ContentType });
            }

            var keys = new string[] { "Content-Language", "Content-Location", "Content-Range", "Content-MD5", "Content-Disposition", "Content-Encoding" };
            foreach (var key in keys)
            {
                if (context.Request.Headers.ContainsKey(key))
                {
                    content.Headers.TryAddWithoutValidation(key, context.Request.Headers[key].ToArray());
                }
            }

            return content;
        }

        private async Task<HttpContent> MapContentAsync(HttpContext context)
        {
            if (context.Request.Body == null || (context.Request.Body.CanSeek && context.Request.Body.Length <= 0))
            {
                return null;
            }

            var body = await ToByteArray(context.Request.Body);
            var content = new ByteArrayContent(body);

            return CheckHeaders(content, context);
        }

        private async Task<byte[]> ToByteArray(Stream stream)
        {
            using (stream)
            {
                using (var memStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memStream);

                    return memStream.ToArray();
                }
            }
        }
    }
}
