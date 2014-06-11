//**********************************************************
//*                                                        *
//*                CS302 Exercise 6                        *
//*                                                        *
//*                 SpellCheck GUI                         *
//*                                                        *
//*                 Adrian Flannery                        *
//*                   adrianu2                             *
//*        Interface for a spell check program             *
//*                                                        *
//**********************************************************
import java.io.*;
import javax.swing.text.*;
import java.awt.*;
import javax.swing.*;
import java.util.*;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import java.awt.event.*;

public class Exercise6 extends JFrame implements DocumentListener
{

   private final int SIZE = 350029;   // hash table size - a prime number
                                      // delibertly small so there will be many collisions
   private String target = null;
   private HashTable ht = new HashTable(SIZE);
   private JScrollPane scrollpane;
   private JTextArea textArea;
   private JButton Add = new JButton("Add Word To Dictionary");


   public static void main(String args[])
   {

      SwingUtilities.invokeLater
      (new Runnable()
         {
            public void run()
            {
               new Exercise6();
            }
         }
      );
   }


   public Exercise6()
   {
      Scanner scanFile = null;
      int count = 0;

      initializeGUI();

      try
      {
         scanFile = new Scanner(new File("dictionary.txt"));
      }
      catch (Exception e)
      {
         System.out.println("*** Error: dictionary file not found");
      }

      // insert words from dictionary into hashtable
      while (scanFile.hasNextLine())
      {
         String word = scanFile.nextLine();
         ht.insert(word);
         count++;
      }

      System.out.println("*** " + count + " words placed in hash table");

      ht.writeTableToFile(0,249); // write the first 250 hash table entries to HashFile.txt
   }


   private void initializeGUI()
   {
      JFrame f = new JFrame("Adrian Flannery  Ex. 6");  // Place your name here

      JPanel panel = new JPanel();
      panel.add(Add);
      f.add(panel, BorderLayout.SOUTH);

      textArea = new JTextArea();
      textArea.getDocument().addDocumentListener(this);
      textArea.setLineWrap(true);
      textArea.setFont(new Font("Courier", Font.BOLD, 16));
      textArea.setWrapStyleWord(true);
      scrollpane = new JScrollPane(textArea);
      setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
      f.add(scrollpane , BorderLayout.CENTER);

      f.setSize(400, 300);
      f.setVisible(true);

      Add.addActionListener
      (new ActionListener()
         {
            public void actionPerformed(ActionEvent e)  // add new word to dictionary
            {
              String text = textArea.getText();
              String word = "";
              for(int i=0; i<text.length(); i++)      // finds words and adds them to the dictionary
              {
                if (text.charAt(i)==' ' && word.length()>0)
                {
                  ht.insert(word);               //inserts the word
                  word = "";
                }
                if (text.charAt(i)!=' ')
                  word += text.charAt(i);           // builds the word
              }                      
            }
         }
      );
   }

   
   // Listener methods needed for DocumentListener interface
   public void insertUpdate(DocumentEvent ev)
   {
      Result result;
      String text = null;
      int w = 0;
      int length = 0;
      int pos = ev.getOffset();
      

      if (ev.getLength() != 1)
         return;

      try
      {
         text = textArea.getText(0, pos + 1);   // pos + 1 is the length required
      }
      catch (BadLocationException e)
      {
         e.printStackTrace();
      }
       
      String word = "";
      for(int i=0; i<text.length(); i++)              // loops through string, builds words, and checks them against dictionary
      {
        if (text.charAt(i)==' ' && word.length()>0)        // checks the built word against the dictionary
        {
          System.out.println();
          result = ht.find(word.toLowerCase());
          if (result.getLocation()==-1)
          {
            System.out.println("*** " + word.toLowerCase() + " is NOT in the dictionary");
            SwingUtilities.invokeLater(new SpellCheckTask(i-word.length(), word.length()));      //highlights word not in dictionary
          }
          else
            System.out.println("*** " + word.toLowerCase() + " is in position " + result.getLocation());
          System.out.println("*** " + result.getHomeLocation() + " is the home address");
          System.out.println("*** " + result.getLocationsExamined() + " locations examined");
          word = "";
        }
        if (text.charAt(i)!=' ')            // builds words
          word += text.charAt(i);
      }
   }
   



   public void changedUpdate(DocumentEvent ev)  // needed for DocumentListener interface
   { }


   public void removeUpdate(DocumentEvent ev)   // needed for DocumentListener interface
   { }


   private class SpellCheckTask implements Runnable
   {
      private int position, length;

      SpellCheckTask(int position, int length)
      {
         this.position = position;
         this.length = length;
      }

      public void run()
      {
         textArea.select(position, position+length);
         textArea.setSelectionColor(Color.PINK);
      }
   }
}
