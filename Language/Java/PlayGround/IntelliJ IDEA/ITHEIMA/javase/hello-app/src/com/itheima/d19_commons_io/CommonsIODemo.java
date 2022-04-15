package com.itheima.d19_commons_io;
import org.apache.commons.io.FileUtils;
import java.io.File;

/**
    目标:Commons-io包的使用介绍。

    什么是Commons-io包？
            commons-io是apache开源基金组织提供的一组有关IO操作的类库，
            可以挺提高IO功能开发的效率。commons-io工具包提供了很多有关io操作的类，

    见下表：
         | 包                                  | 功能描述                                     |
         | ----------------------------------- | :------------------------------------------- |
         | org.apache.commons.io               | 有关Streams、Readers、Writers、Files的工具类 |
         | org.apache.commons.io.input         | 输入流相关的实现类，包含Reader和InputStream  |
         | org.apache.commons.io.output        | 输出流相关的实现类，包含Writer和OutputStream |
         | org.apache.commons.io.serialization | 序列化相关的类

    步骤：
         1. 下载commons-io相关jar包；http://commons.apache.org/proper/commons-io/
         2. 把commons-io-2.6.jar包复制到指定的Module的lib目录中
         3. 将commons-io-2.6.jar加入到classpath中

    小结：
         IOUtils和FileUtils可以方便的复制文件和文件夹！！
 */
public class CommonsIODemo {
    public static void main(String[] args) throws Exception {

////        // 1.完成文件复制！
//        IOUtils.copy(new FileInputStream("D:\\resources\\hushui.jpeg"),
//                new FileOutputStream("D:\\resources\\hushui2.jpeg"));


////        // 2.完成文件复制到某个文件夹下！
//        FileUtils.copyFileToDirectory(new File("D:\\resources\\hushui.jpeg"), new File("D:/"));


          // 3.完成文件夹复制到某个文件夹下！
//          FileUtils.copyDirectoryToDirectory(new File("D:\\resources") , new File("D:\\new"));
//           FileUtils.deleteDirectory(new File("D:\\new"));

         // JDK1.7 自己也做了一些一行代码完成复制的操作:New IO的技术
         // Files.copy(Path.of("D:\\resources\\hushui.jpeg"), Path.of("D:\\resources\\hushui3.jpeg"));

        FileUtils.deleteDirectory(new File("D:\\new"));
    }
}
