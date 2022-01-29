import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.TimeUnit;

public class TestService {
    public static void main(String[] args) {
        while (true) {
            try {
                String date = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new Date());
                System.out.println("TestService at " + date);

                // Thread.sleep(1000 * 3); // 用这个也可以，网上推荐用下面的，没有研究具体细节，测试都可用
                TimeUnit.SECONDS.sleep(3);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}

/*
 * # javac TestService.java
 * # java TestService
 * TestService at 2022-01-29 01:00:06
 * TestService at 2022-01-29 01:00:09
 * TestService at 2022-01-29 01:00:12
 * TestService at 2022-01-29 01:00:15
 * TestService at 2022-01-29 01:00:18
 * TestService at 2022-01-29 01:00:21
 */