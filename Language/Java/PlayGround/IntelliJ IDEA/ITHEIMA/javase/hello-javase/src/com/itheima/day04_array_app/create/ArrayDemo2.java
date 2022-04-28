package com.itheima.day04_array_app.create;

/**

 */
public class ArrayDemo2 {
    public static void main(String[] args) {
        // 目标：学会访问数组的元素
        int[] ages = {12, 24, 36};
        //            0    1   2

        // 取值： 数组名称[索引]
        System.out.println(ages[0]);
        System.out.println(ages[1]);
        System.out.println(ages[2]);

        // 赋值：数组名称[索引] = 数据;
        ages[2] = 100;
        System.out.println(ages[2]);

        // 访问数组的长度
        System.out.println(ages.length);

//        int[] arr = {};
//        System.out.println(arr.length - 1);

    }
}
