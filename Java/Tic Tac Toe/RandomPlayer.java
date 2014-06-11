/*
Adrian Flannery
adrianu2
Fall 2009 CS 201 Introduction to Object Oriented Programming
Homework-3 Problem 1
*/

import java.util.Random;

public class RandomPlayer extends Player
{  
  // constructor
  public RandomPlayer(char role)
  {
    // invokes Player contructor
    super(role);
  }
  
  // makes move for randomplayer object
  public void play()
  {
    int row, col;
    Random generator = new Random();
    
    // generates a random position
    do
    {
      row = generator.nextInt(3);
      col = generator.nextInt(3);
    }
    while ((Board.isOccupied(row, col)));     // checks to see if random position is not already taken
    
    
    // makes the random move
    Board.setPosition(row, col, player);
  }
}