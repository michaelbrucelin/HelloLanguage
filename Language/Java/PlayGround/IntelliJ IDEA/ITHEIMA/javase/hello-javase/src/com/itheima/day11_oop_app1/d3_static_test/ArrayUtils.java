package com.itheima.day11_oop_app1.d3_static_test;

public class ArrayUtils {
    /**
       把它的构造器私有化
     */
    private ArrayUtils(){
    }

    /**
       静态方法，工具方法
     */
    public static String toString(int[] arr){
        if(arr != null ){
            String result = "[";
            for (int i = 0; i < arr.length; i++) {
                result += (i == arr.length - 1 ? arr[i] : arr[i] + ", ");
            }
            result += "]";
            return result;
        }else {
            return null;
        }
    }

    /**
     静态方法，工具方法
     */
    public static double getAverage(int[] arr){
        // 总和  最大值 最小值
        int max = arr[0];
        int min = arr[0];
        int sum = 0;
        for (int i = 0; i < arr.length; i++) {
            if(arr[i] > max){
                max = arr[i];
            }
            if(arr[i] < min){
                min = arr[i];
            }
            sum += arr[i];
        }
        return (sum - max - min)*1.0 / (arr.length - 2);
    }
}
