package com.itheima.day17_stream_exception_log_app.d2_stream;
import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Stream;
public class StreamDemo04 {
    public static double allMoney ;
    public static double allMoney2 ; // 2个部门去掉最高工资，最低工资的总和
    public static void main(String[] args) {
        List<Employee> one = new ArrayList<>();
        one.add(new Employee("猪八戒",'男',30000 , 25000, null));
        one.add(new Employee("孙悟空",'男',25000 , 1000, "顶撞上司"));
        one.add(new Employee("沙僧",'男',20000 , 20000, null));
        one.add(new Employee("小白龙",'男',20000 , 25000, null));

        List<Employee> two = new ArrayList<>();
        two.add(new Employee("武松",'男',15000 , 9000, null));
        two.add(new Employee("李逵",'男',20000 , 10000, null));
        two.add(new Employee("西门庆",'男',50000 , 100000, "被打"));
        two.add(new Employee("潘金莲",'女',3500 , 1000, "被打"));
        two.add(new Employee("武大郎",'女',20000 , 0, "下毒"));

        // 1、开发一部的最高工资的员工。（API）
        // 指定大小规则了
//        Employee e = one.stream().max((e1, e2) -> Double.compare(e1.getSalary() + e1.getBonus(),  e2.getSalary() + e2.getBonus()))
//                .get();
//       System.out.println(e);
        Topperformer t = one.stream().max((e1, e2) -> Double.compare(e1.getSalary() + e1.getBonus(),  e2.getSalary() + e2.getBonus()))
                .map(e -> new Topperformer(e.getName(),  e.getSalary() + e.getBonus())).get();
        System.out.println(t);

        // 2、统计平均工资，去掉最高工资和最低工资
        one.stream().sorted((e1, e2) -> Double.compare(e1.getSalary() + e1.getBonus(),  e2.getSalary() + e2.getBonus()))
                .skip(1).limit(one.size() - 2).forEach(e -> {
                    // 求出总和：剩余员工的工资总和
            allMoney += (e.getSalary() + e.getBonus());
        });
        System.out.println("开发一部的平均工资是：" + allMoney / (one.size() - 2));

        // 3、合并2个集合流，再统计
        Stream<Employee> s1 = one.stream();
        Stream<Employee> s2 = two.stream();
        Stream<Employee> s3 = Stream.concat(s1 , s2);
        s3.sorted((e1, e2) -> Double.compare(e1.getSalary() + e1.getBonus(),  e2.getSalary() + e2.getBonus()))
                .skip(1).limit(one.size() + two.size() - 2).forEach(e -> {
            // 求出总和：剩余员工的工资总和
            allMoney2 += (e.getSalary() + e.getBonus());
        });

        // BigDecimal
        BigDecimal a = BigDecimal.valueOf(allMoney2);
        BigDecimal b = BigDecimal.valueOf(one.size()  + two.size() - 2);
        System.out.println("开发部的平均工资是：" + a.divide(b,2, RoundingMode.HALF_UP));
    }
}
