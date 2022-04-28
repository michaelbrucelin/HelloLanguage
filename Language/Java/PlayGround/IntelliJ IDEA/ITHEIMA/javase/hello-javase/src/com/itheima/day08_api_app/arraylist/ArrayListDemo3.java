package com.itheima.day08_api_app.arraylist;

import java.util.ArrayList;

/**
    目标：掌握ArrayList集合的常用API
 */
public class ArrayListDemo3 {
    public static void main(String[] args) {
        ArrayList<String> list = new ArrayList<>();
        list.add("Java");
        list.add("Java");
        list.add("MySQL");
        list.add("MyBatis");
        list.add("HTML");

        // 1、public E get(int index)：获取某个索引位置处的元素值
        String e = list.get(3);
        System.out.println(e);

        // 2、public int size()：获取集合的大小（元素个数）
        System.out.println(list.size());

        // 3、完成集合的遍历
        for (int i = 0; i < list.size(); i++) {
            System.out.println(list.get(i));
        }

        // 4、public E remove(int index)：删除某个索引位置处的元素值,并返回被删除的元素值
        System.out.println(list); // [Java, Java, MySQL, MyBatis, HTML]
        String e2 = list.remove(2);
        System.out.println(e2);
        System.out.println(list);

        // 5、public boolean remove(Object o):直接删除元素值，删除成功返回true，删除失败返回false
        System.out.println(list.remove("MyBatis"));
        System.out.println(list);

        ArrayList<String> list1 = new ArrayList<>();
        list1.add("Java");
        list1.add("王宝强");
        list1.add("Java");
        list1.add("MySQL");
        System.out.println(list1);
        // 只会删除第一次出现的这个元素值，后面的不删除
        System.out.println(list1.remove("Java"));
        System.out.println(list1);

        // 6、public E set(int index,E element)：修改某个索引位置处的元素值。
        String e3 = list1.set(0 , "贾乃亮");
        System.out.println(e3);
        System.out.println(list1);
    }
}
