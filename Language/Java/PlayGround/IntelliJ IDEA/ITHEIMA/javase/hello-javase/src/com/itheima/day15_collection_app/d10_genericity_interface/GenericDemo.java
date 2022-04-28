package com.itheima.day15_collection_app.d10_genericity_interface;

/**
    目标：泛型接口。

    什么是泛型接口？
        使用了泛型定义的接口就是泛型接口。
    泛型接口的格式：
        修饰符 interface 接口名称<泛型变量>{

        }

    需求: 教务系统，提供一个接口可约束一定要完成数据（学生，老师）的增删改查操作

    小结：
        泛型接口可以约束实现类，实现类可以在实现接口的时候传入自己操作的数据类型
        这样重写的方法都将是针对于该类型的操作。
 */
public class GenericDemo {
    public static void main(String[] args) {

    }
}
