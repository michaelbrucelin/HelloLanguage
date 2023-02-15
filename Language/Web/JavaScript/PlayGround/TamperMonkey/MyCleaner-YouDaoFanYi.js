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

    document.title = "有道翻译";
    var item;

    // 侧边
    item = document.querySelector("#app > div.sticky-sidebar");
    if(item) item.remove();

    // 下面几个元素在页面加载完成后仍然无法获取，但是可以获取到其父元素
    // 怀疑是页面渲染完毕后，再根据xhr请求数据等方式，再在页面上绘制新的数据，所以这里使用在父元素上添加事件来完成元素的获取和移除
    // 需要注意把握好下层元素的数量问题，如果绘制元素过多反复触发，会极大的延迟运行速度
    // 参考：
    // https://bbs.tampermonkey.net.cn/thread-835-1-1.html
    // https://bbs.tampermonkey.net.cn/thread-1537-1-1.html
    // https://bbs.tampermonkey.net.cn/thread-967-1-1.html
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

    // 也可以使用Setinterval来进行循环判断，当获取元素不为空的时候继续执行，但需要注意不要创建过多的定时器，以及不使用的时候可以考虑销毁定时器
    // 百度云中等待window中的videojs加载完成的代码，补充一下，油猴中要注意unsafeWindow和window是不一样的... 注意调用的范围
    // const w = unsafeWndow || window,
    //     id = setInterval(() => {
    //         if (myvideojs = myvideojs || w.videoPlayer) {
    //             if (!!getmyvideo("html5player")) {
    //                 clearInterval(id);
    //                 // 该干嘛干嘛
    //             }
    //         }
    //     }, 500);

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
