<Query Kind="Statements" />


// 局部排序
int[] arr = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
arr.Dump("arr");        // [ 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 ]
Array.Sort(arr, 3, 4);
arr.Dump("arr");        // [ 9, 8, 7, 3, 4, 5, 6, 2, 1, 0 ]

// 二维数组
int[,] arr2d = new int[3, 3];
int[,] arr2d_new = (int[,])arr2d.Clone();
arr2d_new[0,0] = 100;
arr2d_new[1,1] = 200;
arr2d_new[2,2] = 300;
arr2d.Dump("arr2d");
arr2d_new.Dump("arr2d_new");

// 内置的二分法
arr = new int[] { 1, 2, 3, 3, 3, 4, 5, 6, 6, 6, 7, 8, 9 };
Array.BinarySearch(arr, 3).Dump();

// 排序
int[] array = new int[] { 3, 6, 7, 1, 9, 7, 8, 2, 4, 5, 0 };
Comparer<int> comparer = Comparer<int>.Create((i, j) => (i - j) switch { > 0 => 1, < 0 => -1, _ => 0 });
Array.Sort(array);
array.Dump();       // [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ]
