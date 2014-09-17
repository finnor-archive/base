using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyApp
{
    public partial class MainPage : UserControl
    {
        private Game gameBoard;
        private GameLogic logic;
        private bool[,] state;
        int remainingCells;
        int flags;

        public MainPage()
        {
            InitializeComponent();
            gameBoard = new Game();
            logic = new GameLogic(gameBoard);
            state = new bool[9, 9];
            foreach (Button cell in GameLayout.Children)
                cell.Content = " ";
            flags = 10;                                         //reverse counter for flags placed
            remainingCells = 71;                                //initial non mine cells 
            time = 0;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            String strValue = (String) clickedButton.Content;

            if (remainingCells==71)                                   //if first cell start timer
                myDispatcherTimer.Start();


            if (!strValue.Equals("!"))                              //if not flagged, then can click
            {
                String name = clickedButton.Name;
                int x = int.Parse(name[1].ToString());
                int y = int.Parse(name[2].ToString());
                int value = gameBoard.getValue(x, y);
                state[x, y] = true;
                if (value >= 10 && remainingCells==71)              //special case where first mine would have lost, mine is moved
                {
                    gameBoard.adjustBoard(x, y);
                }
                else if (value >= 10)                               //else mine then lose
                {
                    GameOver();
                }
                else if (value > 0)                                 //else a cell touching at least one mine
                {
                    remainingCells--;
                    clickedButton.Content = value;
                    clickedButton.IsEnabled = false;
                    if (remainingCells == 0)
                        Win();

                }
                else                                                //else a zero cell and bordering cells are opened
                {
                    logic.clickCell(x, y, state);
                    UpdateMyLayout();
                }
            }
        }


        private void button_MouseRightButtonUp(object sender, MouseButtonEventArgs e)           //set or unset a flag
        {
            Button clickedButton = (Button)sender;
            if (clickedButton.Content.Equals(" "))
            {
                clickedButton.Content = "!";
                flags--;
            }
            else
            {
                clickedButton.Content = " ";
                flags++;
            }

            minesRemaining.Content = flags.ToString();
            e.Handled = true;
        }


        private void GameOver()                                                     //game lost, reveal board
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    foreach (Button cell in GameLayout.Children)
                    {
                        if (Grid.GetRow(cell) == i && Grid.GetColumn(cell) == j)
                        {
                            if (gameBoard.getValue(i, j) >= 10)
                                cell.Content = "X";
                            else
                                cell.Content = (gameBoard.getValue(i, j)).ToString();
                            cell.IsEnabled = false;
                        }
                    }
                }
            }

            myDispatcherTimer.Stop();

            MessageBox.Show("You Lost");
        }

        private void Win()                                                  //win announced
        {

            foreach (Button cell in GameLayout.Children)
            {
                cell.IsEnabled = false;
            }

            myDispatcherTimer.Stop();

            MessageBox.Show("You Won");
        }



        private void UpdateMyLayout()                                         //reveal new board after a left click
        {
            remainingCells = 71;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (state[i, j] == true)
                    {
                        foreach (Button cell in GameLayout.Children)
                        {
                            if (Grid.GetRow(cell) == i && Grid.GetColumn(cell) == j)
                            {
                                if (cell.IsEnabled)
                                {
                                    cell.Content = (gameBoard.getValue(i, j)).ToString();
                                    cell.IsEnabled = false;
                                }
                            }
                        }
                        remainingCells--;
                    }
                }
            }
            if (remainingCells == 0)
                Win();
        }


        private void newGame_Click(object sender, RoutedEventArgs e)                           // reinitialize environment for a new game
        {
            gameBoard = new Game();
            logic = new GameLogic(gameBoard);
            state = new bool[9, 9];
            foreach (Button cell in GameLayout.Children)
            {
                cell.Content = " ";
                cell.IsEnabled = true;
            }
            flags = 10;
            remainingCells = 71;
            minesRemaining.Content = flags.ToString();
            time = 0;
            myTextBlock.Text = "0";
        }


        //Timer
        System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private int time;      //start timer

        public void StartTimer(object o, RoutedEventArgs sender)
        {
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000); 
            myDispatcherTimer.Tick += new EventHandler(Each_Tick);
        }

        // Raised every 100 miliseconds while the DispatcherTimer is active.
        public void Each_Tick(object o, EventArgs sender)
        {
            time++;
            myTextBlock.Text = time.ToString();
        }


    }
}
