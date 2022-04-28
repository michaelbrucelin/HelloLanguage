package com.itheima.day15_collection_app.d5_collection_list;

import java.util.ArrayList;
import java.util.Collection;
import java.util.LinkedList;
import java.util.List;

/**
      目标：ArrayList集合。

      Collection集合的体系
                         Collection<E>(接口)
              /                                                \
           Set<E>(接口)                                         List<E>(接口)
            /                  \                               /                     \                  \
          HashSet<E>(实现类)    TreeSet<E>(实现类)          LinkedList<E>(实现类)  Vector(线程安全)     ArrayList<E>(实现类)
          /
         LinkedHashSet<E>(实现类)

      Collection集合体系的特点:
         Set系列集合： 添加的元素，是无序，不重复，无索引的。
             -- HashSet：添加的元素，是无序，不重复，无索引的。
             -- LinkedHashSet：添加的元素，是有序，不重复，无索引的。
         List系列集合：添加的元素，是有序，可重复，有索引的。
             -- LinkedList： 添加的元素，是有序，可重复，有索引的。
             -- ArrayList： 添加的元素，是有序，可重复，有索引的。
             -- Vector 是线程安全的，速度慢，工作中很少使用。

         1、List集合继承了Collection集合的全部功能，"同时因为List系列集合有索引"，
         2、因为List集合多了索引，所以多了很多按照索引操作元素的功能:
         3、ArrayList实现类集合底层基于数组存储数据的，查询快，增删慢！
             - public void add(int index, E element): 将指定的元素，添加到该集合中的指定位置上。
             - public E get(int index):返回集合中指定位置的元素。
             - public E remove(int index): 移除列表中指定位置的元素, 返回的是被移除的元素。
             - public E set(int index, E element):用指定元素替换集合中指定位置的元素,返回更新前的元素值。
      小结：
            ArrayList集合的底层是基于数组存储数据。查询快，增删慢！（相对的）
 */
public class ListDemo01 {
    public static void main(String[] args) {
        // 1.创建一个ArrayList集合对象：
        // List:有序，可重复，有索引的。
        ArrayList<String> list = new ArrayList<>(); // 一行经典代码！
        list.add("Java");
        list.add("Java");
        list.add("HTML");
        list.add("HTML");
        list.add("MySQL");
        list.add("MySQL");

        // 2.在某个索引位置插入元素。
        list.add(2, "黑马");
        System.out.println(list);

        // 3.根据索引删除元素,返回被删除元素
        System.out.println(list.remove(1));
        System.out.println(list);

        // 4.根据索引获取元素:public E get(int index):返回集合中指定位置的元素。
        System.out.println(list.get(1));

        // 5.修改索引位置处的元素: public E set(int index, E element)
        System.out.println(list.set(1, "传智教育"));
        System.out.println(list);
    }
}
