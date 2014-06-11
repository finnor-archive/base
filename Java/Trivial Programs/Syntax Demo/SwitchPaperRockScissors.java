// ******************************************************************************************
// Adrian Flannery
// SwitchPaperRockScissors.java
// Prompts the user to enter a choice and then displays the choice using case-switch
// ******************************************************************************************

import java.util.Scanner;

public class SwitchPaperRockScissors 
{
  public static void main(String args[]) 
  {
    Scanner scan = new Scanner(System.in);
    int userChoice;
    String userChoiceName = "";
    System.out.print("Your Choice (0-Paper 1-Rock 2-Scissors): ");
    userChoice = scan.nextInt();
    switch (userChoice)
    {
      case 0:
        userChoiceName = "Paper";
        System.out.println("Your choice is " + userChoiceName);
        break;
      case 1:
        userChoiceName = "Rock";
        System.out.println("Your choice is " + userChoiceName);
        break;
      case 2:
        userChoiceName = "Scissors";
        System.out.println("Your choice is " + userChoiceName);
        break;
      default:
       System.out.println("You have inputted a wrong choice!!");
    }        
  }
}