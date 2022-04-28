package com.itheima.day03_flow_control_app.loop;

public class BreakAndContinueDemo11 {
    public static void main(String[] args) {
        // 目标:理解break和continue操作外部循环。
        // 场景：假如你有老婆，你老婆罚你说3天，每天5句我爱你，但是说到第二天的第3句就心软了，以后都不用说了！
        OUT:
        for (int i = 1; i <= 3; i++) {
            for (int j = 1; j <= 5; j++) {
                System.out.println("我爱你~~");
                if(i == 2 && j == 3){
                    break OUT; // 指定跳出外部循环，并结束外部循环了！
                }
            }
            System.out.println("-----------------");
        }

        System.out.println("====================================================");
        // continue可以指定结束外部循环的当次执行，进入外部循环的下一次执行
        // 场景：假如你有老婆，你老婆罚你说3天，每天5句我爱你，但是说到第二天的第3句就心软了，当天
        // 不用说了，但是依然不解恨，第3天还是要说的。
        OUT:
        for (int i = 1; i <= 3; i++) {
            for (int j = 1; j <= 5; j++) {
                System.out.println("我爱你~~");
                if(i == 2 && j == 3){
                    continue OUT;
                }
            }
            System.out.println("-----------------");
        }
    }
}
