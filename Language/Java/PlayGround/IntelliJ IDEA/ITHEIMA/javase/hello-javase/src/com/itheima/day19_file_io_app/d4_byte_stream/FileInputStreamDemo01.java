package com.itheima.day19_file_io_app.d4_byte_stream;

import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;

/**
    目标：字节输入流的使用。

    IO流的体系：
                 字节流                                   字符流
        字节输入流            字节输出流               字符输入流        字符输出流
        InputStream          OutputStream           Reader           Writer  (抽象类)
        FileInputStream      FileOutputStream       FileReader       FileWriter(实现类，可以使用的)

    文件字节输入流：FileInputStream
        -- 作用：以内存为基准，把磁盘文件中的数据以字节的形式读取到内存中去。
                按照字节读文件数据到内存中。
        -- 构造器：
            public FileInputStream(File file):创建字节输入流管道与源文件对象接通
            public FileInputStream(String pathname)：创建字节输入流管道与源文件路径接通。
        -- 方法：
            public int read(): 每次读取一个字节返回，读取完毕返回-1。

    小结：
        一个一个字节读取中文数据输出其实是被淘汰的，性能极差！
         一个一个字节读取中文数据输出，会出现截断中文字节的情况，无法避免读取中文输出乱码的问题。

 */
public class FileInputStreamDemo01 {
    public static void main(String[] args) throws Exception {
        // 1、创建一个文件字节输入流管道与源文件接通。
        // InputStream is = new FileInputStream(new File("file-io-app\\src\\data.txt"));
        // 简化写法
        InputStream is = new FileInputStream("file-io-app\\src\\data.txt");

        // 2、读取一个字节返回 （每次读取一滴水）
//        int b1 = is.read();
//        System.out.println((char)b1);
//
//        int b2 = is.read();
//        System.out.println((char)b2);
//
//        int b3 = is.read();
//        System.out.println((char)b3);
//
//        int b4 = is.read(); // 读取完毕返回-1
//        System.out.println(b4);

        // 3、使用循环改进
        // 定义一个变量记录每次读取的字节    a  b  3   爱
        //                              o o  o   [ooo]
        int b;
        while (( b = is.read() ) != -1){
            System.out.print((char) b);
        }
    }
}















