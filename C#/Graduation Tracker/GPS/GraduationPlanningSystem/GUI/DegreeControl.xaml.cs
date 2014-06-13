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
    /// Interaction logic for DegreeControl.xaml
    /// </summary>
    public partial class DegreeControl : TabItem
    {
        //needed controls
        List<OneYearViews> mYearViews = new List<OneYearViews>();
        List<SemesterControl> mSemesters = new List<SemesterControl>();
        List<Course> mCoursesTaken = new List<Course>();
        Degree mDegree;
        GenerateSchedulesForm mParent;

        //make the views public 
        public List<OneYearViews> YearViews
        {
            get
            {
                return mYearViews;
            }
        }

        public string Title
        {
            set
            {
                TextBlock header = new TextBlock();
                header.Text = value;
                this.Header = header;
            }
        }

        /// <summary>
        /// goes through each control and populates teh semestesr,
        /// </summary>
        public List<Semester> Semesters
        {
            get
            {
                List<Semester> result = new List<Semester>();

                //goto through each view 
                foreach (OneYearViews view in YearViews)
                {
                    //and each semesters
                    foreach (SemesterControl control in view.Semesters)
                    {
                        if (control.Visibility != System.Windows.Visibility.Hidden)
                        {
                            Semester semester = new Semester();
                            semester.TotalAllowedHours = control.MaxHours;
                            foreach (Course course in control.CoursesTaken)
                            {

                                semester.Courses.Add(course);
                            }

                            result.Add(semester);
                        }
                    }
                }
                //return the completed semestesr
                return result;
            }
        }

        /// <summary>
        /// Contrscuro
        /// </summary>
        /// <param name="degree"></param>
        /// <param name="taken"></param>
        /// <param name="parent"></param>
        /// <param name="title"></param>
        public DegreeControl(Degree degree, List<Course> taken, GenerateSchedulesForm parent, string title)
        {
            InitializeComponent();
            mDegree = degree;
            mCoursesTaken = taken;
            LoadCourses(degree);
            mParent = parent;
            TextBlock header = new TextBlock();
            header.Text = title;
            this.Header = header;
        }

        /// <summary>
        /// Load the taken courses into the degree
        /// </summary>
        /// <param name="degree"></param>
        private void LoadCourses(Degree degree)
        {
            mSemesters.Clear();
            mYearViews.Clear();
            int year = 2013;
            for (int i = 0; i < degree.Semesters.Count; i++)
            {
                if ((i % 3) == 0)
                {
                    //add a new year every third semesrters.
                    
                    mYearViews.Add(new OneYearViews(year.ToString() + " - " + (year + 1).ToString()));
                    foreach (SemesterControl sem in mYearViews[i / 3].Semesters)
                    {
                        
                        mSemesters.Add(sem);
                    }
                    year++;
                }
                //place the courses corectly
                mYearViews[i / 3].Semesters[i % 3].txtMaxHours.Text = degree.Semesters[i].TotalAllowedHours.ToString();
                for (int j = 0; j < degree.Semesters[i].Courses.Count; j++)
                {

                    mYearViews[i / 3].Semesters[i % 3].AddCourse(degree.Semesters[i].Courses[j].Name);
                }
            }

            if (mSemesters.Count > degree.Semesters.Count)
            {
                for (int i = degree.Semesters.Count; i < mSemesters.Count; i++)
                {
                    mSemesters[i].Visibility = System.Windows.Visibility.Hidden;
                }
            }

            //register the clicks after createing the view
            foreach (OneYearViews view in mYearViews)
            {
                RegisterClicks(view);
                spMain.Children.Add(view);
            }
        }

        #region DragDropEvents

        private void RegisterClicks(OneYearViews view)
        {
            foreach (SemesterControl control in view.Semesters)
            {
                control.CoursesListView.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(lstCourses_PreviewMouseMove);
                control.CoursesListView.DragEnter += new System.Windows.DragEventHandler(lstCourses_DragEnter);
                control.CoursesListView.Drop += new System.Windows.DragEventHandler(lstCourses_Drop);
                control.CoursesListView.DragLeave += new System.Windows.DragEventHandler(lstCourses_DragLeave);
                control.CoursesListView.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(lstCourses_PreviewMouseLeftButtonDown);
                control.CoursesListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(CoursesListView_SelectionChanged);
            }
        }

        void CoursesListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SemesterControl control = GetSemesterControlFromListView(sender as System.Windows.Controls.ListView);
            int index = mSemesters.IndexOf(control);
            for (int i = 0; i < mSemesters.Count; i++)
            {
                if (i != index)
                {
                    mSemesters[i].CoursesListView.SelectionChanged -= CoursesListView_SelectionChanged;
                    //control.CoursesListView.SelectedItems.Clear();
                    mSemesters[i].CoursesListView.SelectedItems.Clear();
                    mSemesters[i].CoursesListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(CoursesListView_SelectionChanged);

                }
            }
            ListViewItem temp = control.CoursesListView.SelectedItem as ListViewItem;
            if (temp != null)
            {
                mParent.showCourseInfo(temp.Content.ToString());
            }
        }

        Point startPoint = new Point();
        ListViewItem mDraggedClass;
        ListView mDraggedParent;

        private void lstCourses_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                // Get the current mouse position
                Point mousePos = e.GetPosition(null);
                Vector diff = startPoint - mousePos;

                if (e.LeftButton == MouseButtonState.Pressed && (
                    Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    // Get the dragged ListViewItem
                    mDraggedParent = sender as ListView;
                    ListViewItem listViewItem =
                        FindAnchestor<ListViewItem>((DependencyObject)e.OriginalSource);

                    // Find the data behind the ListViewItem
                    ListViewItem contact = (ListViewItem)mDraggedParent.ItemContainerGenerator.
                        ItemFromContainer(listViewItem);
                    mDraggedClass = contact;
                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject("ListViewItem", contact);
                    DragDrop.DoDragDrop(listViewItem, dragData, System.Windows.DragDropEffects.Move);
                }
            }
            catch { }
        }

        // Helper to search up the VisualTree
        private static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void lstCourses_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("ListViewItem") ||
        sender == e.Source)
            {
                e.Effects = System.Windows.DragDropEffects.None;
            }
        }

        private SemesterControl GetSemesterControlFromListView(System.Windows.Controls.ListView view)
        {
            System.Windows.Controls.Grid hope = view.Parent as System.Windows.Controls.Grid;
            System.Windows.Controls.GroupBox hope2 = hope.Parent as System.Windows.Controls.GroupBox;
            return hope2.Parent as SemesterControl;
        }

        public bool Verify()
        {
            try
            {
                bool error = false;
                for (int i = 0; i < mSemesters.Count; i++)
                {
                    foreach (ListViewItem item in mSemesters[i].CoursesListView.Items)
                    {
                        if (CourseCanBeTaken(item.Content.ToString(), i) != "" && !(item.Background == Brushes.Red || item.Background == Brushes.Green))
                        {
                            error = true;
                            item.Background = Brushes.Yellow;
                        }
                        else if (item.Background == Brushes.Yellow)
                            item.Background = Brushes.White;
                    }

                }

                return error;
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void lstCourses_Drop(object sender, System.Windows.DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent("ListViewItem"))
                {
                    ListViewItem courseItem = e.Data.GetData("ListViewItem") as ListViewItem;
                    ListView listView = sender as ListView;
                    SemesterControl control = GetSemesterControlFromListView(listView);
                    int indexOf = mSemesters.IndexOf(control);
                    string course = CourseCanBeTaken(courseItem.Content.ToString(), indexOf);
                    if (course == "")
                    {
                        try
                        {
                            ListView parent1 = courseItem.Parent as ListView;
                            Expander parent2 = parent1.Parent as Expander;
                            ClassListUI parent3 = parent2.Parent as ClassListUI;

                            parent1.Items.Remove(courseItem);

                        }
                        catch
                        { 
                        //means it is another semester
                        }
                        listView.Items.Add(courseItem);
                        int end = mSemesters.IndexOf(control);

                        int start = mSemesters.IndexOf(GetSemesterControlFromListView(mDraggedParent));
                        if (Verify())
                        {
                            MessageBox.Show("Warning:  Degree now contains a schedule in which course(s) are taken before prerequisite.  Schedule may be impossible." + Environment.NewLine + 
                                    "Invalid course selections will be marked in yellow.");
                        }

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Course cannot be moved to that semester.  Prerequisite class " + course + " has not yet been taken.");
                        mDraggedParent.Items.Add(mDraggedClass);
                    }

                    // contact.Background = System.Windows.Media.Brushes.Aqua;
                }
            }
            catch { }
        }

        private bool CourseIsTaken(string courseName)
        {
            foreach (Course course in mCoursesTaken)
            {
                if (course.Name == courseName || Course.NumberToName(courseName) == course.Name)
                    return true;
            }

            return false;
        }

        private string CourseCanBeTaken(string courseName, int semesterNo)
        {
            Course course = new Course(courseName, Course.AcademicStatus.NotYetTaken);
            List<string> prereqs = course.Prereq;
            if (prereqs != null && prereqs.Count > 0)
            {
                
                if (prereqs.Count > 0)
                {
                    string pre = prereqs[0];
                    bool found = false;
                    if (!CourseIsTaken(pre))
                    {
                        string preName = Course.NumberToName(pre);
                        for (int i = 0; i < semesterNo; i++)
                        {
                            if (mSemesters[i].ContainsCourse(preName))
                            {
                                found = true;
                            }
                        }
                        if (!found)
                            return preName;
                    }
                }
            }
            return "";
        }

        private void lstCourses_DragLeave(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent("ListViewItem"))
            {
                ListViewItem contact = e.Data.GetData("ListViewItem") as ListViewItem;
                ListView listView = sender as ListView;
                listView.Items.Remove(contact);
            }
        }


        private void lstCourses_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Store the mouse position
            startPoint = e.GetPosition(null);
        }
        #endregion

        private void btnMarkFailed_Click(object sender, RoutedEventArgs e)
        {
            foreach (SemesterControl control in mSemesters)
            {
                if (control.CoursesListView.SelectedIndex > -1)
                {
                    ListViewItem item = control.CoursesListView.Items[control.CoursesListView.SelectedIndex] as ListViewItem;
                    item.Background = Brushes.Red;
                }
            }
        }

        private void btnMarkPassed_Click(object sender, RoutedEventArgs e)
        {
            foreach (SemesterControl control in mSemesters)
            {
                if (control.CoursesListView.SelectedIndex > -1)
                {
                    ListViewItem item = control.CoursesListView.Items[control.CoursesListView.SelectedIndex] as ListViewItem;
                    item.Background = Brushes.Green;
                }
            }
        }

        private void btnRemoveClass_Click(object sender, RoutedEventArgs e)
        {
            foreach (SemesterControl control in mSemesters)
            {
                if (control.CoursesListView.SelectedIndex > -1)
                {
                    
                    control.CoursesListView.Items.RemoveAt(control.CoursesListView.SelectedIndex);
                    
                }
            }
        }

        private void btnPreviouslyTakenClass_Click(object sender, RoutedEventArgs e)
        {
            foreach (SemesterControl control in mSemesters)
            {
                if (control.CoursesListView.SelectedIndex > -1)
                {
                    ListViewItem item = control.CoursesListView.Items[control.CoursesListView.SelectedIndex] as ListViewItem;
                    mParent.AddToTaken(item.Content.ToString());
                    control.CoursesListView.Items.RemoveAt(control.CoursesListView.SelectedIndex);
                }
            }
        }
    }
}
