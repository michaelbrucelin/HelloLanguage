package com.itheima.d13_logback;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class LogbackDemo {
    // 创建Logback日志对象
    public static final Logger LOGGER = LoggerFactory.getLogger(LogbackDemo.class);

    public static void main(String[] args) {
        try {
            LOGGER.debug("main方法开始执行~~");
            LOGGER.info("日志的第二行，即将开始做除法~~");
            int a = 10;
            int b = 0;
            LOGGER.trace("a=" + a);
            LOGGER.trace("b=" + b);
            System.out.println(a / b);
        } catch (Exception e) {
            e.printStackTrace();
            LOGGER.error("main方法执行出现异常，异常信息为：" + e.getMessage());
        }
    }
}
