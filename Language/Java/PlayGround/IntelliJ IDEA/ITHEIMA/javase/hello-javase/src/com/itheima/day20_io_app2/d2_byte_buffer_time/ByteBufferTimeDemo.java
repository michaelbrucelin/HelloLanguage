package com.itheima.day20_io_app2.d2_byte_buffer_time;

import java.io.*;

/**
    目标：利用字节流的复制统计各种写法形式下缓冲流的性能执行情况。

    复制流：
        （1）使用低级的字节流按照一个一个字节的形式复制文件。
        （2）使用低级的字节流按照一个一个字节数组的形式复制文件。
        （3）使用高级的缓冲字节流按照一个一个字节的形式复制文件。
        （4）使用高级的缓冲字节流按照一个一个字节数组的形式复制文件。

    源文件：C:\course\3-视频\18、IO流-文件字节输出流FileOutputStream写字节数据出去.avi
    目标文件：C:\course\

    小结：
        使用高级的缓冲字节流按照一个一个字节数组的形式复制文件，性能好，建议开发使用！
 */
public class ByteBufferTimeDemo {
    private static final String SRC_FILE = "D:\\course\\基础加强\\day08-日志框架、阶段项目\\视频\\14、用户购票功能.avi";
    private static final String DEST_FILE = "D:\\course\\";

    public static void main(String[] args) {
        // copy01(); // 使用低级的字节流按照一个一个字节的形式复制文件：慢的让人简直无法忍受。直接被淘汰。
        copy02(); // 使用低级的字节流按照一个一个字节数组的形式复制文件: 比较慢，但是还是可以忍受的！
        // copy03(); // 缓冲流一个一个字节复制：很慢，不建议使用。
        copy04(); // 缓冲流一个一个字节数组复制：飞快，简直太完美了（推荐使用）
    }

    private static void copy04() {
        long startTime = System.currentTimeMillis();
        try (
                // 1、创建低级的字节输入流与源文件接通
                InputStream is = new FileInputStream(SRC_FILE);
                // a.把原始的字节输入流包装成高级的缓冲字节输入流
                InputStream bis = new BufferedInputStream(is);
                // 2、创建低级的字节输出流与目标文件接通
                OutputStream os = new FileOutputStream(DEST_FILE + "video4.avi");
                // b.把字节输出流管道包装成高级的缓冲字节输出流管道
                OutputStream bos = new BufferedOutputStream(os);
        ) {

            // 3、定义一个字节数组转移数据
            byte[] buffer = new byte[1024];
            int len; // 记录每次读取的字节数。
            while ((len = bis.read(buffer)) != -1){
                bos.write(buffer, 0 , len);
            }

        } catch (Exception e){
            e.printStackTrace();
        }
        long endTime = System.currentTimeMillis();
        System.out.println("使用缓冲的字节流按照一个一个字节数组的形式复制文件耗时：" + (endTime - startTime)/1000.0 + "s");
    }



    private static void copy03() {
        long startTime = System.currentTimeMillis();
        try (
                // 1、创建低级的字节输入流与源文件接通
                InputStream is = new FileInputStream(SRC_FILE);
                // a.把原始的字节输入流包装成高级的缓冲字节输入流
                InputStream bis = new BufferedInputStream(is);
                // 2、创建低级的字节输出流与目标文件接通
                OutputStream os = new FileOutputStream(DEST_FILE + "video3.avi");
                // b.把字节输出流管道包装成高级的缓冲字节输出流管道
                OutputStream bos = new BufferedOutputStream(os);
        ){

            // 3、定义一个变量记录每次读取的字节（一个一个字节的复制）
            int b;
            while ((b = bis.read()) != -1){
                bos.write(b);
            }
        }catch (Exception e){
            e.printStackTrace();
        }
        long endTime = System.currentTimeMillis();
        System.out.println("使用缓冲的字节流按照一个一个字节的形式复制文件耗时：" + (endTime - startTime)/1000.0 + "s");
    }


    private static void copy02() {
        long startTime = System.currentTimeMillis();
        try (
                // 这里面只能放置资源对象，用完会自动关闭：自动调用资源对象的close方法关闭资源（即使出现异常也会做关闭操作）
                // 1、创建一个字节输入流管道与原视频接通
                InputStream is = new FileInputStream(SRC_FILE);
                // 2、创建一个字节输出流管道与目标文件接通
                OutputStream os = new FileOutputStream(DEST_FILE + "video2.avi")
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
        long endTime = System.currentTimeMillis();
        System.out.println("使用低级的字节流按照一个一个字节数组的形式复制文件耗时：" + (endTime - startTime)/1000.0 + "s");
    }

    /**
      使用低级的字节流按照一个一个字节的形式复制文件
     */
    private static void copy01() {
        long startTime = System.currentTimeMillis();
        try (
                // 1、创建低级的字节输入流与源文件接通
                InputStream is = new FileInputStream(SRC_FILE);
                // 2、创建低级的字节输出流与目标文件接通
                OutputStream os = new FileOutputStream(DEST_FILE + "video1.avi")
                ){

            // 3、定义一个变量记录每次读取的字节（一个一个字节的复制）
            int b;
            while ((b = is.read()) != -1){
                os.write(b);
            }
        }catch (Exception e){
            e.printStackTrace();
        }
        long endTime = System.currentTimeMillis();
        System.out.println("使用低级的字节流按照一个一个字节的形式复制文件耗时：" + (endTime - startTime)/1000.0 + "s");
    }

}
