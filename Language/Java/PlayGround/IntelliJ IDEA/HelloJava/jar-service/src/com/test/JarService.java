package com.test;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Random;

import static java.nio.file.StandardOpenOption.APPEND;

public class JarService {
    public static void main(String[] args) throws IOException {
        Random r = new Random();

        int i = 0;
        int j = r.nextInt(49) + 16;  // 16 - 64

        System.out.println("JarService will stop " + j + " seconds later.");

        while (i++ < j) {
            LocalDateTime instance = LocalDateTime.now();
            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
            Path path = Paths.get("/tmp/test.txt");
            String info = i + ".\t" + formatter.format(instance) + "\n";
            Files.write(path, info.getBytes(), APPEND);

            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        throw new IOException("test");  // 模拟程序崩溃
    }
}
