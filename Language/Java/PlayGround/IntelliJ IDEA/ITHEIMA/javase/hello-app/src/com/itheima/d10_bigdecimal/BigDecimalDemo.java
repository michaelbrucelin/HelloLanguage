package com.itheima.d10_bigdecimal;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.text.NumberFormat;

/**
 * 目标：BigDecimal大数据类。
 * <p>
 * 引入：
 * 浮点型运算的时候直接+  * / 可能会出现数据失真（精度问题）。
 * BigDecimal可以解决浮点型运算数据失真的问题。
 * <p>
 * BigDicimal类：
 * 包：java.math.
 * 创建对象的方式（最好的方式：）
 * public static BigDecimal valueOf(double val) :包装浮点数成为大数据对象。
 * 方法声明
 * public BigDecimal add(BigDecimal value)       加法运算
 * public BigDecimal subtract(BigDecimal value)  减法运算
 * public BigDecimal multiply(BigDecimal value)  乘法运算
 * public BigDecimal divide(BigDecimal value)    除法运算
 * public double doubleValue(): 把BigDecimal转换成double类型。
 */
public class BigDecimalDemo {
    public static void main(String[] args) {
        // 浮点型运算的时候直接+  * / 可能会出现数据失真（精度问题）。
        System.out.println(0.09 + 0.01);  // 0.09999999999999999
        System.out.println(1.0 - 0.32);   // 0.6799999999999999
        System.out.println(1.015 * 100);  // 101.49999999999999
        System.out.println(1.301 / 100);  // 0.013009999999999999

        System.out.println("-------------------------");
        double a = 0.1;
        double b = 0.2;
        double c = a + b;
        System.out.println(c);            // 0.30000000000000004
        System.out.println("--------------------------");
        // 包装浮点型数据成为大数据对象 BigDeciaml
        BigDecimal a1 = BigDecimal.valueOf(a);
        BigDecimal b1 = BigDecimal.valueOf(b);
        BigDecimal c1 = a1.add(b1);
        // BigDecimal c1 = a1.subtract(b1);
        // BigDecimal c1 = a1.multiply(b1);
        // BigDecimal c1 = a1.divide(b1);
        System.out.println(c1);          // 0.3

        // 目的：double
        double rs = c1.doubleValue();
        System.out.println(rs);          // 0.3

        // 注意事项：BigDecimal是一定要精度运算的
        BigDecimal a11 = BigDecimal.valueOf(10.0);
        BigDecimal b11 = BigDecimal.valueOf(3.0);
        /**
         参数一：除数 参数二：保留小数位数  参数三：舍入模式
         */
        BigDecimal c11 = a11.divide(b11, 2, RoundingMode.HALF_UP); // 3.3333333333
        System.out.println(c11);         // 3.33

        System.out.println("-------------------");
    }
}

