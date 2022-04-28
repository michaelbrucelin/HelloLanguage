package com.itheima.day03_flow_control_app.loop;

import java.util.Scanner;

public class DeadForDemo8 {
    public static void main(String[] args) {
        // 目标：学会定义死循环。
//        for ( ; ; ) {
//            System.out.println("Hello World~~~~");
//        }

        // 经典写法
//        while (true) {
//            System.out.println("我是快乐的死循环~~~~");
//        }

//        do{
//            System.out.println("我是快乐的死循环~~~~");
//        }while (true);
        System.out.println("-----------------------------");

        // 1、定义正确的密码
        int okPassword = 520;
        // 2、定义一个死循环让用户不断的输入密码认证
        Scanner sc = new Scanner(System.in);
        while (true) {
            System.out.println("请您输入正确的密码：");
            int password = sc.nextInt();
            // 3、使用if判断密码是否正确
            if(password == okPassword){
                System.out.println("登录成功了~~~");
                break; // 可以理解结束当前所在循环的执行的
            }else {
                System.out.println("密码错误！");
            }
        }
    }
}
