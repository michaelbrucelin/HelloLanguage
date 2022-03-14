package write;

import java.awt.*;
import javax.swing.*;

/**
 * This program shows how to write an XML file. It saves a file describing a
 * modern drawing in SVG format.
 */
public class XMLWriteTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new XMLWriteFrame();
            frame.setTitle("XMLWriteTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}