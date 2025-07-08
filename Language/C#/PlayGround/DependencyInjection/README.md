# README

需求说明
1、目的：演示DI的能力；
2、有配置服务、日志服务，然后再开发一个邮件发送器服务。可以通过配置服务来从文件、环境变量、数据库等地方读取配置，可以通过日志服务来将程序运行过程中的日志信息写入文件、控制台、数据库等。
3、说明：案例中开发了自己的日志、配置等接口，这只是在揭示原理，.NET有现成的，后面讲。

实现1
1、创建三个\.NET Core类库项目，ConfigServices是配置服务的项目，LogServices是日志服务的项目，MailServices是邮件发送器的项目，然后再建一个\.NET Core控制台项目MailSender来调用MailServices。MailServices项目引用ConfigServices项目和LogServices项目，而MailSender项目引用MailServices项目。
2、编写类库项目LogServices，创建ILogProvider接口。编写实现类ConsoleLogProvider。编写一个ConsoleLogProviderExtensions定义扩展方法AddConsoleLog，namespace和IServiceCollection一致。

```powershell
Install-Package Microsoft.Extensions.DependencyInjection
using Microsoft.Extensions.DependencyInjection
```
