using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0745
{
    public class Test0745
    {
        public Test0745()
        {
            dir0745 = Environment.CurrentDirectory;
            dir0745 = Directory.GetParent(dir0745).FullName;
            dir0745 = Directory.GetParent(dir0745).FullName;
            dir0745 = Directory.GetParent(dir0745).FullName;
            dir0745 = Path.Combine(dir0745, "QuestionBank", "Question0745");
        }

        private string dir0745;

        public void Test()
        {
            Test01();
        }

        private void Test01()
        {
            string wordstr = File.ReadAllText(dir0745);
            // string[] words = 
            // WordFilter wordFilter = new WordFilter(words);
        }
    }
}
