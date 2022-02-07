import java.net.*;
import java.io.*;

public class Get {
    public static void main(String[] args) throws Exception {
        URL baidu = new URL("http://www.baidu.com/");
        URLConnection yc = baidu.openConnection();
        BufferedReader in = new BufferedReader(new InputStreamReader(yc.getInputStream()));

        String inputLine;
        while ((inputLine = in.readLine()) != null)
            System.out.println(inputLine);

        in.close();
    }
}

// https://docs.oracle.com/javase/tutorial/networking/urls/readingWriting.html
