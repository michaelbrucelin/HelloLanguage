package com.itheima.day13_oop_app3.d4_polymorphic_test;

public class Computer {
    /**
       提供一个安装的入口：行为。
     */
    public void installUSB(USB u){
        u.connect();

        // 独有功能
        if(u instanceof Mouse){
            Mouse m = (Mouse) u;
            m.click();
        }else if(u instanceof KeyBoard) {
            KeyBoard k = (KeyBoard) u;
            k.keyDown();
        }

        u.unconnect();
    }
}
