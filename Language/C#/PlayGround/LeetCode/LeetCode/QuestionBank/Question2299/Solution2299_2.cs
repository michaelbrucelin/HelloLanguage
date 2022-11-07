using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2299
{
    public class Solution2299_2 : Interface2299
    {
        /// <summary>
        /// 正则表达式
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool StrongPasswordCheckerII(string password)
        {
            if (password.Length < 8) return false;
            if (!Regex.IsMatch(password, "[a-z]")) return false;
            if (!Regex.IsMatch(password, "[A-Z]")) return false;
            if (!Regex.IsMatch(password, "[0-9]")) return false;
            if (!Regex.IsMatch(password, "[!@#$%^&*()+-]")) return false;
            if (Regex.IsMatch(password, @"([a-zA-Z0-9!@#$%^&*()+-])\1+")) return false;

            return true;
        }
    }
}
