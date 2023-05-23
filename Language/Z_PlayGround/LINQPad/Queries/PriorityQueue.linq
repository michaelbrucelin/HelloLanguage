<Query Kind="Statements" />

using System.Collections.Generic;

PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
minpq.Enqueue(1, 1);
minpq.Enqueue(9, 9);
minpq.Enqueue(2, 2);
minpq.Enqueue(8, 8);
minpq.Enqueue(3, 3);
minpq.Enqueue(7, 7);

// foreach (var element in minpq)  // 没有办法遍历优先级队列
