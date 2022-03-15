package progressMonitorInputStream;

import java.awt.*;
import javax.swing.*;

/**
 * A program to test a progress monitor input stream.
 */
public class ProgressMonitorInputStreamTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new TextFrame();
            frame.setTitle("ProgressMonitorInputStreamTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}