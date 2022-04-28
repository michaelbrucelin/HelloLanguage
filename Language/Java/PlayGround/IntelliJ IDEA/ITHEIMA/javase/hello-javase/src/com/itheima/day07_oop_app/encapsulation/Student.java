package com.itheima.day07_oop_app.encapsulation;

public class Student {
    // private私有的成员变量，只能在本类访问。
   private int age;

   public int getAge(){
       return age;
   }

   public void setAge(int age){
        if(age >= 0 && age <= 200){
            this.age = age;
        }else {
            System.out.println("年龄数据有问题，应该不是人的年龄！");
        }
   }
}
