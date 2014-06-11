//******************************************************
//*                                                    *
//*              CS302   Exercise 5.java               *
//*                                                    *
//*                  Do Not Modify                     *
//*                                                    *
//******************************************************
import javax.swing.*;

public class Exercise5 extends JApplet
{

   public Exercise5()
   {
      add(new TreeGUI(new MyBinarySearchTree<Integer>()));
   }

   public static void main(String[] args)
   {
      JFrame frame = new JFrame("Exercise5.java");
      JApplet applet = new Exercise5();
      frame.add(applet);
      frame.setSize(800, 450);
      frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
      frame.setLocationRelativeTo(null);
      frame.setVisible(true);
   }
}