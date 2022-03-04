package webstart;

import java.awt.*;
import javax.swing.*;

/**
 * A calculator with a calculation history that can be deployed as a Java Web
 * Start application.
 */
public class Calculator {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            CalculatorFrame frame = new CalculatorFrame();
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}