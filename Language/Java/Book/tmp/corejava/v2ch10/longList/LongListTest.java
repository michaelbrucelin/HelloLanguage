package longList;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates a list that dynamically computes list entries.
 */
public class LongListTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new LongListFrame();
            frame.setTitle("LongListTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}
