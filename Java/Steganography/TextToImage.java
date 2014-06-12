import java.awt.image.BufferedImage;
import java.awt.*;
import java.util.*;
import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import java.io.*;
import java.awt.geom.*;

public class TextToImage
{
  /**
   * Converts the LinkedList<String> of text into an int[][]array and sets computed hash
   * parameter LinkedList<String>
   * return int[][]
   */
  public static int[][] convertText (LinkedList<String> list)
  {
    LinkedList<String> text = list;
    Scanner scan = new Scanner(System.in);
    
    int lengthDoc = text.size();          // number of lines
    int lengthLine;
    String line;
    int[][] failed = {{0}};
    int hash=0;
    
    int[][] arrayChar = new int[600][600];    // temp image
    char currentLetter;
    
    int x=0;                  
    int y=0;
    
    
    for (int i=0; i<lengthDoc; i++)
    {
      line = text.get(i);                    //get line
      lengthLine = line.length();        // num of chars in line
      
      for (int j=0; j<lengthLine; j++)
      {
        currentLetter = line.charAt(j);      //get letter
        hash = (hash + (int) currentLetter)%256;    // hash function
        arrayChar[x][y] = (int) (currentLetter) + 1;     // value of char + 1
        y++;
        if (y >= arrayChar[0].length)            // check next row of array
        {
          x++;
          y=0;
        }
        if (x >= arrayChar.length)           // check to see if text is too large
        {
          return (failed);                  // returns a array to indicate overflow
        }
      }   
    }
    arrayChar[599][599] = hash;          // hash value
    return(arrayChar);
  }
  
  
  /**
   * Converts the encrypted int[][] array of text into a BufferedImage
   * parameter int[][]
   * return BufferedImage
   */
  public static BufferedImage makePic (int[][] input)
  {
    int w = input[0].length;
    int h = input.length;
    BufferedImage image = new BufferedImage(w, h/3, BufferedImage.TYPE_INT_RGB);     //creates an image of int[x][y] to image[x][y/3]
    Color clr;
    int r,g,b;
    for(int i=0; i<w; i++)
    {
      for(int j=0; j<h; j+=3)
      {
        r = input[i][j];                   //loops through contents of array; each 3-tuple of nums is converted to a color
        g = input[i][j+1];
        b = input[i][j+2];    
        clr = new Color(r, g, b);
        image.setRGB(i, j/3, clr.getRGB());
      }
    }
    return(image);
  }
  
  
  
  /**
   * Converts the BufferedImage into an encrypted int[][] array of text
   * parameter BufferedImage
   * return int[][]
   */
  public static int[][] convertImage(BufferedImage image)
  {
    int[][] text = new int[image.getWidth()][image.getHeight()*3];        //image[x][y] to int[x][3*y]
    Color clr;
    int r,g,b;
    for(int i=0; i<image.getWidth(); i++)            //loops through pixels; each pixel becomes 3 ints
    {
      for(int j=0; (j/3)<image.getHeight(); j+=3)
      {
        clr = new Color(image.getRGB(i, j/3));
        r = clr.getRed();
        g = clr.getGreen();
        b = clr.getBlue();
        text[i][j] = r;
        text[i][j+1] = g;
        text[i][j+2] = b;    
      }
    }
    
    return (text);
    
  }
  
  
  /**
   * Converts the encrypted int[][] text into a .txt file and checks hash value
   * parameter int[][], String
   * return void
   */
  public static void makeText(int[][] input, String outFileName)
  {
    int hash = 0;
    int presentChar;
    PrintWriter out = null;
      
    try
    { 
      FileWriter outFile = new FileWriter(outFileName);
      out = new PrintWriter(outFile);
    } 
    catch (IOException e)
    { 
      e.printStackTrace();
    }
 
    for(int i=0; i<input.length && (input[i][0] != 0); i++)
    {
      for(int j=0; j<input[i].length && (input[i][j] != 0); j++)        //loops through array and prints characters to file
      {
        presentChar = (input[i][j]-1);
        out.print((char)presentChar);
        hash = (hash + presentChar)%256;
      }
    }
    if (input[599][599] == hash)          //checks hash and inserts message on verified or not
    {
      out.print("\r\nText verified");
    }
    else
    {
      out.print("\r\nLoss of Data Integrity");
    }
      
    out.close();
  }
}