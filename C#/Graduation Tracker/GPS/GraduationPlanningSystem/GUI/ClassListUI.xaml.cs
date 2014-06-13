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
    /// Interaction logic for ClassListUI.xaml
    /// </summary>
    public partial class ClassListUI : StackPanel
    {
        GenerateSchedulesForm mParent;

        /// <summary>
        /// Make the lists public so others may access
        /// </summary>
        public List<ListView> ListViews
        {
            get 
            {
                List<ListView> result = new List<ListView>();

                result.Add(lstElectives);
                result.Add(lstReplacementClasses);
                result.Add(lstRequiredClasses);
                result.Add(lstTakenClasses);
                return result;
            }
        }

        /// <summary>
        /// Constructor.  Parent is required for some event operations.
        /// </summary>
        /// <param name="parent"></param>
        public ClassListUI(GenerateSchedulesForm parent)
        {
            InitializeComponent();
            mParent = parent;
            RegisterClicks();
        }

        public List<Course> GetTakenList()
        {
            List<Course> result = new List<Course>();

            for (int i = 0; i < lstTakenClasses.Items.Count; i++)
            {
                ListViewItem item = lstTakenClasses.Items[i] as ListViewItem;
                result.Add( new Course(item.Content.ToString(), Course.AcademicStatus.NotYetTaken));
            }

            return result;
        }

        /// <summary>
        /// Add a list of courses to the ui.
        /// </summary>
        /// <param name="list">list of courses that will be that have already  been taken that semester.</param>
        public void SetTakenClass (List<Course> list)
        {
            //clear the list first.
            this.lstTakenClasses.Items.Clear();
            foreach (Course course in list)
            {
                ListViewItem item = new ListViewItem();
                item.Content = course.Name;
                this.lstTakenClasses.Items.Add(item);
            }
        }

        //add class to be taken.
        public void TakenAdd(string course)
        {
            ListViewItem item = new ListViewItem();
            item.Content = course;
            this.lstTakenClasses.Items.Add(item);
        }

        /// <summary>
        /// Set requiremetns list
        /// </summary>
        /// <param name="list"></param>
        public void SetRequirements(List<Course> list)
        {
            //clear list first.
            this.lstRequiredClasses.Items.Clear();
            foreach (Course course in list)
            {
                ListViewItem item = new ListViewItem();
                item.Content = course.Name;
                this.lstRequiredClasses.Items.Add(item);
            }
        }

        /// <summary>
        /// Add a list of courses to the ui.
        /// </summary>
        public void SetReplacement(List<Course> list)
        {
            //clear first
            lstReplacementClasses.Items.Clear();
            foreach (Course course in list)
            {
                ListViewItem item = new ListViewItem();
                item.Content = course.Name;
                this.lstReplacementClasses.Items.Add(item);
            }
        }

        /// <summary>
        /// Add a list of courses to the ui.
        /// </summary>
        public void SetElectives(List<Elective> list)
        {
            //clear first
            lstElectives.Items.Clear();
            foreach (Elective elec in list)
            {
                ListViewItem item = new ListViewItem();
                item.Content = elec.Name + " - " + elec.RemainingHours.ToString() + " Hrs";
                this.lstElectives.Items.Add(item);
            }
        }


             #region DragDropEvents
        /// <summary>
        /// registre all the events for each lsitview
        /// </summary>
        private void RegisterClicks()
        {
   
            lstTakenClasses.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(lstCourses_PreviewMouseMove);
            lstTakenClasses.DragEnter += new System.Windows.DragEventHandler(lstCourses_DragEnter);
            lstTakenClasses.Drop += new System.Windows.DragEventHandler(lstCourses_Drop);
            lstTakenClasses.DragLeave += new System.Windows.DragEventHandler(lstCourses_DragLeave);
            lstTakenClasses.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(lstCourses_PreviewMouseLeftButtonDown);
            lstTakenClasses.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(CoursesListView_SelectionChanged);


            lstRequiredClasses.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(lstCourses_PreviewMouseMove);
            lstRequiredClasses.DragEnter += new System.Windows.DragEventHandler(lstCourses_DragEnter);
            lstRequiredClasses.Drop += new System.Windows.DragEventHandler(lstCourses_Drop);
            lstRequiredClasses.DragLeave += new System.Windows.DragEventHandler(lstCourses_DragLeave);
            lstRequiredClasses.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(lstCourses_PreviewMouseLeftButtonDown);
            lstRequiredClasses.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(CoursesListView_SelectionChanged);

            lstReplacementClasses.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(lstCourses_PreviewMouseMove);
            lstReplacementClasses.DragEnter += new System.Windows.DragEventHandler(lstCourses_DragEnter);
            lstReplacementClasses.Drop += new System.Windows.DragEventHandler(lstCourses_Drop);
            lstReplacementClasses.DragLeave += new System.Windows.DragEventHandler(lstCourses_DragLeave);
            lstReplacementClasses.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(lstCourses_PreviewMouseLeftButtonDown);
            lstReplacementClasses.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(CoursesListView_SelectionChanged);

            //lstElectives.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(lstCourses_PreviewMouseMove);
            lstElectives.DragEnter += new System.Windows.DragEventHandler(lstCourses_DragEnter);
            lstElectives.Drop += new System.Windows.DragEventHandler(lstCourses_Drop);
            //lstElectives.DragLeave += new System.Windows.DragEventHandler(lstCourses_DragLeave);
            //lstElectives.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(lstCourses_PreviewMouseLeftButtonDown);
            lstElectives.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(CoursesListView_SelectionChanged);
           
        }

        void lstElectives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

     

        private void lstCourses_Drop(object sender, System.Windows.DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent("ListViewItem"))
                {
                    ListViewItem semester = e.Data.GetData("ListViewItem") as ListViewItem;
                    ListView listView = sender as ListView;
                    SemesterControl control = GetSemesterControlFromListView(listView);
                    //int indexOf = mSemesters.IndexOf(control);
                    //string course = CourseCanBeTaken(semester.Content.ToString(), indexOf);
                    //if (course == "")
                    //{
                    //    listView.Items.Add(semester);
                    //    int end = mSemesters.IndexOf(control);

                    //    int start = mSemesters.IndexOf(GetSemesterControlFromListView(mDraggedParent));
                    //    if (start < end)
                    //        Verify(start, end);
                    //    else
                    //        Verify(end, start);
                    //}
                    //else
                    //{
                    //    System.Windows.Forms.MessageBox.Show("Course cannot be moved to that semester.  Prerequisite class " + course + " has not yet been taken.");
                    //    mDraggedParent.Items.Add(mDraggedClass);
                    //}

                    // contact.Background = System.Windows.Media.Brushes.Aqua;
                }
            }
            catch { }
        }

        /// <summary>
        /// on select change, update teh coure info displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CoursesListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ListView control = (sender as System.Windows.Controls.ListView);
            
            ListViewItem temp = control.SelectedItem as ListViewItem;
            if (temp != null)
            {
                mParent.showCourseInfo(temp.Content.ToString());
            }
        }

        Point startPoint = new Point();
        ListViewItem mDraggedClass;
        ListView mDraggedParent;

        /// <summary>
        /// on mouse move, check if we need to grab an item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
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

        /// <summary>
        /// on drag enter set up the effects as needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstCourses_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("ListViewItem") ||
        sender == e.Source)
            {
                e.Effects = System.Windows.DragDropEffects.None;
            }
        }

        /// <summary>
        /// pulls all the semesters taken from teh list
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        private SemesterControl GetSemesterControlFromListView(System.Windows.Controls.ListView view)
        {
            System.Windows.Controls.Grid hope = view.Parent as System.Windows.Controls.Grid;
            System.Windows.Controls.GroupBox hope2 = hope.Parent as System.Windows.Controls.GroupBox;
            return hope2.Parent as SemesterControl;
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


        private void btnRemoveCourse_Click(object sender, RoutedEventArgs e)
        {
            if (lstTakenClasses.SelectedIndex >= 0)
            { 
                lstTakenClasses.Items.RemoveAt(lstTakenClasses.SelectedIndex);
            }
        }
    }
}
