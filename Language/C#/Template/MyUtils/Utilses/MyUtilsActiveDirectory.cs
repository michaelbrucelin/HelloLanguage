using System;
using System.ComponentModel;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Net.NetworkInformation;

namespace WindowsFormsApp0
{
    public static class MyUtilsActiveDirectory
    {
        //验证电脑是否在域中
        //电脑在域中，返回true；电脑不在域中，返回false；
        //电脑在域中，但是使用本地用户登录，返回true；
        public static bool IsPCInDomain1()
        {
            MyUtilsWin32.NetJoinStatus status = MyUtilsWin32.NetJoinStatus.NetSetupUnknownStatus;
            IntPtr pDomain = IntPtr.Zero;
            int result = MyUtilsWin32.NetGetJoinInformation(null, out pDomain, out status);
            if (pDomain != IntPtr.Zero)
            {
                MyUtilsWin32.NetApiBufferFree(pDomain);
            }
            if (result == MyUtilsWin32.ErrorSuccess)
            {
                return status == MyUtilsWin32.NetJoinStatus.NetSetupDomainName;
            }
            else
            {
                throw new Exception("Domain Info Get Failed", new Win32Exception());
            }
        }

        //验证电脑是否在域中
        //电脑在域中，返回true；电脑不在域中，返回false；
        //电脑在域中，但是使用本地用户登录，返回false；
        public static bool IsPCInDomain2()
        {
            try
            {
                Domain.GetComputerDomain();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //验证电脑是否在域中
        //电脑在域中，返回true；电脑不在域中，返回false；
        //电脑在域中，但是使用本地用户登录，返回true；
        public static bool IsPCInDomain3()
        {
            if (IPGlobalProperties.GetIPGlobalProperties().DomainName.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //验证当前用户是否为域用户
        public static bool IsUserInDomain()
        {
            if (IsPCInDomain2())
            {
                //当使用IsPCInDomain2()时，这个地方有逻辑错误，因为当不是域用户时，IsPCInDomain2()返回的就是false;
                //这个暂时没有优化，使用前需要重新构造
                try
                {
                    Domain.GetCurrentDomain();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //获取电脑所在域的域名
        //电脑在域中，但是使用本地用户登录，抛异常
        public static string GetPCDomainName1()
        {
            try
            {
                return Domain.GetComputerDomain().ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        //获取电脑所在域的域名
        //电脑在域中，但是使用本地用户登录，正确返回域名
        public static string GetPCDomainName2()
        {
            return IPGlobalProperties.GetIPGlobalProperties().DomainName;
        }

        //获取当前用户所在域的域名
        public static string GetUserDomainName()
        {
            try
            {
                return Domain.GetCurrentDomain().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //验证域用户账号密码
        public static bool VerifyDomainAccount(string domain, string account, string password)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain))
            {
                return pc.ValidateCredentials(account, password);
            }
        }
    }
}

