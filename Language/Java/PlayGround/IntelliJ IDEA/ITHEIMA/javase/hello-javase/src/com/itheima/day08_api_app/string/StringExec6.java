package com.itheima.day08_api_app.string;

import java.util.Random;

/**
    练习题：使用String完成随机生成5位的验证码。
 */
public class StringExec6 {
    public static void main(String[] args) {
        // 1、定义可能出现的字符信息
        String datas = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        // 2、循环5次，每次生成一个随机的索引，提取对应的字符连接起来即可
        String code = "";
        Random r = new Random();
        for (int i = 0; i < 5; i++) {
            // 随机一个索引
            int index = r.nextInt(datas.length());
            char c = datas.charAt(index);
            code += c;
        }

        // 3、输出字符串变量即可
        System.out.println(code);
    }
}
