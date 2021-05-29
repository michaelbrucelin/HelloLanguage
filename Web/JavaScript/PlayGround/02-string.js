//string对象
var str = "abcde,fghij.klmno~pqrst,uvwxyz";
console.log(str.length);
console.log(str.charAt(4));
console.log(str.indexOf('d'));
console.log(str.split(','));
//console.log(str.split(',').split('.'));  不能链式书写？
console.log(str.split(/[,.~]/));  //js中/... .../表示正则
console.log(str.sub());  //将字符串显示为下标，输出<sub>abcde,fghij.klmno~pqrst,uvwxyz</sub>
console.log(str.substr(1, 4));
console.log(str.substring(1, 4));
console.log(str.toUpperCase());
console.log(str.toLowerCase());
console.log(str.match(/,.*,/));
console.log(str.replace(/,.*,/, '===='));
console.log(str.search(/,.*,/));