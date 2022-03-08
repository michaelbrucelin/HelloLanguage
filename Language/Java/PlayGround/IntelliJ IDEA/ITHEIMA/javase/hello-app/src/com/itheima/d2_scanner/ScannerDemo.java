package com.itheima.d2_scanner;

import java.util.Scanner;

public class ScannerDemo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("请输入一个数字");
        int num = scanner.nextInt();
        System.out.println("你输入的数字是：" + num);

        System.out.println("请输入一个字符串");
        String str = scanner.next();
        System.out.println("你输入的字符串是：" + str);

        scanner.close();
    }
}
