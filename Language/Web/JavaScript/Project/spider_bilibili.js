// 获取B站各区百大UP主的数据
// https://www.kanbilibili.com/rank/ups/fans

// 获取所有id
let tabs = $('.tid-tabs .blue');
let all = [];
let area = {};
let i = 1;
console.warn('正在获取百大up的id...');
for (let i = 0; i < $('.name').length; i++) {
    all.push($('.name')[i].innerHTML);
}
console.log('%c ☑%c 已获取百大up的id！', 'color:green', 'font-weight:bold');
console.warn('正在前往动画分区...');
let timer = setInterval(function () {
    getData(i, timer);
    console.log(`当前分区是 %c ${tabs[i].innerHTML}`, 'color:blue');
    i++;
}, 1000)
let getData = async (i, timer) => {
    try {
        tabs[i].click();
        console.log('%c ☑%c 分区切换成功！', 'color:green', 'font-weight:bold');
        setTimeout(function () {
            console.warn('开始获取分区up的id...');
            if (i == tabs.length - 1) {
                area[tabs[i].innerHTML] = [];
                for (let j = 0; j < $('.name').length; j++) {
                    area[tabs[i].innerHTML].push($('.name')[j].innerHTML);
                }
                clearInterval(timer);
                console.log('%c ☑%c 恭喜你，全部获取完成！', 'color:green', 'font-weight:bold');
                console.log('百大up：', all);
                console.log(area);
            } else {
                area[tabs[i].innerHTML] = [];
                for (let j = 0; j < $('.name').length; j++) {
                    area[tabs[i].innerHTML].push($('.name')[j].innerHTML);
                }
                console.log('%c ☑%c 该分区获取完毕！', 'color:green', 'font-weight:bold');
                console.warn('准备跳转至下一分区...');
            }
        }, 500)
    } catch (error) {
        console.log(error);
    }
}
// 得到统计结果
let result = {};

for (let i in area) {
    result[i] = area[i].filter(item => all.find(up => up == item));
}

console.log(result);

// 排序
let arr = [];
for (let i in result) {
    arr.push({ area: i, num: result[i].length });
}
arr = arr.sort((a, b) => b.num - a.num);
arr.forEach((item, index) => {
    console.log(`第${index + 1}`, item.area, item.num);
})

// 得到当前人数
let num = 0;
for (let i in result) {
    num += result[i].length;
}
console.log(num);

// 得到无分区up
let noArea = [...all];
for (let i in result) {
    noArea = noArea.filter(item => !result[i].find(up => up == item));
}
console.log('没有分区的up', noArea);