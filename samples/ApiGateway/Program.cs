using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureAppConfiguration((context, config) =>
                    {
                        config.SetBasePath(context.HostingEnvironment.ContentRootPath);
                        config.AddJsonFile("marmota.json", true, true);
                    })
                   .UseStartup<Startup>();
    }
}
