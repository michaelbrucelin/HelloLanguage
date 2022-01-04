//call()、apply()与bind()

var name = '张三', age = 18;
var obj = {
    name: '李四',
    objAge: this.age,
    myFun: function () {
        console.log(this.name + "的年龄是：" + this.age);
    }
}


console.log("======== Sample 01 ========");
console.log(obj.objAge);
obj.myFun();

var name2 = '王五';
function myshow() {
    console.log(this.name2);
}

console.log("======== Sample 02 ========");
myshow();


var name = '张三', age = 18;
var obj = {
    name: '李四',
    objAge: this.age,
    myFun: function () {
        console.log(this.name + "的年龄是：" + this.age);
    }
}
var db = {
    name: '弗丁',
    age: 99
}

console.log("======== Sample 03 ========");
obj.myFun.call(db);
obj.myFun.apply(db);
obj.myFun.bind(db)();


var name = '张三', age = 18;
var obj = {
    name: '李四',
    objAge: this.age,
    myFun: function (a, z) {
        console.log(this.name + "的年龄是：" + this.age, "来自" + a + ", 去往" + z + ".");
    }
}
var db = {
    name: '弗丁',
    age: 99
}

console.log("======== Sample 04 ========");
obj.myFun.call(db, '暴风城', '诺森德');
obj.myFun.apply(db, ['暴风城', '诺森德']);
obj.myFun.bind(db, '暴风城', '诺森德')();
obj.myFun.bind(db, ['暴风城', '诺森德'])();