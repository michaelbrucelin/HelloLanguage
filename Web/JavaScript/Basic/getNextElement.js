/*
DOM中有nextSibling属性，但是没有nextElement属性，这里自己实现一个方法；
代码摘自《JavaScript DOM 编程艺术》一书；
*/

//node为查找元素的nextSibling属性，《JavaScript DOM编程艺术》中的源代码
function getNextElement(node) {
    if (node.nodeType == 1) {  //元素节点
        return node;
    }
    if (node.nextSibling) {
        return getNextElement(node.nextSibling);
    }
    return null;
}

//下面是自己改写的，node为查找元素
function getNextElement(node) {
    if (node.nextSibling.nodeType == 1) {  //元素节点
        return node.nextSibling;
    }
    if (node.nextSibling.nextSibling) {
        return getNextElement(node.nextSibling.nextSibling);
    }
    return null;
}