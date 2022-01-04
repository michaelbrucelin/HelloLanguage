/*
解决不同版本的IE浏览器创建XMLHttpObject对象；
代码摘自《JavaScript DOM 编程艺术》一书；
*/

function getHTTPObject() {
    if (typeof XMLHttpRequest == "undefined") {
        XMLHttpRequest = function () {
            try { return new ActiveXObject("Msxml2.XMLHTTP.6.0"); }
            catch (e) { }
            try { return new ActiveXObject("Msxml2.XMLHTTP.3.0"); }
            catch (e) { }
            try { return new ActiveXObject("Msxml2.XMLHTTP"); }
            catch (e) { }

            return false;
        }
    }

    return new XMLHttpRequest();
}