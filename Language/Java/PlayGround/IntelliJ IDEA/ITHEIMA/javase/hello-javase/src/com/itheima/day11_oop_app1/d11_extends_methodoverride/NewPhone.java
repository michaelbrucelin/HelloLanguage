package com.itheima.day11_oop_app1.d11_extends_methodoverride;

public class NewPhone extends Phone{
    /**
      方法重写了
     */
    @Override
    public void call() {
        super.call();
        System.out.println("支持视频通话~~~");
    }

    /**
     方法重写了
     */
    @Override
    public void sendMessage() {
        super.sendMessage();
        System.out.println("支持发送图片和视频~~~");
    }
}
