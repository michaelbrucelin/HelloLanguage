//Array对象

//创建数组方式1
var arr = new Array();  //var arr = new Array(3);  不强制要求指定数组的长度，更像C#的ArrayList
arr[0] = "a";
arr[1] = "b";
arr[3] = "d";

console.log(arr);
console.log(arr.join());
console.log(arr.join(';'));
console.log(arr.toString());

//创建数组方式2
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

//创建数组方式3
var arr3 = ["A", "B", "C", "D"];

//关联数组
//关联数组就是使用字符串来代替数组的索引，不建议使用，如果需要这样使用就直接使用Object了
//本质上就是给数组添加了属性，而不是真正意义上的将数组的索引改为字符串
var arr4 = Array();  //john lennon
arr4["name"] = "John";
arr4["year"] = 1940;
arr4["living"] = false;

//Array对象的常用声明方法
var arr0 = Array();
var arr0 = Array(10);
var arr0 = Array("A", "B", "C", "D");
var arr0 = ["A", "B", "C", "D"];