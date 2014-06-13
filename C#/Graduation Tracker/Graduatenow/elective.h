#ifndef ELECTIVE_H
#define ELECTIVE_H
#include "course.h"
class Elective
{
private:
   static const int NAMELENGTH = 50;
public:
    Elective();
    Elective(char[NAMELENGTH]);
    bool ElectiveIsTaken();
     Course Courses[10];
     char Name[50];
};

#endif // ELECTIVE_H
