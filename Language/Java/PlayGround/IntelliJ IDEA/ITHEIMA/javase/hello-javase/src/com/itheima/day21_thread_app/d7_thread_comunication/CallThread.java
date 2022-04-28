package com.itheima.day21_thread_app.d7_thread_comunication;

public class CallThread extends Thread{
    @Override
    public void run() {
        // 不断的打入电话
        while (true){
            CallSystem.call();
        }
    }
}
