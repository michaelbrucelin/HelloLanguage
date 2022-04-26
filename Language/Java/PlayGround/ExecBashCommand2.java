import java.io.BufferedReader;
import java.io.InputStreamReader;

public class ExecBashCommand2 {
    public static void main(String[] args) {
        // String command = "ls -l";
        String[] command = {
                "/bin/sh",
                "-c",
                "ls /etc | grep release"
        };

        try {
            Process process = Runtime.getRuntime().exec(command);
            BufferedReader reader = new BufferedReader(new InputStreamReader(process.getInputStream()));
            String line;
            while ((line = reader.readLine()) != null) {
                System.out.println(line);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}

/*
 * 如果命令中有管道，需要加工一下。
 */