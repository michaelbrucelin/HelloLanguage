/*
向window.onload添加执行的函数；
代码摘自《JavaScript DOM 编程艺术》一书；
*/

function addLoadEvent(func) {
    var oldonload = window.onload;
    if (typeof window.onload != 'function') {
        window.onload = func;
    } else {
        window.onload = function () {
            oldonload();
            func();
        }
    }
}