using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Web.Services.Description;

namespace WindowsFormsApp0
{
    public static class MyUtilsTransfer
    {
        #region 局域网远程开机
        public static readonly Regex MacCheckRegex = new Regex(MyUtilsResources.regex_mac);

        //唤醒主要逻辑方法
        public static bool WakeUpComputer(string mac)
        {
            if (MacCheckRegex.IsMatch(mac, 0))
            {
                byte[] macByte = FormatMac(mac);
                WakeUpComputer_Core(macByte);
                return true;
            }

            return false;
        }

        private static void WakeUpComputer_Core(byte[] mac)
        {
            //50000就是随便给的一个端口
            WakeUpComputer_Core(mac, IPAddress.Broadcast, 50000);
        }

        private static void WakeUpComputer_Core(byte[] mac, IPAddress broadcast, ushort port)
        {
            UdpClient client = new UdpClient();

            //这里发的是Broadcast，即255.255.255.255，所以不需要IP
            client.Connect(broadcast, port);

            //生成魔术包，“FFFFFFFFFFFF”+16次mac的byte字节
            byte[] packet = new byte[17 * 6];
            for (int i = 0; i < 6; i++)
            {
                packet[i] = 0xFF;
            }

            for (int i = 1; i <= 16; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    packet[i * 6 + j] = mac[j];
                }
            }

            //唤醒动作，发送魔术包
            client.Send(packet, packet.Length);
        }

        private static byte[] FormatMac(string macInput)
        {
            byte[] mac = new byte[6];

            string str = Regex.Replace(macInput, @"[/\s:]", "-");
            //消除MAC地址中的“-”符号
            string[] macArray = str.Split('-');

            //mac地址从string转换成byte
            for (var i = 0; i < 6; i++)
            {
                var byteValue = Convert.ToByte(macArray[i], 16);
                mac[i] = byteValue;
            }

            return mac;
        }
        #endregion
    }
}
