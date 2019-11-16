using Marmota.Abstractions;
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
                var request = (HttpRequestMessage)value;

                using var client = httpClientFactory.CreateClient();

                var response = await client.SendAsync(request, context.RequestAborted);
                if (response.IsSuccessStatusCode)
                {
                    context.Items.Add(MarmotaHttpContextItems.Response, response);
                }
            }

            await _next(context);
        }
    }
}