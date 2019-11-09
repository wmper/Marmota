using Microsoft.AspNetCore.Http;
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

        public async Task Invoke(HttpContext context)
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

            context.Items.Add(MarmotaHttpContextItems.Requetst, httpRequestMessage);

            await _next(context);
        }
    }
}
