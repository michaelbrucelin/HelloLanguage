package tree;

import java.awt.*;
import javax.swing.*;

/**
 * This program shows a simple tree.
 */
public class SimpleTree {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new SimpleTreeFrame();
            frame.setTitle("SimpleTree");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}
