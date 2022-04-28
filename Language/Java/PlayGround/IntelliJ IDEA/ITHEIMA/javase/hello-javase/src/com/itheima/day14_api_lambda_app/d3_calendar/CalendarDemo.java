package com.itheima.day14_api_lambda_app.d3_calendar;

import javax.xml.crypto.Data;
import java.util.Calendar;
import java.util.Date;

/**
    目标：日历类Calendar的使用,可以得到更加丰富的信息。

    Calendar代表了系统此刻日期对应的日历对象。
    Calendar是一个抽象类，不能直接创建对象。
    Calendar日历类创建日历对象的语法：
        Calendar rightNow = Calendar.getInstance();
    Calendar的方法：
        1.public static Calendar getInstance(): 返回一个日历类的对象。
        2.public int get(int field)：取日期中的某个字段信息。
        3.public void set(int field,int value)：修改日历的某个字段信息。
        4.public void add(int field,int amount)：为某个字段增加/减少指定的值
        5.public final Date getTime(): 拿到此刻日期对象。
        6.public long getTimeInMillis(): 拿到此刻时间毫秒值
    小结：
        记住。
 */
public class CalendarDemo{
    public static void main(String[] args) {
        // 1、拿到系统此刻日历对象
        Calendar cal = Calendar.getInstance();
        System.out.println(cal);

        // 2、获取日历的信息:public int get(int field)：取日期中的某个字段信息。
        int year = cal.get(Calendar.YEAR);
        System.out.println(year);

        int mm = cal.get(Calendar.MONTH) + 1;
        System.out.println(mm);

        int days = cal.get(Calendar.DAY_OF_YEAR) ;
        System.out.println(days);

        // 3、public void set(int field,int value)：修改日历的某个字段信息。
        // cal.set(Calendar.HOUR , 12);
        // System.out.println(cal);

        // 4.public void add(int field,int amount)：为某个字段增加/减少指定的值
        // 请问64天后是什么时间
        cal.add(Calendar.DAY_OF_YEAR , 64);
        cal.add(Calendar.MINUTE , 59);

        //  5.public final Date getTime(): 拿到此刻日期对象。
        Date d = cal.getTime();
        System.out.println(d);

        //  6.public long getTimeInMillis(): 拿到此刻时间毫秒值
        long time = cal.getTimeInMillis();
        System.out.println(time);

    }
}
