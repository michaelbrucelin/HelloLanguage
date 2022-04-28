package com.itheima.day24_xml_app.d3_factory_pattern;

public class Mac extends Computer{
    @Override
    public void start() {
        System.out.println(getName() + "以非常优雅的方法启动了，展示了一个苹果logo");
    }
}
