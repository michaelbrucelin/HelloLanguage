import java.io.*;
import java.net.*;

public class Post {
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

            connection.setUseCaches(false);
            connection.setDoOutput(true);

            // Send request
            DataOutputStream wr = new DataOutputStream(connection.getOutputStream());
            wr.writeBytes(jsonData);
            wr.close();

            // Get Response
            InputStream is = connection.getInputStream();
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
}
