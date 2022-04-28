package com.itheima.day21_thread_app.d2_api;
/**
    目标：线程的API
 */
public class ThreadDemo02 {
    // main方法是由主线程负责调度的
    public static void main(String[] args) throws Exception {
        for (int i = 1; i <= 5; i++) {
            System.out.println("输出：" + i);
            if(i == 3){
                // 让当前线程进入休眠状态
                // 段子：项目经理让我加上这行代码，如果用户愿意交钱，我就注释掉。
                Thread.sleep(3000);
            }
        }
    }
}










