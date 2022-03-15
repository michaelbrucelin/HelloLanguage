package textFormat;

import java.awt.*;
import javax.swing.*;

/**
 * A program to test formatted text fields
 */
public class FormatTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new FormatTestFrame();
            frame.setTitle("FormatTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}
