package com.itheima.day02.scanner;
import java.util.Scanner;
// 1、导包操作 (并不需要自己写的，以后通过工具进行导入更方便)
public class ScannerDemo {
    public static void main(String[] args) {
        // 目标：接收用户的键盘输入的数据。
        // 2、得到一个键盘扫描器对象
        Scanner sc = new Scanner(System.in);

        System.out.println("请您输入您的年龄：");
        // 3、等待接收用户输入一个整数，按了回车键才会把数据交给age变量
        int age = sc.nextInt();
        System.out.println("您的年龄是：" + age);

        System.out.println("请您输入您的名称：");
        // 4、等待接收用户输入一个字符串，按了回车键才会把数据交给name变量
        String name = sc.next();
        System.out.println(name + "欢迎进入系统！");
    }
}
