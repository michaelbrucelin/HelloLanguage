package com.itheima.day11_oop_app1.d6_singleinstance;

/**
    目标：设计懒汉单例
 */
public class SingleInstance2 {
    /**
       2、定义一个静态的成员变量用于存储一个对象，一开始不要初始化对象，因为人家是懒汉
     */
    private static SingleInstance2 instance;

    /**
       1、私有构造器啊
     */
    private SingleInstance2(){
    }

    /**
      3、提供一个方法暴露，真正调用这个方法的时候才创建一个单例对象
     */
    public static SingleInstance2 getInstance(){
        if(instance == null){
            // 第一次来拿对象，为他做一个对象
            instance = new SingleInstance2();
        }
        return instance;
    }
}
