import java.io.*;
import java.util.*;


public class ReadFile
{
  /**
   * Reads the file and converts it into a LinkedList<String> of the lines
   * parameter String
   * return LinkedList<String>
   */
  public static LinkedList<String> readText(String fileName) throws IOException
  {
    boolean failed = false;
    Scanner scanner = new Scanner(System.in);
    boolean anotherLine;
    String file = fileName;
    
    LinkedList<String> list = new LinkedList();
    
    try
    {
      scanner = new Scanner(new File(file));           //read the file
    }
    catch (IOException ex)
    {
      failed = true;
      System.out.println("Sorry, file not found: " + fileName);
      return (null);
    }
    
    if(failed == false)
    {
      
      String line = scanner.nextLine();        
      anotherLine = scanner.hasNextLine();
      
      while(anotherLine)
      {  
        if (!(line.equals("")))           // if line isnt empty
          list.add(line + "\r\n");        // add the line and insert newline
        else
          list.add("\r\n");               //else add new line if line is empty
        line = scanner.nextLine();
        anotherLine = scanner.hasNextLine();
      } 
      list.add(line);
    }  
    
    return(list);
  }
}