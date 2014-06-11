/*
Adrian Flannery
adrianu2
Fall 2009 CS 201 Introduction to Object Oriented Programming
Homework-3 Problem 1
*/

public class Board
{
  // creates a static board as only one board will be used
  private static char[][] board = {{'+', '+', '+'}, {'+', '+', '+'}, {'+', '+', '+'}};
  
  // constructor
  public Board()
  {  
  }
  
  // sets the position chosen by the player object to its role('X' or 'O')
  public static void setPosition (int row, int col, char playerChar)
  {
    board[col][row] = playerChar;
  }
  
  // returns the character at a chosen position
  public static char getPosition (int row, int col)
  {
    return((board[col][row]));
  }
  
  // returns true if a 'X' or 'O' occupies the postion and false if a '+' does
  public static Boolean isOccupied (int row, int col)
  {
    return((board[col][row])!='+');
  }
  
  // returns true if the board is full and false if a '+' is still present
  public Boolean isFull()
  {
    for(int i=0; i<board.length; i++)
    {
      for(int j=0; j<board[i].length; j++)
      {
        if (board[i][j]=='+')
        {
          return(false);
        }
      }
    }
    return(true);
  }
  
  //checks for a winner
  public char checkWinner()
  {
    //checks all rows for horizontal wins
    if (board[0][0]==board[0][1] && board[0][1]==board[0][2] && board[0][0] != '+')
    {
      return(board[0][0]);
    }
    if (board[1][0]==board[1][1] && board[1][1]==board[1][2] && board[1][0] != '+')
    {
      return(board[1][0]);
    }
    if (board[2][0]==board[2][1] && board[2][1]==board[2][2] && board[2][0] != '+')
    {
      return(board[2][0]);
    }
    
    //checks all columns for vertical wins
    if (board[0][0]==board[1][0] && board[1][0]==board[2][0] && board[0][0] != '+')
    {
      return(board[0][0]);
    }
    if (board[0][1]==board[1][1] && board[1][1]==board[2][1] && board[0][1] != '+')
    {
      return(board[0][1]);
    }
    if (board[0][2]==board[1][2] && board[1][2]==board[2][2] && board[0][2] != '+')
    {
      return(board[0][2]);
    }
    
    //checks for diagonal wins
    if (board[0][0]==board[1][1] && board[1][1]==board[2][2] && board[0][0] != '+')
    {
      return(board[0][0]);
    }
    if (board[0][2]==board[1][1] && board[1][1]==board[2][0] && board[0][2] != '+')
    {
      return(board[0][2]);
    }
    
    //else return '+'
    return('+');
  }
  
  // returns the board as a string
  public String toString()
  {
    String result = "";
    for(int i=0; i<board.length; i++)
    {
      for(int j=0; j<board[i].length; j++)
      {
        result += board[i][j];
      }
      result += "\n";
    }
    return(result);
  }
}