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
        }
    }
})();
