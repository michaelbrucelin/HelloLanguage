package com.itheima.day24_xml_app.d4_decorator_pattern;

/**
  装饰模式

    定义父类：InputStream
    定义实现类：FileInputStream 继续父类 定义功能
    定义装饰实现类：BufferedInputStream 继承父类 定义功能 包装原始类，增强功能。
 */
public class DecoratorPattern {
    public static void main(String[] args) {
        InputStream is = new BufferedInputStream(new FileInputStream());
        System.out.println(is.read());
        System.out.println(is.read(new byte[3]));
    }
}






