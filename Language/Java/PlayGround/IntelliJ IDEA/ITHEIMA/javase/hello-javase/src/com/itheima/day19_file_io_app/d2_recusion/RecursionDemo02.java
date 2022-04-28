package com.itheima.day19_file_io_app.d2_recusion;

/**
      目标：递归的算法和执行流程
 */
public class RecursionDemo02 {
    public static void main(String[] args) {
        System.out.println(f(5));
    }

    public static int f(int n){
        if(n == 1){
            return 1;
        }else {
            return f(n - 1) * n;
        }
    }
}












