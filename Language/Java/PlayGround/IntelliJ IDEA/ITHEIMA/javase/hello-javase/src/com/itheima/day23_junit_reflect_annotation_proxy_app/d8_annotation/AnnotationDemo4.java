package com.itheima.day23_junit_reflect_annotation_proxy_app.d8_annotation;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

public class AnnotationDemo4 {
    public void test1(){
        System.out.println("===test1===");
    }

    @MyTest
    public void test2(){
        System.out.println("===test2===");
    }

    @MyTest
    public void test3(){
        System.out.println("===test3===");
    }

    /**
      启动菜单：有注解的才被调用。
     */
    public static void main(String[] args) throws Exception {
        AnnotationDemo4 t = new AnnotationDemo4();
        // a.获取类对象
        Class c = AnnotationDemo4.class;
        // b.提取全部方法
        Method[] methods = c.getDeclaredMethods();
        // c.遍历方法，看是否有MyTest注解，有就跑它
        for (Method method : methods) {
            if(method.isAnnotationPresent(MyTest.class)){
                // 跑它
                method.invoke(t);
            }
        }
    }
}
