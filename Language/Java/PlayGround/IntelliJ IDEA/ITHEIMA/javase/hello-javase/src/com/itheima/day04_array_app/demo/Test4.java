package com.itheima.day04_array_app.demo;

import java.util.Random;
import java.util.Scanner;

public class Test4 {
    public static void main(String[] args) {
        // 目标：键盘录入一组工号，最终要随机输出一组出来作为排名
        // 1、动态初始化一个数组，存储5个工号
        int[] codes = new int[5];

        // 2、定义一个循环，循环5次，依次录入一个工号存入对应的位置
        Scanner sc = new Scanner(System.in);
        for (int i = 0; i < codes.length; i++) {
            // 正式录入工号
            System.out.println("请您输入第" + (i + 1) + "个员工的工号：");
            int code = sc.nextInt();
            // 存入到数组中去
            codes[i] = code;
        }

        // 3、遍历数组中的每个元素，然后随机一个索引出来，让该元素与随机索引位置处的元素值进行交换（本节的重点）
        // codes = [12, 36, 28, 45, 99]
        Random r = new Random();
        for (int i = 0; i < codes.length; i++) {
            // 当前遍历的元素值：codes[i]
            // 随机一个索引位置出来：codes[index]
            int index = r.nextInt(codes.length);

            // 定义一个临时变量存储index位置处的值
            int temp = codes[index];
            codes[index] = codes[i];
            codes[i] = temp;
        }

        // 4、遍历数组元素输出就是随机排名的结果
        for (int i = 0; i < codes.length; i++) {
            System.out.print(codes[i] + "\t");
        }
    }
}
