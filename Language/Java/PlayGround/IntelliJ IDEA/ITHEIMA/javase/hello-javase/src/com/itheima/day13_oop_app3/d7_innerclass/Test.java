package com.itheima.day13_oop_app3.d7_innerclass;

/**
    目标：了解局部内部类的语法
 */
public class Test {

    static {
         class Dog{

         }

         abstract class Animal{

         }

         interface SportManInter{

         }
    }

    public static void main(String[] args) {
        class Cat{
            private String name;

            public static int onLineNumber = 100;

            public String getName() {
                return name;
            }

            public void setName(String name) {
                this.name = name;
            }
        }

        interface SportManInter{

        }

        Cat c = new Cat();
        c.setName("叮当猫~");
        System.out.println(c.getName());
    }
}
