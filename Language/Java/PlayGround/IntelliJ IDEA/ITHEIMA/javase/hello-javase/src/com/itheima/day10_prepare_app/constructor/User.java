package com.itheima.day10_prepare_app.constructor;

public class User {
    private String name;
    private String loginName;
    private String passWord;
    private int age;

    // 构造器 ： 无参数构造器是默认存在的
    public User(){
        System.out.println("无参数构造器被触发执行~~~");
    }

    // 有参数构造器
    public User(String name, String loginName, String passWord, int age) {
        this.name = name;
        this.loginName = loginName;
        this.passWord = passWord;
        this.age = age;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getLoginName() {
        return loginName;
    }

    public void setLoginName(String loginName) {
        this.loginName = loginName;
    }

    public String getPassWord() {
        return passWord;
    }

    public void setPassWord(String passWord) {
        this.passWord = passWord;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }
}
