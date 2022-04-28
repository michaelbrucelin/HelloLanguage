package com.itheima.day13_oop_app3.d6_innerclass;

public class Test2 {
    public static void main(String[] args) {
        People.Heart heart = new People().new Heart();
        heart.show();
    }
}

class People{
    private int heartbeat = 150;

    /**
       成员内部类
     */
    public class Heart{
        private int heartbeat = 110;

        public void show(){
            int heartbeat = 78;
            System.out.println(heartbeat); // 78
            System.out.println(this.heartbeat); // 110
            System.out.println(People.this.heartbeat); // 150
        }
    }
}