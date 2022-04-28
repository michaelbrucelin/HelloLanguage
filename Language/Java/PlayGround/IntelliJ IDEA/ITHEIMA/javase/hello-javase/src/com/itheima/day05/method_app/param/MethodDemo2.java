package com.itheima.day05.method_app.param;

public class MethodDemo2 {
    public static void main(String[] args) { // 黄波  人生导师！！   拓展培训！
        // 目标：理解引用类型的参数传递机制：值传递，区分其不同点
        int[] arrs = {10, 20, 30};
        change(arrs);
        System.out.println(arrs[1]); // 222
    }

    public static void change(int[] arrs){
        System.out.println(arrs[1]); // 20
        arrs[1] = 222;
        System.out.println(arrs[1]); // 222
    }
}
