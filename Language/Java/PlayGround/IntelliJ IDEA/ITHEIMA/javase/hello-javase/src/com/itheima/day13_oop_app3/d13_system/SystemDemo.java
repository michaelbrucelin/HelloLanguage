package com.itheima.day13_oop_app3.d13_system;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.text.SimpleDateFormat;
import java.util.Arrays;

/**
    目标：System系统类的使用。
    System代表当前系统。（虚拟机系统）
    静态方法：
        1.public static void exit(int status):终止JVM虚拟机，非0是异常终止。
        2.public static long currentTimeMillis():获取当前系统此刻时间毫秒值。(重点)
        3.可以做数组的拷贝。
             arraycopy(Object var0, int var1, Object var2, int var3, int var4);
             * 参数一：原数组
             * 参数二：从原数组的哪个位置开始赋值。
             * 参数三：目标数组
             * 参数四：赋值到目标数组的哪个位置
             * 参数五：赋值几个。
 */
public class SystemDemo {
    public static void main(String[] args) {
        System.out.println("程序开始。。。");

        // System.exit(0); // JVM终止！

        // 2、计算机认为时间有起源：返回1970-1-1 00：00：00 走到此刻的总的毫秒值：时间毫秒值。
        long time = System.currentTimeMillis();
        System.out.println(time);

        long startTime = System.currentTimeMillis();
        // 进行时间的计算：性能分析
        for (int i = 0; i < 100000; i++) {
            System.out.println("输出：" + i);
        }
        long endTime = System.currentTimeMillis();
        System.out.println((endTime - startTime)/1000.0 + "s");


        // 3、做数组拷贝（了解）
        /**
         arraycopy(Object src,  int  srcPos,
         Object dest, int destPos,
         int length)
         参数一：被拷贝的数组
         参数二：从哪个索引位置开始拷贝
         参数三：复制的目标数组
         参数四：粘贴位置
         参数五：拷贝元素的个数
         */
        int[] arr1 = {10, 20, 30, 40, 50, 60, 70};
        int[] arr2 = new int[6]; // [0, 0, 0, 0, 0, 0] ==>  [0, 0, 40, 50, 60, 0]
        System.arraycopy(arr1, 3, arr2, 2, 3);
        System.out.println(Arrays.toString(arr2));

        System.out.println("-------------------");
        double i = 10.0;
        double j = 3.0;

//
//        System.out.println(k1);

        System.out.println("程序结束。。。。");
    }
}
