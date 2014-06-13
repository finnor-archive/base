using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraduationPlanningSystem.Data_Objects;

namespace GraduationPlanningSystem
{
    public partial class MainForm : Form
    {
        private List<Degree> mDegreeList;

        public MainForm()
        {
            InitializeComponent();
            mDegreeList = new List<Degree>();
            Degree undecided = new Degree("Undecided");
            undecided.Year = 2013;
            Degree math = new Degree("Math");
            math.Year = 2013;
            mDegreeList.Add(undecided);
            mDegreeList.Add(math);
            SetupGUI();
        }

        private void SetupGUI()
        {
            int x  = comboMajor.Items.Count;

            foreach (Degree degree in mDegreeList)
            {
                comboMajor.Items.Add(degree.Name);
            }
        }

        private void btnEditTaken_Click(object sender, EventArgs e)
        {
            AlreadyTakenClasses form = new AlreadyTakenClasses();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateSchedulesForm form = new GenerateSchedulesForm();
            form.Show();
        }

        private void comboMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Degree degree = mDegreeList[comboMajor.SelectedIndex];
            comboPosYear.Items.Add( degree.Year.ToString());
        }
    }
}
