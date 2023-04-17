<Query Kind="Statements" />


// 局部排序
int[] arr = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
arr.Dump("arr");  // [ 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 ]
Array.Sort(arr, 3, 4);
arr.Dump("arr");  // [ 9, 8, 7, 3, 4, 5, 6, 2, 1, 0 ]
