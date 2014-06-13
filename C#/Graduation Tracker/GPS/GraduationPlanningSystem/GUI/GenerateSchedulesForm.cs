using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Forms.in
using GraduationPlanningSystem.Data_Objects;
//using GraduationPlanningSystem.GUI;
using System.Windows.Forms.Integration;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WPF = System.Windows.Controls;
using WPFMedia = System.Windows.Media;

namespace GraduationPlanningSystem
{
    //largest gui in the proejct
    public partial class GenerateSchedulesForm : Form
    {
        //Working degree
        private Degree mDegree;

        //courses taken list
        private List<Course> mCoursesTaken;

        //views
        private List<OneYearViews> mYearViews = new List<OneYearViews>();
        private List<SemesterControl> mSemesters = new List<SemesterControl>();
        //pass/fail colores
        private WPFMedia.Brush mFailedColor = WPFMedia.Brushes.Red;
        private WPFMedia.Brush mPassedColor = WPFMedia.Brushes.Green;
        //list of classes not taken
        ClassListUI uiClassList;
        //ui of the degree
        List<DegreeControl> mDegreeControls = new List<DegreeControl>();
        //our tabs
        private System.Windows.Controls.TabControl mTabs;

        DBClass mDb;

        //contructor
        public GenerateSchedulesForm(String degreeType, Degree degree, DBClass db)
        {
            InitializeComponent();
            //setup the class list
            uiClassList = new ClassListUI(this);
            this.elementHost3.Child = uiClassList;
            mDb = db;
            //setup the degree and taken list
            mDegree = degree;
            // removes classes taken from the default schedule

            mCoursesTaken = degree.TakenCourses;
            uiClassList.SetTakenClass(mCoursesTaken);
           // RegisterClicks();
            //add the degree control to the tab

            while (mDegree.Semesters.Count < mDegree.MaxSemesters)
            {
                mDegree.Semesters.Add(new Semester());
            }

            DegreeControl page = new DegreeControl(mDegree, mCoursesTaken, this, "Default");
            mTabs = new System.Windows.Controls.TabControl();
            mTabs.Items.Add(page);
            elementHost1.Child = mTabs;
            mTabs.SelectionChanged += new WPF.SelectionChangedEventHandler(mTabs_SelectionChanged);
            uiClassList.lstElectives.SelectionChanged += new WPF.SelectionChangedEventHandler(lstElectives_SelectionChanged);
            //UpdateCourseList(mDegree, control);
            //mDegreeControls.Add(control);

            List<string> codes = db.GetDegreeCodes();
            this.cmboDegreeSwitch.Items.Clear();
            foreach (string code in codes)
            {
                cmboDegreeSwitch.Items.Add(code);
            }
            
        }

        //on sleection, show replacements
        void lstElectives_SelectionChanged(object sender, WPF.SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ListViewItem item = uiClassList.lstElectives.SelectedItem as System.Windows.Controls.ListViewItem;
            if (item != null)
            ShowReplacementsFromElective(item.Content.ToString());
            
        }

        //on tab change, show the new populated lists
        void mTabs_SelectionChanged(object sender, WPF.SelectionChangedEventArgs e)
        {
            PopulateLists();
        }

        //show the replacement classes
        private void ShowReplacements(string courseName)
        {

            //uiClassList.lstElectives.Items.Clear();
            foreach (Elective elective in mDegree.ElectiveCourses)
            {
                foreach (Course course in elective.Courses)
                {
                    if (course.Name == courseName)
                    {
                        uiClassList.SetReplacement(elective.Courses);
                        return;
                    }
                }

            }
        }

        //show the replacement classes
        private void ShowReplacementsFromElective(string electiveName)
        {

            //uiClassList.lstElectives.Items.Clear();
            foreach (Elective elective in mDegree.ElectiveCourses)
            {
                if (electiveName.Contains(elective.Name))
                {
                    uiClassList.SetReplacement(elective.Courses);
                    return;
                }
            }
        }

       

