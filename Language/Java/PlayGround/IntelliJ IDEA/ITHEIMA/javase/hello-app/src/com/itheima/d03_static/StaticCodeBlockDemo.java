package com.itheima.d03_static;

public class StaticCodeBlockDemo {
    public static void main(String[] args) {
        // 静态代码块有static修饰，属于类，在类加载的时候执行，在构造器之前执行
        // 作用：初始化静态资源
        StaticCodeBlock o1 = new StaticCodeBlock();
    }
}
