package com.itheima.day17_stream_exception_log_app.d2_stream;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

/**
   目标：初步体验Stream流的方便与快捷
 */
public class StreamTest {
    public static void main(String[] args) {
        List<String> names = new ArrayList<>();
        Collections.addAll(names, "张三丰","张无忌","周芷若","赵敏","张强");
        System.out.println(names);
//
//        // 1、从集合中找出姓张的放到新集合
//        List<String> zhangList = new ArrayList<>();
//        for (String name : names) {
//            if(name.startsWith("张")){
//                zhangList.add(name);
//            }
//        }
//        System.out.println(zhangList);
//
//        // 2、找名称长度是3的姓名
//        List<String> zhangThreeList = new ArrayList<>();
//        for (String name : zhangList) {
//            if(name.length() == 3){
//                zhangThreeList.add(name);
//            }
//        }
//        System.out.println(zhangThreeList);

        // 3、使用Stream实现的
        names.stream().filter(s -> s.startsWith("张")).filter(s -> s.length() == 3).forEach(s -> System.out.println(s));
    }
}
