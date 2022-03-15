package textChange;

import java.awt.*;
import javax.swing.*;

public class ChangeTrackingTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new ColorFrame();
            frame.setTitle("ChangeTrackingTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}