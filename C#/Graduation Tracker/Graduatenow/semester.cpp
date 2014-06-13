#include "semester.h"

Semester::Semester()
{
}

Semester::Semester(int max)
{
    TotalAllowedHours = max;
}

int Semester::GetTotalHours()
{
    int result = 0;

    for (int i = 0; i < 10; i++)
    {
        result = result + Courses[i].Hours;
    }

    return result;
}
