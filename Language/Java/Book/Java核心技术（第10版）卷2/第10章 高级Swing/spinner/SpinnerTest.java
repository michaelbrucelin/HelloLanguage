package spinner;

import java.awt.*;
import javax.swing.*;

/**
 * A program to test spinners.
 */
public class SpinnerTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new SpinnerFrame();
            frame.setTitle("SpinnerTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}
