package com.itheima.day13_oop_app3.d9_api_object;

/**
    目标：掌握Object类中toString方法的使用。
 */
public class Test1 {
    public static void main(String[] args) {
        Student s = new Student("周雄", '男', 19);
        // String rs = s.toString();
        // System.out.println(rs);

        // System.out.println(s.toString());

        // 直接输出对象变量，默认可以省略toString调用不写的
        System.out.println(s);
    }
}
