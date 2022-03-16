package tableSelection;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates selection, addition, and removal of rows and
 * columns.
 */
public class TableSelectionTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new TableSelectionFrame();
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}