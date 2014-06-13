#ifndef DEGREEPLANNER_H
#define DEGREEPLANNER_H

#include "course.h"
#include "degree.h"
#include "semester.h"
#include "elective.h"
#include "degreelist.h"

class DegreePlanner
{
public:
    DegreePlanner();
    void FillDegreeList(DegreeList list, Degree degree, Semester semester, int semesterNo);
};

#endif // DEGREEPLANNER_H
