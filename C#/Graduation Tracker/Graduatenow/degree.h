#ifndef DEGREE_H
#define DEGREE_H
#include "elective.h"
#include "course.h"
#include "semester.h"

class Degree
{
private:
    static const int NAMELENGTH = 50;
    static const int MAXCOURSES = 20;
    static const int MAXSEMESTERS = 20;


public:
    Degree();
    Degree(char[NAMELENGTH]);
    Course RequiredCourses[MAXCOURSES];
    Elective Electives[MAXCOURSES];
    Semester Semesters[MAXSEMESTERS];
    char Name[NAMELENGTH];
    bool AddRequirement(Course course);
    bool AddElective(Elective elect);
    int GetRequirementCount();
    int GetElectiveCount();
    int RequirementCount;
    int ElectiveCount;
};

#endif // DEGREE_H
