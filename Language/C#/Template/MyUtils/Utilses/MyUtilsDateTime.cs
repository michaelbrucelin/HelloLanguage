using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsDateTime
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// 将DateTime转为Unix时间戳
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ConvertToUnixTimeStamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch;
            return (long)elapsedTime.TotalSeconds;
        }

        /// <summary>
        /// 将DateTime转为Java时间戳
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ConvertToJavaTimeStamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch;
            return (long)elapsedTime.TotalMilliseconds;
        }

        /// <summary>
        /// 将Unix时间戳转为DateTime
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            // dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToUniversalTime();

            return dateTime;
        }

        /// <summary>
        /// 将Java时间戳转为DateTime
        /// </summary>
        /// <param name="javaTimeStamp"></param>
        /// <returns></returns>
        public static DateTime JavaTimeStampToDateTime(double javaTimeStamp)
        {
            // Java timestamp is milliseconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            // dateTime = dateTime.AddMilliseconds(javaTimeStamp).ToLocalTime();
            dateTime = dateTime.AddMilliseconds(javaTimeStamp).ToUniversalTime();

            return dateTime;
        }

        /// <summary>
        /// 计算指定日期是一周中的第几天
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        public static int GetWeekday(DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            return (dt.DayOfWeek - startOfWeek + 7) % 7 + 1;
        }
    }
}
