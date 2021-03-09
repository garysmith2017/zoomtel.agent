
const NewModel = function (obj) {
    return JSON.parse( JSON.stringify(obj));

}

//返回yyyy-mm-01
const getDateYM01 = function () {
    var date = new Date();
    var seperator1 = "-";
    var month = date.getMonth() + 1;
    var strDate = "01";
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    var dateStr = date.getFullYear() + seperator1 + month + seperator1 + strDate;
    return dateStr;
} 

//返回yyyy-mm-dd
const getDateYMD = function () {
    var date = new Date();
    var seperator1 = "-";
    var month = date.getMonth() + 1;
    
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate;
    return currentdate;

}
const getDateYmdPlusOne = function () {
    var date = new Date((new Date() / 1000 + 86400) * 1000);
    var seperator1 = "-";
    var month = date.getMonth() + 1;
    
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate;
    return currentdate;

}


//返回yyyy-mm-dd hh-mi-ss
const getDateYMDHMS= function () {
    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
        + " " + date.getHours() + seperator2 + date.getMinutes()
        + seperator2 + date.getSeconds();
    return currentdate;
} 


Date.prototype.Format = function (fmt) {
 
    var o = {
        "M+": this.getMonth() + 1,                 //月份 
        "d+": this.getDate(),                    //日 
        "h+": this.getHours(),                   //小时 
        "m+": this.getMinutes(),                 //分 
        "s+": this.getSeconds(),                 //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds()             //毫秒 
    };
    if (/(y+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        }
    }
    return fmt; 
}

const formatDateTime = function (value, fmt) {
    if (fmt == null) {

        fmt = "yyyy-MM-dd";
    }
    if (value == undefined) {
        return "--";
    }
    if (value != null && value.indexOf("-") > 0) {
        value = value.replace(/-/g, '/');
    }
    //console.log("formatDateTime：" + value);
    if (value.indexOf("0001") >= 0) {
        return "--";

    } else {
        return new Date(value).Format(fmt);
    }

}

//export default {
//    formatDateTime
//}