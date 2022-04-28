package com.itheima.day06_practice_app;

import java.util.Random;
import java.util.Scanner;

/**
    需求：一个大V直播抽奖，奖品是现金红包，分别有{2, 588 , 888, 1000, 10000}五个奖金。
    请使用代码模拟抽奖，打印出每个奖项，奖项的出现顺序要随机且不重复。打印效果如下：（随机顺序，不一定是下面的顺序）
 */
public class Test7 {
    public static void main(String[] args) {
        // 1、定义一个数组存储可以抽奖的金额 总数
        int[] money = {2, 588, 888, 1000, 10000};

        // 2、定义一个数组用于存储已经被抽中的奖金金额。
        int[] lockMoney = new int[money.length];

        // 3、开始模拟抽奖逻辑
        Scanner sc = new Scanner(System.in);
        Random r = new Random();
        for (int i = 0; i < money.length; i++) {
            // 分别代表抽奖一次。
            System.out.println("您要开始打开红包吗，您可以输入任意内容进行抽奖：");
            sc.next(); // 目的是为了让程序在这里等一下，直到用户按了数据和回车就下来抽奖一次！

            while (true) {
                // 4、开始抽奖了，随机一个索引取提取金额
                int index = r.nextInt(money.length);
                int currentMoney = money[index];

                boolean flag = true; // 代表默认没有被抽过

                // 5、判断这个红包金额之前是否有人抽中过！
                for (int j = 0; j < lockMoney.length; j++) {
                    if(lockMoney[j] == currentMoney){
                        // 说明这个金额已经被抽过了！
                        flag = false; // 表示已经被抽走了
                        break;
                    }
                }

                if(flag){
                    System.out.println("您当前很幸运，抽中了：" + currentMoney);
                    // 必须把这个金额放到被抽中的数组中去
                    lockMoney[i] = currentMoney;
                    break; // 当次抽象已经结束！
                }
            }
        }
    }
}
