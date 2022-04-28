package com.itheima.day05.method_app.demo;

public class Test1 {
    public static void main(String[] args) {
        // 需求：使用方法计算1-n的和并返回
        System.out.println("1-5的和是：" + sum(5));
        System.out.println("--------------------");
        System.out.println("1-100的和是：" + sum(100));
    }

    public static int sum(int n){
        int sum = 0;
        for (int i = 1; i <= n ; i++) {
            sum += i;
        }
        return sum;
    }
}
