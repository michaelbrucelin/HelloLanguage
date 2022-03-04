package systemInfo;

import java.io.*;
import java.util.*;

/**
 * This program prints out all system properties.
 */
public class SystemInfo {
    public static void main(String args[]) {
        try {
            Properties sysprops = System.getProperties();
            sysprops.store(System.out, "System Properties");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
