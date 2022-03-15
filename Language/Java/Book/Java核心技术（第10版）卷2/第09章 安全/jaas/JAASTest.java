package jaas;

import java.awt.*;
import javax.swing.*;

/**
 * This program authenticates a user via a custom login and then looks up a
 * system property with the user's privileges.
 */
public class JAASTest {
   public static void main(final String[] args) {
      System.setSecurityManager(new SecurityManager());
      EventQueue.invokeLater(() -> {
         JFrame frame = new JAASFrame();
         frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
         frame.setTitle("JAASTest");
         frame.setVisible(true);
      });
   }
}
