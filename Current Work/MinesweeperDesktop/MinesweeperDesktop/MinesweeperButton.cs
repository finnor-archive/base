using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperDesktop
{
    class MinesweeperButton : System.Windows.Forms.Button
    {
        private int x, y;

        public MinesweeperButton(int i, int j) : base()
        {
            x = i;
            y = j;
        }

        public int X
        {
            get 
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }
    }
}
