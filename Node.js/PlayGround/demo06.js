//Dictionary对象

//本质上还是一个数组，不能使用C#中的数组来理解js中的数组
var dic = new Array();
dic["zs"] = "张三";
dic["ls"] = "李四";
dic["ww"] = "王五";
dic["zl"] = "赵六";

console.log(dic.length);  //当Array的对象中存储的是一个键值对时，长度为0
console.log(dic["zs"]);
alert(dic instanceof (Array));
for (let item in dic) {
    console.log(dic[item]);
}


//本质上是一个Json
var dic2 = { "zs": "张三", "ls": "李四", "ww": "王五", "zl": "赵六" };

console.log(dic2.length);
console.log(dic2["zs"]);
alert(dic2 instanceof (Array));

for (let item in dic2) {
    console.log(dic2[item]);
}