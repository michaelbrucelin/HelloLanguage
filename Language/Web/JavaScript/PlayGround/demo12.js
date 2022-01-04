//工具函数，摘自《CSS揭秘》
//方便获取和遍历所有匹配特定CSS选择符的DOM元素
function $$(selector, context){
    context = context || document;
    var elements = context.querySelectorAll(selector);
    return Array.prototype.slice.call(elements);
}