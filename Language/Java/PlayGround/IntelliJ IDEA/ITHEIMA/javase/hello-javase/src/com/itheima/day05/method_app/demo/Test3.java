package com.itheima.day05.method_app.demo;

public class Test3 {
    public static void main(String[] args) {
        // 需求：使用方法，支持找出任意整型数组的最大值返回。
        int[] ages = {23, 19, 25, 78, 34};
        int max = getArrayMaxData(ages);
        System.out.println("最大值数据是：" + max);

        System.out.println("-------------------");
        int[] ages1 = {31, 21, 99, 78, 34};
        int max1 = getArrayMaxData(ages1);
        System.out.println("最大值数据是：" + max1);
    }

    public static int getArrayMaxData(int[] arr){
        // 找出数组的最大值返回
        int max = arr[0];
        // 遍历数组的每个元素与最大值的数据进行比较，若较大则替换
        for (int i = 1; i < arr.length; i++) {
            if(arr[i] > max){
                max = arr[i];
            }
        }
        return max;
    }
}
