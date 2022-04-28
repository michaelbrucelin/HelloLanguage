package com.itheima.day23_junit_reflect_annotation_proxy_app.d8_annotation;

/**
   目标：认识元注解
 */
//@MyTest // 只能注解方法和成员变量
public class AnnotationDemo2 {

    @MyTest
    private String name;

    @MyTest
    public void test(){

    }

    public static void main(String[] args) {

    }
}
