//密码强度校验2
function checkPassword3(fieldId, tipMsg) {
    //返回密码的强度级别
    function checkStrong(sPW) {
        if (sPW.length < 8 || sPW.length > 20) {
            return 0;  //密码太短或太长
        }
        Modes = 0;
        for (i = 0; i < sPW.length; i++) {
            //测试每一个字符的类别并统计一共有多少种模式.
            Modes |= CharMode(sPW.charCodeAt(i));
        }
        return bitTotal(Modes);
    }
    //判断字符类型
    function CharMode(iN) {
        if (iN >= 48 && iN <= 57) { return 1; }   //数字
        if (iN >= 65 && iN <= 90) { return 2; }   //大写字母
        if (iN >= 97 && iN <= 122) { return 4; }  //小写
        else { return 8; }  //特殊字符
    }
    //统计字符类型
    function bitTotal(num) {
        modes = 0;
        for (i = 0; i < 4; i++) {
            if (num & 1) modes++;
            num >>>= 1;
        }
        return modes;
    }
    /**
	 * 密码强度等级说明，字符包括：小写字母、大写字母、数字、特殊字符
	 * 1---密码包含其中之一
	 * 2---密码包含其中之二
	 * 3---密码包含其中之三
	 * 4---密码包含其中之四
     */
    var fieldValue = getValue(fieldId);
    if (fieldValue != "" && checkStrong(fieldValue) < 2) {
        tipMsg = '登录密码由8-20位数字+字母组成，字母区分大小写';
        errShow(fieldId, tipMsg);
        return false;
    }
    return true;
}
