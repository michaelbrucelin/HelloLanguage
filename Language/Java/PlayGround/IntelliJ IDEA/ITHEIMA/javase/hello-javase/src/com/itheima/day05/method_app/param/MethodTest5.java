package com.itheima.day05.method_app.param;

public class MethodTest5 {
    public static void main(String[] args) {
        // 需求：比较任意2个整型数组的内容是否一样，一样返回true 反之
        int[] arr1 = {10, 20, 30};
        int[] arr2 = {10, 20, 30};
        System.out.println(compare(arr1, arr2));

        System.out.println("-------------------");
        int[] arr3 = null;
        int[] arr4 = {};
        System.out.println(compare(arr3, arr4));
    }

    /**
        1、定义一个方法：参数：接收2个整型数组，返回值类型：布尔类型
     */
    public static boolean compare(int[] arr1, int[] arr2){
        if(arr1 != null && arr2 != null){
            // 2、判断2个数组的内容是一样的呢
            if(arr1.length == arr2.length){
                for (int i = 0; i < arr1.length; i++) {
                    if(arr1[i] != arr2[i]){
                        return false;
                    }
                }
                return true; // 是一样的！
            }else {
                return false;
            }
        }else {
            return false;
        }
    }
}
