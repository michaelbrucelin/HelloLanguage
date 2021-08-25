// js中获取当前时间的字符串
// https://stackoverflow.com/questions/3066586/get-string-in-yyyymmdd-format-from-js-date-object

Date.prototype.yyyymmdd = function () {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return [this.getFullYear(),
    (mm > 9 ? '' : '0') + mm,
    (dd > 9 ? '' : '0') + dd
    ].join('');
};

Date.prototype.yyyymmddhhmiss = function () {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();
    var hh = this.getHours();
    var mi = this.getMinutes();
    var ss = this.getSeconds();

    return [this.getFullYear(),
    (mm > 9 ? '' : '0') + mm,
    (dd > 9 ? '' : '0') + dd,
    (hh > 9 ? '' : '0') + hh,
    (mi > 9 ? '' : '0') + mi,
    (ss > 9 ? '' : '0') + ss,
    ].join('');
};

var date = new Date();
date.yyyymmdd();
date.yyyymmddhhmiss();
