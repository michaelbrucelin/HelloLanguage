// 将数组去重复
// https://stackoverflow.com/questions/1960473/get-all-unique-values-in-a-javascript-array-remove-duplicates

// 方法1
// ES6/ES2015, Using the Set and the spread operator (thanks le-m), the single line solution is:
var items = ['a', 1, 'a', 2, '1'];
var unique = [...new Set(items)];
unique;

// 方法2
// With JavaScript 1.6 / ECMAScript 5 you can use the native filter method of an Array in the following way to get an array with unique values:
function onlyUnique(value, index, self) {
    return self.indexOf(value) === index;
}

var items = ['a', 1, 'a', 2, '1'];
var unique = items.filter(onlyUnique);
unique;

// With ES6 it could be shorten to this:
var items = ['a', 1, 'a', 2, '1'];
var unique = items.filter((v, i, a) => a.indexOf(v) === i);
unique;
