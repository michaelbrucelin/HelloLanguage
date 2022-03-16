package treeRender;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates cell rendering and listening to tree selection
 * events.
 */
public class ClassTree {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new ClassTreeFrame();
            frame.setTitle("ClassTree");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}
