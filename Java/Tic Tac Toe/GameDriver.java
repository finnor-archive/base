/*
Adrian Flannery
adrianu2
Fall 2009 CS 201 Introduction to Object Oriented Programming
Homework-3 Problem 1
*/

import java.util.Scanner;

public class GameDriver
{
  public static void main(String[] args)
  {
    Scanner scan = new Scanner(System.in);
    String response;
    
    // declares the player objects that will later utilize polymorphism to take the appropriate player
    Player player1;
    Player player2;
    
    do
    {
      // prompts user to decide on type of player 1
      System.out.print("What type of player for player 1 'X': (human, random, or corner)");
      response = scan.nextLine();
      
      //declares player1 as human
      if (response.equalsIgnoreCase("human"))
      {
        player1 = new Player('X');
      }
      else
      {
        // declares player1 as a random player
        if (response.equalsIgnoreCase("random"))
        {
          player1 = new RandomPlayer('X');
        }
        else
        {
          // declares player1 as a corner player
          if (response.equalsIgnoreCase("corner")) 
          {
            player1 = new CornerPlayer('X');
          }
          // if improper input is received player 1 is given a null reference so that the user can be prompted again
          else
          {
            player1 = null;
          }
        }
      }
    }
    while(player1 == null);       // decides whether to prompt user again or not
    
    do
    {
      // prompts user to decide on type of player 1
      System.out.print("What type of player for player 2 'O': (human, random, or corner)");
      response = scan.nextLine();
      
      //declares player2 as human
      if (response.equalsIgnoreCase("human"))
      {
        player2 = new Player('O');
      }
      else
      {
        // declares player2 as a random player
        if (response.equalsIgnoreCase("random"))
        {
          player2 = new RandomPlayer('O');
        }
        else
        {
          // declares player2 as a corner player
          if (response.equalsIgnoreCase("corner"))
          {
            player2 = new CornerPlayer('O');
          }
          // if improper input is received player 1 is given a null reference so that the user can be prompted again
          else
          {
            player2 = null;
          }
        }
      }
    }
    while(player2 == null);       // decides whether to prompt user again or not
        
    // creates the board object
    Board board = new Board();
    
    // the playing process is looped until the board is full or a winner has been recognized
    while (!(board.isFull()) && ((board.checkWinner()=='+')))
    {
      // checks for winner or full before each move so that unneccesary moves aren't made
      if (!(board.isFull()) && ((board.checkWinner()=='+')))
      {
        // allows player1 to move
        System.out.println("Player 1 'X'");
        player1.play();
        //prints board after move is made
        System.out.println(board);
        //delievers congratulations if winning move has been made
        if (board.checkWinner()=='X')
          System.out.println("Congratulations, player 1 wins.");
      }
      
      // repeats the above process for player2
      if (!(board.isFull()) && ((board.checkWinner()=='+')))
      {
        System.out.println("Player 2 'O'");
        player2.play();
        System.out.println(board);
        if (board.checkWinner()=='O')
          System.out.println("Congratulations, player 2 wins");
      }
      
      // tells user if the game ended in a tie
      if ((board.isFull()) && (board.checkWinner()=='+'))
      {
        System.out.println("The game ends in a tie");
      }
    }
  }
}
       
    
        