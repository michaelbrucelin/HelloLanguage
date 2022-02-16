package com.test.java;

import java.io.File;
import java.io.IOException;

import com.test.utils.MyFileUtils;
import com.test.utils.MyJacksonUtils;
import com.test.models.CurrentCall;

public class Main {
    public static void main(String[] args) throws IOException {
        // System.out.println("Hello World!");

        String filePath = new File("").getAbsolutePath();
        // System.out.println(filePath);
        String currentCallStr = MyFileUtils.readFile(filePath + "/hello-console/src/com/test/resources/currentcall567.json");
        System.out.println("=============================== 1 yes");

        CurrentCall currentCall = MyJacksonUtils.json2Bean(currentCallStr, CurrentCall.class);
        System.out.println("=============================== 2 yes");

        System.out.println(currentCall.infoCurrentCalls.size());
    }
}
