package desktopApp;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates the desktop app API.
 */
public class DesktopAppTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new DesktopAppFrame();
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}