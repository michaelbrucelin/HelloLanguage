/*
自己实现一个insertAfter函数，对应insertBefore函数；
代码摘自《JavaScript DOM 编程艺术》一书；
*/

function insertAfter(newElement, targetElement) {
    var parent = targetElement.parentNode;
    if (parent.lastChild == targetElement) {
        parent.appendChild(newElement);
    } else {
        parent.insertBefore(newElement, targetElement.nextSibling);
    }
}