//******************************************************
//*                                                    *
//*              CS302   Exercise 5                    *
//*                                                    *
//*                  TreeGUI.java                      *
//*                                                    *
//*                Adrian Flannery                     *
//*                   adrianu2                         *
//*   Creates an interface for a binary tree program   *
//******************************************************
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.util.Random;

public class TreeGUI extends JPanel
{
   private MyBinarySearchTree<Integer> tree;
   private JTextField Key      = new JTextField("",3);
   private PaintTree paintTree = new PaintTree();

   //defines the buttons for the interface
   private JButton Insert      = new JButton("Insert");
   private JButton Siblings    = new JButton("Siblings");
   private JButton Leaves      = new JButton("Leaves");
   private JButton LessThan    = new JButton("Less Than");
   private JButton LeftNodes   = new JButton("Left Nodes");
   private JButton LevelOrder  = new JButton("Level Order");
   private JButton LVR         = new JButton("LVR");
   private JButton DeleteAll   = new JButton("Delete All");

   private String name = "CS302  Adrian Flannery  adrianu2", emptyTree = "The Tree Is Empty",
                  listMessage, text , action;
   private Integer[] keyArray;
   private Font  font1 = new Font("Courier", Font.BOLD, 14);
   private Font  font2 = new Font("Courier", Font.BOLD, 18);
   private Random generator = new Random();
   private int key, keyCount = 0;
   
   //boolean that will keep a value for whether an input is a nymber
   private boolean isNumber;


   public TreeGUI(MyBinarySearchTree<Integer> tree)
   {
      this.tree = tree;
      defineApp();
   }


