import java.io.*;
import java.net.*;
import java.util.zip.GZIPInputStream;

// 与Post2.java一样，只是支持了gzip请求并自动处理
// 增加了自动识别返回的数据是否是gzip压缩的，通过检查返回数据开头的“幻数”来识别
public class Post4 {
    public static void main(String[] args) throws Exception {
        String targetURL = "http://mlintest.test.test:8080/external/server/GetCurrentCall";
        String jsonData = "{}";

        String currentcall = executePost(targetURL, jsonData);
        System.out.println(currentcall.length());
        // System.out.println(currentcall);
    }

    public static String executePost(String targetURL, String jsonData) {
        HttpURLConnection connection = null;

        try {
            // Create connection
            URL url = new URL(targetURL);
            connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod("POST");
            connection.setRequestProperty("Content-Type", "text/html;charset=UTF-8"); // VOS3000要求的
            connection.setRequestProperty("Accept-Encoding", "gzip");

            connection.setUseCaches(false);
            connection.setDoOutput(true);

            // Send request
            DataOutputStream wr = new DataOutputStream(connection.getOutputStream());
            wr.writeBytes(jsonData);
            wr.close();

            // Get Response, 通过检查返回数据开头的“幻数”来识别是否是gzip压缩的
            InputStream is = DecompressStream(connection.getInputStream());
            try (BufferedReader rd = new BufferedReader(new InputStreamReader(is))) {
                StringBuilder response = new StringBuilder(); // or StringBuffer if Java version 5-
                String line;
                while ((line = rd.readLine()) != null) {
                    response.append(line);
                    response.append('\n');
                }
                // rd.close();

                return response.toString();
            }
        } catch (Exception e) {
            e.printStackTrace();

            return null;
        } finally {
            if (connection != null) {
                connection.disconnect();
            }
        }
    }

    // 通过检查返回数据开头的“幻数”来识别是否是gzip压缩的
    public static InputStream DecompressStream(InputStream input) throws Exception {
        PushbackInputStream pb = new PushbackInputStream(input, 2); // we need a pushbackstream to look ahead
        byte[] signature = new byte[2];
        int len = pb.read(signature); // read the signature
        pb.unread(signature, 0, len); // push back the signature to the stream
        if (signature[0] == (byte) 0x1f && signature[1] == (byte) 0x8b) // check if matches standard gzip magic number
            return new GZIPInputStream(pb);
        else
            return pb;
    }
}
