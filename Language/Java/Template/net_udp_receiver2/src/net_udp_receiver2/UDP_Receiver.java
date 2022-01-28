package net_udp_receiver2;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.Arrays;

public class UDP_Receiver {
	public static void main(String[] args) throws IOException {
		System.out.println("udp receiver is start to listen.");

		// 创建UDP网络对象
		InetAddress address = InetAddress.getByName("127.0.0.1");
		int port = 12306;
		DatagramSocket ds = new DatagramSocket(port, address);

		// 接收数据的缓冲池
		byte[] bys = new byte[1024];
		DatagramPacket dp = new DatagramPacket(bys, bys.length);

		while (true) {
			// 接收数据
			ds.receive(dp);

			// 处理接收来的数据
			byte datas[] = dp.getData();
			int len = dp.getLength();
			String dataString = new String(datas, 0, len);

			if (Arrays.asList("quit", "exit").contains(dataString.toLowerCase())) {
				break;
			} else {
				System.out.println(dataString);
			}
		}

		// 关闭
		ds.close();

		System.out.println("udp receiver is close.");
	}
}
