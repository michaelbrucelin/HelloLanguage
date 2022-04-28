package com.itheima.day19_file_io_app.d1_file;

import java.io.File;
import java.util.Arrays;

/**

    目标：File针对目录的遍历
    - public String[] list()：
         获取当前目录下所有的"一级文件名称"到一个字符串数组中去返回。
    - public File[] listFiles()(常用)：
         获取当前目录下所有的"一级文件对象"到一个文件对象数组中去返回（重点）
 */
public class FileDemo04 {
    public static void main(String[] args) {
        // 1、定位一个目录
        File f1 = new File("D:/resources");
        String[] names = f1.list();
        for (String name : names) {
            System.out.println(name);
        }

        // 2.一级文件对象
        // 获取当前目录下所有的"一级文件对象"到一个文件对象数组中去返回（重点）
        File[] files = f1.listFiles();
        for (File f : files) {
            System.out.println(f.getAbsolutePath());
        }

        // 注意事项
        File dir = new File("D:/resources/ddd");
        File[] files1 = dir.listFiles();
        System.out.println(Arrays.toString(files1));
    }
}
