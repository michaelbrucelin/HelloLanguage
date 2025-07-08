using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace MailSender
{
    internal class Program
    {
        /// <summary>
        /// Install-Package Microsoft.Extensions.DependencyInjection
        /// using Microsoft.Extensions.DependencyInjection
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            // 注册服务
            services.AddScoped<ILogProvider, ConsoleLogProvider>();
            services.AddScoped<IConfigService, EnvVarConfigService>();
            services.AddScoped<IMailService, MailService>();
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                // 根对象需要用ServiceLocator的方式去获取，关联的对象可以直接注入
                IMailService mailService = sp.GetRequiredService<IMailService>();
                mailService.Send("Hello", "somebody@some.com", "hello?");
            }

            // Console.ReadLine();
        }
    }
}
