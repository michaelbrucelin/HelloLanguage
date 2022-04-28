package com.itheima.day17_stream_exception_log_app.d2_stream;

import java.util.*;
import java.util.function.IntFunction;
import java.util.stream.Collectors;
import java.util.stream.Stream;

/**
     目标：收集Stream流的数据到 集合或者数组中去。
 */
public class StreamDemo05 {
    public static void main(String[] args) {
        List<String> list = new ArrayList<>();
        list.add("张无忌");
        list.add("周芷若");
        list.add("赵敏");
        list.add("张强");
        list.add("张三丰");
        list.add("张三丰");

        Stream<String> s1 = list.stream().filter(s -> s.startsWith("张"));
        List<String> zhangList = s1.collect(Collectors.toList()); // 可变集合
        zhangList.add("java1");
        System.out.println(zhangList);

//       List<String> list1 = s1.toList(); // 得到不可变集合
//       list1.add("java");
//       System.out.println(list1);

        // 注意注意注意：“流只能使用一次”
        Stream<String> s2 = list.stream().filter(s -> s.startsWith("张"));
        Set<String> zhangSet = s2.collect(Collectors.toSet());
        System.out.println(zhangSet);

        Stream<String> s3 = list.stream().filter(s -> s.startsWith("张"));
//         Object[] arrs = s3.toArray();
        String[] arrs = s3.toArray(String[]::new); // 可以不管，拓展一下思维！！
        System.out.println("Arrays数组内容：" + Arrays.toString(arrs));

    }
}
