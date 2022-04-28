package com.itheima.day11_oop_app1.d8_extends_test;

/**
   角色类 父类
 */
public class Role {
    private String name;
    private int age;

    /**
        共同行为
     */
    public void queryCourse(){
        System.out.println(name + "开始查看课程信息~~");
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }
}
