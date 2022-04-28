package com.itheima.day11_oop_app1.d14_this;

public class Student {
    private String name;
    private String schoolName;

    public Student() {
    }

    public Student(String name) {
        // 借用兄弟构造器！
        this(name, "黑马培训中心");
    }


    public Student(String name, String schoolName) {
        this.name = name;
        this.schoolName = schoolName;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSchoolName() {
        return schoolName;
    }

    public void setSchoolName(String schoolName) {
        this.schoolName = schoolName;
    }
}
