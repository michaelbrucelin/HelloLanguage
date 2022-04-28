package com.itheima.day20_io_app2.d6_printStream;

import java.io.FileOutputStream;
import java.io.PrintStream;

/**
    目标：了解改变输出语句的位置到文件
 */
public class PrintDemo2 {
    public static void main(String[] args) throws Exception {
        System.out.println("锦瑟无端五十弦");
        System.out.println("一弦一柱思华年");

        // 改变输出语句的位置（重定向）
        PrintStream ps = new PrintStream("io-app2/src/log.txt");
        System.setOut(ps); // 把系统打印流改成我们自己的打印流

        System.out.println("庄生晓梦迷蝴蝶");
        System.out.println("望帝春心托杜鹃");
    }
}
