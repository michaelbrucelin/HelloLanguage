package com.itheima.day15_collection_app.d2_collection_api;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;

/**
    目标：Collection集合的常用API.
    Collection是集合的祖宗类，它的功能是全部集合都可以继承使用的，所以要学习它。
    Collection API如下:
         - public boolean add(E e)：  把给定的对象添加到当前集合中 。
         - public void clear() :清空集合中所有的元素。
         - public boolean remove(E e): 把给定的对象在当前集合中删除。
         - public boolean contains(Object obj): 判断当前集合中是否包含给定的对象。
         - public boolean isEmpty(): 判断当前集合是否为空。
         - public int size(): 返回集合中元素的个数。
         - public Object[] toArray(): 把集合中的元素，存储到数组中。
    小结：
        记住以上API。
 */
public class CollectionDemo {
    public static void main(String[] args) {
        // HashSet:添加的元素是无序，不重复，无索引。
        Collection<String> c = new ArrayList<>();
        // 1.添加元素, 添加成功返回true。
        c.add("Java");
        c.add("HTML");
        System.out.println(c.add("HTML"));
        c.add("MySQL");
        c.add("Java");
        System.out.println(c.add("黑马"));
        System.out.println(c); // [Java, HTML, HTML, MySQL, Java, 黑马]

        // 2.清空集合的元素。
        // c.clear();
        // System.out.println(c);

        // 3.判断集合是否为空 是空返回true,反之。
        // System.out.println(c.isEmpty());

        // 4.获取集合的大小。
        System.out.println(c.size());

        // 5.判断集合中是否包含某个元素。
        System.out.println(c.contains("Java"));  // true
        System.out.println(c.contains("java")); // false
        System.out.println(c.contains("黑马")); // true

        // 6.删除某个元素:如果有多个重复元素默认删除前面的第一个！
        System.out.println(c.remove("java")); // false
        System.out.println(c);
        System.out.println(c.remove("Java")); // true
        System.out.println(c);

        // 7.把集合转换成数组  [HTML, HTML, MySQL, Java, 黑马]
        Object[] arrs = c.toArray();
        System.out.println("数组：" + Arrays.toString(arrs));

        System.out.println("----------------------拓展----------------------");
        Collection<String> c1 = new ArrayList<>();
        c1.add("java1");
        c1.add("java2");
        Collection<String> c2 = new ArrayList<>();
        c2.add("赵敏");
        c2.add("殷素素");
        // addAll把c2集合的元素全部倒入到c1中去。
        c1.addAll(c2);
        System.out.println(c1);
        System.out.println(c2);
    }
}
