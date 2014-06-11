/*
Adrian Flannery
adrianu2
Fall 2009 CS 201 Introduction to Object Oriented Programming
Homework-3 Problem 1
*/

import java.util.Scanner;

public class Player
{
  // declares the role('X' or 'O') for a player
  protected char player;
  
  // constructor
  public Player(char role)
  {
    player = role;
  }
  
  // makes moves for the player object
  public void play()
  {
    Scanner scan = new Scanner(System.in);
    int row, col;
    
    //prompts the user for move to be made
    do
    {
      System.out.print("What position do you want: (e.g. 0 0, row x column)");
      col = scan.nextInt();
      row = scan.nextInt();
    }
    while ((Board.isOccupied(row, col)));   // checks that the input is not already taken
    
    // makes prescribed move
    Board.setPosition(row, col, player);
  }
}
                       
                         