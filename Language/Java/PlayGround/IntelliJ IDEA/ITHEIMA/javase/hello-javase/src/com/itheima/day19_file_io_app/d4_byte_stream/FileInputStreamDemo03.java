package com.itheima.day19_file_io_app.d4_byte_stream;
import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;

/**
   目标：使用文件字节输入流一次读完文件的全部字节。可以解决乱码问题。
 */
public class FileInputStreamDemo03 {
    public static void main(String[] args) throws Exception {
        // 1、创建一个文件字节输入流管道与源文件接通
        File f = new File("file-io-app/src/data03.txt");
        InputStream is = new FileInputStream(f);

        // 2、定义一个字节数组与文件的大小刚刚一样大。
//        byte[] buffer = new byte[(int) f.length()];
//        int len = is.read(buffer);
//        System.out.println("读取了多少个字节：" + len);
//        System.out.println("文件大小：" + f.length());
//        System.out.println(new String(buffer));

        // 读取全部字节数组
        byte[] buffer = is.readAllBytes();
        System.out.println(new String(buffer));

    }
}
