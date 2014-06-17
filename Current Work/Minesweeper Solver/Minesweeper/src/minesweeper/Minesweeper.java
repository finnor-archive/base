/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package minesweeper;

import java.util.Random;

/**
 *
 * @author Adrian
 */
public class Minesweeper {

    private int[][] board = new int[16][30];
    private Random gen = new Random();
    
    public Minesweeper()
    {
        int mines = 99;
        int x;
        int y;
        
        
        
        //add 99 mines to board
        while (mines>0)
        {
            x = gen.nextInt(16);
            y = gen.nextInt(30);
            if (board[x][y]<100)            //if not already a mine
            {
                board[x][y] = 100;          //100+ represents mine
                mines--;
                
                //add the presence to neighboring cells
                //boundary conditions first
                if(x==0)
                {
                    if (y==0)               //if top left corner
                    {
                        board[x+1][y]++;
                        board[x+1][y+1]++;
                        board[x][y+1]++;
                    }
                    else if (y==29)         //if bottom left corner
                    {
                        board[x][y-1]++;
                        board[x+1][y-1]++;
                        board[x+1][y]++;
                    }
                    else                    //if left wall
                    {
                        board[x+1][y]++;
                        board[x+1][y+1]++;
                        board[x][y+1]++;
                        board[x][y-1]++;
                        board[x+1][y-1]++;
                    }
                }
                else if (x==15) 
                {
                    if (y==0)               //if top right corner
                    {
                        board[x-1][y]++;
                        board[x-1][y+1]++;
                        board[x][y+1]++;
                    }
                    else if (y==29)         //if bottom right corner
                    {
                        board[x-1][y]++;
                        board[x-1][y-1]++;
                        board[x][y-1]++;
                    }
                    else                    //if right wall
                    {
                        board[x-1][y]++;
                        board[x-1][y+1]++;
                        board[x][y+1]++;
                        board[x-1][y-1]++;
                        board[x][y-1]++;
                    }
                }
                else if (y==0)              //if top wall
                {
                    board[x-1][y]++;
                    board[x-1][y+1]++;
                    board[x][y+1]++;
                    board[x+1][y]++;
                    board[x+1][y+1]++;  
                }
                else if (y==29)             //if bottom wall
                {
                    board[x-1][y]++;
                    board[x-1][y-1]++;
                    board[x][y-1]++;
                    board[x+1][y-1]++;
                    board[x+1][y]++; 
                }
                else                        //else cell has eight neighbors
                {
                    board[x-1][y]++;
                    board[x-1][y-1]++;
                    board[x-1][y+1]++;
                    board[x][y-1]++;
                    board[x][y+1]++;
                    board[x+1][y-1]++;
                    board[x+1][y]++; 
                    board[x+1][y+1]++;
                }
            }
        }
    }
    
    public String clickCell(int x, int y)           //return cell value as String
    {
        if (board[x][y]>100)
            return ("x");
        else
            return (Integer.toString(board[x][y]));
    }
    
    public String toString()                        //return board as string
    {
      String out = "";
      for (int i=0; i<16; i++)
      {
        for (int j=0; j<30; j++)
        {
          if (board[i][j]>=100)
            out += "    x";
          else
            out += "    " + board[i][j];
        }
        out+= "\n";
      }
      return out;
    }
}
