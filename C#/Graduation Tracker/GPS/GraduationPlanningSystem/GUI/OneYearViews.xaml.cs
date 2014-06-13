using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraduationPlanningSystem
{
    /// <summary>
    /// Interaction logic for OneYearViews.xaml
    /// </summary>
    public partial class OneYearViews : UserControl
    {
        
        //title to be set.  "summer" "fall" and "spring" are typical
        public string Title { get; set; }

        //list of semesters contained here
        public List<SemesterControl> Semesters { get; set; } 

        //constructor.  sets up fall, spring, and summer semetsrs
        public OneYearViews(string title)
        {
            InitializeComponent();
            Semesters = new List<SemesterControl>();
            SemesterControl fall = new SemesterControl("Fall");
            fall.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Grid.SetColumn(fall, 0);
            gridMain.Children.Add(fall);
            Semesters.Add(fall);

            SemesterControl spring = new SemesterControl("Spring");
            spring.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Grid.SetColumn(spring, 1);
            gridMain.Children.Add(spring);
            Semesters.Add(spring);

            SemesterControl summer = new SemesterControl("Summer");
            summer.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Grid.SetColumn(summer, 2);
            gridMain.Children.Add(summer);
            Semesters.Add(summer);

            txtHeader.Text = title;
        }


    }
}
