// 限制系统只允许使用IE或Safari浏览器

if ((navigator.userAgent.indexOf("MSIE") == -1) && (navigator.platform.indexOf("Mac") == -1)) {
    location.replace('/css/crmcss/page/helpBrowser.html');
}