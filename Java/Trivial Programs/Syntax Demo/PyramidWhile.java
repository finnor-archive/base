// *********************************************************************************************************
// Adrian Flannery
// PyramidWhile.java
// Prompts the user to enter a number and builds a right triangle of such base and height using a while loop
// *********************************************************************************************************

import java.util.Scanner;
  
public class PyramidWhile 
{
  public static void main(String args[]) 
  {
    Scanner scan = new Scanner(System.in);
    int number;
    int counter = 1;
    int nestedcounter;
    System.out.print("Enter an integer 1 through 9:");
    number = scan.nextInt();
    while (counter <= number)
     {
      nestedcounter = 1;
      while (nestedcounter <= counter)
       {
        System.out.print(counter);
        nestedcounter++;
       }
      counter++;
      System.out.println();
     }
  }
}