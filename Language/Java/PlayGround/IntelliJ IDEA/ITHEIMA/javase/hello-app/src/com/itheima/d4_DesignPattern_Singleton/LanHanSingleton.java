package com.itheima.d4_DesignPattern_Singleton;

/**
 * 懒汉单例模式
 * 在真正需要用类的对象的时候，才去创建一个对象（延迟加载对象）
 */
// 1. 定义一个单例类
public class LanHanSingleton {
    // 2. 创建一个私有的静态的对象
    //        静态成员对象在类加载的时候就创建好了
    private static LanHanSingleton instance;  // null

    // 3. 创建一个私有的构造器
    private LanHanSingleton() {
    }

    // 4. 创建一个公共的静态的方法，返回一个对象
    public static LanHanSingleton getInstance() {
        // 初始化对象
        if (instance == null) {
            instance = new LanHanSingleton();
        }
        return instance;
    }
}