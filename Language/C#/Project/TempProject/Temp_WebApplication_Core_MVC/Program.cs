using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Temp_WebApplication_Core_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //如果想要忽略其他配置文件，只是用MyAppsettings.json这个配置文件，可以这样做
                //.ConfigureAppConfiguration((context, configBuilder) =>
                //{
                //    configBuilder.Sources.Clear();
                //    configBuilder.AddJsonFile("MyAppsettings.json");
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
