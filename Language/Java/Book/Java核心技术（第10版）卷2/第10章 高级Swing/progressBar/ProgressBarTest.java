package progressBar;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates the use of a progress bar to monitor the progress
 * of a thread.
 */
public class ProgressBarTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new ProgressBarFrame();
            frame.setTitle("ProgressBarTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}
