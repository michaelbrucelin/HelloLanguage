package com.itheima.day02_basic_app.operator;

public class OperatorDemo7 {
    public static void main(String[] args) {
        // 目标：学会使用逻辑运算符，并能够选择合适的逻辑运算符解决问题。
        double size = 9.8;
        double storage = 6;
        // 需求：尺寸大于等于6.95 内存要大于等于8GB
        // 注意：必须前后都是true结果才是true
        System.out.println(size >= 6.95 & storage >=8);

        // 需求：要么内存大于等于8 要么尺寸大于等于6.95
        // 注意：只要有一个是true 结果就一定是true
        System.out.println(size >= 6.95 | storage >=8);

        System.out.println(!true);
        System.out.println(!false);

        // 逻辑异或：必须两个不同结果才是true
        System.out.println(false ^ true); // true
        System.out.println(true ^ false); // true
        System.out.println(true ^ true); // false
        System.out.println(false ^ false); // false

        System.out.println("-----------&&  &  || |的区别-------------------");
        int a = 10;
        int b = 20;
        // System.out.println(a > 100 && ++b > 10);
        System.out.println(a > 100 & ++b > 10);
        System.out.println(b);

        int i = 10;
        int j = 20;
        //System.out.println(i > 2 || ++j > 10);
        System.out.println(i > 2 | ++j > 10);
        System.out.println(j);
    }
}
