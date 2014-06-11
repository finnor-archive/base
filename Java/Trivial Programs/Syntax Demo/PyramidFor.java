// *********************************************************************************************************
// Adrian Flannery
// PyramidWhile.java
// Prompts the user to enter a number and builds a right triangle of such base and height using a for loop
// *********************************************************************************************************

import java.util.Scanner;
  
public class PyramidFor 
{
  public static void main(String args[]) 
  {
    Scanner scan = new Scanner(System.in);
    int number;
    System.out.print("Enter an integer 1 through 9:");
    number = scan.nextInt();
    for (int counter = 1; counter <= number; counter++)
     {
      for (int nestedcounter = 1; nestedcounter <= counter; nestedcounter++)
       {
        System.out.print(counter);
       }
      System.out.println();
     }
  }
}