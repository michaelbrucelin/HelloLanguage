package com.itheima.day10_prepare_app.javabean;

public class Test {
    public static void main(String[] args) {
        // 注册信息：用对象封装的
        User u1 = new User();
        u1.setName("黑马黎明");
        u1.setSalary(1000000);
        u1.setHeight(160);
        u1.setIntroduce("爱处不处~~~");
        System.out.println(u1.getName());
        System.out.println(u1.getSalary());
        System.out.println(u1.getHeight());
        System.out.println(u1.getIntroduce());

        User u2 = new User("黑马吴彦祖", 183.5, 10, "反正就是帅~~" );
        System.out.println(u2.getName());
        System.out.println(u2.getSalary());
        System.out.println(u2.getHeight());
        System.out.println(u2.getIntroduce());
    }
}
