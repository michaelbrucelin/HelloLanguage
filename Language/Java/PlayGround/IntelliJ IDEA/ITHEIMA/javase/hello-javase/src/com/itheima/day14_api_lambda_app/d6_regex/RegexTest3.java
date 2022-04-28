package com.itheima.day14_api_lambda_app.d6_regex;

import java.util.Arrays;
import java.util.Scanner;

public class RegexTest3 {
    public static void main(String[] args) {
        // 目标：校验 手机号码 邮箱  电话号码
        // checkPhone();
        // checkEmail();
        // checkTel();

        // 同学可以完成校验金额是否格式金额： 99  0.5  99.5  019   | 0.3.3

        int[] arr = {10, 4, 5,3, 4,6,  2};
        System.out.println(Arrays.binarySearch(arr, 2));

    }

    public static void checkTel(){
        Scanner sc = new Scanner(System.in);
        while (true) {
            System.out.println("请您输入您的电话号码：");
            String tel = sc.next();
            // 判断邮箱格式是否正确   027-3572457  0273572457
            if(tel.matches("0\\d{2,6}-?\\d{5,20}")){
                System.out.println("格式正确，注册完成！");
                break;
            }else {
                System.out.println("格式有误！");
            }
        }
    }

    public static void checkEmail(){
        Scanner sc = new Scanner(System.in);
        while (true) {
            System.out.println("请您输入您的注册邮箱：");
            String email = sc.next();
            // 判断邮箱格式是否正确   3268847878@qq.com
            // 判断邮箱格式是否正确   3268847dsda878@163.com
            // 判断邮箱格式是否正确   3268847dsda878@pci.com.cn
            if(email.matches("\\w{1,30}@[a-zA-Z0-9]{2,20}(\\.[a-zA-Z0-9]{2,20}){1,2}")){
                System.out.println("邮箱格式正确，注册完成！");
                break;
            }else {
                System.out.println("格式有误！");
            }
        }
    }

    public static void checkPhone(){
        Scanner sc = new Scanner(System.in);
        while (true) {
            System.out.println("请您输入您的注册手机号码：");
            String phone = sc.next();
            // 判断手机号码的格式是否正确
            if(phone.matches("1[3-9]\\d{9}")){
                System.out.println("手机号码格式正确，注册完成！");
                break;
            }else {
                System.out.println("格式有误！");
            }
        }
    }
}
