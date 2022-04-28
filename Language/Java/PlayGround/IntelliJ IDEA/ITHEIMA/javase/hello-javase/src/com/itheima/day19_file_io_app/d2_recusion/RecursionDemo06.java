package com.itheima.day19_file_io_app.d2_recusion;

import java.io.File;
import java.io.IOException;
import java.util.Arrays;

/**
    目标：啤酒2元1瓶，4个盖子可以换一瓶，2个空瓶可以换一瓶，
        请问10元钱可以喝多少瓶酒，剩余多少空瓶和盖子。
        答案：15瓶 3盖子 1瓶子

 */
public class RecursionDemo06 {

    // 定义一个静态的成员变量用于存储可以买的酒数量
    public static int totalNumber; // 总数量
    public static int lastBottleNumber; // 记录每次剩余的瓶子个数
    public static int lastCoverNumber; // 记录每次剩余的盖子个数


    public static void main(String[] args) {
        // 1、拿钱买酒
        buy(10);
        System.out.println("总数：" + totalNumber);
        System.out.println("剩余盖子数：" + lastCoverNumber);
        System.out.println("剩余瓶子数：" + lastBottleNumber);
    }

    public static void buy(int money){
        // 2、看可以立马买多少瓶
        int buyNumber = money / 2; // 5
        totalNumber += buyNumber;

        // 3、把盖子 和瓶子换算成钱
        // 统计本轮总的盖子数  和 瓶子数
        int coverNumber = lastCoverNumber + buyNumber;
        int bottleNumber = lastBottleNumber + buyNumber;

        // 统计可以换算的钱
        int allMoney = 0;
        if(coverNumber >= 4){
            allMoney += (coverNumber / 4) * 2;
        }
        lastCoverNumber = coverNumber % 4;

        if(bottleNumber >= 2){
            allMoney += (bottleNumber / 2) * 2;
        }
        lastBottleNumber = bottleNumber % 2;

        if(allMoney >= 2){
            buy(allMoney);
        }

        Integer[] arr2 = new Integer[]{11, 22, 33};
        Arrays.sort(arr2);
    }
}
