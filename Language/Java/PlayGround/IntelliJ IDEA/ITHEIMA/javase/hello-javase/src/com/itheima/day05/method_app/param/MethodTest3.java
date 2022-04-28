package com.itheima.day05.method_app.param;

public class MethodTest3 {
    public static void main(String[] args) {
        // 需求：定义方法，可以打印任意整型数组的内容：[12, 32, 23]
        // 4、定义数组，再调用方法
        int[] arr = {12, 32, 23};
        printArray(arr);

        System.out.println("-----------------");
        int[] arr2 = {};
        printArray(arr2);

        System.out.println("-----------------");
        int[] arr3 = null;
        printArray(arr3);
    }

    /**
        1、定义一个方法：参数：整型数组类型的变量  返回值类型申明：void
     */
    public static void printArray(int[] arr){
        if(arr != null){
            // 2、把数组内容打印出来。
            System.out.print("[");
            // 3、开始遍历数组中的每个数据
            for (int i = 0; i < arr.length; i++) {
                // 如果发现是最后一个元素不加逗号
//            if(i == arr.length - 1){
//                System.out.print(arr[i]);
//            }else {
//                System.out.print(arr[i] + ", ");
//            }
                System.out.print(i == arr.length - 1 ? arr[i] : arr[i] + ", ");
            }
            System.out.println("]");
        }else {
            System.out.println("当前数组对象不存在，其地址是：null");
        }
    }
}
