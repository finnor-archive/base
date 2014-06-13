#include "course.h"

Course::Course()
{
}

Course::Course(bool taken, int hours, char name[NAMELENGTH], int defaultSemester)
{
    Taken = taken;
    Hours = hours;
    for (int i = 0; i < NAMELENGTH; i++ )
    {
        Name[i]  = name[i];
    }
    DefaultSemester = defaultSemester;
}
