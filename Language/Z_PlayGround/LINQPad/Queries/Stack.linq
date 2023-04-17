<Query Kind="Statements" />


// 1. stack to list
Stack<int> stack = new Stack<int>();
stack.Push(3);
stack.Push(2);
stack.Push(1);
stack.Push(9);
List<int> list = new List<int>(stack);
list.Dump("list");


// 2. stack.Peek()--;  不支持这样操作
Stack<int> stack = new Stack<int>();
stack.Push(10);
stack.Push(20);
stack.Push(100);
for (int i = 0; i < 100; i++)
{
	Console.Write($"{stack.Peek()}  ");
	stack.Peek()--;  // 不支持这样操作
}