        // displays the course information for the selected course
        public void showCourseInfo(String myCourse)
        {
            try
            {
                ShowReplacements(myCourse);
                lstBoxReplacements.Items.Clear();                 //since new selection has been made, the replacement courses box is cleared in case it wasn't empty
                DataTable result = GraduationPlanningSystem.db.find(myCourse, "course");
                DataRow[] rows = result.Select();
                Object[] rowArray = rows[0].ItemArray;
                txtBoxCourseTitle.Text = (String)rowArray[1];
                txtBoxUID.Text = (String)rowArray[0];
                txtBoxCourseNumber.Text = (String)rowArray[2];
                txtBoxDepartment.Text = (String)rowArray[4];
                txtBoxHours.Text = (String)(rowArray[3].ToString());
                txtBoxSemester.Text = (String)rowArray[9];
          

            //empties the prereq/coreq/precoreq boxes
            lstBoxPrereqs.DataSource = null;
            lstBoxCoreqs.DataSource = null;
            lstBoxPreCoreqs.DataSource = null;
            lstBoxPrereqs.Items.Clear();
            lstBoxCoreqs.Items.Clear();
            lstBoxPreCoreqs.Items.Clear();


            //the information needed for prereqs/coreqs/precoreqs must be parsed from the database
            String entry = (String)rowArray[5];
            if (entry.Equals(""))
                lstBoxPrereqs.Items.Add("No prereqs");
            else
            {
                List<String> preReqs = ParseGPS.parseReqs(entry);
                lstBoxPrereqs.DataSource = preReqs;

            }

            entry = (String)rowArray[6];
            if (entry.Equals(""))
                lstBoxCoreqs.Items.Add("No coreqs");
            else
            {
                List<String> coReqs = ParseGPS.parseReqs(entry);
                lstBoxCoreqs.DataSource = coReqs;
            }

            entry = (String)rowArray[7];
            if (entry.Equals(""))
                lstBoxPreCoreqs.Items.Add("No pre/coreqs");
            else
            {
                List<String> preCoReqs = ParseGPS.parseReqs(entry);
                lstBoxPreCoreqs.DataSource = preCoReqs;
            }
            }
            catch { }
        }

        //add class to the taken list
        public void AddToTaken(string course)
        {
            mCoursesTaken.Add(new Course(course, Course.AcademicStatus.Pass));
            uiClassList.TakenAdd(course);
        }

        //displays classes that can replace the one selected when button was clicked.
        private void btnFindReplacement_Click(object sender, EventArgs e)
        {
            if (txtBoxUID.Text.Equals("MA00171"))
            {
                lstBoxReplacements.Items.Add("No Valid Replacements");
            }
            if (txtBoxUID.Text.Equals("HY00101"))
            {
                //placeholder code.... deprecated
                lstBoxReplacements.Items.Add("Meet Reqs And Can Replace");
                lstBoxReplacements.Items.Add("\tWorld History to 1500");
                lstBoxReplacements.Items.Add("");
                lstBoxReplacements.Items.Add("Do Not Meet Reqs");
                lstBoxReplacements.Items.Add("\tWestern Civ II");
                lstBoxReplacements.Items.Add("\tWorld History since 1500");
                lstBoxReplacements.Items.Add("");
                lstBoxReplacements.Items.Add("Cannot Be Added This Semester");
                lstBoxReplacements.Items.Add("\tSpring/Summer Only History Req");
            }
        }

        //mark a class as taken
        private void btnMarkTaken_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();

            ListViewItem.ListViewSubItem llvi = new ListViewItem.ListViewSubItem();
            llvi.Text = "back";
        }

        public void AddCourseToTakenList(string course)
        { 
            mCoursesTaken.Add(new Course(course, Course.AcademicStatus.Pass));
        }

