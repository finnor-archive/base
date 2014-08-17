using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperDesktop
{
   public class Board 
   {

        private MinesweeperButton[,] Buttons = new MinesweeperButton[16, 30];
        private int[,] board = new int[16,30];
        private Random gen = new Random();
    
        public Board()
        {
            int mines = 99;
            int x;
            int y;
        
        
        
            //add 99 mines to board
            while (mines>0)
            {
                x = gen.Next(16);
                y = gen.Next(30);
                if (board[x, y]<100)            //if not already a mine
                {
                    board[x, y] = 100;          //100+ represents mine
                    mines--;
                
                    //add the presence to neighboring cells
                    //boundary conditions first
                    if(x>0)
                    {
                        board[x-1, y]++;
                        if (y>0)
                            board[x-1, y-1]++;
                        if (y<29)
                            board[x-1, y+1]++;
                    }
                    if(x<15)
                    {
                        board[x+1, y]++;
                        if (y>0)
                            board[x+1, y-1]++;
                        if (y<29)
                            board[x+1, y+1]++;
                    }
                    if (y>0)
                        board[x, y-1]++;
                    if (y<29)
                        board[x, y+1]++;
                }
            }
        }
    
        public String clickCell(int x, int y)           //return cell value as String
        {
            if (board[x, y]>=100)
                return ("x");
            else
                return (board[x, y].ToString());
        }
    }
    /*
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
     */

}