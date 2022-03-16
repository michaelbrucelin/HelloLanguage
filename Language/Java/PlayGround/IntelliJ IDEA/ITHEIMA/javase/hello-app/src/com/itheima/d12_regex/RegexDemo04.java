package com.itheima.d12_regex;

/**
 * 目标：正则表达式在方法中的应用。
 * public String[] split(String regex)：
 * -- 按照正则表达式匹配的内容进行分割字符串，反回一个字符串数组。
 * public String replaceAll(String regex,String newStr)
 * -- 按照正则表达式匹配的内容进行替换
 */
public class RegexDemo04 {
    public static void main(String[] args) {
        String names = "小路dhdfhdf342蓉儿43fdffdfbjdfaf小何";

        String[] arrs = names.split("\\w+");
        for (int i = 0; i < arrs.length; i++) {
            System.out.println(arrs[i]);
        }

        String names2 = names.replaceAll("\\w+", "  ");
        System.out.println(names2);
    }
}
