#-------------------------------------------------
#
# Project created by QtCreator 2012-10-11T08:09:50
#
#-------------------------------------------------

QT       += core gui

TARGET = Graduatenow
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    degree.cpp \
    course.cpp \
    semester.cpp \
    elective.cpp \
    degreeplanner.cpp \
    degreelist.cpp

HEADERS  += mainwindow.h \
    degree.h \
    course.h \
    semester.h \
    elective.h \
    degreeplanner.h \
    degreelist.h

FORMS    += mainwindow.ui \
    dialog.ui \
    semesterDisplay.ui

RESOURCES += \
    UAHlogo.qrc
