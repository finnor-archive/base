using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperDesktop
{
    public partial class MinesweeperForm : Form
    {
        private Board game;
        private MinesweeperButton[,] btnBoard = new MinesweeperButton[16, 30];
        Buttons btns;
        private bool[,] visited = new bool[16, 30];

        public MinesweeperForm()
        {
            InitializeComponent();
            game = new Board();
        }

        private void Minesweeper_Load(object sender, EventArgs e)
        {
            int posX = 0;
            int posY = 0;
            MinesweeperButton cellBtn;
            for (int i = 0; i < btnBoard.GetLength(0); i++)
            {
                for (int j = 0; j < btnBoard.GetLength(1); j++)
                {
                    cellBtn = new MinesweeperButton(i, j);
                    cellBtn.Width = 20;
                    cellBtn.Height = 20;
                    cellBtn.Left = posX;
                    cellBtn.Top = posY;
                    ButtonPanel.Controls.Add(cellBtn);
                    btnBoard[i, j] = cellBtn;
                    posX += 20;
                    cellBtn.MouseUp += new MouseEventHandler(cellBtn_MouseUp);
                }
                posX = 0;
                posY += 20;
            }
            btns = new Buttons(btnBoard, game);
        }

        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            game = new Board();
            for (int i = 0; i < btnBoard.GetLength(0); i++)
            {
                for (int j = 0; j < btnBoard.GetLength(1); j++)
                {
                    btnBoard[i, j].Enabled = true;
                    btnBoard[i, j].Text = "";
                    visited[i, j] = false;
                }
            }
            btns = new Buttons(btnBoard, game);
        }

        private void cellBtn_MouseUp(object sender, MouseEventArgs e)
        {
            MinesweeperButton temp = (MinesweeperButton) sender;
            if (e.Button == MouseButtons.Right)
            {
                if (temp.Text=="#")
                    temp.Text="";
                else if (temp.Text=="")
                    temp.Text="#";
            }
            else if (e.Button == MouseButtons.Left)
            {
                btns.clickButton(temp.X, temp.Y);
            }
        }
    }
}
