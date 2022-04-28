package com.itheima.day13_oop_app3.d8_innerclass_anonymous;

/**
    目标：掌握匿名内部类的使用形式（语法）
 */
public class Test2 {
    public static void main(String[] args) {
        Swimming s = new Swimming() {
            @Override
            public void swim() {
                System.out.println("学生快乐的自由泳🏊‍");
            }
        };
        go(s);

        System.out.println("--------------");

        Swimming s1 = new Swimming() {
            @Override
            public void swim() {
                System.out.println("老师泳🏊的贼快~~~~~");
            }
        };
        go(s1);

        System.out.println("--------------");

        go(new Swimming() {
            @Override
            public void swim() {
                System.out.println("运动员🏊的贼快啊~~~~~");
            }
        });


    }

    /**
       学生 老师 运动员可以一起参加游泳比赛
     */
    public static void go(Swimming s){
        System.out.println("开始。。。");
        s.swim();
        System.out.println("结束。。。");
    }
}


interface Swimming{
    void swim();
}
