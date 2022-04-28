package com.itheima.day03_flow_control_app.loop;

public class ForTest2 {
    public static void main(String[] args) {
        // 需求：计算1-5的和
        // 2、定义一个整数变量用于累加数据求和
        int sum = 0;
        // 1、定义一个for循环找到 1 2 3 4 5
        for (int i = 1; i <= 5 ; i++) {
            // i = 1 2 3 4 5
            // 3、把循环的数据累加给sum变量
            /**
               等价于： sum = sum + i
               i == 1  sum = 0 + 1
               i == 2  sum = 1 + 2
               i == 3  sum = 3 + 3
               i == 4  sum = 6 + 4
               i == 5  sum = 10 + 5
             */
            sum += i;
        }
        System.out.println("1-5的和是：" + sum);
    }
}
