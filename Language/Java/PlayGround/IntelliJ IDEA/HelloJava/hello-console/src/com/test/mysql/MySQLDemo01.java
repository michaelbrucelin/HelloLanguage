package com.test.mysql;

import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;

public class MySQLDemo01 {
    public static void main(String[] args) throws Exception {
        GetDataFromMySQL();
    }

    private static void GetDataFromMySQL() throws Exception {
        ArrayList<MyDataModel> list = new ArrayList();

        try (Connection conn = getConnection()) {
            try (Statement stat = conn.createStatement()) {
                String sql = "select id, callere164, calleee164, starttime, stoptime from e_cdr_20220518_ALL limit 10";

                try (ResultSet rs = stat.executeQuery(sql)) {
                    while (rs.next()) {
                        list.add(new MyDataModel(rs.getInt(1), rs.getString(2), rs.getString(3), rs.getLong(4), rs.getLong(5)));
                    }
                }
            }
        }

        if (list.size() > 0) {
            for (MyDataModel data : list) {
                data.Print();
            }
        }
    }

    private static Connection getConnection() throws Exception {
        Class.forName("com.mysql.jdbc.Driver");             // 注册JDBC驱动
        String url = "jdbc:mysql://192.168.1.140:3306/vos5000cdr";
        String username = "deve01";
        String password = "rfXMm39l#zKHYyS@9laVr0>ga9+veSHf75fhZ";

        return DriverManager.getConnection(url, username, password);  // 打开一个连接
    }
}

class MyDataModel {
    public MyDataModel(int id, String callere164, String calleee164, long starttime, long stoptime) {
        this.id = id;
        this.callere164 = callere164;
        this.calleee164 = calleee164;
        this.starttime = starttime;
        this.stoptime = stoptime;
    }

    public void Print() {
        System.out.println("id: " + id + "\tcallere164: " + callere164 + "\tcalleee164: " + calleee164 + "\tstarttime: " + starttime + "\tstoptime: " + stoptime);
    }

    private int id;
    private String callere164;
    private String calleee164;
    private long starttime;
    private long stoptime;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getCallerE164() {
        return callere164;
    }

    public void setCallerE164(String callere164) {
        this.callere164 = callere164;
    }

    public String getCalleeE164() {
        return calleee164;
    }

    public void setCalleeE164(String calleee164) {
        this.calleee164 = calleee164;
    }

    public long getStarttime() {
        return starttime;
    }

    public void setStarttime(long starttime) {
        this.starttime = starttime;
    }

    public long getStoptime() {
        return stoptime;
    }

    public void setStoptime(long stoptime) {
        this.stoptime = stoptime;
    }
}
