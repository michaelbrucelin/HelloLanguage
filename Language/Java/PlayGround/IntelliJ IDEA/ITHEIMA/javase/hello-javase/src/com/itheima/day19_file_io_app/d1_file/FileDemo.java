package com.itheima.day19_file_io_app.d1_file;

import java.io.File;

/**
    目标：学会创建File对象定位操作系统的文件（文件 文件夹的）
 */
public class FileDemo {
    public static void main(String[] args) {
        // 1、创建File对象（指定了文件的路径）
        // 路径写法： D:\resources\xueshan.jpeg
        //          D:/resources/xueshan.jpeg
        //          File.separator
//        File f = new File("D:\\resources\\xueshan.jpeg");
//        File f = new File("D:/resources/xueshan.jpeg");
        File f = new File("D:" + File.separator+"resources"+ File.separator +"xueshan.jpeg");
        long size = f.length(); // 是文件的字节大小
        System.out.println(size);

        // 2、File创建对象，支持绝对路径 支持相对路径（重点）
        File f1 = new File("D:\\resources\\beauty.jpeg"); // 绝对路径
        System.out.println(f1.length());

        // 相对路径：一般定位模块中的文件的。 相对到工程下！！
        File f2 = new File("file-io-app/src/data.txt");
        System.out.println(f2.length());

        // 3、File创建对象 ，可以是文件也可以是文件夹
        File f3 = new File("D:\\resources");
        System.out.println(f3.exists()); // 判断这个路径是否存在，这个文件夹存在否

    }
}
