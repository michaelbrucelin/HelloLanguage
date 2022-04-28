package com.itheima.day04_array_app.demo;

public class Test1 {
    public static void main(String[] args) {
        // 需求：数组元素求和
        // 1、把这些数据拿到程序中使用数组记住
        int[] money = {16, 32, 8, 100, 78};

        // 3、定义一个求和变量累加数组的元素值
        int sum = 0;

        // 2、遍历数组中的每个元素
        for (int i = 0; i < money.length; i++) {
            // 拿到每个元素值累加
            sum += money[i];
        }

        // 4、输出求和变量即可
        System.out.println("数组的元素和是：" + sum);
    }
}
