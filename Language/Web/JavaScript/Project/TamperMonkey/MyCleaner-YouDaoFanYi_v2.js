// ==UserScript==
// @name         MyCleaner-YouDaoFanYi
// @namespace    http://tampermonkey.net/
// @version      0.2
// @description  try to take over the world!
// @author       You
// @match        *://fanyi.youdao.com/*
// @icon         https://www.google.com/s2/favicons?sz=64&domain=youdao.com
// @grant        GM_addStyle
// ==/UserScript==

(function() {
    'use strict';

    document.title = "有道翻译";

    let app = document.querySelector("#app");
    app.addEventListener("DOMNodeInserted", function(event) {
        // sider
        let sider = document.querySelector("#app > div.index.os_Windows > div > div.web-frame-inner-container > div.sidebar-container");
        // sider.hidden = true;
        if(sider) sider.remove();

        // header
        let header = document.querySelector("#app > div.index.os_Windows > div > div.header-outer-container > div > div.header-inner-container > div");
        // header.hidden = true;
        if(header) header.remove();

        // footer
        let footer = document.querySelector("#app > div.index.os_Windows > div > div.web-frame-inner-container > div.web-frame-content > div > div.footer");
        // footer.hidden = true;
        if(footer) footer.remove();

        // ad
        let ad = document.querySelector("#app > div.index.os_Windows > div > div.web-frame-inner-container > div.web-frame-content > div > div.web-frame-inner-content > div > div:nth-child(2) > div > div.box_ch");
        // ad.hidden = true;
        if(ad) ad.remove();
    });
})();
