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
using Temp_WebApplication_Core_MVC.Services;

namespace Temp_WebApplication_Core_MVC
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
            //�����������������鷳�����һ�Ҫ����ת����������ConfigureServices���潫��������ӳ�䵽һ������ʹ��
            //var thisBold = _configuration["Temp_WebApplication_Core:BoldDepartmentEmployeeCountThreshold"];
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddControllers();  //��APIʱʹ��

            services.AddSingleton<IClock, ChinaClock>();  //���һ��������ÿ������IClockʱ������һ��ChinaClock

            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.Configure<ThisOptions>(_configuration.GetSection("Temp_WebApplication_Core_MVC"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //�ж��ǲ��ǿ�����������Ӧ��Ŀ���ԡ���������Ļ���������ASPNETCORE_ENVIRONMENT
            if (env.IsDevelopment())
            {
                //����ǿ���ģʽ��������ǹܵ��еĵ�һ���м��
                app.UseDeveloperExceptionPage();
            }

            //ʹ��html��css��js�Ⱦ�̬�ļ����м������Ϊ������Ҫֱ��·����Ϣ�����Կ��Էŵ�·���м��ǰ��
            app.UseStaticFiles();

            //���Խ�http����תΪhttps������м��
            app.UseHttpsRedirection();

            //�����֤�м������Ҫ����UseEndpoints�м��ǰ��
            app.UseAuthentication();

            //·���м����������ǿ���ģʽ�����緢��������ģʽ��Ĭ������������ǹܵ��еĵ�һ���м��
            app.UseRouting();

            //�˵��м����url��β�Ĳ��֣����Ƕ˵�
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                //endpoints.MapGet("/guid", async context =>
                //{
                //    await context.Response.WriteAsync($"Hello {{{Guid.NewGuid()}}}!");
                //});

                //endpoints.MapGet("/datetime", async context =>
                //{
                //    await context.Response.WriteAsync($"Hello {{{DateTime.Now}}}!");
                //});

                //MVCע��·��ģ��
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Department}/{action=Index}/{id?}");

                //ʹ��Attribute·��
                endpoints.MapControllers();
            });
        }
    }
}
