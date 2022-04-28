package com.itheima.day19_file_io_app.d2_recusion;

/**
      目标 猴子吃桃。

     公式（合理的）： f(x) - f(x)/2 - 1 = f(x+1)
                   2f(x) - f(x) - 2 = 2f(x + 1)
                   f(x) = 2f(x + 1) + 2

    求f(1) = ?
    终结点： f（10） = 1
    递归的方向：合理的
 */
public class RecursionDemo04 {
    public static void main(String[] args) {
        System.out.println(f(1));
        System.out.println(f(2));
        System.out.println(f(3));
    }

    public static int f(int n){
        if(n == 10){
            return 1;
        }else {
            return 2 * f(n + 1) + 2;
        }
    }
}












