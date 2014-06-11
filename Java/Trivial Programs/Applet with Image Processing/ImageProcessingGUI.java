//********************************************************************
//
//  CS302
//
//  ImageProcessingGUI.java
//
//********************************************************************

import java.awt.*;
import javax.swing.*;

public class ImageProcessingGUI
{
   //-----------------------------------------------------------------
   //  Creates and displays a frame containing a split pane. The
   //  user then selects an option from the list to be displayed.
   //-----------------------------------------------------------------
   public static void main (String[] args)
   {
      JFrame frame = new JFrame ("Image Processing");
      frame.setDefaultCloseOperation (JFrame.EXIT_ON_CLOSE);
      Dimension minimumSize = new Dimension(700, 500);
      frame.setMinimumSize(minimumSize);

      JLabel imageLabel = new JLabel();
      JPanel imagePanel = new JPanel();
      imagePanel.add (imageLabel);
      imagePanel.setBackground (Color.white);

      ImageListPanel imageList = new ImageListPanel (imageLabel);

      JSplitPane sp = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT,
                                     imageList, imagePanel);

      sp.setOneTouchExpandable (true);

      frame.getContentPane().add (sp);
      frame.pack();
      frame.setVisible(true);
   }
}
