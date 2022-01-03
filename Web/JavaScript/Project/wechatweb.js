// 网页版微信自动发消息，没有成功

var msgbox = document.getElementById('editArea');
msgbox.innerHTML = 'can this scuess?';

var atags = document.getElementsByTagName('a');
for (let i = 0; i < atags.length; i++) {
    if (atags[i].innerHTML == '发送') {
        atags[i].click();
    }
}