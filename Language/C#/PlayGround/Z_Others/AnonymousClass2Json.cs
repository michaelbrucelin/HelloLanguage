using System;
using Newtonsoft.Json;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 使有匿名类型构建数据，然后将匿名类型转为json，个人觉得这样代码比较优雅，也不容易出错（与拼接字符串相比）
            var jsonObj = new
            {
                name = txtGWName.Text,
                account = txtCNum.Text,
                registerType = 0,  // 0 静态 1 动态，默认为1
                lockType = cmbLockType.Text == "无锁定" ? 0 : 3,
                callLevel = t_callLevel,
                capacity = (int)nudCapacity.Value,
                routingGatewayGroupsAllow = t_routingGatewayGroupsAllow,
                routingGatewayGroups = t_routingGatewayGroups,
                softswitchRestricted = t_softswitchRestricted,
                softswitchVosNames = t_softswitchVosNames,
                remoteIps = txtIp.Text,
                callerLimitE164GroupsAllow = false,
                callerLimitE164Groups = "Caller",
                calloutCalleePrefixesAllow = rdoCalleePrefixAllow.Checked ? true : false,
                // calloutCalleeRoutePrefixes = txtRoutePrefix.Text,  // 接口不好用，暂时先取消
                calloutCalleePrefixes = txtNumPrefix.Text,
                rewriteRulesOutCaller = txtCallerDialRule.Text,
            };

            string thirdpartyinfo = JsonConvert.SerializeObject(jsonObj);
        }
    }
}
