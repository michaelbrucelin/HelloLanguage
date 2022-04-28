package com.itheima.day18_movie_buy_app.bean;

public class Business extends User{
    // 店铺名称
    private String shopName;
    // 店铺地址
    private String address;

    public String getShopName() {
        return shopName;
    }

    public void setShopName(String shopName) {
        this.shopName = shopName;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }
}
