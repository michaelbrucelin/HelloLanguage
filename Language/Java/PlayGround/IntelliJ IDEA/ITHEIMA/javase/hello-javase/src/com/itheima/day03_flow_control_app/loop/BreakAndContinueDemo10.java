package com.itheima.day03_flow_control_app.loop;

public class BreakAndContinueDemo10 {
    public static void main(String[] args) {
        // 目标：理解break 和 continue的作用。
        // 场景：假如你又有老婆了，然后你犯错了，你老婆罚你做5天家务，每天都是洗碗。
        // 但是洗碗到第三天后心软了 原谅你了不用洗了
        for (int i = 0; i < 5; i++) {
            System.out.println("快乐的洗碗~~~~");
            if(i == 2) {
                break; // 跳出并结束当前循环的执行~~
            }
        }

        // continue 跳出当前循环的当次执行，进入循环的下一次
        // 场景：假如你又有老婆了，然后你犯错了，你老婆罚你做5天家务，
        // 每天都是洗碗。但是洗碗到第三天后心软了 原谅你了不用洗了 但是依然不解恨 继续洗第4天 5天
        for (int i = 1; i <= 5 ; i++) {
            if(i == 3){
                continue; // 立即跳出当次执行，进入循环的下一次！
            }
            System.out.println("洗碗：" + i);
        }
    }
}
