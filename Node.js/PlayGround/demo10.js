//密码强度校验1
/*
    思路：，定义变量level，默认为0
    验证密码长度，长度小于8直接退出
    验证密码中是否含有数字，    含有level++
    验证密码中是否含有小写字母，含有level++
    验证密码中是否含有大写字母，含有level++
    验证密码中是否含有特殊字符，含有level++
*/
function checkPassword(password) {
    if (password.length < 8) { return -1; }
    var level = 0;
    var regex = /\d/;
    if (regex.test(password)) { level++; }
    regex = /[a-z]/;
    if (regex.test(password)) { level++; }
    regex = /[A-Z]/;
    if (regex.test(password)) { level++; }
    regex = /[^0-9a-zA-Z]/;
    if (regex.test(password)) { level++; }
    return level;
}