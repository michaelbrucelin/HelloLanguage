package main.java;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

/*
	https://www.fatalerrors.org/a/java-udp-receive-data-send-data.html
	The steps of sending data by UDP are as follows:
		1. Create a Socket object (datagram Socket) on the sender side
		2. Create data and package it
		3. Call the method of datagram socket object to send data
		4. Close the sender
	Look at the code demo:
*/
public class UDPTransfer {
	public static void main(String[] args) throws IOException {
		// Create a Socket object (datagram Socket) on the sender side
		DatagramSocket ds = new DatagramSocket();

		// Create data and package it
		// DatagramPacket(byte[] buf, int length, InetAddress address, int port)
		// Construct a packet and send the length packet to the specified port number on the specified host
		byte[] bys = "hello, udp".getBytes();
		int len = bys.length;
		InetAddress address = InetAddress.getByName("127.0.0.1");
		int port = 10086; // Port number
		DatagramPacket dp = new DatagramPacket(bys, len, address, port);

		// Call the method of datagram socket object to send data
		// Void send (datagram socket P) sends packets from this socket
		ds.send(dp);

		// Close the sender
		ds.close();

		System.out.println("done.");
	}
}
