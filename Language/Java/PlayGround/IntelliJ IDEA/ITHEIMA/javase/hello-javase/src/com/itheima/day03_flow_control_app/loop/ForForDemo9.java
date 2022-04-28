package com.itheima.day03_flow_control_app.loop;

public class ForForDemo9 {
    public static void main(String[] args) {
        // 目标：理解嵌套循环的执行流程
        // 场景：假如你有老婆，然后你犯错了，你老婆罚你说5天，每天3句我爱你。
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 3; j++) {
                System.out.println("我爱你");
            }
            System.out.println("--------------");
        }

        /**
            *****
            *****
            *****
            *****
         */
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 5; j++) {
                System.out.print("*");
            }
            System.out.println(); // 换行
        }
    }
}
