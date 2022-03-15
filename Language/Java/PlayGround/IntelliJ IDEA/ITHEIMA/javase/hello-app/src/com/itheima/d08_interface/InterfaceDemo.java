package com.itheima.d08_interface;

public class InterfaceDemo {
    public static void main(String[] args) {
        PingPongMan p = new PingPongMan();
        p.run();

        SportManInter.inAddr();
        // PingPongMan.inAddr();
    }
}