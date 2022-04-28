package com.itheima.day07_oop_app.demo;

import java.util.Scanner;

/**
    需求：模拟购物车的功能。
    1、定义一个商品类：Article(属性：名称、价格)
    2、定义一个数组容器存储商品对象的，代表购物车对象。
 */
public class Test {
    public static void main(String[] args) {
        // a、定义一个数组存储商品对象的，代表购物车对象。
        Article[] shopCar = new Article[10];

        // b、让用户选择功能
        while (true) {
            Scanner sc = new Scanner(System.in);
            System.out.println("添加商品：add");
            System.out.println("查看商品：query");
            System.out.println("修改数量：update");
            System.out.println("结算价格：pay");
            System.out.println("请您选择要操作的功能：");
            String command = sc.next();
            switch (command) {
                case "add":
                    // 把商品加入到购物车中去。
                    addArticle(shopCar);
                    break;
                case "query":
                    // 查看购物车中的商品信息
                    queryArticle(shopCar);
                    break;
                case "update":
                    updateArticle(shopCar);
                    break;
                case "pay":
                    calcPayMoney(shopCar);
                    break;
                default:
                    System.out.println("当前命令输入有误！");
            }
        }
    }

    private static void calcPayMoney(Article[] shopCar) {
        queryArticle(shopCar);
        // 准备一个double类型的变量统计总金额
        double money = 0;
        for (int i = 0; i < shopCar.length; i++) {
            Article a = shopCar[i];
            if(a != null){
                money += (a.price * a.buyNumber);
            }else {
                break;
            }
        }
        System.out.println("本次商品购买的总价为：" + money);
    }

    public static void updateArticle(Article[] shopCar) {
        Scanner sc = new Scanner(System.in);
        while (true) {
            System.out.println("请您输入要修改数量的商品名称：");
            String name = sc.next();
            Article a = getArticleByName(name , shopCar );
            if(a != null){
                System.out.println("请您输入修改后购买的数量：");
                int buyNumber = sc.nextInt();
                a.buyNumber = buyNumber;
                System.out.println("该商品的购买数量修改了！");
                break;
            }else {
                System.out.println("购物车中没有该商品信息");
            }
        }
    }

    public static Article getArticleByName(String name , Article[] shopCar){
        for (int i = 0; i < shopCar.length; i++) {
            Article a = shopCar[i];
            if(a != null && a.name.equals(name) ){
                return a;
            }
        }
        return null;
    }

    public static void queryArticle(Article[] shopCar) {
        System.out.println("商品名称\t商品价格\t商品的购买数量");
        // 展示购物车的商品信息
        for (int i = 0; i < shopCar.length; i++) {
            Article a = shopCar[i];
            if(a != null){
                System.out.println(a.name +"\t" + a.price + "\t" + a.buyNumber);
            }else {
                return;
            }
        }
    }

    public static void addArticle(Article[] shopCar) {
        Scanner sc = new Scanner(System.in);
        System.out.println("请您输入商品的名称：");
        String name = sc.next();
        System.out.println("请您输入商品的价格：");
        double price = sc.nextDouble();
        System.out.println("请您输入购买商品的数量：");
        int buyNumber = sc.nextInt();

        // 创建一个商品对象，封装这些数据
        Article a = new Article();
        a.name = name;
        a.price = price;
        a.buyNumber = buyNumber;

        // 遍历这个购物车数组对象，看哪个位置是null,如果是null ,把商品对象添加进去
        for (int i = 0; i < shopCar.length; i++) {
            if(shopCar[i] == null){
                shopCar[i] = a; // 把商品对象添加到这个位置了
                break;
            }
        }
        System.out.println("添加成功！");
    }
}
