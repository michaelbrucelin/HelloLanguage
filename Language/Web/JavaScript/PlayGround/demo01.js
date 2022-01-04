var hw = 'hello world';
console.log(hw);

var fs = require('fs');
fs.readFile('./data/hello.txt', function (error, data) {
    console.log(data.toString());
});

fs.writeFile('./data/hi.txt', 'hi world\nhi nodejs', function () {
    console.log('write successed');
})