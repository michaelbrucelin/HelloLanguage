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
            //services.AddControllers();  //��APIʱʹ��

            services.AddSingleton<IClock, ChinaClock>();  //���һ��������ÿ������IClockʱ������һ��ChinaClock

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
                    //ʹ��Attribute·��
                    endpoints.MapRazorPages();
                });
            });
        }
    }
}
