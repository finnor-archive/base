using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyApp
{
    public class Game
    {
        private Random gen = new Random();
        private int[,] board = new int[9, 9];

        public Game() 
        {
            int mines = 10;
            int x;
            int y;



            //add 10 mines to board
            while (mines > 0)
            {
                x = gen.Next(9);
                y = gen.Next(9);
                if (board[x, y] < 10)            //if not already a mine
                {
                    board[x, y] += 10;          //10+ represents mine
                    mines--;

                    //add the presence to neighboring cells
                    //boundary conditions first
                    if (x > 0)
                    {
                        board[x - 1, y]++;
                        if (y > 0)
                            board[x - 1, y - 1]++;
                        if (y < 8)
                            board[x - 1, y + 1]++;
                    }
                    if (x < 8)
                    {
                        board[x + 1, y]++;
                        if (y > 0)
                            board[x + 1, y - 1]++;
                        if (y < 8)
                            board[x + 1, y + 1]++;
                    }
                    if (y > 0)
                        board[x, y - 1]++;
                    if (y < 8)
                        board[x, y + 1]++;
                }
            }
        }





        public void adjustBoard (int i, int j)           //moves the mine from the specific location
        {
            //remove mine
            if (i > 0)
            {
                board[i - 1, j]--;
                if (j > 0)
                    board[i - 1, j - 1]--;
                if (j < 8)
                    board[i - 1, j + 1]--;
            }
            if (i < 8)
            {
                board[i + 1, j]--;
                if (j > 0)
                    board[i + 1, j - 1]--;
                if (j < 8)
                    board[i + 1, j + 1]--;
            }
            if (j > 0)
                board[i, j - 1]--;
            if (j < 8)
                board[i, j + 1]--;

            board[i, j]-=10;


            int mines = 1;
            int x, y;
            while (mines > 0)
            {
                x = gen.Next(9);
                y = gen.Next(9);
                if (board[x, y] < 10 && x!=i && y!=j)            //if not already a mine and not the location clicked
                {
                    board[x, y] = 10;          //10+ represents mine
                    mines--;

                    //add the presence to neighboring cells
                    //boundary conditions first
                    if (x > 0)
                    {
                        board[x - 1, y]++;
                        if (y > 0)
                            board[x - 1, y - 1]++;
                        if (y < 8)
                            board[x - 1, y + 1]++;
                    }
                    if (x < 8)
                    {
                        board[x + 1, y]++;
                        if (y > 0)
                            board[x + 1, y - 1]++;
                        if (y < 8)
                            board[x + 1, y + 1]++;
                    }
                    if (y > 0)
                        board[x, y - 1]++;
                    if (y < 8)
                        board[x, y + 1]++;
                }
            }
        }


        public int getValue(int x, int y)           //return cell value as String
        {
            return (board[x, y]);
        }

    }
}
