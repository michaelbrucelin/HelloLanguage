/*
验证浏览器是否支持某个css属性或值，可以使用Modernizr等库来实现，这里是一个模拟实现；
实现：做一些特性检测，然后给根元素添加辅助类；
思路：
    1. 检测某个样式是否被支持，核心思路就是在任一元素的element.style对象上检查该属性是否存在；
    2. 检测某个具体的属性值是否被支持，核心思路就是将其赋值给对应的属性，然后再检查浏览器是否还保存着这个值；
            这个过程会改变元素的样式，因此我们需要一个隐藏的元素；
    3. 检测选择符和@规则的支持情况，代码稍稍复杂一些，这里不做演示；
            核心思路，在解析CSS代码时，浏览器总会丢弃它自己无法识别的部分，因此我们可以动态的应用样式并检测它是否生效，
            以此来判断浏览器是否可以识别某个特性；
代码摘自《CSS揭秘》一书；
*/

function testProperty(property) {
    var root = document.documentElement;  // <html>

    if (property in root.style) {
        root.classList.add(property.toLowerCase());
        return true;
    }

    root.classList.add('no-' + property.toLowerCase());
    return false;
}

function testValue(id, value, property) {
    var dummy = document.createElement('p');
    dummy.style[property] = value;

    if (dummy.style[property]) {
        root.classList.add(id);
        return true;
    }

    root.classList.add('no-' + id);
    return false;
}