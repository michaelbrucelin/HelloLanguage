// 从数组中随机获取一项，或几项
// https://stackoverflow.com/questions/5915096/get-a-random-item-from-a-javascript-array
// https://stackoverflow.com/questions/19269545/how-to-get-a-number-of-random-elements-from-an-array

// 测试数据
var items = Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');

// 1. 随机获取一项
var item = items[Math.floor(Math.random() * items.length)];

// 2. 随机获取几项
function getRandom(arr, n) {
    var result = new Array(n),
        len = arr.length,
        taken = new Array(len);

    if (n > len)
        throw new RangeError("getRandom: more elements taken than available");
    while (n--) {
        var x = Math.floor(Math.random() * len);
        result[n] = arr[x in taken ? taken[x] : x];
        taken[x] = --len in taken ? taken[len] : len;
    }

    return result;
}

var itemn = getRandom(items, 3);
