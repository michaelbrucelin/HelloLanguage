import java.sql.*;
import java.util.ArrayList;

public class MySQLSelect {
    public static void main(String[] args) {
        ArrayList<DataModel> list = new ArrayList();

        try (Connection conn = getConnection()) {
            try (Statement stat = conn.createStatement()) {
                String sql = "select a.`name`, c.account, a.locktype\n"
                        + "from vos5000.e_gatewayrouting as a\n"
                        + "inner join vos5000.e_gatewayroutingsetting as b on b.gatewayrouting_id = a.id\n"
                        + "inner join vos5000.e_customer as c on c.id = a.clearingcustomer_id\n"
                        + "where a.`name` like 'P00%' and a.rtpforwardtype = 1";

                try (ResultSet rs = stat.executeQuery(sql)) {
                    while (rs.next()) {
                        list.add(new DataModel(rs.getString(1), rs.getString(2), rs.getInt(3)));
                    }
                }
            }
        } catch (SQLException e) {
            for (Throwable t : e)
                System.out.println(t.getMessage());
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        if (list.size() > 0) {
            for (DataModel data : list) {
                System.out.println(data.getName() + " " + data.getAccount() + " " + data.getLocktype());
            }
        } else {
            System.out.println("No data");
        }
    }

    // 驱动下载：https://www.mysql.com/products/connector/
    // mysql-connector-java-5.1.49-bin.jar
    public static Connection getConnection() throws Exception {
        Class.forName("com.mysql.jdbc.Driver");                       // 注册JDBC驱动
        String url = "jdbc:mysql://ip:port/database";
        String username = "account";
        String password = "password";

        return DriverManager.getConnection(url, username, password);  // 打开一个连接
    }
}

class DataModel {
    public DataModel(String name, String account, int locktype) {
        this.name = name;
        this.account = account;
        this.locktype = locktype;
    }

    String name;
    String account;
    int locktype;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAccount() {
        return account;
    }

    public void setAccount(String account) {
        this.account = account;
    }

    public int getLocktype() {
        return locktype;
    }

    public void setLocktype(int locktype) {
        this.locktype = locktype;
    }
}
