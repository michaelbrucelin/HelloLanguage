package com.itheima.day03_flow_control_app.random;

import java.util.Random;
import java.util.Scanner;

public class RandomDemo2 {
    public static void main(String[] args) {
        // 1、随机一个幸运号码 1- 100之间  (0 - 99) + 1
        Random r = new Random();
        int luckNumber = r.nextInt(100) + 1;

        // 2、使用一个死循环让用户不断的去猜测，并给出提示
        Scanner sc = new Scanner(System.in);
        while (true) {
            // 让用户输入数据猜测
            System.out.println("请您输入猜测的数据（1-100）：");
            int guessNumber = sc.nextInt();

            // 3、判断这个猜测的号码与幸运号码的大小情况
            if(guessNumber > luckNumber){
                System.out.println("您猜测的数据过大~");
            }else if(guessNumber < luckNumber){
                System.out.println("您猜测的数据过小");
            }else {
                System.out.println("恭喜您，猜中了，可以去买单了~~~");
                break; // 直接跳出并结束当前死循环！！
            }
        }
    }
}
