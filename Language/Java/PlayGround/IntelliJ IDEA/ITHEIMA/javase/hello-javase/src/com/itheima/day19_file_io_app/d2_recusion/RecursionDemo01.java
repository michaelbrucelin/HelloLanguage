package com.itheima.day19_file_io_app.d2_recusion;

/**
         递归的形式
 */
public class RecursionDemo01 {
    public static void main(String[] args) {
        test2();
    }

    public static void test(){
        System.out.println("=======test被执行========");
        test(); // 方法递归 直接递归形式
    }

    public static void test2(){
        System.out.println("=======test2被执行========");
        test3(); // 方法递归 间接递归
    }

    private static void test3() {
        System.out.println("=======test3被执行========");
        test2();
    }
}












