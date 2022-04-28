package com.itheima.day04_array_app.create;

public class ArrayDemo5 {
    public static void main(String[] args) {
        // 目标：掌握动态初始化元素默认值的规则。
        // 1、整型数组的元素默认值都是0
        int[] arr = new int[10];
        System.out.println(arr[0]);
        System.out.println(arr[9]);

        // 2、字符数组的元素默认值是多少呢？ 0
        char[] chars = new char[100];
        System.out.println((int)chars[0]);
        System.out.println((int)chars[99]);

        // 3、浮点型数组的元素默认值是0.0
        double[] scores = new double[90];
        System.out.println(scores[0]);
        System.out.println(scores[89]);

        // 4、布尔类型的数组
        boolean[] booleans = new boolean[100];
        System.out.println(booleans[0]);
        System.out.println(booleans[99]);

        // 5、引用类型的数组
        String[] names = new String[90];
        System.out.println(names[0]);
        System.out.println(names[89]);

        // int[] arrs = new int[3]{30, 40, 50};

        int[] a = {1,2,3};
        int[] b = {1,2,3};
        System.out.println(a);
        System.out.println(b);
    }
}
