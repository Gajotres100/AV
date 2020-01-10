using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ComProvis.CSP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5001")
                .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false);
    }
}
