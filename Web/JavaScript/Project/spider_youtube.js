// 获取Youtube播放列表的全部url，以便提供给youtube-dl或you-get等工具下载。
// 使用方法：打开播放列表的第一个视频，在浏览器的控制台键入代码，执行即可。

var urlstr = window.location.href;
var url = new URL(urlstr);
var listid = url.searchParams.get('list');
var channelid = url.searchParams.get('ab_channel');

var urlist = [];
urlist[urlist.length] = window.location.href;

var nextbtn = document.querySelector("#movie_player > div.ytp-chrome-bottom > div.ytp-chrome-controls > div.ytp-left-controls > a.ytp-next-button.ytp-button");
while (nextbtn) {
    let nexturlstr = nextbtn.href;
    let nexturl = new URL(nexturlstr);
    let nextlistid = nexturl.searchParams.get('list');
    let nextchannelid = nexturl.searchParams.get('ab_channel');
    if (nextlistid == listid && nextchannelid == channelid) {
        urlist[urlist.length] = nextbtn.href;
        nextbtn.click();
    }
    else {
        break;
    }

    await new Promise(r => setTimeout(r, 2000));  // 等待2秒
    nextbtn = document.querySelector("#movie_player > div.ytp-chrome-bottom > div.ytp-chrome-controls > div.ytp-left-controls > a.ytp-next-button.ytp-button");
}

console.log(urlist);
