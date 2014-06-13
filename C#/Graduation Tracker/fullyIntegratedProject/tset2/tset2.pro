#-------------------------------------------------
#
# Project created by QtCreator 2012-11-05T03:11:14
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = tset2
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \

    ../../Graduatenow/semester.cpp \
    ../../Graduatenow/elective.cpp \
    ../../Graduatenow/degreeplanner.cpp \
    ../../Graduatenow/degreelist.cpp \
    ../../Graduatenow/degree.cpp \
    ../../Graduatenow/course.cpp

HEADERS  += mainwindow.h \
    ../../Graduatenow/semester.h \
    ../../Graduatenow/elective.h \
    ../../Graduatenow/degreeplanner.h \
    ../../Graduatenow/degreelist.h \
    ../../Graduatenow/degree.h \
    ../../Graduatenow/course.h

FORMS    += mainwindow.ui

OTHER_FILES += \
    ../../../../Documents/class/Graduatenow/chargerhorse.emf \
    ../../../../Documents/class/Graduatenow/chargerhorse.png

RESOURCES += \
    resource.qrc
