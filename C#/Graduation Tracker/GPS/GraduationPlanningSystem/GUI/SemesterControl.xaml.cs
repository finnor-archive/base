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
using GraduationPlanningSystem.Data_Objects;

namespace GraduationPlanningSystem
{
    /// <summary>
    /// Interaction logic for SemesterControl.xaml
    /// </summary>
    public partial class SemesterControl : UserControl
    {
        //deprecated
        public ListCollectionView Course { get; set; }

        //provides a list of all courses taken in teh semester
        public List<Course> CoursesTaken
        {
            
            get
            {
                List<Course> result = new List<Course>();

                foreach (ListViewItem item in CoursesListView.Items)
                {
                    if (item != null && item.Content != null)
                    {
                        //check the status of the course
                        if (item.Background == Brushes.Red)
                            result.Add(new Course(item.Content.ToString(), Data_Objects.Course.AcademicStatus.Failed));
                        else if (item.Background == Brushes.Green)
                            result.Add(new Course(item.Content.ToString(), Data_Objects.Course.AcademicStatus.Pass));
                        else
                            result.Add(new Course(item.Content.ToString(), Data_Objects.Course.AcademicStatus.NotYetTaken));
                    }
                }

                return result;
            }
        }

        //constructor
        public SemesterControl()
        {
            InitializeComponent();
        }

        //returns the semestesr 
        public SemesterControl(string semester)
        {
            InitializeComponent();
            txtHeader.Text = semester;
        }

        //add a course to the control
        public void AddCourse(string name)
        {
            if (name != null)
            {
                ListViewItem item = new ListViewItem();
                item.Content = name;
                this.CoursesListView.Items.Add(item);
            }
        }

        //remove a course from the control
        public void RemoveCourse(int index)
        {
            CoursesListView.Items.RemoveAt(index);
        }

        //clear the view
        public void Clear()
        {
            CoursesListView.Items.Clear();
        }

        //check and see if the course is being taken
        public bool ContainsCourse(string courseName)
        {
            foreach (ListViewItem item in CoursesListView.Items)
            {
                if (item.Content.ToString() == courseName)
                    return true;
            }
            return false;
        }

        public int MaxHours
        {
            get
            {
                try
                {
                    return Convert.ToInt32(txtMaxHours.Text);
                }

                catch
                {
                    return 0;
                }
            }
        }


        //check to see if a course is taken and not failed
        public bool ContainsCourseNotFail(string courseName)
        {
            foreach (ListViewItem item in CoursesListView.Items)
            {
                if (item.Content.ToString() == courseName && item.Background != Brushes.Red)
                    return true;
            }
            return false;
        }

        public void ResetSelected()
        {
            CoursesListView.SelectedItems.Clear();
        }
    }
}
