package Codes;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketAddress;
import java.net.UnknownHostException;
import java.util.Vector;

import com.MysqlJdbc;
import com.TimeUtil;

/**
 * 服务器端程序
 * 
 * @author ccna_zhang
 * 
 */
public class UdpReceiver { // udp接受数据
    public static void main(String[] args) {
        DoInsert doin = new DoInsert();
        Thread a = new Thread(doin);
        a.start();

        try {
            // InetAddress address =InetAddress.getLocalHost();
            // InetAddress address = InetAddress.getByName("192.168.160.143");
            InetAddress address = InetAddress.getByName("172.16.1.29");
            int port = 8080;

            // 创建DatagramSocket对象
            DatagramSocket socket = new DatagramSocket(port, address);

            byte[] buf = new byte[1024]; // 定义byte数组
            DatagramPacket packet = new DatagramPacket(buf, buf.length); // 创建DatagramPacket对象

            System.out.println("准备开始接收发给" + address + "的数据");
            int i = 0;
            while (true) {
                socket.receive(packet); // 通过套接字接收数据
                if (packet == null) {
                    // 如果没收到数据包就继续下次搜索
                } else {
                    i++;
                    // System.out.println(i + "*****" +
                    // Messcollection.mess.size());
                    String getMsg = new String(buf, 0, packet.getLength(),
                            "UTF-8");
                    Messcollection.setmess(getMsg);
                    // System.out.println("接收到的客户端发送的数据为：" + "------" + getMsg);

                    // 回执
                    String[] msg = getMsg.split(",");
                    int length = msg.length;
                    String flown = "";
                    int k = 37;// 正常情况下 第36个元素是fo
                    if (msg[k].startsWith("\"MBX")) {
                        // 软交换前一个是flowno
                        flown = msg[k - 1];
                    } else {
                        k++;
                        while (k < length) {
                            // 软交换前一个是flowno
                            if (msg[k].startsWith("\"MBX")) {
                                flown = msg[k - 1];
                                break;
                            } else {
                                k++;
                            }
                        }
                    }
                    // 从服务器返回给客户端数据
                    InetAddress clientAddress = packet.getAddress(); //
                    // 获得客户端的IP地址
                    int clientPort = packet.getPort(); // 获得客户端的端口号
                    SocketAddress sendAddress = packet.getSocketAddress();
                    // String feedback = "Received" + "****" + getMsg;
                    String feedback = flown;

                    if (i % 10000 == 0) {
                        System.out.println("回复客户端：" + "*****" + clientAddress + "***" + feedback);
                    }
                    byte[] backbuf = feedback.getBytes();
                    DatagramPacket sendPacket = new DatagramPacket(backbuf, backbuf.length, sendAddress); // 封装返回给客户端的数据
                    socket.send(sendPacket); // 通过套接字反馈服务器数据
                }
            }

            // socket.close(); // 关闭套接字
        } catch (UnknownHostException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

class DoInsert implements Runnable {// 新的线程执行插入
    @Override
    public void run() {
        // TODO Auto-generated method stub
        int rowsbatch = 10000;
        String contestbatch = "";
        int batchi = 0;//
        int times = 0;// 一次插入的批次控制
        StringBuilder sbu = new StringBuilder();
        while (true) {
            int i = 0;
            if (Messcollection.mess.size() > rowsbatch) {
                // 存在一次插入的条数时，进行插入
                System.out.println(" 当前共有记录行数" + Messcollection.mess.size() + "***" + TimeUtil.getCurrTimeS());
                Vector vtemp = new Vector();
                for (i = 0; i < rowsbatch; i++) {
                    String element = Messcollection.mess.elementAt(i).toString();
                    vtemp.add(element);
                    // Messcollection.mess.remove(element);
                }
                System.out.println("要移动" + TimeUtil.getCurrTimeS());
                Messcollection.mess.removeAll(vtemp);
                System.out.println("移动结束" + TimeUtil.getCurrTimeS());
                // for(int k=0;k<rowsbatch;k++){
                // String element = vtemp.elementAt(k)
                // .toString();
                // String detail = element.replace("'", "''").replace("\"",
                // "'").replace(",,",
                // ",'',").replace(",,",
                // ",'',");
                // contestbatch = contestbatch + "," + "(" + detail + ")";
                // }

                for (int k = 0; k < rowsbatch; k++) {
                    String element = vtemp.elementAt(k).toString();
                    String detail = element.replace("'", "''")
                            .replace("\"", "'").replace(",,", ",'',")
                            .replace(",,", ",'',");
                    // if(detail.indexOf("C03A")>0){
                    // System.out.println(" 当前数据为："+detail);
                    // }
                    sbu.append("," + "(" + detail + ")");
                }
                // sbu.toString();
                times++;
                System.out.println(" 处理完毕还剩" + Messcollection.mess.size() + "***" + TimeUtil.getCurrTimeS());
                System.out.println(" 收集数据 共" + i + "行 " + " times:" + times);
                // for循环结束 表明凑够了固定条数，开启插入工具
            }
            if (times == 3) {
                // 凑够 n 轮插入一次
                System.out.println("开始插入" + batchi++ + "批" + "***" + TimeUtil.getCurrTimeS());
                MysqlJdbc.insertbatch(
                        "insert into udptest(callere164,calleraccesse164, calleee164,calleeaccesse164,callerip, "
                                + " callergatewayid, callerproductid,callertogatewaye164, 	callertype, calleeip,calleegatewayid, "
                                + "calleeproductid,   calleetogatewaye164, calleetype,  	billingmode,  calllevel,  	agentfeetime,starttime, 	"
                                + "stoptime,callerpdd,	calleepdd,	holdtime, 	callerareacode, feetime,fee,   suitefee, "
                                + " suitefeetime,        incomefee,           customeraccount,     customername,   calleeareacode,      agentfee,   "
                                + "agentsuitefee,       agentsuitefeetime,   agentaccount,        agentname,   flowno,  "
                                + "       softswitchname,      softswitchcallid,    callercallid,  calleecallid,  enddirection,   "
                                + "     endreason,   calleebilling,       cdrlevel,  agentcdr_id) values "
                                // +
                                // "
                                // ('Q0002CS100319607819993','9607819993','S0099966507944325','9001966507944325','198.154.109.36','CS10031_ZX','VOS3000
                                // V2.1.3.2','9607819993',1,'213.230.188.1','ZX-00-05343_966ALL_DZS0099','','966507944325',1,1,5,0,1469683084946,1469683084946,10000,1988,0,'',0,0.0,0.0,0,0.0,'CS10031_ZX','Shaun
                                // Telecom
                                // Limited','',0.0,0.0,0,'P00-05343','Telenor',5166923438,'MBX5000_5:6288012166477876591,MBX5000_3:6288012081595114378',"
                                // +
                                // "-1,'290fbb5963616c6c00b951c9@198.154.109.36','239b99a3b63616c6c074856bb@172.16.1.8',0,-7,0,0,-1)");

                                // + contestbatch.substring(1)); // 1 表示去掉开头多于的逗号
                                + sbu.toString().substring(1)); // 1 表示去掉开头多于的逗号
                System.out.println(" 插入完成" + "***" + TimeUtil.getCurrTimeS());
                times = 0;
                // contestbatch = "";
                sbu.delete(0, sbu.length());
                try {
                    Thread.sleep(2000);//
                } catch (InterruptedException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            } else {
                // 没做插入 只是简单收集 间歇5秒 ，如果有插入动作，则间歇减小 变为2秒
                try {
                    Thread.sleep(5000);//
                } catch (InterruptedException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }
        }
    }
}

class Messcollection {// 收集cdr 作为公共数据区域
    static Vector mess = new Vector(10000, 2000);

    public static void setmess(String messe) {
        mess.add(messe);
    }
}