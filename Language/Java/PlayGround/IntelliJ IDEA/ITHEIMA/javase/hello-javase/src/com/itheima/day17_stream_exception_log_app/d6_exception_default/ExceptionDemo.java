package com.itheima.day17_stream_exception_log_app.d6_exception_default;
/**
     目标：异常的产生默认的处理过程解析。(自动处理的过程！)
    （1）默认会在出现异常的代码那里自动的创建一个异常对象：ArithmeticException。
    （2）异常会从方法中出现的点这里抛出给调用者，调用者最终抛出给JVM虚拟机。
    （3）虚拟机接收到异常对象后，先在控制台直接输出异常栈信息数据。
    （4）直接从当前执行的异常点干掉当前程序。
    （5）后续代码没有机会执行了，因为程序已经死亡。

    小结：
         异常一旦出现，会自动创建异常对象，最终抛出给虚拟机，虚拟机
         只要收到异常，就直接输出异常信息，干掉程序！！

         默认的异常处理机制并不好，一旦真的出现异常，程序立即死亡！
 */
public class ExceptionDemo {
    public static void main(String[] args) {
        System.out.println("程序开始。。。。。。。。。。");
        chu(10, 0);
        System.out.println("程序结束。。。。。。。。。。");
    }

    public static void chu(int a , int b){
        System.out.println(a);
        System.out.println(b);
        int c = a / b;
        System.out.println(c);
    }
}
















