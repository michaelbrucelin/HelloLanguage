package com.itheima.day16_collection_map_app2.d1_collection_set;

import java.util.HashSet;
import java.util.Set;

/**
    目标：让Set集合把重复内容的对象去掉一个（去重复）
 */
public class SetDemo3 {
    public static void main(String[] args) {
        // Set集合去重复原因：先判断哈希值算出来的存储位置是否相同 再判断equals
        Set<Student> sets = new HashSet<>();

        Student s1 = new Student("无恙", 20, '男');
        Student s2 = new Student("无恙", 20, '男');
        Student s3 = new Student("周雄", 21, '男');
        System.out.println(s1.hashCode());
        System.out.println(s2.hashCode());
        System.out.println(s3.hashCode());

        sets.add(s1);
        sets.add(s2);
        sets.add(s3);

        System.out.println(sets);
    }
}
