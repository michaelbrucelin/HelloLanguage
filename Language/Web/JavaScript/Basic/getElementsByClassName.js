/*
自己实现一个getElementsByClassName函数，这个例子不适用于匹配多个类名；
代码摘自《JavaScript DOM 编程艺术》一书；
*/

function getElementsByClassName(node, classname) {
    if (node.getElementsByClassName) {
        return node.getElementsByClassName(classname);
    } else {
        var results = new Array();
        var elems = node.getElementsByTagName("*");
        for (var i = 0; i < elems.length; i++) {
            if (elems[i].className.indexOf(classname) != -1) {
                results[results.length] = elems[i];
            }
        }
    }
    return results;
}