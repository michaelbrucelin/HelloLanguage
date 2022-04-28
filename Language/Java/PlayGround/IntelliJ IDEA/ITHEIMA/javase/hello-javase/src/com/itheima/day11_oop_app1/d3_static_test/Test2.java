package com.itheima.day11_oop_app1.d3_static_test;

public class Test2 {
    public static void main(String[] args) {
        int[] arr = {10, 20, 30};
        System.out.println(arr);
        System.out.println(ArrayUtils.toString(arr));
        System.out.println(ArrayUtils.getAverage(arr));

        int[] arr1 = null;
        System.out.println(ArrayUtils.toString(arr1));
        int[] arr2 = {};
        System.out.println(ArrayUtils.toString(arr2));

    }
}
