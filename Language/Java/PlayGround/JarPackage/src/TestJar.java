package JarPackage.src;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.TimeUnit;

public class TestJar {
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
 * # jar cmvf META-INF/MANIFEST.MF TestJar.jar src/TestJar.java
 * added manifest
 * adding: src/TestJar.java(in = 684) (out= 432)(deflated 36%)
 */
