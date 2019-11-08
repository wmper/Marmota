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
            var httpRequestMessage = new HttpRequestMessage()
            {
                //Method = new HttpMethod(context.Request.Method),
                //Content = null,
                //Headers = null,
                //Properties = null,
                //RequestUri = new System.Uri() { },
                //Version = null
            };

            var client = httpClientFactory.CreateClient();

            var response = client.SendAsync(httpRequestMessage, context.RequestAborted);

            context.Items.Add("Response", response);

            await _next(context);
        }
    }
}
