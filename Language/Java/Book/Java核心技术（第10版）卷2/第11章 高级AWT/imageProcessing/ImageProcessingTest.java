package imageProcessing;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates various image processing operations.
 */
public class ImageProcessingTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new ImageProcessingFrame();
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}