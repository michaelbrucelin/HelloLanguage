package com.itheima.day01_helloworld_app.literal;

public class LiteralDemo {
    public static void main(String[] args) {
        // 目标：掌握数据在程序中的书写格式
        // 1、整数
        System.out.println(66);
        System.out.println(-23);

        // 2、小数
        System.out.println(99.5);

        // 3、字符：必须单引号围起来，有且仅能有一个字符
        System.out.println('中');
        System.out.println('0');
        System.out.println('\n');  // \n换行
        System.out.println('\t');  // \t空格
        System.out.println('a');

        // 4、字符串：必须双引号围起来，内容可以随意
        System.out.println("");
        System.out.println("我爱你中国！abc");
        System.out.println("    学习Java使我快乐！~~~");

        // 5、布尔类型：true false
        System.out.println(true);
        System.out.println(false);

        // 6、空类型 null (以后再详细说明！)
    }
}
