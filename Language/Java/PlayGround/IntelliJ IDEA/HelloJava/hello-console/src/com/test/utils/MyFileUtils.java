package com.test.utils;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.stream.Stream;

public class MyFileUtils {
    // Read file content into the string with - Files.lines(Path path, Charset cs)
    // Java8中只能一行一行的读取文件，不能一次性读取，如果是Java11可以使用Files.readString();
    public static String readFile(String filePath) {
        StringBuilder sb = new StringBuilder();

        try (Stream<String> stream = Files.lines(Paths.get(filePath), StandardCharsets.UTF_8)) {
            stream.forEach(s -> sb.append(s).append("\n"));
        } catch (IOException e) {
            e.printStackTrace();
        }

        return sb.toString();
    }
}
