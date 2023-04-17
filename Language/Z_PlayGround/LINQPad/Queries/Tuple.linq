<Query Kind="Statements" />


// 元组可以交换两个引用类型变量的值
int[] arr1 = new int[] { 1, 1, 1 };
int[] arr2 = new int[] { 2, 2, 2 };
arr1.Dump("arr1");
arr2.Dump("arr2");
(arr1, arr2) = (arr2, arr1);
arr1.Dump("arr1");
arr2.Dump("arr2");