   private void defineApp()
   {
      this.setLayout(new BorderLayout());
      add(paintTree, BorderLayout.CENTER);

      JPanel panel = new JPanel();

      //adds the buttons to the interface
      panel.add(new JLabel("Key: "));
      panel.add(Key);
      panel.add(Insert);
      panel.add(Siblings);
      panel.add(Leaves);
      panel.add(LessThan);
      panel.add(LeftNodes);
      panel.add(LevelOrder);
      panel.add(LVR);
      panel.add(DeleteAll);

      add(panel, BorderLayout.SOUTH);
      keyCount = 0;


      Insert.addActionListener
      (new ActionListener()
         {
            public void actionPerformed(ActionEvent e)
            {
               int tries = 0;
               keyArray = null;
               boolean inserted = false;
               action = "Insert";

               text = Key.getText();

               if (!text.equals(""))
               {
                  try
                  {
                     key = Integer.parseInt(text);

                     if (key < 0 || key > 99)
                        JOptionPane.showMessageDialog(null, "Key Must In Range 0 To 99");
                     else
                        if (tree.find(key) != null)
                        JOptionPane.showMessageDialog(null, key + "  Is Already In The Tree");
                     else
                     {
                        tree.insert(key);
                        if (tree.height() < 5)
                           keyCount++;
                        else
                        {
                           tree.remove(key);
                           JOptionPane.showMessageDialog(null, "Adding " + key + " Will Exceed Height " + tree.height() );
                        }
                     }
                  }
                  catch (Exception ex)
                  {
                     JOptionPane.showMessageDialog(null, text + " Is Not An Integer");
                  }
               }
               else
               {
                  while (tries < 500 && !inserted &&
                         keyCount <= Math.pow(2,tree.height()+1) - 1)
                  {
                      tries++;
                      key =  generator.nextInt(100);
                      if (tree.find(key) == null)
                      {
                         tree.insert(key);
                         if (tree.height() < 5)
                         {
                            keyCount++;
                            inserted = true;
                         }
                         else
                            tree.remove(key);
                      }
                  }

                  if (!inserted)
                     JOptionPane.showMessageDialog(null, "Cannot Insert");
               }


               Key.setText("");
               paintTree.repaint();
            }
         }
      );


      //checks to see if the Siblings button has been clicked and calls the method
      Siblings.addActionListener
      (new ActionListener()
         {
            public void actionPerformed(ActionEvent e)
            {
               keyArray = null;

               action = "Siblings";
               if (tree.isEmpty())
                  JOptionPane.showMessageDialog(null, emptyTree);
               else
               {
                  listMessage = "   Siblings";
                  keyArray = new Integer[keyCount];
                  tree.siblings(keyArray);
               }

               paintTree.repaint();
               
            }
         }
      );
  
      //checks to see if the Leaves button has been clicked and calls the method
      Leaves.addActionListener
      (new ActionListener()
         {
            public void actionPerformed(ActionEvent e)
            {
               keyArray = null;

               action = "Leaves";
               if (tree.isEmpty())
                  JOptionPane.showMessageDialog(null, emptyTree);
               else
               {
                  listMessage = "     Leaves";
                  keyArray = new Integer[keyCount];
                  tree.leaves(keyArray);
               }

               paintTree.repaint();
            }
         }
      );
  
      //checks to see if the LessThan button has been clicked and calls the method
      LessThan.addActionListener
      (new ActionListener()
         {
            public void actionPerformed(ActionEvent e)
            {
               isNumber = true;
               keyArray = null;
               text = Key.getText();
               action = "Less Than";
               
               
               if (tree.isEmpty())        //checks to see if there is a tree
               {
                  JOptionPane.showMessageDialog(null, emptyTree);
               }
               else
               {
                 if(text.equals(""))             //checks to see if there is an input
                 {
                   JOptionPane.showMessageDialog(null, "No Key Entered");
                 }
                 else
                 {
                   for (int i = 0; i < text.length(); i++) //checks to see if the number is negative
                   {
                     if (text.charAt(0)=='-')
                     {
                       if(i!=0 && !Character.isDigit(text.charAt(i)))
                       {
                         isNumber = false;
                       }
                     }
                     else 
                     { 
                       if(!Character.isDigit(text.charAt(i)))      //checks to see if the text is a number
                         isNumber = false;
                     }
                   }
                   if (!isNumber)    //gives error message if input is not a number
                   {
                     JOptionPane.showMessageDialog(null, text + " Is Not An Integer");
                   }
                   else
                   {
                     key = Integer.parseInt(text);
                     if (key<0 || key>99)            //checks if the number is in range
                     {
                       JOptionPane.showMessageDialog(null, "Key Must Be In Range 0 To 99");
                     }
                     else
                     {
                       listMessage = "  Less Than";
                       keyArray = new Integer[keyCount];
                       tree.lessThan(key, keyArray);
                     }
                   }
                 }
               }

               paintTree.repaint();
            }
         }
      );
  
      //checks to see if the LeftNodes button has been clicked and calls the method
      LeftNodes.addActionListener
      (new ActionListener()
         {
            public void actionPerformed(ActionEvent e)
            {
               keyArray = null;

               action = "Left Nodes";
               if (tree.isEmpty())
                  JOptionPane.showMessageDialog(null, emptyTree);
               else
               {
                  listMessage = " Left Nodes";
                  keyArray = new Integer[keyCount];
                  tree.leftNodes(keyArray);
               }

               paintTree.repaint();
            }
         }
      );
  
  
      //checks to see if the LevelOrder button has been clicked and calls the method
      LevelOrder.addActionListener
      (new ActionListener()
         {
            public void actionPerformed(ActionEvent e)
            {
               keyArray = null;

               action = "Level Order";
               if (tree.isEmpty())
                  JOptionPane.showMessageDialog(null, emptyTree);
               else
               {
                  listMessage = "Level Order";
                  keyArray = new Integer[keyCount];
                  tree.levelOrder(keyArray);
               }

               paintTree.repaint();
               
            }
         }
      );
      

      LVR.addActionListener
      (new ActionListener()
         {
            public void actionPerformed(ActionEvent e)
            {
               keyArray = null;

               action = "LVR";
               if (tree.isEmpty())
                  JOptionPane.showMessageDialog(null, emptyTree);
               else
               {
                  listMessage = "        LVR";
                  keyArray = new Integer[keyCount];
                  tree.lvr(keyArray);
               }

               paintTree.repaint();
            }
         }
      );


      DeleteAll.addActionListener
      (new ActionListener()
         {
            public void actionPerformed(ActionEvent e)
            {

               keyArray = null;
               action = "DeleteAll";

               if (tree.isEmpty( ))
                  JOptionPane.showMessageDialog(null, emptyTree);
               else
               {
                  tree.root = null;
                  keyCount = 0;
               }

               paintTree.repaint();
            }
         }
      );

   }


   class PaintTree extends JPanel
   {
      private int verticalDistance = 50;
      private int radius = 20;
      private int count = 0;

      protected void paintComponent(Graphics g)
      {
         super.paintComponent(g);

         g.setFont( font2 );
         g.drawString(name, 10,15);

         if (tree.getRoot() != null)
            displayTree(g, tree.getRoot(), getWidth() / 2, 30, getWidth() / 4);
         
         if (keyArray != null)  // display tree traversal
            displayKeyArray(g, keyArray);
      }


