package com.itheima.day06_practice_app;

import java.util.Random;

/**
      需求：定义方法实现随机产生一个5位的验证码，每位可能是数字、大写字母、小写字母。
 */
public class Test3 {
    public static void main(String[] args) {
        // 4、调用获取验证码的方法得到一个随机的验证码
        String code = createCode(8);
        System.out.println("随机验证码：" + code);
    }

    /**
       1、定义一个方法返回一个随机验证码：是否需要返回值类型申明？String  是否需要申明形参：int n
     */
    public static String createCode(int n){
        // 3、定义一个字符串变量记录生成的随机字符
        String code = "";
        Random r = new Random();
        // 2、定义一个for循环，循环n次，依次生成随机字符
        for (int i = 0; i < n; i++) {
            // i = 0 1 2 3 4
            // 3、生成一个随机字符：英文大写 小写 数字 (0 1 2)
            int type = r.nextInt(3); // 0  1  2
            switch (type){
                case 0:
                    // 大写字符（A 65 - Z 65+25）  (0 - 25) + 65
                    char ch = (char) (r.nextInt(26) + 65);
                    code += ch;
                    break;
                case 1:
                    // 小写字符（a 97 - z 97+25）  (0 - 25) + 97
                    char ch1 = (char) (r.nextInt(26) + 97);
                    code += ch1;
                    break;
                case 2:
                    // 数字字符
                    code += r.nextInt(10); // 0 - 9
                    break;
            }
        }
        return code;
    }
}
