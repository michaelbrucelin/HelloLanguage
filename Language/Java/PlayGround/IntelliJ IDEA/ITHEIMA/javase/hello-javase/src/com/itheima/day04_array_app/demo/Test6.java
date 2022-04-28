package com.itheima.day04_array_app.demo;

public class Test6 {
    public static void main(String[] args) {
        // 数组（基本面试题）
        int[] arr1 = {10, 20, 30};
        int[] arr2 = {11, 20, 30};  // 内容 个数完全一样。

        if(arr1 == arr2){
            System.out.println("两个数组相等！");
        }else{
            // 地址不同，比较内容是否相同！
            if(arr1.length == arr2.length){
                // 编程思想：定义一个信号位，默认认为是相等的。
                boolean flag = true;

                for (int i = 0; i < arr1.length; i++) {
                    if(arr1[i] != arr2[i]){
                        System.out.println("两个数组不相等！");
                        flag = false; // 表示不相等了
                        break;
                    }
                }

                if(flag){
                    System.out.println("两个数组相等！！");
                }

            }else {
                System.out.println("两个数组不相等！");
            }
        }
    }
}
