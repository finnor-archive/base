/**
 * Adrian Flannery, Zhaojie Liu
 * Two modes of operation
 * Mode 1: convert a .txt file into an verifiable encrypted .bmp
 * Mode 2: convert a .bmp file into a .txt and reports teh verification
 */


import java.awt.image.BufferedImage;
import java.awt.*;
import java.util.*;
import javax.imageio.ImageIO;
import java.io.*;


public class DriverSten
{
  /**
   * Drives the operation of the program
   */
  public static void main(String[] args) throws IOException
  {
    String fileName;
    String outFileName;
    String choice;
    String tempKey;
    boolean readT = true;
    boolean pass;
    int length;
    int[][] input = new int[600][600];
    BufferedImage image;
    File file;
    Scanner scan = new Scanner(System.in);
    
    System.out.println("Enter the shared key: ");        //passphrase to enter system
    tempKey = scan.nextLine();
    pass = Encrypt.checkKey(tempKey);                   //checks passphrase
    
    if (pass)                //if pass phrase is correct
    { 
      System.out.println("(1) Convert text to image: ");          //options for operation
      System.out.println("(2) Convert image to text: ");
      choice = scan.nextLine();  
      System.out.println("Enter Input FileName: ");
      fileName = scan.nextLine();
      System.out.println("Enter Output FileName: ");
      outFileName = scan.nextLine();
      System.out.println("Will write the results to " + outFileName );
             
    
      if(choice.equals("1"))       // text to image
      {
        LinkedList<String> text = new LinkedList();         //linked list of lines of the text
        try
        {
          text = ReadFile.readText(fileName);             //creates list of lines
          if (text==null)
            readT = false;
        }
        catch (IOException ex)
        {
          readT = false;
        }
        if (readT)                  //if readText works
        {
          length = text.size();
          for(int i=0; i<length; i++)
          {
            System.out.print(text.get(i));           //print the text
          }
        }
      
        if (readT)
          input = TextToImage.convertText(text);        //convert the text into an int[][] array
        
        if ((input.length != 1) && (readT))                   //checks text for overflow or empty
        {
          input = Encrypt.encryptInt(input);     //encrypt the int[][] array
          image = TextToImage.makePic(input);    //convert the array into an image
          LoadAndShow.display(image);            //displays image
          
          try
          {
            file = new File(outFileName);              //writes image to file
            ImageIO.write(image, "bmp", file); 
          }
          catch(IOException e)
          {
          }
        }
        if (input.length == 1)
        {
          System.out.println("Overflow");
        }
      }
      if (choice.equals("2"))          //image to text
      {
        
        file = new File(fileName); 
        try
        {
        image = ImageIO.read(file); 
        input = TextToImage.convertImage(image);     //converts image to int[][] array
        input = Encrypt.encryptInt(input);          // decrypts the array
        TextToImage.makeText(input, outFileName);    // writes the text to file
        }
        catch(IOException e)
        {
          System.out.println("Invalid image");
        }
      }
    }
    else
    {
      System.out.println("Invalid key");
    }
  }
}