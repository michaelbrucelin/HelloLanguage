package tabbedPane;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates the tabbed pane component organizer.
 */
public class TabbedPaneTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new TabbedPaneFrame();
            frame.setTitle("TabbedPaneTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}
