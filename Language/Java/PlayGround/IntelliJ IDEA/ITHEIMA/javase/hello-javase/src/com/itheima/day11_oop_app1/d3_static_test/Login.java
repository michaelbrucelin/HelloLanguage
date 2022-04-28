package com.itheima.day11_oop_app1.d3_static_test;

public class Login {
    public static void main(String[] args) {
        // 验证码：
        System.out.println("验证码：" + VerifyTool.createCode(10));
    }
}
