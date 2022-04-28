package com.itheima.day20_io_app2.d4_transfer_stream;

import java.io.*;

/**
     目标：字符输入转换流InputStreamReader的使用。

             字节流                                     字符流
     字节输入流               字节输出流              字符输入流            字符输出流
     InputStream             OutputStream          Reader               Writer   (抽象类)
     FileInputStream         FileOutputStream      FileReader           FileWriter(实现类)
     BufferedInputStream     BufferedOutputStream  BufferedReader       BufferedWriter(实现类，缓冲流)
                                                   InputStreamReader    OutputStreamWriter
     字符输入转换流InputStreamReader:
          -- 作用：可以解决字符流读取不同编码乱码的问题。
                  也可以把原始的字节流按照指定编码转换成字符输入流

          -- 构造器：
                public InputStreamReader(InputStream is)：可以使用当前代码默认编码转换成字符流，几乎不用！
                public InputStreamReader(InputStream is,String charset):可以指定编码把字节流转换成字符流(核心)

     小结：
        字符输入转换流InputStreamReader:作用：可以解决字符流读取不同编码乱码的问题。
        public InputStreamReader(InputStream is,String charset):可以指定编码把字节流转换成字符流(核心)
 */
public class InputStreamReaderDemo01 {
    public static void main(String[] args) throws Exception {
        // 代码UTF-8   文件 GBK  "D:\\resources\\data.txt"
        // 1、提取GBK文件的原始字节流。   abc 我
        //                            ooo oo
        InputStream is = new FileInputStream("D:\\resources\\data.txt");
        // 2、把原始字节流转换成字符输入流
        // Reader isr = new InputStreamReader(is); // 默认以UTF-8的方式转换成字符流。 还是会乱码的  跟直接使用FileReader是一样的
        Reader isr = new InputStreamReader(is , "GBK"); // 以指定的GBK编码转换成字符输入流  完美的解决了乱码问题

        BufferedReader br = new BufferedReader(isr);
        String line;
        while ((line = br.readLine()) != null){
            System.out.println(line);
        }
    }
}



















