package serialTransfer;

import java.awt.*;
import javax.swing.*;

/**
 * This program demonstrates the transfer of serialized objects between virtual
 * machines.
 */
public class SerialTransferTest {
    public static void main(String[] args) {
        EventQueue.invokeLater(() -> {
            JFrame frame = new SerialTransferFrame();
            frame.setTitle("SerialTransferTest");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setVisible(true);
        });
    }
}