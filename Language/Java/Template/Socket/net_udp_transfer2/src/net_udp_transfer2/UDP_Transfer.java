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

		InetAddress address = InetAddress.getByName("127.0.0.1");
		int port = 12306;
		DatagramPacket dp = new DatagramPacket(new byte[] {}, 0, address, port);

		while (true) {
			BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
			// System.out.print("Enter a string to send");
			String s = br.readLine();

			// 打包待发送的数据
			byte[] bys = s.getBytes();
			// DatagramPacket dp = new DatagramPacket(bys, bys.length, address, port);
			dp.setData(bys);
			dp.setLength(bys.length);

			// 发送数据
			ds.send(dp);

			if (Arrays.asList("quit", "exit").contains(s.toLowerCase())) {
				break;
			}
		}

		// 关闭
		ds.close();

		System.out.println("udp transfer is close.");
	}
}
