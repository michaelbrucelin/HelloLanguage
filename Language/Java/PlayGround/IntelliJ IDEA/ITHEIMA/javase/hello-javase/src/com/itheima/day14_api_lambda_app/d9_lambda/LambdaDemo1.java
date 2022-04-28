package com.itheima.day14_api_lambda_app.d9_lambda;

public class LambdaDemo1 {
    public static void main(String[] args) {
        // 目标：学会使用Lambda的标准格式简化匿名内部类的代码形式
        Animal a = new Animal() {
            @Override
            public void run() {
                System.out.println("乌龟跑的很慢~~~~~");
            }
        };
        a.run();

        // 注意：lambda并不是可以简化所有匿名匿名内部类形式！！
//        Animal a1 = () -> {
//            System.out.println("乌龟跑的很慢~~~~~");
//        };
//        a1.run();
    }
}



abstract class Animal{
    public abstract void run();
}


