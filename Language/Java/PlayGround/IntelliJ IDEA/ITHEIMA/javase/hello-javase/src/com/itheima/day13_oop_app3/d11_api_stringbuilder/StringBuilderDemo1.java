package com.itheima.day13_oop_app3.d11_api_stringbuilder;

/**
    目标：学会使用StringBuilder操作字符串,最终还需要知道它性能好的原因
 */
public class StringBuilderDemo1 {
    public static void main(String[] args) {
        StringBuilder sb = new StringBuilder(); // ""
        sb.append("a");
        sb.append("b");
        sb.append("c");
        sb.append(1);
        sb.append(false);
        sb.append(3.3);
        sb.append("abc");
        System.out.println(sb);

        StringBuilder sb1 = new StringBuilder();
        // 支持链式编程
        sb1.append("a").append("b").append("c").append("我爱你中国");
        System.out.println(sb1);

        // 反转
        sb1.reverse().append("110");
        System.out.println(sb1);

        System.out.println(sb1.length());

        // 注意：StringBuilder只是拼接字符串的手段：效率好。
        // 最终的目的还是要恢复成String类型。
        StringBuilder sb2 = new StringBuilder();
        sb2.append("123").append("456");
        // 恢复成String类型
        String rs = sb2.toString();
        check(rs);
    }

    public static void check(String data){
        System.out.println(data);
    }
}
