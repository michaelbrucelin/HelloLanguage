package renderQuality;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates the effect of the various rendering hints.
 */
public class RenderQualityTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new RenderQualityTestFrame();
            frame.setTitle("RenderQualityTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}