using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0641
{
    public interface Interface0641
    {
        public bool InsertFront(int value);

        public bool InsertLast(int value);

        public bool DeleteFront();

        public bool DeleteLast();

        public int GetFront();

        public int GetRear();

        public bool IsEmpty();

        public bool IsFull();
    }
}
