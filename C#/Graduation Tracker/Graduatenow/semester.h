#ifndef SEMESTER_H
#define SEMESTER_H
#include "course.h"

class Semester
{
public:
    Semester();
    Semester(int);
    Course Courses[10];
    int TotalAllowedHours;
    int GetTotalHours();

};

#endif // SEMESTER_H
