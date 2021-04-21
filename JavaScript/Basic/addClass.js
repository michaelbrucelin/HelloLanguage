/*
使用DOM为一个元素添加一个类样式；
如果该元素已经包含要添加的类样式，会重复添加，这部分目前还没有优化；
代码摘自《JavaScript DOM 编程艺术》一书；
*/

function addClass(element, value) {
    if (!element.className) {
        element.className = value;
    } else {
        newClassName = element.className;
        newClassName += " ";
        newClassName += value;
        element.className = newClassName;
    }
}