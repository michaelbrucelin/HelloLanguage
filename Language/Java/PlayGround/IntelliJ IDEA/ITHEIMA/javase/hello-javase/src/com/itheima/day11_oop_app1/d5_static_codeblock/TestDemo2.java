package com.itheima.day11_oop_app1.d5_static_codeblock;

public class TestDemo2 {

    private String name;

    /**
       属于对象的，与对象一起加载，自动触发执行。
     */
    {
        System.out.println("==构造代码块被触发执行一次==");
        name = "张麻子";
    }

    public TestDemo2(){
        System.out.println("==构造器被触发执行==");
    }

    public static void main(String[] args) {
        // 目标：学习构造代码块的特点、基本作用
        TestDemo2 t = new TestDemo2();
        System.out.println(t.name);

        TestDemo2 t1 = new TestDemo2();
        System.out.println(t1.name);
    }

}
