const jsdom = require('jsdom');
const { JSDOM } = jsdom;
const { document } = (new JSDOM('<!doctype html><html><body></body></html>')).window;
global.document = document;
const window = document.defaultView;
const $ = require('jquery')(window);

//jquery中可以使用map()方法遍历数组
var arr = [1, 2, 3, 4];
console.log(arr);

arr = $.map(arr, function (item) {
    return item * item;
});
console.log(arr);

//自己使用js模拟一个map方法
function mymap(arr, fn) {
    var rst = [], value;
    for (let i = 0; i < arr.length; i++) {
        value = fn(arr[i], i);
        if (value != null) {
            rst[rst.length] = value;
        }
    }
    return rst;
}

arr = mymap(arr, (item, index) => {
    return item * index;
})
console.log(arr);

//map()方法只能处理数组，如果需要处理字典，需要使用each()方法
//each()方法的实现使用了js中的call()方法
var dic = { "name": "ZhangSan", "age": 18, "sex": "boy" };
console.log("========== 1 ==========");
$.each(dic, (key, value) => {
    console.log(key + ":\t" + value);
})
console.log("========== 2 ==========");
$.each(dic, (key) => {
    console.log(key + ":\t" + dic[key]);
})
console.log("========== 3 ==========");
$.each(dic, function () {
    console.log(this);
})