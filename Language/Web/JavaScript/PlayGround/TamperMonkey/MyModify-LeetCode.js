// ==UserScript==
// @name         MyModify-LeetCode
// @namespace    http://tampermonkey.net/
// @version      0.1
// @description  try to take over the world!
// @author       You
// @match        *://leetcode.cn/*
// @icon         data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==
// @grant        none
// ==/UserScript==

(function() {
    'use strict';

    // 让“运行”按钮更大
    var btns = document.getElementsByTagName("button");
    for(let i =0; i < btns.length; i++) {
        if(btns[i].innerText == '运行') {
            // btns[i].innerText = '运 行';  // 不好看
            btns[i].style.setProperty("padding-left", "128px");
            btns[i].style.setProperty("padding-right", "128px");
            btns[i].id = "my_id_run";       // 添加自定义id，用于下面添加的css选择器
            // 下面是通过js添加事件的方式实现hover样式，是好用的，现在已经改为下面的添加css的方式实现
            //btns[i].onmouseover = function() {
            //    this.style.backgroundColor = "#34B560";
            //    this.style.color = "#FFFFFF";
            //}
            //btns[i].onmouseout = function() {
            //    this.style.removeProperty("background-color");
            //    this.style.removeProperty("color");
            //}
        }
    }

    /* 采用这种方式设置没有生效，但是同样的方式在“有道云翻译”页面是生效的，究竟是为什么没弄明白，使用下面自定义的GM_addStyle(css)是好用的
        // @grant        GM_addStyle
        const css = `#my_id_run:hover {
                       background-color: #34B560 !important;
                       color: #FFFFFF !important;
                     }`;
        GM_addStyle(css);
    */

    // 直接使用GM_addStyle()不好用，不确认是为什么，参照下面的链接，自己实现了一个GM_addStyle()就好用了
    // https://stackoverflow.com/questions/23683439/gm-addstyle-equivalent-in-tampermonkey
    function GM_addStyle(css) {
        const style = document.getElementById("GM_addStyleBy8626") || (function() {
            const style = document.createElement('style');
            style.type = 'text/css';
            style.id = "GM_addStyleBy8626";
            document.head.appendChild(style);
            return style;
        })();
        const sheet = style.sheet;
        sheet.insertRule(css, (sheet.rules || sheet.cssRules || []).length);
    }

    // GM_addStyle('* { font-size: 99px !important; }');  // 测试用的
    GM_addStyle(`#my_id_run:hover {
                   background-color: #34B560 !important;
                   color: #FFFFFF !important;
                 }
    `);
})();
