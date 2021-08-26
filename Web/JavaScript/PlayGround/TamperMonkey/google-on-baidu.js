// ==UserScript==
// @name         google on baidu!
// @namespace    http://tampermonkey.net/
// @version      0.1
// @description  Google It!
// @author       micha
// @match        https://www.baidu.com/*
// @grant        GM_openInTab
// @include      https://code.jquery.com/jquery-3.2.1.min.js
// ==/UserScript==

(function() {
    'use strict';

    alert('hello world, google is coming.');

    $('#su').after('<input type="button" id="google" value="Google It" class="btn self-btn bg s_btn" style="background-color:rgb(80, 112, 239);" />');
    $("#google").click(function() {
        googleIt();
    });

    function googleIt() {
        // alert('google');
        var searchText = document.querySelector('#kw').value;
        //location.href = getGoogleUrl(searchText);     // 在当前页面打开
        GM_openInTab(getGoogleUrl(searchText), false);  // 在新的页面打开
    }
    function getGoogleUrl(searchText) {
        return 'https://www.google.com/search?q=' + searchText;
    }
})();
