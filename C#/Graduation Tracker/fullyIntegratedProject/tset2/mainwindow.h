#ifndef MAINWINDOW_H
#define MAINWINDOW_H
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



private:
    Ui::MainWindow *ui;
    QStandardItemModel *semester1;
     QStandardItemModel *semester2;
};

#endif // MAINWINDOW_H
