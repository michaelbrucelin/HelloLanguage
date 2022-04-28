package com.itheima.day18_movie_buy_app.bean;

import java.util.HashMap;
import java.util.Map;

/**
   客户角色
 */
public class Customer extends User{
    // 定义一个属性存储购买记录。
    private Map<String, Boolean> buyMovies = new HashMap<>();

    public Map<String, Boolean> getBuyMovies() {
        return buyMovies;
    }

    public void setBuyMovies(Map<String, Boolean> buyMovies) {
        this.buyMovies = buyMovies;
    }
}
