package com.itheima.day03_flow_control_app.loop;

public class WhileTest6 {
    public static void main(String[] args) {
        // 需求：珠穆朗峰高度是8848860 纸张厚度 0.1 折叠纸张直到不低于珠穆朗峰位置，求折叠几次
        // 1、定义变量记录山峰的高度 纸张的厚度
        double peakHeight = 8848860;
        double paperThickness = 0.1;

        // 3、定义一个变量用于记录纸张折叠的次数
        int count = 0;

        // 2、定义一个while循环控制纸张进行折叠
        while (paperThickness < peakHeight){
            // 让纸张的厚度多一倍
            paperThickness *= 2;
            count++;
        }
        System.out.println("折叠的次数：" + count);
        System.out.println("纸张的最终厚度：" + paperThickness);
    }
}
