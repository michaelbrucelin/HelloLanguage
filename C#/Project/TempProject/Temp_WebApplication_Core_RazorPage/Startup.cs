using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Temp_WebApplication_Core_RazorPage.Services;

namespace Temp_WebApplication_Core_RazorPage
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            //services.AddControllers();  //做API时使用

            services.AddSingleton<IClock, ChinaClock>();  //添加一个单例，每当请求IClock时，返回一个ChinaClock

            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.Configure<ThisOptions>(_configuration.GetSection("Temp_WebApplication_Core_RazorPage"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //判断是不是开发环境，对应项目属性—调试下面的环境变量：ASPNETCORE_ENVIRONMENT
                if (env.IsDevelopment())
                {
                    //如果是开发模式，这个就是管道中的第一个中间件
                    app.UseDeveloperExceptionPage();
                }

                //使用html、css、js等静态文件的中间件，因为它不需要直到路由信息，所以可以放到路由中间件前面
                app.UseStaticFiles();

                //可以将http请求转为https请求的中间件
                app.UseHttpsRedirection();

                //身份认证中间件，需要放在UseEndpoints中间件前面
                app.UseAuthentication();

                //路由中间件，如果不是开发模式，例如发布的生产模式，默认情况下它就是管道中的第一个中间件
                app.UseRouting();

                //端点中间件，url结尾的部分，就是端点
                app.UseEndpoints(endpoints =>
                {
                    //使用Attribute路由
                    endpoints.MapRazorPages();
                });
            });
        }
    }
}
