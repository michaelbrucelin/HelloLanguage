/*
DOM有lastChild属性，但是没有lastChildElement属性，这里实现一个；
代码摘自《JavaScript DOM 编程艺术》一书；
*/

function getLastChildElement(node) {
    var allElements = node.getElementsByTagName("*");
    if (allElements.length < 1) {
        return null;
    }
    return allElements[allElements.length - 1];
}