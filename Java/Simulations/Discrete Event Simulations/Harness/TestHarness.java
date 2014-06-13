import java.util.Scanner;
import java.io.*;

public class TestHarness
{
  public static void main(String[] args)
  {
    String inputFileName;
    Scanner scan = new Scanner(System.in);
    FEL fel = new FEL();
    System.out.println("Input Test File: ");
    inputFileName = scan.nextLine();
    
    try
    {
      scan = new Scanner(new File(inputFileName));
    }
    catch (IOException ex)
    {
      System.out.println("Sorry, file not found: " + inputFileName);
    }
    
    String operation;
    char op; 
    int[] attributes= new int[3];
    int startInt;
    int parsingStage;
    int getNum;
    while (scan.hasNextLine())
    {
      operation = scan.nextLine();
      op = operation.charAt(0);
      if (op=='I')
      {
        startInt=2;
        parsingStage=0;
        for (int i=3; i<operation.length(); i++)
        {
          if (operation.charAt(i)==',' || operation.charAt(i)==')')
          {
            attributes[parsingStage] = Integer.parseInt(operation.substring(startInt, i));
            startInt = i+2;
            parsingStage++;
          }
        }
        System.out.println("insert(" + attributes[0] + ", " + attributes[1] + ", " + attributes[2] + ") ");
        fel.insert(new Event(attributes[0], attributes[1], attributes[2]));
      }
      else if (op=='G')
      {
        getNum = Integer.parseInt(operation.substring(2, operation.length()-1));
        System.out.println("get(" + getNum + ") = " + fel.get(getNum));
      }
      else
      {
        System.out.println("getNext() = " + fel.getNext());
      }
    }
  }
}