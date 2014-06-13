#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::button1Pressed()
{
}

void MainWindow::btnGenSchedulePressed()
{
    //QListWidgetItem *temp =  ui->listMajor->currentItem();
   // QString text =  temp->text();

   // if (text == "Math")
   // {
    semester1 = new QStandardItemModel(0,0,this);
    semester2 = new QStandardItemModel(0,0,this);
   // QStandardItem *parentItem = semester1.invisibleRootItem();
   // for (int row = 0; row < 4; ++row) {
  //          QStandardItem *item = new QStandardItem(QString("fsdfjl").arg(row).arg(0));
  //          semester1->setItem(row, item);
   // }

    //for (int i = 0; i < )
    //int x = degree.RequirementCount;

    Degree *math = new Degree("Math");
    math->AddRequirement(Course(false, 3, "Cal A", 1));
    math->AddRequirement(Course(false, 3, "Cal B", 1));
    math->AddRequirement(Course(false, 3, "Linear", 2));
    math->AddRequirement(Course(false, 3, "DiffEQ", 2));
    for (int i = 0;i < math->RequirementCount; i++)
    {
        if (math->RequiredCourses[i].DefaultSemester==1)
        {
        QStandardItem *item1 = new QStandardItem(QString(math->RequiredCourses[i].Name).arg(i).arg(0));
         semester1->setItem(semester1->rowCount(), item1);
      }
        else

        {
            QStandardItem *item1 = new QStandardItem(QString(math->RequiredCourses[i].Name).arg(semester2->rowCount()).arg(0));
             semester2->setItem(semester2->rowCount(), item1);
        }
    }

   // QStandardItem *item1 = new QStandardItem(QString("Cal A").arg(0).arg(0));
   // semester1->setItem(0, item1);
   // QStandardItem *item2 = new QStandardItem(QString("Cal B").arg(1).arg(0));
  //  semester1->setItem(1, item2);
  /*  QStandardItem *item3 = new QStandardItem(QString("Eng 101").arg(2).arg(0));
    semester1->setItem(2, item3);
    QStandardItem *item4 = new QStandardItem(QString("Phys 101").arg(3).arg(0));
    semester1->setItem(3, item4);

    QStandardItem *item11 = new QStandardItem(QString("Linear").arg(0).arg(0));
    semester2->setItem(0, item11);
    QStandardItem *item21 = new QStandardItem(QString("Wester Civ").arg(1).arg(0));
    semester2->setItem(1, item21);
    QStandardItem *item31 = new QStandardItem(QString("Music Appreciation").arg(2).arg(0));
    semester2->setItem(2, item31);
    QStandardItem *item41 = new QStandardItem(QString("Art Appreciation").arg(3).arg(0));
    semester2->setItem(3, item41);
*/

    ui->lstSemester1->setModel(semester1);
     ui->lstSemester2->setModel(semester2);
}


void MainWindow::GenerateSchedule()
{
    //QListWidgetItem *temp =  ui->listMajor->currentItem();
   // QString text =  temp->text();

   // if (text == "Math")
   // {
    semester1 = new QStandardItemModel(6,0,this);
    semester2 = new QStandardItemModel(6,0,this);
   // QStandardItem *parentItem = semester1.invisibleRootItem();
   // for (int row = 0; row < 4; ++row) {
  //          QStandardItem *item = new QStandardItem(QString("fsdfjl").arg(row).arg(0));
  //          semester1->setItem(row, item);
   // }

    QStandardItem *item1 = new QStandardItem(QString("Cal A").arg(0).arg(0));
    semester1->setItem(0, item1);
    QStandardItem *item2 = new QStandardItem(QString("Cal B").arg(1).arg(0));
    semester1->setItem(1, item2);
    QStandardItem *item3 = new QStandardItem(QString("Eng 101").arg(2).arg(0));
    semester1->setItem(2, item3);
    QStandardItem *item4 = new QStandardItem(QString("Phys 101").arg(3).arg(0));
    semester1->setItem(3, item4);

    QStandardItem *item11 = new QStandardItem(QString("Linear").arg(0).arg(0));
    semester2->setItem(0, item11);
    QStandardItem *item21 = new QStandardItem(QString("Wester Civ").arg(1).arg(0));
    semester2->setItem(1, item21);
    QStandardItem *item31 = new QStandardItem(QString("Music Appreciation").arg(2).arg(0));
    semester2->setItem(2, item31);
    QStandardItem *item41 = new QStandardItem(QString("Art Appreciation").arg(3).arg(0));
    semester2->setItem(3, item41);

    ui->lstView1->setModel(semester1);
     ui->lstView2->setModel(semester2);
   /* ListModel {
         ListElement {
             name: "Bill Smith"
             number: "555 3264"
         }
         ListElement {
             name: "John Brown"
             number: "555 8426"
         }
         ListElement {
             name: "Sam Wise"
             number: "555 0473"
         }

    ListViewModel  ui->lstView1->model();*/
   // }
}
