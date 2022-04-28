package com.itheima.day04_array_app.demo;

public class Test7 {
    public static void main(String[] args) {
        //  1     1
        //  2     1
        //  3     2
        //  4     3
        //  5     5
        //  6     8
        //  ...
        //  ...
        //  ...
        //  20
        int[] numbers = new int[20];
        numbers[0] = 1;
        numbers[1] = 1;

        for (int i = 2; i < numbers.length; i++) {
            numbers[i] = numbers[i-1] + numbers[i-2];
        }

        for (int i = 0; i < numbers.length; i++) {
            System.out.println((i+1) +"月兔子数：" +  numbers[i]);
        }
    }
}
