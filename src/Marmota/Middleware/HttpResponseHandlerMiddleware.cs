using Marmota.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marmota.Middleware
{
    public class HttpResponseHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpResponseHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Items.TryGetValue(MarmotaHttpContextItems.Response, out object value))
            {
                var httpResponseMessage = (HttpResponseMessage)value;

                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = (int)httpResponseMessage.StatusCode;
                }

                if (httpResponseMessage.Content is null)
                {
                    return;
                }

                if (httpResponseMessage.Content.Headers.ContentLength.HasValue)
                {
                    context.Response.ContentType = httpResponseMessage.Content.Headers.ContentType.ToString();
                    context.Response.ContentLength = httpResponseMessage.Content.Headers.ContentLength;
                }

                foreach (var item in httpResponseMessage.Content.Headers)
                {
                    CheckHeadler(context, item);
                }

                var content = await httpResponseMessage.Content.ReadAsStreamAsync();
                using (content)
                {
                    if (httpResponseMessage.StatusCode != HttpStatusCode.NotModified && context.Response.ContentLength != 0)
                    {
                        await content.CopyToAsync(context.Response.Body);
                    }
                }
            }
        }

        private void CheckHeadler(HttpContext context, KeyValuePair<string, IEnumerable<string>> item)
        {
            if (!context.Response.Headers.ContainsKey(item.Key))
            {
                context.Response.Headers.Add(item.Key, new StringValues(item.Value.ToArray()));
            }
        }
    }
}
