using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1417
{
    public class Solution1417_2
    {
        /// <summary>
        /// 原地操作
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Reformat(string s)
        {
            if (s.Length == 0) return s;

            // 如果数字与字母的数量相差大于1，无解
            int digitcnt = 0, charcnt = 0;
            for (int i = 0; i < s.Length; i++)
                if (char.IsDigit(s[i])) digitcnt++;
                else charcnt++;
            if (digitcnt - charcnt > 1 || digitcnt - charcnt < -1)
                return "";

            // 数字与字母的数量相差小于等于1，有解
            char[] buffer = s.ToCharArray();

            // 第一个字符必须是数量多的那一类
            bool needigit;
            if (digitcnt != charcnt && digitcnt > charcnt != char.IsDigit(buffer[0]))
            {
                needigit = !(digitcnt > charcnt);
                for (int i = 1; i < buffer.Length; i++)
                {
                    if (char.IsDigit(buffer[i]) != needigit)
                    {
                        Swap(buffer, 0, i);
                        break;
                    }
                }
            }
            else
                needigit = char.IsDigit(buffer[0]) ? false : true;

            // 逐步向后处理，如果某一位的字符类型不对，就向后找合适的做交换
            for (int i = 1; i < buffer.Length; i++, needigit = !needigit)
            {
                if (char.IsDigit(buffer[i]) != needigit)
                {
                    bool found = false;
                    for (int j = i + 1; j < buffer.Length; j++)
                    {
                        if (char.IsDigit(buffer[j]) == needigit)
                        {
                            Swap(buffer, i, j);
                            found = true;
                            break;
                        }
                    }

                    if (!found) return "";
                }
            }

            return new string(buffer);
        }

        private void Swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
