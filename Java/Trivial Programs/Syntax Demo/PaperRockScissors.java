// ******************************************************************************************
// Adrian Flannery
// PaperRockScissors.java
// Prompts the user to enter a choice and then displays the choice using nested if statements
// ******************************************************************************************

import java.util.Scanner;

public class PaperRockScissors 
{
  public static void main(String args[]) 
  {
    Scanner scan = new Scanner(System.in);
    int userChoice;
    String userChoiceName = "";
    System.out.print("Your Choice (0-Paper 1-Rock 2-Scissors): ");
    userChoice = scan.nextInt();
 
    if (userChoice>=0 && userChoice<=2) 
     {
      if (userChoice == 0)
        userChoiceName = "Paper";
      if (userChoice == 1)
        userChoiceName = "Rock";
      if (userChoice == 2)
        userChoiceName = "Scissors";
      
      System.out.println("Your choice is " + userChoiceName);
     } 
    else 
      System.out.println("You have inputted a wrong choice!!");
  }
}