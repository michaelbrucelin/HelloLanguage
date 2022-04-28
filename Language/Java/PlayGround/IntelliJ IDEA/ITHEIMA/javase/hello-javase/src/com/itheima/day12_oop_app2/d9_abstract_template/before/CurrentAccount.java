package com.itheima.day12_oop_app2.d9_abstract_template.before;

/**
  活期账户
 */
public class CurrentAccount {
    private String cardId;
    private double money;

    public CurrentAccount() {
    }

    public CurrentAccount(String cardId, double money) {
        this.cardId = cardId;
        this.money = money;
    }

    /**
     登录结算利息
     */
    public void handle(String loginName , String passWord ){
        // a.判断登录是否成功
        if("itheima".equals(loginName) && "123456".equals(passWord)){
            System.out.println("登录成功。。");
            // b.正式结算利息
            double result =  money * 0.0175; // 结算利息了
            // c.输出利息详情
            System.out.println("本账户利息是："+ result);
        }else{
            System.out.println("用户名或者密码错误了");
        }
    }


    public String getCardId() {
        return cardId;
    }

    public void setCardId(String cardId) {
        this.cardId = cardId;
    }

    public double getMoney() {
        return money;
    }

    public void setMoney(double money) {
        this.money = money;
    }
}
