using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCGKPLAB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((hostingContextx, config) =>
                    {
                        var env = hostingContextx.HostingEnvironment;

                        config.SetBasePath(env.ContentRootPath)
                            .AddJsonFile("Secrets.json", optional: true, reloadOnChange: true);
                    })
                  .ConfigureLogging((hostingContext, logging) =>
                  {
                      logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                      logging.AddConsole();
                      logging.AddDebug();
                      logging.AddEventSourceLogger();
                      logging.AddNLog();
                  })
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();                     
                 });

        // .Net 6.0 me
        //var builder = WebApplication.CreateBuilder(args);
        //builder.Configuration
        //    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Secrets.json");


        //.ConfigureServices(services => 
        //            services.AddHostedService<DerivedBackgroundPrinter>());
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
