package Codes;

import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.DatagramPacket;
import java.net.HttpURLConnection;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.URL;
import java.net.UnknownHostException;
import java.net.DatagramSocket;
import java.util.Arrays;
import java.util.Date;
import java.util.Vector;
import java.util.zip.GZIPInputStream;
import java.util.zip.GZIPOutputStream;

import org.json.JSONException;
import org.json.JSONObject;

import com.sun.xml.internal.bind.v2.runtime.unmarshaller.XsiNilLoader.Array;

/**
 * 使用Sender类来代表客户端程序，
 * 
 * @author ccna_zhang
 * 
 */

public class Sender { // udp发送数据
    public static void main(String[] args) {
        try {
            // Socket socket = new Socket("192.168.102.11", 8080);
            Socket socket = new Socket("218.213.211.124", 49051);
            // 向服务器端发送数据
            OutputStream os = socket.getOutputStream();
            DataOutputStream bos = new DataOutputStream(os);
            JSONObject json1 = new JSONObject();

            // try {
            // json1.put("gatewayRoutingName","*_251*");
            // } catch (JSONException e1) {
            // // TODO Auto-generated catch block
            // e1.printStackTrace();
            // }
            ////
            bos.writeUTF(json1.toString());
            bos.flush();

            // 接收次数
            InputStream istime = socket.getInputStream();
            DataInputStream distime = new DataInputStream(istime);
            int times = Integer.parseInt(distime.readUTF());
            // 确认数据
            OutputStream osr = socket.getOutputStream();
            DataOutputStream bosr = new DataOutputStream(osr);
            bosr.writeUTF("共收times：" + times);

            byte[] bs = new byte[4096000];
            int size = 65535;
            for (int i = 0; i < times; i++) {
                // 接收服务器端数据
                // ServerSocket serverSocket = new ServerSocket(49051);
                // Socket socketme = serverSocket.accept();
                // byte[] bst=new byte[size];
                // InputStream is = socketme.getInputStream();
                // DataInputStream dis = new DataInputStream(is);
                //
                // int len=dis.read(bst);
                // System.out.println("收到压缩后长度："+len);
                // System.arraycopy(bst,0,bs,i*size,size);
                //
                // OutputStream ost = socketme.getOutputStream();
                // DataOutputStream bost = new DataOutputStream(ost);
                //
                // bost.writeUTF("当前" + "times："+i);
                // bost.flush();
                // try {
                // Thread.sleep(800);
                // } catch (InterruptedException e) {
                // // TODO Auto-generated catch block
                // e.printStackTrace();
                // }

                byte[] bst = new byte[size];
                InputStream is = socket.getInputStream();
                DataInputStream dis = new DataInputStream(is);

                int len = dis.read(bst);
                System.out.println("收到压缩后长度：" + len);
                System.arraycopy(bst, 0, bs, i * size, size);

                OutputStream ost = socket.getOutputStream();
                DataOutputStream bost = new DataOutputStream(ost);

                bost.writeUTF("当前" + "times：" + i);
                bost.flush();
                try {
                    Thread.sleep(512);
                } catch (InterruptedException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }

            byte[] bs1 = uncompress(bs);
            // System.out.println("收到压缩后长度："+len);
            System.out.println("接收数据：" + bs1.length);
            // System.out.println(len+"888"+ new String (bs1,"utf-8"));
        } catch (UnknownHostException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static byte[] uncompress(byte[] bytes) {
        if (bytes == null || bytes.length == 0) {
            return null;
        }
        System.out.println("接收数据：" + bytes.length);
        ByteArrayOutputStream out = new ByteArrayOutputStream();
        ByteArrayInputStream in = new ByteArrayInputStream(bytes);
        try {
            GZIPInputStream ungzip = new GZIPInputStream(in);
            byte[] buffer = new byte[256];
            int n;
            while ((n = ungzip.read(buffer)) >= 0) {
                out.write(buffer, 0, n);
            }
        } catch (IOException e) {
            // ApiLogger.error("gzip uncompress error.", e);
        }

        return out.toByteArray();
    }
}

// udp发送数据源码2 拆包
// public static void main(String[] args) {
//
// // SenderLog sl=new SenderLog();
// //
// // Thread dic = new Thread(sl);
// // dic.start();
// //
// long g = new Date().getTime();
// // for (int i = 0; i < 1000000; i++) {
//
// JSONObject json1 = new JSONObject();
//
//// try {
//// json1.put("gatewayRoutingName","*_852*");
//// } catch (JSONException e1) {
//// // TODO Auto-generated catch block
//// e1.printStackTrace();
//// }
// String msg = json1.toString();
// byte[] buf = msg.getBytes();
// try {
//
//// InetAddress address = InetAddress.getByName("192.168.102.11"); // 服务器地址
// InetAddress address = InetAddress.getByName("218.213.211.124");
// // // 服务器地址
// int port = 8080; // 服务器的端口号
// // 创建发送方的数据报信息
// DatagramPacket dataGramPacket = new DatagramPacket(buf, buf.length,
// address, port);
//
// DatagramSocket socket = new DatagramSocket(); // 创建套接字
// socket.send(dataGramPacket); // 通过套接字发送数据
// System.out.println("客户端发送的数据为:" + msg + " "
// + InetAddress.getLocalHost());
//
// //
// // try {
// // Thread.sleep(2);
// // } catch (InterruptedException e) {
// // // TODO Auto-generated catch block
// // e.printStackTrace();
// // }
// // // // 接收服务器反馈数据
//
// byte[] backbuf = new byte[4096];
// DatagramPacket backPacket = new DatagramPacket(backbuf,
// backbuf.length);
//
// socket.receive(backPacket);
// while (backPacket == null) {// 如果没收到数据包就继续下次搜索
// backbuf = new byte[4096];
// backPacket = new DatagramPacket(backbuf,
// backbuf.length);
// socket.receive(backPacket);
// }
// String [] t=new String(backbuf, "UTF-8").split(":");
// int times = Integer.parseInt(t[1].trim());
// System.out.println(times);
//
// //回复准备就绪
//
// String tt="times:"+(times+1);
// byte[] btimes=tt.getBytes();
// DatagramPacket sendPackett1 = new
// DatagramPacket(btimes,btimes.length,address, port);//发送接收次数
// System.out.println("发送次数："+(times));
// socket.send(sendPackett1);
//
//
//
//// int size= 61440;
//// int size=71680;//no
//// int size=51200;//ok
// int size=10240;
// byte[] backresult = new byte[30720000];
// try {
// Thread.sleep(100);
// } catch (InterruptedException e) {
// // TODO Auto-generated catch block
// e.printStackTrace();
// }
// for (int i = 0; i < times; i++) {
//
// byte[] back= new byte[size];
// DatagramPacket backP= new DatagramPacket(back,
// back.length);
// socket.receive(backP);
//// while (backP == null) {// 如果没收到数据包就继续下次搜索
//// back = new byte[size];
//// backPacket = new DatagramPacket(back,
//// back.length);
//// socket.receive(backPacket);
//// }
// System.arraycopy(back,0,backresult,i*size,size);
// try {
// Thread.sleep(100);
// } catch (InterruptedException e) {
// // TODO Auto-generated catch block
// e.printStackTrace();
// }
// String ms=""+i;
// System.out.println("接收数据：" + ms);
// buf = ms.getBytes();
// DatagramPacket data = new DatagramPacket(buf, buf.length,
// address, port);
// DatagramSocket so = new DatagramSocket(); // 创建套接字
// socket.send(dataGramPacket); // 通过套接字发送数据
// System.out.println("接收完成回复数据：" + ms);
//// try {
//// Thread.sleep(100);
//// } catch (InterruptedException e) {
//// // TODO Auto-generated catch block
//// e.printStackTrace();
//// }
// }
// // String backMsg = new String(backbuf, 0, backPacket.getLength());
// byte[] back = uncompress(backresult);
// String backMsg = new String(back, "UTF-8");
// System.out.println("接收数据：" + back.length);
// // System.out.println("服务器返回的数据为:" + backMsg);
//
// socket.close();
//
// // boolean b=true;
// // while(b){
// // byte[] backbuf = new byte[2048000];
// // DatagramPacket backPacket = new DatagramPacket(backbuf,
// // backbuf.length);
// //
// // socket.receive(backPacket);
// //
// // // String backMsg = new String(backbuf, 0,
// // backPacket.getLength());
// // byte[] back= uncompress(backbuf);
// // String backMsg=new String(back,"UTF-8");
// // System.out.println("接收数据："+back.length);
// // // System.out.println("服务器返回的数据为:" + backMsg);
// // b=false;
// // //
// // socket.close();
// // }
//
// } catch (UnknownHostException e) {
// e.printStackTrace();
// } catch (IOException e) {
// e.printStackTrace();
// }
// // }
// System.out.println("g" + " " + new Date().getTime());
// }
//
// public static byte[] uncompress(byte[] bytes) {
// if (bytes == null || bytes.length == 0) {
// return null;
// }
// System.out.println("接收数据：" + bytes.length);
// ByteArrayOutputStream out = new ByteArrayOutputStream();
// ByteArrayInputStream in = new ByteArrayInputStream(bytes);
// try {
// GZIPInputStream ungzip = new GZIPInputStream(in);
// byte[] buffer = new byte[256];
// int n;
// while ((n = ungzip.read(buffer)) >= 0) {
// out.write(buffer, 0, n);
// }
// } catch (IOException e) {
// // ApiLogger.error("gzip uncompress error.", e);
// }
//
// return out.toByteArray();
// }
// }
//
// class SenderLog implements Runnable {
// public void run() {
//
// while (true) {
// try {
// getlogfromInte();
// System.out.println("日志记录");
// Thread.sleep((int) (5000));
// } catch (InterruptedException e) {
// // TODO Auto-generated catch block
// e.printStackTrace();
// } catch (Exception e) {
// // TODO Auto-generated catch block
// e.printStackTrace();
// }
//
// System.gc();
// }
// }
//
// private void getlogfromInte() {
// byte[] backbuf = new byte[1024];
// try {
// InetAddress address = InetAddress.getLocalHost();
// int port = 8080;
//
// // 创建DatagramSocket对象
// DatagramSocket socket = new DatagramSocket(port, address);
// // ServerSocket ss= new ServerSocket(port);
// DatagramPacket backPacket = new DatagramPacket(backbuf,
// backbuf.length);
//
// socket.receive(backPacket);
//
// String backMsg = new String(backbuf, 0, backPacket.getLength());
// System.out.println("服务器返回的数据为:" + backMsg);
// socket.close();
// } catch (IOException e) {
// // TODO Auto-generated catch block
// e.printStackTrace();
// } // 接收返回数据
// }
// }

//
// //udp发送数据源码
// public class Sender { // udp发送数据
//
// public static void main(String[] args) {
//
// // SenderLog sl=new SenderLog();
// //
// // Thread dic = new Thread(sl);
// // dic.start();
// //
// long g = new Date().getTime();
// for (int i = 0; i < 1000000; i++) {
// String msg = "Hello,World," + "-----," + i;
// byte[] buf = msg.getBytes();
// try {
//
// InetAddress address = InetAddress.getByName("192.168.102.11"); // 服务器地址
// int port = 8080; // 服务器的端口号
// // 创建发送方的数据报信息
// DatagramPacket dataGramPacket = new DatagramPacket(buf,
// buf.length, address, port);
//
// DatagramSocket socket = new DatagramSocket(); // 创建套接字
// socket.send(dataGramPacket); // 通过套接字发送数据
// System.out.println("客户端发送的数据为:" + msg);
//
// try {
// Thread.sleep(2);
// } catch (InterruptedException e) {
// // TODO Auto-generated catch block
// e.printStackTrace();
// }
// // // 接收服务器反馈数据
// byte[] backbuf = new byte[1024];
// DatagramPacket backPacket = new DatagramPacket(backbuf,
// backbuf.length);
//
// socket.receive(backPacket);
//
// String backMsg = new String(backbuf, 0, backPacket.getLength());
// System.out.println("服务器返回的数据为:" + backMsg);
//
// //
// socket.close();
//
// } catch (UnknownHostException e) {
// e.printStackTrace();
// } catch (IOException e) {
// e.printStackTrace();
// }
// }
// System.out.println("g" + " " + new Date().getTime());
// }
// }
//
// class SenderLog implements Runnable {
// public void run() {
//
// while (true) {
// try {
// getlogfromInte();
// System.out.println("日志记录");
// Thread.sleep((int) (5000));
// } catch (InterruptedException e) {
// // TODO Auto-generated catch block
// e.printStackTrace();
// } catch (Exception e) {
// // TODO Auto-generated catch block
// e.printStackTrace();
// }
//
// System.gc();
// }
// }
//
// private void getlogfromInte() {
// byte[] backbuf = new byte[1024];
// try {
// InetAddress address = InetAddress.getLocalHost();
// int port = 8080;
//
// // 创建DatagramSocket对象
// DatagramSocket socket = new DatagramSocket(port, address);
// // ServerSocket ss= new ServerSocket(port);
// DatagramPacket backPacket = new DatagramPacket(backbuf,
// backbuf.length);
//
// socket.receive(backPacket);
//
// String backMsg = new String(backbuf, 0, backPacket.getLength());
// System.out.println("服务器返回的数据为:" + backMsg);
// socket.close();
// } catch (IOException e) {
// // TODO Auto-generated catch block
// e.printStackTrace();
// } // 接收返回数据
// }
// }