        //generate the schedules
        private void btnGenerateSchedules_Click(object sender, EventArgs e)
        {
            int schedulesToGen = 0;

            try
            {
                schedulesToGen = Convert.ToInt32(txtGenSchedules.Text);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Unable to parse request.  Please designate a number of schedules " +
                    "between 1 and 10.");
            }
            if (schedulesToGen > 0 && schedulesToGen <= 10)
            {
                Degree copy = mDegree.Clone();
                {
                    copy.Semesters.Clear();
                    // PlanPage selected = (PlanPage)tabControl1.SelectedTab;
                    //TODO
                    DegreeControl control = (DegreeControl)mTabs.Items[mTabs.SelectedIndex];
                    control.Title = "Model";
                    mTabs.Items.Clear();
                    mTabs.Items.Add(control);
                    copy.Semesters = control.Semesters;

                  
                }

               
                DegreePlanner planner = new DegreePlanner();
                
                    copy.TakenCourses = uiClassList.GetTakenList();

                    List<Degree> generated = planner.GenerateSchedules(copy, schedulesToGen);

                    int success = 0;
                    for (int i = 0; i < generated.Count; i++)
                    {
                        bool grad = true;
                        generated[i].Name = ((i + 1).ToString()); //nk

                        DegreeControl control = new DegreeControl(generated[i], mCoursesTaken, this, (i + 1).ToString());
                        control.Verify();
                        mTabs.Items.Add(control);
                        //tabControl1.TabPages.Add(new PlanPage(temp, mCoursesTaken, this)); //nk
                        //tabControl1.TabPages[i + 1].Text = (i + 1).ToString(); //nk
                        
                        Degree checkGrad = generated[i].Clone();
                        checkGrad.Semesters = generated[i].Semesters;

                        //Check for graduation on requirements
                        foreach (Course course in checkGrad.RequiredCourses)
                        {
                            //check all semesters and the Taken list
                            if (checkGrad.SemesterCourseTaken(course.UID).Count == 0 && !CourseIsTaken(course.Name))
                                grad = false;
                        }

                        //Check for graduation of electives
                        foreach (Elective elective in checkGrad.ElectiveCourses)
                        {
                            elective.RemainingHours = checkGrad.ElectiveBeingTaken(elective);
                            if (checkGrad.ElectiveBeingTaken(elective) > (Int64)0)
                            {
                                grad = false;
                            }
                        }

                        if (grad)
                            success++;

                        
                    }

                    System.Windows.Forms.MessageBox.Show(schedulesToGen.ToString() + " schedules were successfully generated." + Environment.NewLine + Environment.NewLine + 
                                                            success.ToString() + " schedules resulted in graduation! "
                      );
                //  tabControl1.TabPages.Add(new PlanPage());
            }
            else
            { 
                
            }
        }

        
        //populat teh required, taken, elective, and replacement classes
        private void PopulateLists()
        {
            List<Course> required = new List<Course>();
            List<Elective> electives = new List<Elective>();
            if (mTabs.SelectedIndex > -1)
            {
                DegreeControl control = (DegreeControl)mTabs.Items[mTabs.SelectedIndex];
                Degree clone = mDegree.Clone();
                clone.Semesters = control.Semesters;

                foreach (Course course in clone.RequiredCourses)
                {
                    //check all semesters and the Taken list
                    if (clone.SemesterCourseTaken(course.UID).Count == 0 && !CourseIsTaken(course.Name))
                        required.Add(course);
                }

                uiClassList.SetRequirements(required);

                foreach (Elective elective in clone.ElectiveCourses)
                {
                    elective.RemainingHours = clone.ElectiveBeingTaken(elective);
                    if (clone.ElectiveBeingTaken(elective) > (Int64)0)
                    {
                        electives.Add(elective);
                        
                    }
                }
                uiClassList.SetElectives(electives);
            }
        }


        //mark the class as failed
        private void btnMarkFailed_Click(object sender, EventArgs e)
        {
            foreach (SemesterControl control in mSemesters)
            {
                if (control.CoursesListView.SelectedIndex > -1)
                {
                    WPF.ListViewItem item = control.CoursesListView.Items[control.CoursesListView.SelectedIndex] as WPF.ListViewItem;
                    item.Background = mFailedColor;
                }
            }
        }

        //close the program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //save the degree out
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.gps)|GPS";
            openFileDialog1.AddExtension = true;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Degree degree = mDegree.Clone();
                degree.Semesters.Clear();
                DegreeControl control = (DegreeControl)mTabs.Items[mTabs.SelectedIndex];
                degree.Semesters = control.Semesters;
                degree.TakenCourses = uiClassList.GetTakenList();


                XMLSerializer.SerializeDegreeToXML(degree, openFileDialog1.FileName + ".gps");
            }
        }

        //
        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\" ;
            openFileDialog1.Filter = "txt files (*.gps)|*gps|All files (*.*)|*.*" ;
            openFileDialog1.FilterIndex = 2 ;
            openFileDialog1.RestoreDirectory = true ;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Degree degree = XMLSerializer.DeserializeXMLToDegree(openFileDialog1.FileName);

                mCoursesTaken = degree.TakenCourses;
                mDegree = degree;
                uiClassList.SetTakenClass(mCoursesTaken);
                // RegisterClicks();
                //add the degree control to the tab

                while (mDegree.Semesters.Count < mDegree.MaxSemesters)
                {
                    mDegree.Semesters.Add(new Semester());
                }

                DegreeControl page = new DegreeControl(mDegree, mCoursesTaken, this, "Default");
                mTabs.Items.Clear();
                mTabs.Items.Add(page);
              
                //this.RegCourses(degree);
            }
        }

        /// <summary>
        /// junk code, deprecated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewEditClasses_Click(object sender, EventArgs e)
        {
            

            if (cmboDegreeSwitch.SelectedIndex >= 0)
        {
            System.Windows.Forms.MessageBox.Show("Be aware:  switching Majors may result in certain classes not being counted towards " +
            "earning your degree.  Some majors may have different grade requirements.  Be sure to seek help with " +
            "an advisor regarding your program of study.");

            string degreeName = mDb.GetDegreeFromCode(cmboDegreeSwitch.SelectedItem.ToString());
            Degree degree = Degree.LoadDegree(mDb, degreeName);
                

            
            mDegree.RequiredCourses.Clear();
            mDegree.ElectiveCourses.Clear();

            mDegree.RequiredCourses = degree.RequiredCourses;
            mDegree.ElectiveCourses = degree.ElectiveCourses;
            PopulateLists();
        }

            #region Deprecated

            //else if (cmboDegreeSwitch.SelectedIndex == 1)
            //{
            //    mDegree.RequiredCourses.Clear();
            //    mDegree.ElectiveCourses.Clear();
            //    Degree temp = Degree.LoadCPE(mDb);
            //    mDegree.RequiredCourses = temp.RequiredCourses;
            //    mDegree.ElectiveCourses = temp.ElectiveCourses;
            //    PopulateLists();       
            //}

            //else if (cmboDegreeSwitch.SelectedIndex == 2)
            //{
            //    mDegree.RequiredCourses.Clear();
            //    mDegree.ElectiveCourses.Clear();
            //    Degree temp = Degree.LoadOPE(mDb);
            //    mDegree.RequiredCourses = temp.RequiredCourses;
            //    mDegree.ElectiveCourses = temp.ElectiveCourses;
            //    PopulateLists();
            //}

            #endregion
        }

        /// <summary>
        /// grabs teh ee requiremtns, deprecated to be generic
        /// </summary>
        /// <returns></returns>
        private List<Course> EERequirements()
        {
            List<Course> result = new List<Course>();

            return result;
        }

        //on load do nothing...
        private void GenerateSchedulesForm_Load(object sender, EventArgs e)
        {
            //ElementHost host = new ElementHost();
            //OneYearViews wpfcontrol = new OneYearViews();

            //host.Controls.Add((UserControl)wpfcontrol);
            //host.Dock = DockStyle.Fill;
            //this.Controls.Add(host);
        }

        #region DragDropEvents

        private void RegisterClicks(ClassListUI view)
        {
            foreach (System.Windows.Controls.ListView control in view.ListViews)
            {
                control.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(lstCourses_PreviewMouseMove);
                control.DragEnter += new System.Windows.DragEventHandler(lstCourses_DragEnter);
                control.DragLeave += new System.Windows.DragEventHandler(lstCourses_DragLeave);
                control.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(lstCourses_PreviewMouseLeftButtonDown);
            }
        }

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
        }

        System.Windows.Point startPoint = new System.Windows.Point();
        System.Windows.Controls.ListViewItem mDraggedClass;
        System.Windows.Controls.ListView mDraggedParent;

        private void lstCourses_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                // Get the current mouse position
                System.Windows.Point mousePos = e.GetPosition(null);
                Vector diff = startPoint - mousePos;

                if (e.LeftButton == MouseButtonState.Pressed && (
                    Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    // Get the dragged ListViewItem
                    mDraggedParent = sender as System.Windows.Controls.ListView;
                    System.Windows.Controls.ListViewItem listViewItem =
                        FindAnchestor<System.Windows.Controls.ListViewItem>((DependencyObject)e.OriginalSource);

                    // Find the data behind the ListViewItem
                    System.Windows.Controls.ListViewItem contact = (System.Windows.Controls.ListViewItem)mDraggedParent.ItemContainerGenerator.
                        ItemFromContainer(listViewItem);
                    mDraggedClass = contact;
                    // Initialize the drag & drop operation
                    System.Windows.DataObject dragData = new System.Windows.DataObject("System.Windows.Controls.ListViewItem", contact);
                    System.Windows.DragDrop.DoDragDrop(listViewItem, dragData, System.Windows.DragDropEffects.Move);
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
            if (!e.Data.GetDataPresent("System.Windows.Controls.ListViewItem") ||
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

        private void lstCourses_Drop(object sender, System.Windows.DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent("System.Windows.Controls.ListViewItem"))
                {
                    System.Windows.Controls.ListViewItem semester = e.Data.GetData("System.Windows.Controls.ListViewItem") as System.Windows.Controls.ListViewItem;
                    System.Windows.Controls.ListView listView = sender as System.Windows.Controls.ListView;
                    SemesterControl control = GetSemesterControlFromListView(listView);
                    int indexOf = mSemesters.IndexOf(control);
                    string course = CourseCanBeTaken(semester.Content.ToString(), indexOf);
                    if ( course == "")
                    {
                        listView.Items.Add(semester);
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

        private bool CourseIsBeingTaken(string courseName, DegreeControl plan)
        {
            foreach (OneYearViews year in plan.YearViews)
            {
                foreach (SemesterControl control in year.Semesters)
                {
                    if (control.ContainsCourseNotFail(courseName))
                        return true;
                }
            }

                return false;
            }

        private bool CourseIsTaken(string courseName)
        {
            foreach (Course course in mCoursesTaken)
            {
                if (course.Name == courseName)
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
                foreach (string pre in prereqs)
                {
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
            return "" ;
        }

        private void lstCourses_DragLeave(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Controls.ListViewItem"))
            {
                System.Windows.Controls.ListViewItem contact = e.Data.GetData("System.Windows.Controls.ListViewItem") as System.Windows.Controls.ListViewItem;
                System.Windows.Controls.ListView listView = sender as System.Windows.Controls.ListView;
                listView.Items.Remove(contact);
            }
        }


        private void lstCourses_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Store the mouse position
            startPoint = e.GetPosition(null);
        }
        #endregion

        private void elementHost1_ChildChanged(object sender, ChildChangedEventArgs e)
        {

        }

        private void elementHost3_ChildChanged(object sender, ChildChangedEventArgs e)
        {

        }
    }
}
