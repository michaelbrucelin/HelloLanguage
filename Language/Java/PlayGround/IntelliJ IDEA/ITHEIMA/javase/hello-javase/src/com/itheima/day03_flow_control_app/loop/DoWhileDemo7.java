package com.itheima.day03_flow_control_app.loop;

public class DoWhileDemo7 {
    public static void main(String[] args) {
        // 目标：学会使用dowhile循环，并理解其执行流程
        int i = 0;
        do {
            System.out.println("Hello World");
            i++;
        }while (i < 3);

        System.out.println("--------------------");
        for (int j = 0; j < 3; j++) {
            System.out.println("Hello World");
        }
        for (int j = 0; j < 3; j++) {
            System.out.println("Hello World");
        }

        int n = 0;
        while (n < 3){
            System.out.println("Hello World");
            n++;
        }
        System.out.println(n);
    }
}
