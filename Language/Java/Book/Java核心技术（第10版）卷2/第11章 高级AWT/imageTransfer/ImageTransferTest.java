package imageTransfer;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates the transfer of images between a Java application
 * and the system clipboard.
 */
public class ImageTransferTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new ImageTransferFrame();
            frame.setTitle("ImageTransferTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}
