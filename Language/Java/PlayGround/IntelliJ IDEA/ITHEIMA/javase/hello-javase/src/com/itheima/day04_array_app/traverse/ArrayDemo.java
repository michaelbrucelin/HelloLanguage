package com.itheima.day04_array_app.traverse;

public class ArrayDemo {
    public static void main(String[] args) {
        // 目标：学会进行数组元素的遍历
        int[] arr = {12, 24, 12, 48, 98};
        //           0    1   2   3   4

        // 原始遍历方式
//        System.out.println(arr[0]);
//        System.out.println(arr[1]);
//        System.out.println(arr[2]);
//        System.out.println(arr[3]);
//        System.out.println(arr[4]);

//        for (int i = 0; i < 5; i++) {
//            System.out.println(arr[i]);
//        }

        // 终极数组遍历形式
        for (int i = 0; i < arr.length; i++) {
            System.out.println(arr[i]);
        }
    }
}
