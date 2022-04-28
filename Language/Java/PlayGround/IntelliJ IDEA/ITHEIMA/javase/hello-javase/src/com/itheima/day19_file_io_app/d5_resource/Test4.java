package com.itheima.day19_file_io_app.d5_resource;

import java.io.*;

/**
   目标：拷贝文件夹
 */
public class Test4 {
    public static void main(String[] args) {
         // D:\resources
        copy(new File("D:\\resources") , new File("D:\\new"));
    }

    public static void copy(File src , File dest){
        // 1、判断源目录是否存在
        if(src!= null && src.exists() && src.isDirectory()){
            // 2、目标目录需要创建一下  D:\new\resources
            File destOne = new File(dest , src.getName());
            destOne.mkdirs();

            // 3、提取原目录下的全部一级文件对象
            File[] files = src.listFiles();
            // 4、判断是否存在一级文件对象
            if(files != null && files.length > 0) {
                // 5、遍历一级文件对象
                for (File file : files) {
                    // 6、判断是文件还是文件夹，是文件直接复制过去
                    if(file.isFile()){
                        copyFile(file, new File(destOne , file.getName()));
                    }else {
                        // 7、当前遍历的是文件夹，递归复制
                        copy(file, destOne);
                    }
                }
            }

        }
    }

    public static void copyFile(File srcFile, File destFile){
        try (
                // 1、创建一个字节输入流管道与原视频接通
                InputStream is = new FileInputStream(srcFile);
                // 2、创建一个字节输出流管道与目标文件接通
                OutputStream os = new FileOutputStream(destFile);
                ) {
            // 3、定义一个字节数组转移数据
            byte[] buffer = new byte[1024];
            int len; // 记录每次读取的字节数。
            while ((len = is.read(buffer)) != -1){
                os.write(buffer, 0 , len);
            }
        } catch (Exception e){
            e.printStackTrace();
        }
    }
}
