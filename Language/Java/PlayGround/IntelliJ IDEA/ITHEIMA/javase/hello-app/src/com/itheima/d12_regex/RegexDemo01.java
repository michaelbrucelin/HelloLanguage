package com.itheima.d12_regex;

public class RegexDemo01 {
    public static void main(String[] args) {
        // 需求：校验qq号码，必须全部数字 6 - 20位
        System.out.println(checkQQ("251425998"));
        System.out.println(checkQQ("2514259a98"));
        System.out.println(checkQQ(null));
        System.out.println(checkQQ("2344"));

        System.out.println("-------------------------");
        // 正则表达式的初体验：
        System.out.println(checkQQ2("251425998"));
        System.out.println(checkQQ2("2514259a98"));
        System.out.println(checkQQ2(null));
        System.out.println(checkQQ2("2344"));
    }

    public static boolean checkQQ2(String qq) {
        return qq != null && qq.matches("\\d{6,20}");
    }

    public static boolean checkQQ(String qq) {
        // 1、判断qq号码的长度是否满足要求
        if (qq == null || qq.length() < 6 || qq.length() > 20) {
            return false;
        }

        // 2、判断qq中是否全部是数字，不是返回false
        //  251425a87
        for (int i = 0; i < qq.length(); i++) {
            // 获取每位字符
            char ch = qq.charAt(i);
            // 判断这个字符是否不是数字，不是数字直接返回false
            if (ch < '0' || ch > '9') {
                return false;
            }
        }

        return true; // 肯定合法了！
    }
}
