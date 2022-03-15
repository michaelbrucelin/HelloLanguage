package treeEdit;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates tree editing.
 */
public class TreeEditTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new TreeEditFrame();
            frame.setTitle("TreeEditTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}