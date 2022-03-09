package com.itheima.d6_abstract;

/**
 * 抽象类只有签名（模板），没有具体实现
 */
public abstract class Animal {
    private String name;

    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public abstract void eat();

    public abstract void sleep();

    public void breathe() {
        System.out.println(getName() + "呼吸");
    }
}
