#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <Qt>
#include <QtGui>
#include <QtCore>
#include <QMainWindow>
#include <QListView>
#include <QStandardItemModel>
#include <degree.h>
#include "degreelist.h"
#include <Qt>
#include <QtGui>
#include <QtCore>
#include <QMainWindow>
#include <QListView>
#include <QStandardItemModel>


namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    
private slots:
    void GenerateSchedule();
    void button1Pressed();
    void btnGenSchedulePressed();

private:
    Ui::MainWindow *ui;
    QStandardItemModel *semester1;
     QStandardItemModel *semester2;
    void SetupMathDegree();
    Degree Math;
};

#endif // MAINWINDOW_H
