package com.itheima.day18_movie_buy_app.bean;

import com.itheima.run.MovieSystem;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.Date;
import java.util.List;

public class Movie {
    private String name;
    private String actor;
    private double time;
    private double price;
    private int number; // 余票
    private Date startTime; // 放映时间

    public Movie() {
    }

    public Movie(String name, String actor, double time, double price, int number, Date startTime) {
        this.name = name;
        this.actor = actor;
        this.time = time;
        this.price = price;
        this.number = number;
        this.startTime = startTime;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getActor() {
        return actor;
    }

    public void setActor(String actor) {
        this.actor = actor;
    }

    public double getScore() {
        List<Double> scores = MovieSystem.MOVIES_SCORE.get(name);
        if(scores!=null && scores.size() > 0){
            double sum = 0;
            for (Double score : scores) {
                sum += score;
            }
            return BigDecimal.valueOf(sum).divide(BigDecimal.valueOf(scores.size()), 2 , RoundingMode.UP).doubleValue();
        }else {
            return 0;
        }
    }


    public double getTime() {
        return time;
    }

    public void setTime(double time) {
        this.time = time;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public int getNumber() {
        return number;
    }

    public void setNumber(int number) {
        this.number = number;
    }

    public Date getStartTime() {
        return startTime;
    }

    public void setStartTime(Date startTime) {
        this.startTime = startTime;
    }
}
