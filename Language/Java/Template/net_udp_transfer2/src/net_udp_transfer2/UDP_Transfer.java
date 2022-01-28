package net_udp_transfer2;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.Arrays;

public class UDP_Transfer {
	public static void main(String[] args) throws IOException {
		System.out.println("udp transfer is start to listen.");
		
		// 创建UDP网络对象
		DatagramSocket ds = new DatagramSocket();

		while (true) {
			BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
			// System.out.print("Enter a string to send");
			String s = br.readLine();

			if (Arrays.asList("quit", "exit").contains(s.toLowerCase())) {
				break;
			} else {
				// 打包待发送的数据
				byte[] bys = s.getBytes();
				int len = bys.length;
				InetAddress address = InetAddress.getByName("127.0.0.1");
				int port = 12306;
				DatagramPacket dp = new DatagramPacket(bys, len, address, port);

				// 发送数据
				ds.send(dp);
			}
		}

		// 关闭
		ds.close();

		System.out.println("udp transfer is close.");
	}
}
