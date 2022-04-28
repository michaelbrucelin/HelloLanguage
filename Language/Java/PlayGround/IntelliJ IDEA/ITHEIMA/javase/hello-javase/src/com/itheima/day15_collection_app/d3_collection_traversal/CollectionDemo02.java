package com.itheima.day15_collection_app.d3_collection_traversal;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
/**
     目标：Collection集合的遍历方式。

     什么是遍历? 为什么开发中要遍历？
     遍历就是一个一个的把容器中的元素访问一遍。
     开发中经常要统计元素的总和，找最值，找出某个数据然后干掉等等业务都需要遍历。

     Collection集合的遍历方式是全部集合都可以直接使用的，所以我们学习它。
     Collection集合的遍历方式有三种:
         （1）迭代器。
         （2）foreach(增强for循环)。
         （3）JDK 1.8开始之后的新技术Lambda表达式。

     b.foreach(增强for循环)遍历集合。
         foreach是一种遍历形式，可以遍历集合或者数组。
         foreach遍历集合实际上是迭代器遍历集合的简化写法。
         foreach遍历的关键是记住格式：
            for(被遍历集合或者数组中元素的类型 变量名称 : 被遍历集合或者数组){

            }
 */
public class CollectionDemo02 {
    public static void main(String[] args) {
        Collection<String> lists = new ArrayList<>();
        lists.add("赵敏");
        lists.add("小昭");
        lists.add("殷素素");
        lists.add("周芷若");
        System.out.println(lists);
        // [赵敏, 小昭, 殷素素, 周芷若]
        //  ele

        for (String ele : lists) {
            System.out.println(ele);
        }

        System.out.println("------------------");
        double[] scores = {100, 99.5 , 59.5};
        for (double score : scores) {
            System.out.println(score);
//            if(score == 59.5){
//                score = 100.0; // 修改无意义，不会影响数组的元素值。
//            }
        }
        System.out.println(Arrays.toString(scores));

    }
}
