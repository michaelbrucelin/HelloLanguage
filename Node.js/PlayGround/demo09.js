//正则的声明
var regex = new RegExp("CS\\d{5}");  //这样声明需要转义
var regex = /CS\d{5}/;               //这样声明更简洁，不需要转义

//test()相当于C#中的IsMatch()
console.log(regex.test("aCS12345b"));

//exec()相当于C#中的Match()和Matches()
//具体是只提取第一组还是提取所有组，取决于正则的声明(/g)，而不是函数的调用
console.log(regex.exec("aCS12345b"));

var regex = /CS\d{5}/i;  //忽略大小写
var regex = /CS\d{5}/g;  //在使用exec提取时，默认只提取第一组，模式中加g会提取所有组
var regex = /CS\d{5}/m;  //匹配多行

console.log(regex.exec("acs12345b"));

//String的正则表达式扩展方法
var str = "helloworld";
str.replace()  //支持正则替换
str.match()    //匹配模式
str.search()   //查找

//示例1
var regex1 = /(.+)@((.+)\.(.+))/;
var str1 = "123@abc.com";
var match1 = str1.match(regex1);
console.log("================逐个输出================");
console.log(RegExp.$0);
console.log(RegExp.$1);
console.log(RegExp.$2);
console.log(RegExp.$3);
console.log(RegExp.$4);
console.log("================这样放在循环中无效================");
for (let i = 0; i < match1.length; i++) {
    console.log(RegExp.$i);
}
console.log("================这样放在循环中才有效================");
console.log(match1);
for (let i = 0; i < match1.length; i++) {
    console.log(match1[i]);
}

//示例2
var str2 = "北京 北京 北京";
console.log(str2.replace("北京", "大连"));
console.log(str2.replace(/北京/, "大连"));
console.log(str2.replace(/北京/g, "大连"));

//示例3
String.prototype.myTrim = function () {
    //return this.replace(/(^\s+)|(\s+$)/g,"");
    //据说在js中复杂的正则，尤其是带有 | 的正则很低效；
    //所以尽管下面执行了两次正则，但是由于每个正则都很简单，仍然比上面的写法高效
    //没有验证
    return this.replace(/^\s+/, "").replace(/\s+$/, "");
}

var str3 = "  ====  ";
console.log(str3.myTrim());
