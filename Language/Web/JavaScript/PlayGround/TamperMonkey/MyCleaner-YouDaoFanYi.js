// ==UserScript==
// @name         MyCleaner-YouDaoFanYi
// @namespace    http://tampermonkey.net/
// @version      0.1
// @description  try to take over the world!
// @author       You
// @match        *://fanyi.youdao.com/*
// @icon         https://www.google.com/s2/favicons?sz=64&domain=youdao.com
// @grant        GM_addStyle
// ==/UserScript==

(function() {
    'use strict';

    var item;

    // 侧边
    item = document.querySelector("#app > div.sticky-sidebar");
    if(item) item.remove();

    // 下面几个元素在页面加载完成后仍然无法获取，但是可以获取到其父元素
    // 怀疑是页面渲染完毕后，再根据xhr请求数据等方式，再在页面上绘制新的数据，所以这里使用在父元素上添加事件来完成元素的获取和移除
    let app = document.querySelector("#app");
    app.addEventListener("DOMNodeInserted", function(event) {
        // 人工按钮
        item = document.querySelector("#app > div.index.os_Windows > div.translate-tab-container > div.tab-header > div.tab-left > div:nth-child(3)");
        if(item) item.remove();
        // 菜单
        item = document.querySelector("#app > div.index.os_Windows > div.top-nav.top > div > ul");
        // if(item) item.remove();
        if(item) {
            let lis = item.getElementsByTagName('li');
            for(let i = 0; i < lis.length; i++) {
                if(lis[i]) lis[i].remove();
            }
        }
        // footer
        item = document.querySelector("#app > div.index.os_Windows > div.footer");
        if(item) item.remove();
    });

    const css = `
                @media (max-width: 1920px) {
                    :root {
                        --main-container-width: 70% !important;
                    }
                }

                @media (max-width: 1280px) {
                    :root {
                        --main-container-width: 70% !important;
                    }
                }

                :root {
                    --main-container-width: 70% !important;
                }

                .tab-item {
                    height: 36px !important;
                    width: 108px !important;
                }
                `;
    GM_addStyle(css);
})();
