package com;



import java.net.ProxySelector;
import java.sql.*; 
import java.util.Vector;
public class MysqlJdbc { 

	 public static void insertbatchnew(Vector comlist, String column, String casTableName){
			
				StringBuilder stbd = new StringBuilder();
				String temp = "";
				 PreparedStatement stmt=null;
				  Connection connect =null;   
				int lastLength = comlist.size() - (comlist.size() / 200) * 200;
				int theStartPos = (comlist.size() / 200) * 200;
				// System.out.println(comlist.size()+""+lastLength+""+theStartPos);
				try {
					connect =  createconnectjdbc();   
					for (int j = 1; j <= comlist.size() - lastLength; j++) {
						stbd.append("  (" + comlist.elementAt(j - 1) + "),");
						if (j % 100 == 0) {
							System.out.println("start" + j);

							stmt = connect.prepareStatement(" into " + casTableName + "(" + column
									+ ") VALUES "+stbd.substring(0,stbd.length()-1));

							stmt.execute();
							
							// System.out.println("start"+stbd);
							stbd.setLength(0);
							stmt.close();

						}
					}

					for (int k = theStartPos; k < comlist.size(); k++) {

						temp = ("INSERT  into " + casTableName + "(" + column
								+ ") VALUES (" + comlist.elementAt(k) + ")");

						stmt = connect.prepareStatement(temp);
						stmt.execute();
						// System.out.println("start"+temp);
						stmt.close();// 每次执行后均关闭

					}

				} catch (SQLException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();

				} finally {
					if (stmt != null) {
						try {
							stmt.close();
						} catch (SQLException e) {
							e.printStackTrace();
						}
					}
					if (connect != null) {
						try {
							connect.close();
						} catch (SQLException e) {
							e.printStackTrace();

						}
					}
				}

			}

	  

  public static void insertbatch(String comd){
	  try { 
	  Connection connect =  createconnectjdbc();      
	  
      System.out.println("Success connect Mysql server!"); 
      Statement stmt = connect.createStatement(); 
      int rs = stmt.executeUpdate(comd); 
                                                              //user 为你表的名称 
     
        System.out.println(rs); 
       
	  }
    catch (Exception e) { 
      System.out.print("insert error!"); 
      e.printStackTrace(); 
    } 
  }
  
  public static void sel(){
	    try { 
	        Connection connect =  createconnectjdbc();
	         
	   
	        System.out.println("Success connect Mysql server!"); 
	        Statement stmt = connect.createStatement(); 
	        ResultSet rs = stmt.executeQuery("select * from udptest"); 
	                                                                //user 为你表的名称 
	        while (rs.next()) { 
	          System.out.println(rs.getString("info")); 
	        } 
	      } 
	      catch (Exception e) { 
	        System.out.print("get data error!"); 
	        e.printStackTrace(); 
	      } 
  }
		public static Connection createconnectjdbc() throws SQLException{
			ProxySelector.setDefault(null);
			Connection conn= null;		 
		
			try{		
				Class.forName("com.mysql.jdbc.Driver");
				conn = DriverManager.getConnection( 
				          "jdbc:mysql://127.0.0.1:3306/test","root","");   
				 //连接URL为   jdbc:mysql//服务器地址/数据库名  ，后面的2个参数分别是登陆用户名和密码 
								}catch (SQLException e) {		
				e.printStackTrace();	
				throw new SQLException("数据库连接失败");
			}	catch (ClassNotFoundException cnfex) {
				System.err.println("装载 JDBC 驱动程序失败。");
				cnfex.printStackTrace();
				System.exit(1); // terminate program
			}
			return conn;
		}
} 