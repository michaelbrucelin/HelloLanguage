using ConfigServices;
using LogServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailServices
{
    /// <summary>
    /// 实现类可以考虑在其它项目中创建，这里图省事直接创建在类库项目中
    /// </summary>
    public class MailService : IMailService
    {
        public MailService(ILogProvider log, IConfigService config)
        {
            this.log = log;
            this.config = config;
        }

        private readonly ILogProvider log;
        private readonly IConfigService config;

        public void Send(string title, string to, string body)
        {
            log.LogInfo("准备发送邮件");
            string smtpServer = config.GetValue("SmtpServer");
            string userName = config.GetValue("UserName");
            string password = config.GetValue("Password");
            Console.WriteLine($"邮件服务器信息, SmtpServer: {smtpServer}, UserName: {userName}, Password: {password}");
            Console.WriteLine($"正在发送邮件, title: {title}, to: {to}, body: {body}");
            log.LogInfo("邮件发送完成");
        }
    }
}
