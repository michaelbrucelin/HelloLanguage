package com.itheima.day19_file_io_app.d4_byte_stream;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.OutputStream;

/**
    目标：字节输出流的使用。

    IO流的体系：
            字节流                                   字符流
    字节输入流           字节输出流               字符输入流       字符输出流
    InputStream         OutputStream           Reader         Writer     (抽象类)
    FileInputStream     FileOutputStream       FileReader     FileWriter (实现类)

    a.FileOutputStream文件字节输出流。
        -- 作用：以内存为基准，把内存中的数据，按照字节的形式写出到磁盘文件中去。
                 简单来说，把内存数据按照字节写出到磁盘文件中去。
        -- 构造器：
            public FileOutputStream(File file):创建一个字节输出流管道通向目标文件对象。
            public FileOutputStream(String file):创建一个字节输出流管道通向目标文件路径。
            public FileOutputStream(File file , boolean append):创建一个追加数据的字节输出流管道通向目标文件对象。
            public FileOutputStream(String file , boolean append):创建一个追加数据的字节输出流管道通向目标文件路径。
        -- 方法：
           public void write(int a):写一个字节出去 。
           public void write(byte[] buffer):写一个字节数组出去。
           public void write(byte[] buffer , int pos , int len):写一个字节数组的一部分出去。
                           参数一，字节数组；参数二：起始字节索引位置，参数三：写多少个字节数出去。
    小结：
        记住。
        换行：  os.write("\r\n".getBytes()); // 换行
        追加数据管道： OutputStream os = new FileOutputStream("day10_demo/out01.txt" , true); // 追加管道！！
 */
public class OutputStreamDemo04 {
    public static void main(String[] args) throws Exception {
        // 1、创建一个文件字节输出流管道与目标文件接通
        OutputStream os = new FileOutputStream("file-io-app/src/out04.txt" , true); // 追加数据管道
//        OutputStream os = new FileOutputStream("file-io-app/src/out04.txt"); // 先清空之前的数据，写新数据进入

        // 2、写数据出去
        // a.public void write(int a):写一个字节出去
        os.write('a');
        os.write(98);
        os.write("\r\n".getBytes()); // 换行
        // os.write('徐'); // [ooo]

        // b.public void write(byte[] buffer):写一个字节数组出去。
        byte[] buffer = {'a' , 97, 98, 99};
        os.write(buffer);
        os.write("\r\n".getBytes()); // 换行

        byte[] buffer2 = "我是中国人".getBytes();
//        byte[] buffer2 = "我是中国人".getBytes("GBK");
        os.write(buffer2);
        os.write("\r\n".getBytes()); // 换行


        // c. public void write(byte[] buffer , int pos , int len):写一个字节数组的一部分出去。
        byte[] buffer3 = {'a',97, 98, 99};
        os.write(buffer3, 0 , 3);
        os.write("\r\n".getBytes()); // 换行

        // os.flush(); // 写数据必须，刷新数据 可以继续使用流
        os.close(); // 释放资源，包含了刷新的！关闭后流不可以使用了
    }
}
