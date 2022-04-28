package com.itheima.day08_api_app.arraylist;

import java.util.ArrayList;

/**
      目标: 能够使用泛型约束ArrayList集合操作的数据类型
 */
public class ArrayListDemo2 {
    public static void main(String[] args) {
        // ArrayList<String> list = new ArrayList<String>();
        ArrayList<String> list = new ArrayList<>(); // JDK 1.7开始，泛型后面的类型申明可以不写
        list.add("Java");
        list.add("MySQL");
//        list.add(23);
//        list.add(23.5);

        ArrayList<Integer> list2 = new ArrayList<>();
        list2.add(23);
        list2.add(100);
        // list2.add("Java");
    }
}
