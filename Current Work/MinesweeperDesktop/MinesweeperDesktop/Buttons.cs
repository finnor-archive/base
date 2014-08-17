using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperDesktop
{
    class Buttons
    {
        private MinesweeperButton[,] btnBoard;
        private Board game;

        public Buttons(MinesweeperButton[,] inBtnBoard, Board inGame)
        {
            btnBoard = inBtnBoard;
            game = inGame;
        }

        public void clickButton(int x, int y)
        {
            MinesweeperButton temp = btnBoard[x, y];
            temp.Text = game.clickCell(x, y);
            temp.Enabled = false;
            if (temp.Text == "x")
            {
                //btnQueue.Enqueue(temp);
            }
            else if (temp.Text == "0")
            {
                Queue<MinesweeperButton> btnQueue = new Queue<MinesweeperButton>();
                while (btnQueue.Count != 0)
                {

                }

            }
            else
            {

            }
        }
    }
}
