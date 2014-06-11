//********************************************************************
//  Adrian Flannery    
//  NestedPanels.java  
//  Demonstrates a basic componenet hierarchy.
//********************************************************************

import java.awt.*;
import javax.swing.*;

public class NestedPanels
{
   //-----------------------------------------------------------------
   //  Presents two colored panels nested within a third.
   //-----------------------------------------------------------------
   public static void main (String[] args)
   {
      JFrame frame = new JFrame ("Nested Panels");
      frame.setDefaultCloseOperation (JFrame.EXIT_ON_CLOSE);

      // Set up My Panels
      JPanel myPanels = new JPanel();
      myPanels.setPreferredSize (new Dimension(320, 20));
      myPanels.setBackground (Color.blue);
      JLabel label0 = new JLabel ("My Panels");
      myPanels.add (label0);
      
      // Set up first subpanel
      JPanel subPanel1 = new JPanel();
      subPanel1.setPreferredSize (new Dimension(150, 100));
      subPanel1.setBackground (Color.green);
      JLabel label1 = new JLabel ("One");
      subPanel1.add (label1);

      // Set up second subpanel
      JPanel subPanel2 = new JPanel();
      subPanel2.setPreferredSize (new Dimension(150, 100));
      subPanel2.setBackground (Color.red);
      JLabel label2 = new JLabel ("Two");
      subPanel2.add (label2);
      
      // Set up third subpanel
      JPanel subPanel3 = new JPanel();
      subPanel3.setPreferredSize (new Dimension(300, 100));
      subPanel3.setBackground (Color.yellow);
      JLabel label3 = new JLabel ("Three");
      subPanel3.add (label3);

      // Set up primary panel
      JPanel primary = new JPanel();
      primary.setPreferredSize (new Dimension(320, 260));
      primary.setBackground (Color.blue);
      primary.add (myPanels);
      primary.add (subPanel1);
      primary.add (subPanel2);
      primary.add (subPanel3);

      frame.getContentPane().add(primary);
      frame.pack();
      frame.setVisible(true);
   }
}
