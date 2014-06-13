/********************************************************************************
** Form generated from reading UI file 'semesterDisplay.ui'
**
** Created: Sat Nov 3 19:11:43 2012
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_SEMESTERDISPLAY_H
#define UI_SEMESTERDISPLAY_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QDialog>
#include <QtGui/QDialogButtonBox>
#include <QtGui/QHeaderView>
#include <QtGui/QListView>

QT_BEGIN_NAMESPACE

class Ui_Dialog
{
public:
    QDialogButtonBox *buttonBox;
    QListView *lstSemester1;
    QListView *lstSemester2;
    QListView *lstSemester3;
    QListView *lstSemester4;

    void setupUi(QDialog *Dialog)
    {
        if (Dialog->objectName().isEmpty())
            Dialog->setObjectName(QString::fromUtf8("Dialog"));
        Dialog->resize(647, 454);
        buttonBox = new QDialogButtonBox(Dialog);
        buttonBox->setObjectName(QString::fromUtf8("buttonBox"));
        buttonBox->setGeometry(QRect(270, 390, 341, 32));
        buttonBox->setOrientation(Qt::Horizontal);
        buttonBox->setStandardButtons(QDialogButtonBox::Cancel|QDialogButtonBox::Ok);
        lstSemester1 = new QListView(Dialog);
        lstSemester1->setObjectName(QString::fromUtf8("lstSemester1"));
        lstSemester1->setGeometry(QRect(20, 10, 201, 151));
        lstSemester2 = new QListView(Dialog);
        lstSemester2->setObjectName(QString::fromUtf8("lstSemester2"));
        lstSemester2->setGeometry(QRect(350, 10, 201, 151));
        lstSemester3 = new QListView(Dialog);
        lstSemester3->setObjectName(QString::fromUtf8("lstSemester3"));
        lstSemester3->setGeometry(QRect(20, 200, 201, 151));
        lstSemester4 = new QListView(Dialog);
        lstSemester4->setObjectName(QString::fromUtf8("lstSemester4"));
        lstSemester4->setGeometry(QRect(360, 210, 201, 151));

        retranslateUi(Dialog);
        QObject::connect(buttonBox, SIGNAL(accepted()), Dialog, SLOT(accept()));
        QObject::connect(buttonBox, SIGNAL(rejected()), Dialog, SLOT(reject()));

        QMetaObject::connectSlotsByName(Dialog);
    } // setupUi

    void retranslateUi(QDialog *Dialog)
    {
        Dialog->setWindowTitle(QApplication::translate("Dialog", "Dialog", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class Dialog: public Ui_Dialog {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_SEMESTERDISPLAY_H
