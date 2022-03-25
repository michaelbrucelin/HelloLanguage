package socket;

import java.io.*;
import java.net.*;
import java.util.*;

/**
 * 非书中的源码，个人测试的，测试代码有效，与下面的命令行结果一致
 * telnet horstmann.com 80
 * GET / HTTP/1.1
 * Host: horstmann.com // 两次换行
 */
public class SocketTest2 {
    public static void main(String[] args) throws IOException {
        try (Socket s = new Socket("horstmann.com", 80); Scanner in = new Scanner(s.getInputStream(), "UTF-8")) {
            PrintWriter out = new PrintWriter(s.getOutputStream(), true);
            out.println("GET / HTTP/1.1");
            out.println("Host: horstmann.com");
            out.println();

            while (in.hasNextLine()) {
                String line = in.nextLine();
                System.out.println(line);
            }
        }
    }
}
