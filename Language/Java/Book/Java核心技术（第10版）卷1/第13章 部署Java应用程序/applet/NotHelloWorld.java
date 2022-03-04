package applet;

import java.awt.*;
import javax.swing.*;

public class NotHelloWorld extends JApplet {
    public void init() {
        EventQueue.invokeLater(() -> {
            JLabel label = new JLabel("Not a Hello, World applet",
                    SwingConstants.CENTER);
            add(label);
        });
    }
}