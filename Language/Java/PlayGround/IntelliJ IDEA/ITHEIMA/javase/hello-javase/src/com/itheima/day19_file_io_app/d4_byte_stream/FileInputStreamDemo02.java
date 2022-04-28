package com.itheima.day19_file_io_app.d4_byte_stream;
import java.io.FileInputStream;
import java.io.InputStream;
/**
   目标：使用文件字节输入流每次读取一个字节数组的数据。
 */
public class FileInputStreamDemo02 {
    public static void main(String[] args) throws Exception {
        // 1、创建一个文件字节输入流管道与源文件接通
        InputStream is = new FileInputStream("file-io-app/src/data02.txt");

        // 2、定义一个字节数组，用于读取字节数组
//        byte[] buffer = new byte[3]; // 3B
//        int len = is.read(buffer);
//        System.out.println("读取了几个字节：" + len);
//        String rs = new String(buffer);
//        System.out.println(rs);
//
//        int len1 = is.read(buffer);
//        System.out.println("读取了几个字节：" + len1);
//        String rs1 = new String(buffer);
//        System.out.println(rs1);
//        // buffer = [a b c]
//
//        // buffer = [a b c]  ==>  [c d c]
//        int len2 = is.read(buffer);
//        System.out.println("读取了几个字节：" + len2);
//        // 读取多少倒出多少
//        String rs2 = new String(buffer,0 ,len2);
//        System.out.println(rs2);
//
//        int len3 = is.read(buffer);
//        System.out.println(len3); // 读取完毕返回-1

        // 3、改进使用循环，每次读取一个字节数组
        byte[] buffer = new byte[3];
        int len; // 记录每次读取的字节数。
        while ((len = is.read(buffer)) != -1) {
            // 读取多少倒出多少
            System.out.print(new String(buffer, 0 , len));
        }
    }
}
