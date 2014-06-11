/*********************************************************************
 * Adrian Flannery
 * adrianu2
 * CS-302
 * Programming Exercise 3
 * The program creates a panel for the interface with a menu
 ********************************************************************/

import java.awt.*;
import java.awt.image.*;
import java.io.*;
import javax.imageio.*;
import javax.swing.*;
import javax.swing.event.*;

public class ImageListPanel extends JPanel
{
   private BufferedImage img, newImg;
   private JLabel label;
   private JList list;

   //*****************************************************************
   //  Load the list of options into the list.
   //*****************************************************************
   public ImageListPanel (JLabel imageLabel)
   {
      label = imageLabel;

      String[] selectNames = { "Adrian Flannery",
                               "adrianu2",
                               " ",
                               "car.jpg",
                               "motorcycle.jpg",
                               "tiger.jpg",
                               "temple.jpg",
                               "painting.jpg",
                               "tree.jpg",
                               "airplane.bmp",
                               " ",
                               "clear red",
                               "primary colors",
                               "negative",
                               "grayscale",
                               "rotate 90",
                               "rotate 180",
                               "mirror",
                               "mirror vertical",
                               "mirror horizontal",
                               "reduce",
                             };

      list = new JList (selectNames);
      list.addListSelectionListener (new ListListener());
      list.setSelectionMode (ListSelectionModel.SINGLE_SELECTION);

      add (list);
      setBackground (Color.white);
      label.setFont (new Font ("Helvetica", Font.BOLD, 18));
   }

   //*****************************************************************
   //  Represents the listener for the options list.
   //*****************************************************************
   private class ListListener implements ListSelectionListener
   {
      public void valueChanged (ListSelectionEvent event)
      {
         if (list.isSelectionEmpty())
            label.setIcon (null);
         else
         {
            String option = (String)list.getSelectedValue();
            int len = option.length();
            String end = option.substring(len - 4,len);

            if ( end.equalsIgnoreCase(".jpg") ||
                 end.equalsIgnoreCase(".gif") ||
                 end.equalsIgnoreCase(".bmp")    )
            {
               try
               {
                  img = ImageIO.read(new File(option));
                  ImageIcon image = new ImageIcon (img);
                  label.setIcon (image);

               }
               catch (IOException e)
               {
                   System.out.println("\n\nError: " + option + " not found\n\n");
               }
            }
            else
            {
                if (option.equals("clear red"))
                   newImg = ImageProcessing.clearRed(img);
                if (option.equals("primary colors"))
                   newImg = ImageProcessing.primaryColors(img);
                if (option.equals("negative"))
                   newImg = ImageProcessing.negative(img);
                if (option.equals("grayscale"))
                   newImg = ImageProcessing.grayscale(img);
                if (option.equals("rotate 90"))
                   newImg = ImageProcessing.rotate90(img);
                if (option.equals("rotate 180"))
                   newImg = ImageProcessing.rotate180(img);
                if (option.equals("mirror"))
                   newImg = ImageProcessing.mirror(img);
                if (option.equals("mirror vertical"))
                   newImg = ImageProcessing.mirrorVertical(img);
                if (option.equals("mirror horizontal"))
                   newImg = ImageProcessing.mirrorHorizontal(img);
                if (option.equals("reduce"))
                   newImg = ImageProcessing.reduce(img);

                ImageIcon image = new ImageIcon (newImg);
                label.setIcon (image);
            }
         }
      }
   }
}
