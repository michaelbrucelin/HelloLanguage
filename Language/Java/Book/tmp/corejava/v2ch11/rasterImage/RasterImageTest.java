package rasterImage;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates how to build up an image from individual pixels.
 */
public class RasterImageTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new RasterImageFrame();
            frame.setTitle("RasterImageTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}