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
    public partial class GraduationPlanningSystem : Form
    {
        public static DBClass db;
        public static List<Course> coursesTaken;

        public GraduationPlanningSystem()
        {
            InitializeComponent();
            coursesTaken = new List<Course>();
            db = new DBClass();         //initializes database
        }

        //Go to Edit Taken Classes Form;
        private void btnEditTaken_Click(object sender, EventArgs e)
        {
            AlreadyTakenClasses form = new AlreadyTakenClasses();
            form.Show();
        }

        //Go to Generate Schedule Form
        private void button1_Click(object sender, EventArgs e)
        {
            GenerateSchedulesForm form = new GenerateSchedulesForm(coursesTaken, "EE");
            form.Show();
        }
    }
}
