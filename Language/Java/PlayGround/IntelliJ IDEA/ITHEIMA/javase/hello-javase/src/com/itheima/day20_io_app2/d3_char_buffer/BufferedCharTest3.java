package com.itheima.day20_io_app2.d3_char_buffer;

import java.io.*;
import java.util.*;

/**
   目标：完成出师表顺序的恢复，并存入到另一个新文件中去。
 */
public class BufferedCharTest3 {
    public static void main(String[] args) {
        try(
                // 1、创建缓冲字符输入流管道与源文件接通
                BufferedReader br = new BufferedReader(new FileReader("io-app2/src/csb.txt"));

                // 5、定义缓冲字符输出管道与目标文件接通
                BufferedWriter bw = new BufferedWriter(new FileWriter("io-app2/src/new.txt"));
                ) {

            // 2、定义一个List集合存储每行内容
            List<String> data = new ArrayList<>();
            // 3、定义循环，按照行读取文章
            String line;
            while ((line = br.readLine()) != null){
                data.add(line);
            }
            System.out.println(data);

            // 4、排序
            // 自定义排序规则
            List<String> sizes = new ArrayList<>();
            Collections.addAll(sizes, "一","二","三","四","五","陆","柒","八","九","十","十一");

            Collections.sort(data, new Comparator<String>() {
                @Override
                public int compare(String o1, String o2) {
                    // o1   八.,....
                    // o2   柒.,....
                    return sizes.indexOf(o1.substring(0, o1.indexOf(".")))
                            - sizes.indexOf(o2.substring(0, o2.indexOf(".")));
                }
            });
            System.out.println(data);

            // 6、遍历集合中的每行文章写出去，且要换行
            for (String datum : data) {
                bw.write(datum);
                bw.newLine(); // 换行
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
