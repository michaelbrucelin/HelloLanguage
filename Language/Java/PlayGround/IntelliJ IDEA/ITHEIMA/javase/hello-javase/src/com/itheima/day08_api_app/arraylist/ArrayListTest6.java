package com.itheima.day08_api_app.arraylist;

import java.util.ArrayList;
import java.util.Scanner;

/**
    案例：学生信息系统：展示数据，并按照学号完成搜索
     学生类信息（学号，姓名，性别，班级）
     测试数据：
     "20180302","叶孤城",23,"护理一班"
     "20180303","东方不败",23,"推拿二班"
     "20180304","西门吹雪",26,"中药学四班"
     "20180305","梅超风",26,"神经科2班"
 */
public class ArrayListTest6 {
    public static void main(String[] args) {
        // 1、定义一个学生类，后期用于创建对象封装学生数据
        // 2、定义一个集合对象用于装学生对象
        ArrayList<Student> students = new ArrayList<>();
        students.add(new Student("20180302","叶孤城",23,"护理一班"));
        students.add(new Student("20180303","东方不败",23,"推拿二班"));
        students.add(new Student( "20180304","西门吹雪",26,"中药学四班"));
        students.add(new Student( "20180305","梅超风",26,"神经科2班"));
        System.out.println("学号\t\t名称\t年龄\t\t班级");

        // 3、遍历集合中的每个学生对象并展示其数据
        for (int i = 0; i < students.size(); i++) {
            Student s = students.get(i);
            System.out.println(s.getStudyId() +"\t\t" + s.getName()+"\t\t"
                    + s.getAge() +"\t\t" + s.getClassName());
        }

        // 4、让用户不断的输入学号，可以搜索出该学生对象信息并展示出来（独立成方法）
        Scanner sc = new Scanner(System.in);
        while (true) {
            System.out.println("请您输入要查询的学生的学号：");
            String id = sc.next();
            Student s = getStudentByStudyId(students, id);
            // 判断学号是否存在
            if(s == null){
                System.out.println("查无此人！");
            }else {
                // 找到了该学生对象了，信息如下
                System.out.println(s.getStudyId() +"\t\t" + s.getName()+"\t\t"
                        + s.getAge() +"\t\t" + s.getClassName());
            }
        }
    }

    /**
      根据学号，去集合中找出学生对象并返回。
     * @param students
     * @param studyId
     * @return
     */
    public static Student getStudentByStudyId(ArrayList<Student> students, String studyId){
        for (int i = 0; i < students.size(); i++) {
            Student s = students.get(i);
            if(s.getStudyId().equals(studyId)){
                return s;
            }
        }
        return null; // 查无此学号！
    }
}






