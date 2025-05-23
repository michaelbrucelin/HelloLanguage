package dnd;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates the basic Swing support for drag and drop.
 */
public class SwingDnDTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new SwingDnDFrame();
            frame.setTitle("SwingDnDTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}