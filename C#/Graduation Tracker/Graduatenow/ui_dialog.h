/********************************************************************************
** Form generated from reading UI file 'dialog.ui'
**
** Created: Sat Nov 3 19:11:43 2012
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_DIALOG_H
#define UI_DIALOG_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QCheckBox>
#include <QtGui/QDialog>
#include <QtGui/QDialogButtonBox>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>

QT_BEGIN_NAMESPACE

class Ui_Dialog
{
public:
    QDialogButtonBox *buttonBox;
    QLabel *label;
    QCheckBox *checkBox;
    QLabel *label_2;

    void setupUi(QDialog *Dialog)
    {
        if (Dialog->objectName().isEmpty())
            Dialog->setObjectName(QString::fromUtf8("Dialog"));
        Dialog->resize(862, 358);
        Dialog->setStyleSheet(QString::fromUtf8("background-image: url(:/chargerhorse.png);"));
        buttonBox = new QDialogButtonBox(Dialog);
        buttonBox->setObjectName(QString::fromUtf8("buttonBox"));
        buttonBox->setGeometry(QRect(30, 240, 341, 32));
        buttonBox->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        buttonBox->setOrientation(Qt::Horizontal);
        buttonBox->setStandardButtons(QDialogButtonBox::Cancel|QDialogButtonBox::Help|QDialogButtonBox::Ok|QDialogButtonBox::Save);
        buttonBox->setCenterButtons(true);
        label = new QLabel(Dialog);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(0, 10, 131, 16));
        label->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        checkBox = new QCheckBox(Dialog);
        checkBox->setObjectName(QString::fromUtf8("checkBox"));
        checkBox->setGeometry(QRect(210, 10, 121, 17));
        checkBox->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));
        label_2 = new QLabel(Dialog);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(0, 40, 981, 151));
        label_2->setStyleSheet(QString::fromUtf8("color: rgb(255, 255, 255);"));

        retranslateUi(Dialog);

        QMetaObject::connectSlotsByName(Dialog);
    } // setupUi

    void retranslateUi(QDialog *Dialog)
    {
        Dialog->setWindowTitle(QApplication::translate("Dialog", "Dialog", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("Dialog", "MA 171-Calculus A", 0, QApplication::UnicodeUTF8));
        checkBox->setText(QApplication::translate("Dialog", "Select Class", 0, QApplication::UnicodeUTF8));
        label_2->setText(QApplication::translate("Dialog", "Associated Term: Fall 2012\n"
"Registration Dates: Apr 10, 2012 to Aug 28, 2012\n"
"Levels: Undergraduate\n"
"\n"
"Main Campus\n"
"Lecture Schedule Type\n"
"4.000 Credits\n"
"View Catalog Entry\n"
"\n"
"	Time 	Days 	Instructors\n"
"Class   8:00 am - 8:55 am 	MTWF 	Lanita G. Presson", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class Dialog: public Ui_Dialog {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_DIALOG_H
