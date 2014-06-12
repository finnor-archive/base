import java.io.*;
import java.util.Arrays;
import javax.swing.*;
import java.awt.Container;


class AlphabetDriver 
{
 public static void main(String[] args)
 {
  //List output = new List();
  int numWords=0;
  String[] dictionary = null; 
  
  JFileChooser chooser = new JFileChooser();
  int returnVal = chooser.showOpenDialog(new Container());
  if(returnVal == JFileChooser.APPROVE_OPTION) 
  {
    System.out.println("You chose to open this file: " +
                       chooser.getSelectedFile().getName());
  }
  
  File file = chooser.getSelectedFile();
  try
     {
       BufferedReader in = new BufferedReader(new FileReader(file));
       
       while (in.readLine()!=null)
         numWords++;
       
       dictionary = new String[numWords];
       
       
       in = new BufferedReader(new FileReader(file));
       for (int i=0; i<numWords; i++)
         dictionary[i] = in.readLine();
       in.close(); 
  }
  catch(FileNotFoundException e)    
  {
    e.printStackTrace();
  } 
  catch (IOException e)
  {
    e.printStackTrace();
  }

  char[] alphabet = FindAlphabet.FindAlphabet(dictionary);
  
  
  System.out.println("Alphabet is: ");
  for (int i=0; i<alphabet.length; i++)
  {
    System.out.print(alphabet[i] + ", ");
  }
 }
}