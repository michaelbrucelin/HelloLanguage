package com.itheima.day16_collection_map_app2.d2_params;

import java.util.Arrays;

/**
    目标：可变参数。

    可变参数用在形参中可以接收多个数据。
    可变参数的格式：数据类型...参数名称

    可变参数的作用：
         传输参数非常灵活，方便。
         可以不传输参数。
         可以传输一个参数。
         可以传输多个参数。
         可以传输一个数组。

     可变参数在方法内部本质上就是一个数组。
     可变参数的注意事项：
         1.一个形参列表中可变参数只能有一个！！
         2.可变参数必须放在形参列表的最后面！！
     小结：
        记住。
 */
public class MethodDemo {
    public static void main(String[] args) {

        sum(); // 1、不传参数
        sum(10); // 2、可以传输一个参数
        sum(10, 20, 30); // 3、可以传输多个参数
        sum(new int[]{10, 20, 30, 40, 50}); // 4、可以传输一个数组
    }

    /**
       注意：一个形参列表中只能有一个可变参数,可变参数必须放在形参列表的最后面
     * @param nums
     */
    public static void sum(  int...nums){
        // 注意：可变参数在方法内部其实就是一个数组。 nums
        System.out.println("元素个数：" + nums.length);
        System.out.println("元素内容：" + Arrays.toString(nums));
    }
}
