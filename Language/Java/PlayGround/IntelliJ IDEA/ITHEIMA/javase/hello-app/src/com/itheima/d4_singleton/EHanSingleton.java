package com.itheima.d4_singleton;

/**
 * 饿汉单例模式
 * 在用类获取对象的时候，对象已经创建好了，就不需要再去创建了
 */
// 1. 定义一个单例类
public class EHanSingleton {
    // 2. 创建一个私有的静态的对象
    //        静态成员对象在类加载的时候就创建好了
    private static EHanSingleton instance = new EHanSingleton();

    // 3. 创建一个私有的构造器
    private EHanSingleton() {
    }

    // 4. 创建一个公共的静态的方法，返回一个对象
    public static EHanSingleton getInstance() {
        return instance;
    }
}