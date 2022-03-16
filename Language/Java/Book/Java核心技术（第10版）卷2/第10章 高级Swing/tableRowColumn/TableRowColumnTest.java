package tableRowColumn;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates how to work with rows and columns in a table.
 */
public class TableRowColumnTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new PlanetTableFrame();
            frame.setTitle("TableRowColumnTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}