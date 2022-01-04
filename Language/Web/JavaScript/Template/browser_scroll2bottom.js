//将浏览器中的页面一直滚动到底部，适用于一些靠滚动到底端自动加载数据的页面

var heightA = 0;
var heightZ = document.body.scrollHeight;
do {
    heightA = heightZ;
    // window.scrollTo(0, document.body.scrollHeight);
    window.scrollTo(0, heightZ);
    for (let i = 0; i < 50; i++) {  //等待50次
        await new Promise(r => setTimeout(r, 200));  //每次等待200ms
        heightZ = document.body.scrollHeight;
        if(heightZ > heightA) break;
    }
} while (heightZ > heightA)

alert("it is scroll to the bottom now.");
