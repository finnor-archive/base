/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created: Thu Nov 8 00:51:46 2012
**      by: Qt User Interface Compiler version 4.8.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QCheckBox>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QListView>
#include <QtGui/QListWidget>
#include <QtGui/QMainWindow>
#include <QtGui/QMenu>
#include <QtGui/QMenuBar>
#include <QtGui/QPushButton>
#include <QtGui/QStatusBar>
#include <QtGui/QToolBar>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralWidget;
    QLabel *label;
    QLabel *label_2;
    QLabel *label_3;
    QLabel *label_4;
    QCheckBox *checkBox;
    QCheckBox *checkBox_2;
    QCheckBox *checkBox_3;
    QCheckBox *checkBox_4;
    QListWidget *listWidget;
    QListWidget *listWidget_2;
    QListWidget *listWidget_3;
    QListWidget *listWidget_4;
    QPushButton *pushButton;
    QPushButton *btnGenerateSchedule;
    QListView *lstSemester1;
    QListView *lstSemester2;
    QMenuBar *menuBar;
    QMenu *menuPlan_to_Graduate;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QString::fromUtf8("MainWindow"));
        MainWindow->resize(580, 546);
        MainWindow->setStyleSheet(QString::fromUtf8("background-color: rgb(0, 0, 255);\n"
"selection-color: rgb(255, 0, 0);\n"
"\n"
"background-image: url(:/chargerhorse.png);"));
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QString::fromUtf8("centralWidget"));
        label = new QLabel(centralWidget);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(0, 10, 101, 16));
        label->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        label_2 = new QLabel(centralWidget);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(0, 60, 81, 16));
        label_2->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        label_3 = new QLabel(centralWidget);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(0, 110, 121, 16));
        label_3->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        label_4 = new QLabel(centralWidget);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setGeometry(QRect(0, 170, 111, 16));
        label_4->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        checkBox = new QCheckBox(centralWidget);
        checkBox->setObjectName(QString::fromUtf8("checkBox"));
        checkBox->setGeometry(QRect(0, 220, 70, 17));
        checkBox->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        checkBox_2 = new QCheckBox(centralWidget);
        checkBox_2->setObjectName(QString::fromUtf8("checkBox_2"));
        checkBox_2->setGeometry(QRect(90, 220, 70, 17));
        checkBox_2->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        checkBox_3 = new QCheckBox(centralWidget);
        checkBox_3->setObjectName(QString::fromUtf8("checkBox_3"));
        checkBox_3->setGeometry(QRect(180, 220, 70, 17));
        checkBox_3->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        checkBox_4 = new QCheckBox(centralWidget);
        checkBox_4->setObjectName(QString::fromUtf8("checkBox_4"));
        checkBox_4->setGeometry(QRect(270, 220, 70, 17));
        checkBox_4->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        listWidget = new QListWidget(centralWidget);
        new QListWidgetItem(listWidget);
        new QListWidgetItem(listWidget);
        new QListWidgetItem(listWidget);
        new QListWidgetItem(listWidget);
        listWidget->setObjectName(QString::fromUtf8("listWidget"));
        listWidget->setGeometry(QRect(0, 30, 101, 21));
        listWidget->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        listWidget_2 = new QListWidget(centralWidget);
        new QListWidgetItem(listWidget_2);
        new QListWidgetItem(listWidget_2);
        new QListWidgetItem(listWidget_2);
        new QListWidgetItem(listWidget_2);
        new QListWidgetItem(listWidget_2);
        listWidget_2->setObjectName(QString::fromUtf8("listWidget_2"));
        listWidget_2->setGeometry(QRect(0, 80, 101, 21));
        listWidget_2->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        listWidget_3 = new QListWidget(centralWidget);
        new QListWidgetItem(listWidget_3);
        new QListWidgetItem(listWidget_3);
        new QListWidgetItem(listWidget_3);
        new QListWidgetItem(listWidget_3);
        new QListWidgetItem(listWidget_3);
        listWidget_3->setObjectName(QString::fromUtf8("listWidget_3"));
        listWidget_3->setGeometry(QRect(0, 130, 101, 21));
        listWidget_3->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        listWidget_4 = new QListWidget(centralWidget);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        new QListWidgetItem(listWidget_4);
        listWidget_4->setObjectName(QString::fromUtf8("listWidget_4"));
        listWidget_4->setGeometry(QRect(0, 190, 101, 21));
        listWidget_4->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        pushButton = new QPushButton(centralWidget);
        pushButton->setObjectName(QString::fromUtf8("pushButton"));
        pushButton->setGeometry(QRect(0, 250, 75, 23));
        pushButton->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        btnGenerateSchedule = new QPushButton(centralWidget);
        btnGenerateSchedule->setObjectName(QString::fromUtf8("btnGenerateSchedule"));
        btnGenerateSchedule->setGeometry(QRect(110, 250, 75, 23));
        btnGenerateSchedule->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        lstSemester1 = new QListView(centralWidget);
        lstSemester1->setObjectName(QString::fromUtf8("lstSemester1"));
        lstSemester1->setGeometry(QRect(30, 290, 256, 192));
        lstSemester2 = new QListView(centralWidget);
        lstSemester2->setObjectName(QString::fromUtf8("lstSemester2"));
        lstSemester2->setGeometry(QRect(300, 290, 256, 192));
        MainWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MainWindow);
        menuBar->setObjectName(QString::fromUtf8("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 580, 21));
        menuPlan_to_Graduate = new QMenu(menuBar);
        menuPlan_to_Graduate->setObjectName(QString::fromUtf8("menuPlan_to_Graduate"));
        menuPlan_to_Graduate->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        MainWindow->setMenuBar(menuBar);
        mainToolBar = new QToolBar(MainWindow);
        mainToolBar->setObjectName(QString::fromUtf8("mainToolBar"));
        MainWindow->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(MainWindow);
        statusBar->setObjectName(QString::fromUtf8("statusBar"));
        MainWindow->setStatusBar(statusBar);

        menuBar->addAction(menuPlan_to_Graduate->menuAction());

        retranslateUi(MainWindow);
        QObject::connect(pushButton, SIGNAL(clicked()), MainWindow, SLOT(button1Pressed()));
        QObject::connect(btnGenerateSchedule, SIGNAL(clicked()), MainWindow, SLOT(btnGenSchedulePressed()));

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "MainWindow", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("MainWindow", "Select School Year", 0, QApplication::UnicodeUTF8));
        label_2->setText(QApplication::translate("MainWindow", "Select Major", 0, QApplication::UnicodeUTF8));
        label_3->setText(QApplication::translate("MainWindow", "Graduation Time Frame", 0, QApplication::UnicodeUTF8));
        label_4->setText(QApplication::translate("MainWindow", "Hours Per Semester", 0, QApplication::UnicodeUTF8));
        checkBox->setText(QApplication::translate("MainWindow", "MWF", 0, QApplication::UnicodeUTF8));
        checkBox_2->setText(QApplication::translate("MainWindow", "TR", 0, QApplication::UnicodeUTF8));
        checkBox_3->setText(QApplication::translate("MainWindow", "MW", 0, QApplication::UnicodeUTF8));
        checkBox_4->setText(QApplication::translate("MainWindow", "MTWTFS", 0, QApplication::UnicodeUTF8));

        const bool __sortingEnabled = listWidget->isSortingEnabled();
        listWidget->setSortingEnabled(false);
        QListWidgetItem *___qlistwidgetitem = listWidget->item(0);
        ___qlistwidgetitem->setText(QApplication::translate("MainWindow", "2013", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem1 = listWidget->item(1);
        ___qlistwidgetitem1->setText(QApplication::translate("MainWindow", "2014", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem2 = listWidget->item(2);
        ___qlistwidgetitem2->setText(QApplication::translate("MainWindow", "2015", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem3 = listWidget->item(3);
        ___qlistwidgetitem3->setText(QApplication::translate("MainWindow", "2016", 0, QApplication::UnicodeUTF8));
        listWidget->setSortingEnabled(__sortingEnabled);


        const bool __sortingEnabled1 = listWidget_2->isSortingEnabled();
        listWidget_2->setSortingEnabled(false);
        QListWidgetItem *___qlistwidgetitem4 = listWidget_2->item(0);
        ___qlistwidgetitem4->setText(QApplication::translate("MainWindow", "Math", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem5 = listWidget_2->item(1);
        ___qlistwidgetitem5->setText(QApplication::translate("MainWindow", "Engineering", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem6 = listWidget_2->item(2);
        ___qlistwidgetitem6->setText(QApplication::translate("MainWindow", "English", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem7 = listWidget_2->item(3);
        ___qlistwidgetitem7->setText(QApplication::translate("MainWindow", "History", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem8 = listWidget_2->item(4);
        ___qlistwidgetitem8->setText(QApplication::translate("MainWindow", "Biology", 0, QApplication::UnicodeUTF8));
        listWidget_2->setSortingEnabled(__sortingEnabled1);


        const bool __sortingEnabled2 = listWidget_3->isSortingEnabled();
        listWidget_3->setSortingEnabled(false);
        QListWidgetItem *___qlistwidgetitem9 = listWidget_3->item(0);
        ___qlistwidgetitem9->setText(QApplication::translate("MainWindow", "12 months", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem10 = listWidget_3->item(1);
        ___qlistwidgetitem10->setText(QApplication::translate("MainWindow", "18 months", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem11 = listWidget_3->item(2);
        ___qlistwidgetitem11->setText(QApplication::translate("MainWindow", "24 months", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem12 = listWidget_3->item(3);
        ___qlistwidgetitem12->setText(QApplication::translate("MainWindow", "30 months", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem13 = listWidget_3->item(4);
        ___qlistwidgetitem13->setText(QApplication::translate("MainWindow", "36 months", 0, QApplication::UnicodeUTF8));
        listWidget_3->setSortingEnabled(__sortingEnabled2);


        const bool __sortingEnabled3 = listWidget_4->isSortingEnabled();
        listWidget_4->setSortingEnabled(false);
        QListWidgetItem *___qlistwidgetitem14 = listWidget_4->item(0);
        ___qlistwidgetitem14->setText(QApplication::translate("MainWindow", "0", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem15 = listWidget_4->item(1);
        ___qlistwidgetitem15->setText(QApplication::translate("MainWindow", "1", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem16 = listWidget_4->item(2);
        ___qlistwidgetitem16->setText(QApplication::translate("MainWindow", "2", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem17 = listWidget_4->item(3);
        ___qlistwidgetitem17->setText(QApplication::translate("MainWindow", "3", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem18 = listWidget_4->item(4);
        ___qlistwidgetitem18->setText(QApplication::translate("MainWindow", "4", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem19 = listWidget_4->item(5);
        ___qlistwidgetitem19->setText(QApplication::translate("MainWindow", "5", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem20 = listWidget_4->item(6);
        ___qlistwidgetitem20->setText(QApplication::translate("MainWindow", "6", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem21 = listWidget_4->item(7);
        ___qlistwidgetitem21->setText(QApplication::translate("MainWindow", "7", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem22 = listWidget_4->item(8);
        ___qlistwidgetitem22->setText(QApplication::translate("MainWindow", "8", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem23 = listWidget_4->item(9);
        ___qlistwidgetitem23->setText(QApplication::translate("MainWindow", "9", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem24 = listWidget_4->item(10);
        ___qlistwidgetitem24->setText(QApplication::translate("MainWindow", "10", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem25 = listWidget_4->item(11);
        ___qlistwidgetitem25->setText(QApplication::translate("MainWindow", "11", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem26 = listWidget_4->item(12);
        ___qlistwidgetitem26->setText(QApplication::translate("MainWindow", "12", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem27 = listWidget_4->item(13);
        ___qlistwidgetitem27->setText(QApplication::translate("MainWindow", "13", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem28 = listWidget_4->item(14);
        ___qlistwidgetitem28->setText(QApplication::translate("MainWindow", "14", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem29 = listWidget_4->item(15);
        ___qlistwidgetitem29->setText(QApplication::translate("MainWindow", "15", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem30 = listWidget_4->item(16);
        ___qlistwidgetitem30->setText(QApplication::translate("MainWindow", "16", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem31 = listWidget_4->item(17);
        ___qlistwidgetitem31->setText(QApplication::translate("MainWindow", "17", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem32 = listWidget_4->item(18);
        ___qlistwidgetitem32->setText(QApplication::translate("MainWindow", "18", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem33 = listWidget_4->item(19);
        ___qlistwidgetitem33->setText(QApplication::translate("MainWindow", "19", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem34 = listWidget_4->item(20);
        ___qlistwidgetitem34->setText(QApplication::translate("MainWindow", "20", 0, QApplication::UnicodeUTF8));
        QListWidgetItem *___qlistwidgetitem35 = listWidget_4->item(21);
        ___qlistwidgetitem35->setText(QApplication::translate("MainWindow", "21", 0, QApplication::UnicodeUTF8));
        listWidget_4->setSortingEnabled(__sortingEnabled3);

        pushButton->setText(QApplication::translate("MainWindow", "Get Options", 0, QApplication::UnicodeUTF8));
        btnGenerateSchedule->setText(QApplication::translate("MainWindow", "Gen", 0, QApplication::UnicodeUTF8));
        menuPlan_to_Graduate->setTitle(QApplication::translate("MainWindow", "WELCOME TO UAH GRADUATION PLANNING SYSTEM", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