      private void displayTree(Graphics g, BinaryNode t,int x, int y, int horizontalDistance)
      {
         g.setFont( font1 );

         if (action.equals("Insert") && key == t.getElement())
         {
            g.setColor(Color.YELLOW);
            g.fillOval(x - radius, y - radius, 2 * radius, 2 * radius);
         }
         else
         {
            if (action.equals("Siblings"))   //colors the siblings nodes yellow
            {
               g.setColor(Color.YELLOW);
               for(int i=0; i < keyArray.length; i++)
               {
                 if(keyArray[i]==t.element)
                 {
                   g.fillOval(x - radius, y - radius, 2 * radius, 2 * radius);
                 }
               }
            }
            else
            {
              if (action.equals("Leaves"))   //colors the leaf nodes cyan
              {
                g.setColor(Color.CYAN);
                for(int i=0; i < keyArray.length; i++)
                {
                  if(keyArray[i]==t.element)
                  {
                    g.fillOval(x - radius, y - radius, 2 * radius, 2 * radius);
                  }
                }
              }
              else
              {
                if (action.equals("Less Than"))   //colors the less than nodes pink
                {
                  g.setColor(Color.PINK);
                  for(int i=0; i < keyArray.length; i++)
                  {
                    if(keyArray[i]==t.element)
                    {
                      g.fillOval(x - radius, y - radius, 2 * radius, 2 * radius);
                    }
                  }
                }
                else
                {
                  if (action.equals("Left Nodes"))   //colors the left nodes nodes green
                  {
                    g.setColor(Color.GREEN);
                    for(int i=0; i < keyArray.length; i++)
                    {
                      if(keyArray[i]==t.element)
                      {
                        g.fillOval(x - radius, y - radius, 2 * radius, 2 * radius);
                      }
                    }
                  }
                }
              }
            }
         }

         g.setColor(Color.BLACK);

         g.drawOval(x - radius, y - radius, 2 * radius, 2 * radius);
         g.drawString(t.getElement() + "", x - 7, y + 4);


         if (t.left != null)
         {
            connectLeftChild(g, x - horizontalDistance, y + verticalDistance, x, y);
            displayTree(g, t.left, x - horizontalDistance, y + verticalDistance, horizontalDistance / 2);
         }

         if (t.right != null)
         {
            connectRightChild(g, x + horizontalDistance, y + verticalDistance, x, y);
            displayTree(g, t.right, x + horizontalDistance, y + verticalDistance, horizontalDistance / 2);
         }
      }



      private void connectLeftChild(Graphics g,int xc, int yc, int xp, int yp)
      {
         int xcd, ycd,xpd,ypd;

         //use Pythagorean Theorem
         double h = Math.sqrt(Math.pow((xp - xc), 2) + Math.pow(verticalDistance, 2));

         xcd = (int)(xc + radius * (xp - xc) / h);
         ycd = (int)(yc - radius * verticalDistance / h);
         xpd = (int)(xp - radius * (xp - xc) / h);
         ypd = (int)(yp + radius * verticalDistance / h);
         g.drawLine(xcd, ycd, xpd, ypd);
      }


      private void connectRightChild(Graphics g,int xc, int yc, int xp, int yp)
      {
         int xcd, ycd,xpd,ypd;

         //use Pythagorean Theorem
         double h = Math.sqrt(Math.pow((xp - xc), 2) + Math.pow(verticalDistance, 2));

         xcd = (int)(xc - radius * (xc - xp) / h);
         ycd = (int)(yc - radius * verticalDistance / h);
         xpd = (int)(xp + radius * (xc - xp) / h);
         ypd = (int)(yp + radius * verticalDistance / h);

         g.drawLine(xcd, ycd, xpd, ypd);
      }


      private void displayKeyArray(Graphics g, Integer[] keyArray)
      {
         if (keyArray != null)
         {
            int x  = 40;
            int y  = 300;
            int count = 0;
            String space = "";

            g.setFont( font2 );

            g.drawString(listMessage + ": ", x, y);
            x = 210;

            for (int i = 0; i < keyArray.length && keyArray[i] != null; i++)
            {
               if (keyArray[i] < 10)  // adjust spacing for single digit key
                  space = " ";
               else
                  space = "";

               g.drawString(space + Integer.toString(keyArray[i]), x, y);
               x = x + 32;
               count++;

               if (count % 15 == 0) // check for row change
               {
                  x = 210;
                  y = y + 18;
                  count = 0;
               }
            }
            if (keyArray[0]==null)    //displays message if the array is empty
            {
              g.drawString("None Found", 210,300);
            }
         }
      }

//    may be needed by other actions
      private boolean arrayFind(Integer[] ar, Integer x)
      {
         for (int i = 0; i < ar.length && ar[i] != null; i++)
         {
            if (ar[i] != null)
               if ((ar[i].compareTo(x) == 0))
                   return true;
         }
          return false;
      }
   }

}