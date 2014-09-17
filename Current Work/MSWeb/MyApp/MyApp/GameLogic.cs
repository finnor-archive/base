using System;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyApp
{
    public class GameLogic
    {
        private Game gameBoard;

        public GameLogic(Game inGameBoard)
        {
            gameBoard = inGameBoard;
        }


        //find effects of a click on a zero cell
        public void clickCell(int x, int y, bool[,] state)
        {
            Queue<myTuple> BFS = new Queue<myTuple>();
            BFS.Enqueue(new myTuple(x, y));
            myTuple current;
            int tempCell;
            int currCell;

            while (BFS.Count > 0)               //breadth first search zeros with cells bordering mines as children
            {
                current = BFS.Dequeue();
                currCell = gameBoard.getValue(current.x, current.y);
                if (current.x > 0)
                {
                    if (current.y > 0)                                                //top-left
                    {
                        tempCell = gameBoard.getValue(current.x - 1, current.y - 1);
                        if (state[current.x - 1, current.y - 1] == false)
                        {
                            state[current.x - 1, current.y - 1] = true;
                            if (tempCell == 0)
                                BFS.Enqueue(new myTuple(current.x - 1, current.y - 1));
                        }
                    }
                    if (current.y < 8)                                                //bottom-left
                    {
                        tempCell = gameBoard.getValue(current.x - 1, current.y + 1);
                        if (state[current.x - 1, current.y + 1] == false)
                        {
                            state[current.x - 1, current.y + 1] = true;
                            if (tempCell == 0)
                                BFS.Enqueue(new myTuple(current.x - 1, current.y + 1));
                        }
                    }
                    tempCell = gameBoard.getValue(current.x - 1, current.y);          //left
                    if (state[current.x - 1, current.y] == false)
                    {
                        state[current.x - 1, current.y] = true;
                        if (tempCell == 0)
                            BFS.Enqueue(new myTuple(current.x - 1, current.y));
                    }
                }
                if (current.x <8)
                {
                    if (current.y > 0)                                                //top-right
                    {
                        tempCell = gameBoard.getValue(current.x + 1, current.y - 1);
                        if (state[current.x + 1, current.y - 1] == false)
                        {
                            state[current.x + 1, current.y - 1] = true;
                            if (tempCell == 0)
                                BFS.Enqueue(new myTuple(current.x + 1, current.y - 1));
                        }
                    }
                    if (current.y < 8)                                                //bottom-right
                    {
                        tempCell = gameBoard.getValue(current.x + 1, current.y + 1);
                        if (state[current.x + 1, current.y + 1] == false)
                        {
                            state[current.x + 1, current.y + 1] = true;
                            if (tempCell == 0)
                                BFS.Enqueue(new myTuple(current.x + 1, current.y + 1));
                        }
                    }
                    tempCell = gameBoard.getValue(current.x + 1, current.y);
                    if (state[current.x + 1, current.y] == false)
                    {
                        state[current.x + 1, current.y] = true;
                        if (tempCell == 0)
                            BFS.Enqueue(new myTuple(current.x + 1, current.y));
                    }
                }
                if (current.y > 0)                                            //top
                {
                    tempCell = gameBoard.getValue(current.x, current.y - 1);
                    if (state[current.x, current.y - 1] == false)
                    {
                        state[current.x, current.y - 1] = true;
                        if (tempCell == 0)
                            BFS.Enqueue(new myTuple(current.x, current.y - 1));
                    }
                }
                if (current.y <8)                                            //bottom
                {
                    tempCell = gameBoard.getValue(current.x, current.y + 1);
                    if (state[current.x, current.y + 1] == false)
                    {
                        state[current.x, current.y + 1] = true;
                        if (tempCell == 0)
                            BFS.Enqueue(new myTuple(current.x, current.y + 1));
                    }
                }
            }

        }

    }
}
