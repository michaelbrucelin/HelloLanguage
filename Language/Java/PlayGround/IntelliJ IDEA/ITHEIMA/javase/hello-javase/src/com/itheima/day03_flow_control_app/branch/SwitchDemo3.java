package com.itheima.day03_flow_control_app.branch;

public class SwitchDemo3 {
    public static void main(String[] args) {
        // 目标：清楚switch的注意点。并在开发的时候注意。
        // 表达式类型只能是byte、short、int、char，JDK5开始支持枚举，JDK7开始支持String、不支持double、float、long。
        //double a = 0.1 + 0.2;
        //System.out.println(a);
        long lg = 20;
//      switch (lg){

//      }

        // case给出的值不允许重复，且只能是字面量，不能是变量。
        switch (3){
            case 31:
                break;
            case 3:
                break;
        }

        // 不要忘记写break，否则会出现穿透现象。
        String weekday = "周二";
        switch (weekday){
            case "周一":
                System.out.println("埋头苦干，解决bug ");
                break;
            case "周二":
                System.out.println("请求大牛程序员帮忙");
                //break;
            case "周三":
                System.out.println("今晚啤酒、龙虾、小烧烤");
                //break;
            case "周四":
                System.out.println("主动帮助新来的女程序解决bug");
                break;
            case "周五":
                System.out.println("今晚吃鸡");
                break;
            case "周六":
                System.out.println("与王婆介绍的小芳相亲");
                break;
            case "周日":
                System.out.println("郁郁寡欢、准备上班");
                break;
            default:
                System.out.println("数据有误！");
        }
    }
}
