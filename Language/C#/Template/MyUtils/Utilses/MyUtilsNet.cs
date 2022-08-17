using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsNet
    {
        /// <summary>
        /// 判断字符串是否是一个合法的ip格式
        /// </summary>
        /// <param name="ipstr"></param>
        /// <returns></returns>
        public static bool IsIP(string str)
        {
            IPAddress ip;
            return IPAddress.TryParse(str, out ip);
        }

        /// <summary>
        /// 判断字符串是否是一个合法的ipv4格式
        /// </summary>
        /// <param name="ipstr"></param>
        /// <returns></returns>
        public static bool IsIPv4(string str)
        {
            IPAddress ip;
            bool isip = IPAddress.TryParse(str, out ip);

            return isip && ip.AddressFamily == AddressFamily.InterNetwork;
        }

        /// <summary>
        /// 判断字符串是否是一个合法的ipv4格式
        /// </summary>
        /// <param name="ipstr"></param>
        /// <returns></returns>
        public static bool IsIPv6(string str)
        {
            IPAddress ip;
            bool isip = IPAddress.TryParse(str, out ip);

            return isip && ip.AddressFamily == AddressFamily.InterNetworkV6;
        }

        /// <summary>
        /// 将字符串形式的ip地址转为uint
        /// https://stackoverflow.com/questions/461742/how-to-convert-an-ipv4-address-into-a-integer-in-c
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static uint ConvertIpStr2Int(string ipAddress)
        {
            IPAddress address = IPAddress.Parse(ipAddress);
            byte[] bytes = address.GetAddressBytes();

            // flip big-endian(network order) to little-endian
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt32(bytes, 0);
        }

        /// <summary>
        /// 将uint形式的ip地址转为字符串
        /// https://stackoverflow.com/questions/461742/how-to-convert-an-ipv4-address-into-a-integer-in-c
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static string ConvertIpInt2Str(uint ipAddress)
        {
            byte[] bytes = BitConverter.GetBytes(ipAddress);

            // flip little-endian to big-endian(network order)
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return new IPAddress(bytes).ToString();
        }

        /// <summary>
        /// 从指定的ntp服务器获取时间
        /// https://stackoverflow.com/questions/1193955/how-to-query-an-ntp-server-using-c
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static DateTime GetNTPTimeByDomain(string serverName = "time.windows.com", int timeout = 3000)
        {
            // default Windows time server
            // const string ntpServer = "time.windows.com";

            // NTP message size - 16 bytes of the digest (RFC 2030)
            byte[] ntpData = new byte[48];

            // Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            IPAddress[] addresses = Dns.GetHostEntry(serverName).AddressList;

            return GetNTPTimeByIp(addresses[0], timeout);
        }

        /// <summary>
        /// 从指定的ntp服务器获取时间
        /// </summary>
        /// <param name="serverIp"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static DateTime GetNTPTimeByIp(string serverIp, int timeout = 3000)
        {
            // NTP message size - 16 bytes of the digest (RFC 2030)
            byte[] ntpData = new byte[48];

            // Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            return GetNTPTimeByIp(new IPAddress(ConvertIpStr2Int(serverIp)), timeout);
        }

        /// <summary>
        /// 从指定的ntp服务器获取时间
        /// </summary>
        /// <param name="serverIp"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static DateTime GetNTPTimeByIp(IPAddress serverIp, int timeout = 3000)
        {
            // NTP message size - 16 bytes of the digest (RFC 2030)
            byte[] ntpData = new byte[48];

            // Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            // The UDP port number assigned to NTP is 123
            IPEndPoint ipEndPoint = new IPEndPoint(serverIp, 123);

            // NTP uses UDP
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);

                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = timeout;

                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }

            // Offset to get to the "Transmit Timestamp" field (time at which the reply 
            // departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            // Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            // Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            // Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            ulong milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            // **UTC** time
            DateTime networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        /// <summary>
        /// 从指定的ntp服务器获取时间，辅助方法
        /// stackoverflow.com/a/3294698/162671
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                          ((x & 0x0000ff00) << 8) +
                          ((x & 0x00ff0000) >> 8) +
                          ((x & 0xff000000) >> 24));
        }
    }
}
