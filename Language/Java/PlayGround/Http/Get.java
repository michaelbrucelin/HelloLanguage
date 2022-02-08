import java.net.*;
import java.io.*;

public class Get {
    public static void main(String[] args) throws Exception {
        URL url = new URL("http://www.baidu.com/");
        URLConnection connection = url.openConnection();
        BufferedReader reader = new BufferedReader(new InputStreamReader(connection.getInputStream()));

        String bufferLine;
        while ((bufferLine = reader.readLine()) != null)
            System.out.println(bufferLine);

        reader.close();
    }
}

// https://docs.oracle.com/javase/tutorial/networking/urls/readingWriting.html
