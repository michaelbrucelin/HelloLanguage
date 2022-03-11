package plaf;

import java.awt.*;
import javax.swing.*;

public class PlafTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new PlafFrame();
            frame.setTitle("PlafTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}