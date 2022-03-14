package com.itheima.d8_interface;

public interface SportManInter {
    /**
     * 1、JDK 8开始 ：默认方法(实例方法)
     * -- 必须default修饰，默认用public修饰
     * -- 默认方法，接口不能创建对象，这个方法只能过继给了实现类，由实现类的对象调用。
     */
    default void run() {
        go();
        System.out.println("跑的很快~~~");
    }

    /**
     * 2、静态方法
     * 必须使用static修饰，默认用public修饰
     * -- 接口的静态方法，必须接口名自己调用。
     */
    static void inAddr() {
        System.out.println("我们都在学习Java新增方法的语法，它是Java源码自己会用到的~~~");
    }

    /**
     * 3、私有方法（实例方法）
     * -- JDK 1.9开始才支持的。
     * -- 必须在接口内部才能被访问
     */
    private void go() {
        System.out.println("开始跑~~~");
    }

}
