package com.itheima.day08_api_app.arraylist;

public class Student {
    private String studyId;
    private String name;
    private int age;
    private String className;

    public Student() {
    }

    public Student(String studyId, String name, int age, String className) {
        this.studyId = studyId;
        this.name = name;
        this.age = age;
        this.className = className;
    }

    public String getStudyId() {
        return studyId;
    }

    public void setStudyId(String studyId) {
        this.studyId = studyId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public String getClassName() {
        return className;
    }

    public void setClassName(String className) {
        this.className = className;
    }
}
