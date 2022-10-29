using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0025
{
    public class Test0025
    {
        public void Test()
        {
            Interface0025 solution = new Solution0025_3();
            ListNode head; int k;
            string result, answer;
            int id = 0;

            // 1.
            head = InitLinkedList(new int[] { 1, 2, 3, 4, 5 }); k = 1;
            answer = "[1,2,3,4,5]";
            result = WriteLinkedList(solution.ReverseKGroup(head, k));
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            head = InitLinkedList(new int[] { 1, 2, 3, 4, 5 }); k = 2;
            answer = "[2,1,4,3,5]";
            result = WriteLinkedList(solution.ReverseKGroup(head, k));
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            head = InitLinkedList(new int[] { 1, 2, 3, 4, 5 }); k = 3;
            answer = "[3,2,1,4,5]";
            result = WriteLinkedList(solution.ReverseKGroup(head, k));
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            head = InitLinkedList(new int[] { 1, 2, 3, 4, 5 }); k = 4;
            answer = "[4,3,2,1,5]";
            result = WriteLinkedList(solution.ReverseKGroup(head, k));
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5.
            head = InitLinkedList(new int[] { 1, 2, 3, 4, 5 }); k = 5;
            answer = "[5,4,3,2,1]";
            result = WriteLinkedList(solution.ReverseKGroup(head, k));
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 6.
            head = InitLinkedList(new int[] { 1, 2, 3, 4 }); k = 2;
            answer = "[2,1,4,3]";
            result = WriteLinkedList(solution.ReverseKGroup(head, k));
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }

        public void TestReverse()
        {
            Type type = typeof(Solution0025);
            MethodInfo method = type.GetMethod("ReverseLinkedList", BindingFlags.NonPublic | BindingFlags.Instance);
            object obj = Activator.CreateInstance(type);
            object[] paras;
            ListNode head, tail;
            string result, answer;
            int id = 0;

            // 1. 
            head = InitLinkedList(new int[] { 1, 2, 3, 4, 5 });
            answer = "[5,4,3,2,1]";
            tail = head; while (tail.next != null) tail = tail.next;
            paras = new object[] { head, tail };
            result = WriteLinkedList((((ListNode, ListNode))method.Invoke(obj, paras)).Item1);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2. 
            head = InitLinkedList(new int[] { 1, 2, 3, 4, 5 });
            answer = "[3,2,1,4,5]";
            tail = head; tail = tail.next; tail = tail.next;
            paras = new object[] { head, tail };
            result = WriteLinkedList((((ListNode, ListNode))method.Invoke(obj, paras)).Item1);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }

        private ListNode InitLinkedList(int[] arr)
        {
            if (arr.Length == 0) return null;

            ListNode head = new ListNode();
            ListNode ptr = head;
            for (int i = 0; i < arr.Length; i++, ptr = ptr.next)
                ptr.next = new ListNode(arr[i]);

            return head.next;
        }

        private string WriteLinkedList(ListNode head)
        {
            if (head == null) return "[]";
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            while (head != null) { sb.Append($"{head.val},"); head = head.next; }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
