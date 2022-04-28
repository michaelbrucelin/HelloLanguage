package com.itheima.day03_flow_control_app.loop;

public class ForTest3 {
    public static void main(String[] args) {
        // 需求：求1-0的奇数和
        // 3、定义一个求和的变量 累加奇数和
        int sum = 0;
        // 1、定义一个循环找到 1 2 3...10
        for (int i = 1; i <= 10; i++) {
            // i  1 2 3 4 5 6 7 8 9 10
            // 2、筛选出奇数
            if(i % 2 == 1){
                // i = 1 3 5 7 9
                sum += i;
            }
        }
        // 4、输出求和变量即可
        System.out.println("1-10的奇数和是：" + sum);

        System.out.println("-------------------");
        // 2、定义一个求和的变量 累加奇数和
        int sum1 = 0;
        // 1、定义循环找到 1 3 5 7 9
        for (int i = 1; i <= 10; i+=2) {
            // i = 1 3 5 7 9
            sum1 += i;
        }
        // 3、输出求和变量即可
        System.out.println("1-10的奇数和是：" + sum1);
    }
}
