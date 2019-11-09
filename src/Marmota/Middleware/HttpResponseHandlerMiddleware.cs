using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net.Http;

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

                if (httpResponseMessage.Content.Headers.ContentLength != null)
                {
                    context.Response.ContentLength = httpResponseMessage.Content.Headers.ContentLength;
                }

                var content = await httpResponseMessage.Content.ReadAsStreamAsync();
                using (content)
                {
                    if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.NotModified && context.Response.ContentLength != 0)
                    {
                        await content.CopyToAsync(context.Response.Body);
                    }
                }
            }
        }
    }
}
