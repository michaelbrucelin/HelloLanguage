package com.itheima.day20_io_app2.d4_transfer_stream;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.Reader;

/**
   演示一下代码编码与文件编码相同和不同的情况
 */
public class CharSetTest00 {
    public static void main(String[] args) {
        try (
                // 代码：UTF-8 文件 UTF-8 不会乱码
                // 1、创建一个文件字符输入流与源文件接通。
                // Reader fr = new FileReader("io-app2/src/data01.txt");


                // 代码：UTF-8 文件 GBK  乱码.     abc 我   爱 你中国
                //                                  oo  oo
                Reader fr = new FileReader("D:\\resources\\data.txt");
                // a、把低级的字符输入流包装成高级的缓冲字符输入流。
                BufferedReader br = new BufferedReader(fr);
        ){


            String line;
            while ((line = br.readLine()) != null){
                System.out.println(line);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
