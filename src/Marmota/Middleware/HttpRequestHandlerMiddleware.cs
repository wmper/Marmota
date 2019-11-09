using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marmota.Middleware
{
    public class HttpRequestHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpRequestHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IHttpClientFactory httpClientFactory)
        {
            if (context.Items.TryGetValue(MarmotaHttpContextItems.Requetst, out object value))
            {
                var client = httpClientFactory.CreateClient();

                var response = client.SendAsync((HttpRequestMessage)value, context.RequestAborted);

                context.Items.Add(MarmotaHttpContextItems.Response, response);
            }

            await _next(context);
        }
    }
}
