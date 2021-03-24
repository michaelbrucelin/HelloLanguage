//Array对象

// 创建数组方式1
var arr = new Array();  //var arr = new Array(3);  不强制要求指定数组的长度，更像C#的ArrayList
arr[0] = "a";
arr[1] = "b";
arr[3] = "d";

console.log(arr);
console.log(arr.join());
console.log(arr.join(';'));
console.log(arr.toString());

// 创建数组方式2
var arr2 = Array("A", "B", "C", "D");
for (let i = 0; i < arr2.length; i++) {
    console.log(i);
}
for (let item in arr2) {
    console.log(item);
}

for (let item in window) {
    console.log(item + ":\t" + window[item]);
}

// 创建数组方式3
var arr3 = ["A", "B", "C", "D"];

//Array对象的常用声明方法
var arr0 = Array();
var arr0 = Array(10);
var arr0 = Array("A", "B", "C", "D");
var arr0 = ["A", "B", "C", "D"];