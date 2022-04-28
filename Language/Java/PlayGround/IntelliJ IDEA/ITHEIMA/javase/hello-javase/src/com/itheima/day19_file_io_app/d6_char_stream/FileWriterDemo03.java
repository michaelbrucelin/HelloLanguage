package com.itheima.day19_file_io_app.d6_char_stream;

import java.io.File;
import java.io.FileWriter;
import java.io.Writer;

/**
     目标：字符输出流的使用。

     IO流的体系：
            字节流                                   字符流
     字节输入流           字节输出流               字符输入流       字符输出流
     InputStream         OutputStream           Reader         Writer     (抽象类)
     FileInputStream     FileOutputStream       FileReader     FileWriter (实现类)

     d.FileWriter文件字符输出流的使用。
        -- 作用：以内存为基准，把内存中的数据按照字符的形式写出到磁盘文件中去。
            简单来说，就是把内存的数据以字符写出到文件中去。
        -- 构造器：
           public FileWriter(File file):创建一个字符输出流管道通向目标文件对象。
           public FileWriter(String filePath):创建一个字符输出流管道通向目标文件路径。
           public FileWriter(File file,boolean append):创建一个追加数据的字符输出流管道通向目标文件对象。
           public FileWriter(String filePath,boolean append):创建一个追加数据的字符输出流管道通向目标文件路径。
        -- 方法：
             a.public void write(int c):写一个字符出去
             b.public void write(String c)写一个字符串出去：
             c.public void write(char[] buffer):写一个字符数组出去
             d.public void write(String c ,int pos ,int len):写字符串的一部分出去
             e.public void write(char[] buffer ,int pos ,int len):写字符数组的一部分出去
     小结：
        字符输出流可以写字符数据出去，总共有5个方法写字符。
        覆盖管道：
             Writer fw = new FileWriter("Day10Demo/src/dlei03.txt"); // 覆盖数据管道
        追加数据管道：
             Writer fw = new FileWriter("Day10Demo/src/dlei03.txt",true); // 追加数据管道
        换行：
             fw.write("\r\n"); // 换行
        结论：读写字符文件数据建议使用字符流。复制文件建议使用字节流。
 */
public class FileWriterDemo03 {
    public static void main(String[] args) throws Exception {
        // 1、创建一个字符输出流管道与目标文件接通
        // Writer fw = new FileWriter("file-io-app/src/out08.txt"); // 覆盖管道，每次启动都会清空文件之前的数据
        Writer fw = new FileWriter("file-io-app/src/out08.txt", true); // 覆盖管道，每次启动都会清空文件之前的数据

//      a.public void write(int c):写一个字符出去
        fw.write(98);
        fw.write('a');
        fw.write('徐'); // 不会出问题了
        fw.write("\r\n"); // 换行

//       b.public void write(String c)写一个字符串出去
        fw.write("abc我是中国人");
        fw.write("\r\n"); // 换行


//       c.public void write(char[] buffer):写一个字符数组出去
        char[] chars = "abc我是中国人".toCharArray();
        fw.write(chars);
        fw.write("\r\n"); // 换行


//       d.public void write(String c ,int pos ,int len):写字符串的一部分出去
        fw.write("abc我是中国人", 0, 5);
        fw.write("\r\n"); // 换行


//       e.public void write(char[] buffer ,int pos ,int len):写字符数组的一部分出去
        fw.write(chars, 3, 5);
        fw.write("\r\n"); // 换行


        // fw.flush();// 刷新后流可以继续使用
        fw.close(); // 关闭包含刷线，关闭后流不能使用

    }
}
