package com.itheima.day08_api_app.string;

import java.util.Scanner;

public class StringAPIEqualsDemo4 {
    public static void main(String[] args) {
        // 1、正确登录名和密码
        String okName = "itheima";
        String okPassword = "123456";

        // 2、请您输入登录名称和密码
        Scanner sc = new Scanner(System.in);
        System.out.println("登录名称：");
        String name = sc.next();
        System.out.println("登录密码：");
        String password = sc.next();

        // 3、判断用户输入的登录名称和密码与正确的内容是否相等。
        if(okName.equals(name ) && okPassword.equals(password)){
            System.out.println("登录成功！");
        }else {
            System.out.println("用户名或者密码错误了！");
        }

        // 4、忽略大小写比较内容的Api: 一般用于比较验证码这样的业务逻辑
        String sysCode = "23AdFh";
        String code1 = "23aDfH";
        System.out.println(sysCode.equals(code1)); // false
        System.out.println(sysCode.equalsIgnoreCase(code1)); // true
    }
}
