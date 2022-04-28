package com.itheima.day12_oop_app2.d8_abstract_attention;

public abstract class Animal {
    private  String name;
    public Animal(){
    }
    public abstract void run();
    public abstract void run2();

    public void eat(){

    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
