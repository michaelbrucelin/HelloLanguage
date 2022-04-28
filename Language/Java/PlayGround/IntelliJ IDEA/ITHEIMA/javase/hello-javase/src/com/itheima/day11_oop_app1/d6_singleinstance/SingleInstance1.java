package com.itheima.day11_oop_app1.d6_singleinstance;

/**
    目标：学会使用恶汉单例模式设计单例类
 */
public class SingleInstance1 {
    /**
       static修饰的成员变量，静态成员变量，加载一次，只有一份
     */
    // public static int onLineNumber = 21;
    public static SingleInstance1 instance = new SingleInstance1();

    /**
        1、必须私有构造器：私有构造器对外不能被访问。
     */
    private SingleInstance1(){
    }


}
