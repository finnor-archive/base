using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class BrowseSchedule : Form
    {
        public BrowseSchedule()
        {
            InitializeComponent();
        }

        private void BrowseSchedule_Load(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = listBox2.SelectedItem.ToString();
            if (myCourse.Equals("World History 1"))
            {
                textBox4.Text = "World History 1";
                textBox5.Text = "HY00103";
                textBox6.Text = "HY103";
                textBox12.Text = "History";
                textBox11.Text = "3";
                textBox10.Text = "SMF";
                listBox13.Items.Clear();
                listBox13.Items.Add("Meet Reqs And Can Replace");
                listBox13.Items.Add("\tWestern Civ I");
                listBox13.Items.Add("Do Not Meet Reqs");
                listBox13.Items.Add("\tWestern Civ II");
                listBox13.Items.Add("\tAmerican History II");
                listBox13.Items.Add("\tWorld History II");
                listBox13.Items.Add("Cannot Be Added This Semester");
                listBox13.Items.Add("\tAmerican History I");
            }

        }

    }
}
