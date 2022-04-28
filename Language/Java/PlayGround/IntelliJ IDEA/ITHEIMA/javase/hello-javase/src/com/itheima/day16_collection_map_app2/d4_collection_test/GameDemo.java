package com.itheima.day16_collection_map_app2.d4_collection_test;

import java.util.*;

/**
    目标：斗地主游戏的案例开发。

    业务需求分析:
        斗地主的做牌, 洗牌, 发牌, 排序（拓展知识）, 看牌。
        业务: 总共有54张牌。
        点数: "3","4","5","6","7","8","9","10","J","Q","K","A","2"
        花色: "♠", "♥", "♣", "♦"
        大小王: "👲" , "🃏"
        点数分别要组合4种花色，大小王各一张。
        斗地主：发出51张牌，剩下3张作为底牌。

    功能：
        1.做牌。
        2.洗牌。
        3.定义3个玩家
        4.发牌。
        5.排序（拓展，了解，作业）
        6.看牌
 */
public class GameDemo {
    /**
      1、定义一个静态的集合存储54张牌对象
     */
     public static List<Card> allCards = new ArrayList<>();

    /**
      2、做牌：定义静态代码块初始化牌数据
     */
    static {
        // 3、定义点数：个数确定，类型确定，使用数组
        String[] sizes = {"3","4","5","6","7","8","9","10","J","Q","K","A","2"};
        // 4、定义花色：个数确定，类型确定，使用数组
        String[] colors = {"♠", "♥", "♣", "♦"};
        // 5、组合点数和花色
        int index = 0; // 记录牌的大小
        for (String size : sizes) {
            index++;
            for (String color : colors) {
                // 6、封装成一个牌对象。
                Card c = new Card(size, color, index);
                // 7、存入到集合容器中去
                allCards.add(c);
            }
        }
        // 8 大小王存入到集合对象中去 "👲" , "🃏"
        Card c1 = new Card("" ,  "🃏", ++index);
        Card c2 = new Card("" ,  "👲",++index);
        Collections.addAll(allCards , c1 , c2);
        System.out.println("新牌：" + allCards);
    }

    public static void main(String[] args) {
        // 9、洗牌
        Collections.shuffle(allCards);
        System.out.println("洗牌后：" + allCards);

        // 10、发牌（定义三个玩家，每个玩家的牌也是一个集合容器）
        List<Card> linhuchong = new ArrayList<>();
        List<Card> jiumozhi = new ArrayList<>();
        List<Card> renyingying = new ArrayList<>();

        // 11、开始发牌（从牌集合中发出51张牌给三个玩家，剩余3张作为底牌）
        // allCards = [🃏, A♠, 5♥, 2♠, 2♣, Q♣, 👲, Q♠ ...
        //    i        0  1   2   3   4   5    6  7      %  3
        for (int i = 0; i < allCards.size() - 3; i++) {
            // 先拿到当前牌对象
            Card c = allCards.get(i);
            if(i % 3 == 0) {
                // 请阿冲接牌
                linhuchong.add(c);
            }else if(i % 3 == 1){
                // 请阿鸠
                jiumozhi.add(c);
            }else if(i % 3 == 2){
                // 请盈盈接牌
                renyingying.add(c);
            }
        }

        // 12、拿到最后三张底牌(把最后三张牌截取成一个子集合)
        List<Card> lastThreeCards = allCards.subList(allCards.size() - 3 , allCards.size());

        // 13、给玩家的牌排序（从大到小 可以自己先试试怎么实现）
        sortCards(linhuchong);
        sortCards(jiumozhi);
        sortCards(renyingying);

        // 14、输出玩家的牌：
        System.out.println("啊冲：" + linhuchong);
        System.out.println("啊鸠：" + jiumozhi);
        System.out.println("盈盈：" + renyingying);
        System.out.println("三张底牌：" + lastThreeCards);
    }

    /**
       给牌排序
     * @param cards
     */
    private static void sortCards(List<Card> cards) {
        // cards = [J♥, A♦, 3♥, 🃏, 5♦, Q♥, 2♥
        Collections.sort(cards, new Comparator<Card>() {
            @Override
            public int compare(Card o1, Card o2) {
                // o1 = J♥
                // o2 = A♦
                // 知道牌的大小，才可以指定规则
                return o2.getIndex() - o1.getIndex();
            }
        });
    }

}







