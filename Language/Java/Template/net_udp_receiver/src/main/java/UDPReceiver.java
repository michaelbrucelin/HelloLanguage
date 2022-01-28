package main.java;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

/*
	The steps of receiving data by UDP are as follows:
		1. Create a Socket object (datagram Socket) on the receiving end
		2. Create a packet to accept data
		3. Call the method of datagram socket object to receive data
		4. Close the sender
	Look directly at the code:
*/
public class UDPReceiver {
	public static void main(String[] args) throws IOException {
		// Create a Socket object (datagram Socket) on the receiving end
		// Datagram socket (int port) constructs a datagram socket and binds it to the specified port of the local host
		DatagramSocket ds = new DatagramSocket(10086);

		// Create a packet to accept data
		// Datagram packet (byte[] buf, int length) constructs a datagram packet to accept packets of length
		byte[] bys = new byte[1024];
		DatagramPacket dp = new DatagramPacket(bys, bys.length);

		// Call the method of datagram socket object to receive data
		ds.receive(dp);

		// Parse the packet and display the data on the console
		// byte[] getData() returns the data buffer
		byte datas[] = dp.getData();
		// int getlength() returns the length of the data to be sent or received
		int len = dp.getLength();
		String dataString = new String(datas, 0, len);
		System.out.println("The data are as follows: " + dataString);

		// Close the receiver
		ds.close();

		System.out.println("done.");
	}
}
