using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraduationPlanningSystem.Data_Objects;

namespace GraduationPlanningSystem
{
    public partial class PlanPage : TabPage
    {
        public DegreeControl Control { get; set; }

        public PlanPage(Degree plan, List<Course> taken, GenerateSchedulesForm parent)
        {
            InitializeComponent();
            this.AutoScroll = true;

            Control = new DegreeControl(plan, taken, parent, "sdf");
            this.elementHost2.Child = Control;

        }

    }
}
