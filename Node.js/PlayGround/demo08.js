//扩展方法

String.prototype.myquot = function (sep) {
    //js中没有方法参数的默认值设置方法
    //需要的话就在方法调用时不给形参赋值，这样参数就是undefined，然后再在方法内部判断赋值
    if (!sep) {
        sep = "\"";
    }
    return sep + this + sep;
}

var str = "hello world";
console.log(str.myquot());
console.log(str.myquot("|"));