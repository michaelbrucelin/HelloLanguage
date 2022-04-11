import java.io.BufferedReader;
import java.io.InputStreamReader;

public class ExecBashCommand {
    public static void main(String[] args) {
        String command = "ls -l";
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