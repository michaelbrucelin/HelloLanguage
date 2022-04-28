package com.itheima.day17_stream_exception_log_app.d2_stream;

public class Topperformer {
    private String name;
    private double money; // 月薪

    public Topperformer() {
    }

    public Topperformer(String name, double money) {
        this.name = name;
        this.money = money;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getMoney() {
        return money;
    }

    public void setMoney(double money) {
        this.money = money;
    }

    @Override
    public String toString() {
        return "Topperformer{" +
                "name='" + name + '\'' +
                ", money=" + money +
                '}';
    }
}
