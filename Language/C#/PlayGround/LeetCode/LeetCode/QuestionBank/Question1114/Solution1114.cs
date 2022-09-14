using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1114
{
    public class Foo : Interface1114
    {

        public Foo()
        {
            this.state = 0;
        }

        private static readonly object LOCK = new object();
        private int state;  // 初始值：0，1表示执行完First()，2表示执行完Secind()，3表示执行完Third()

        public void First(Action printFirst)
        {

            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();

            this.state = 1;
        }

        public void Second(Action printSecond)
        {
            while (state != 1) Thread.Sleep(10);

            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();

            this.state = 2;
        }

        public void Third(Action printThird)
        {
            while (state != 2) Thread.Sleep(10);

            // printThird() outputs "third". Do not change or remove this line.
            printThird();

            this.state = 3;
        }
    }
}
