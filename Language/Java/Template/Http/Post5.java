import java.io.*;
import java.net.*;
import java.util.zip.GZIPInputStream;

// 与Post2.java一样，只是支持了gzip请求并自动处理
// 增加了自动识别返回的数据是否是gzip压缩的，通过检查返回数据开头的“幻数”来识别
public class Post5 {
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
            InputStream is = isGzipStream(connection.getByteArrayInputStream())
                    ? new GZIPInputStream(connection.getInputStream())
                    : connection.getInputStream();
            BufferedReader rd = new BufferedReader(new InputStreamReader(is));
            StringBuilder response = new StringBuilder(); // or StringBuffer if Java version 5-
            String line;
            while ((line = rd.readLine()) != null) {
                response.append(line);
                response.append('\n');
            }
            rd.close();

            return response.toString();
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
    /*
     * Determines if a byte array is compressed. The java.util.zip GZip
     * implementation does not expose the GZip header so it is difficult to
     * determine if a string is compressed.
     * 
     * @param bytes an array of bytes
     * 
     * @return true if the array is compressed or false otherwise
     * 
     * @throws java.io.IOException if the byte array couldn't be read
     */
    public static boolean isGzipStream(byte[] bytes) {
        if ((bytes == null) || (bytes.length < 2)) {
            return false;
        } else {
            int head = ((int) bytes[0] & 0xff) | ((bytes[1] << 8) & 0xff00);
            return (GZIPInputStream.GZIP_MAGIC == head);
            // return ((bytes[0] == (byte) (GZIPInputStream.GZIP_MAGIC))
            // && (bytes[1] == (byte) (GZIPInputStream.GZIP_MAGIC >> 8)));
        }
    }
}
