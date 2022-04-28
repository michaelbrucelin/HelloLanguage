package com.itheima.day16_collection_map_app2.d1_collection_set;
import java.util.HashSet;
import java.util.Set;
public class SetDemo1 {
    public static void main(String[] args) {
        // 看看Set系列集合的特点： HashSet LinkedHashSet TreeSet
        //
        Set<String> sets = new HashSet<>(); // 一行经典代码  无序不重复，无索引
        // Set<String> sets = new LinkedHashSet<>(); // 有序  不重复 无索引
        sets.add("MySQL");
        sets.add("MySQL");
        sets.add("Java");
        sets.add("Java");
        sets.add("HTML");
        sets.add("HTML");
        sets.add("SpringBoot");
        sets.add("SpringBoot");
        System.out.println(sets);
    }
}
