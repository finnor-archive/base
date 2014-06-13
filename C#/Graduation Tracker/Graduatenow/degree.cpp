#include "degree.h"

Degree::Degree()
{
    RequirementCount = 0;
    ElectiveCount = 0;
}

Degree::Degree(char name[])
{
    RequirementCount = 0;
    ElectiveCount = 0;

    for (int i = 0; i < NAMELENGTH; i++ )
    {
        Name[i]  = name[i];
    }
}

bool Degree::AddElective(Elective elective)
{
    if (ElectiveCount < MAXCOURSES)
    {
        Electives[ElectiveCount] = elective;
        ElectiveCount++;
         return true;
    }
    return false;
}


bool Degree::AddRequirement(Course course)
{
    if (RequirementCount < MAXCOURSES)
    {
        RequiredCourses[RequirementCount] = course;
        RequirementCount++;
         return true;
    }
    return false;
}

int Degree::GetElectiveCount()
{
    return ElectiveCount;
}

int Degree::GetRequirementCount()
{
    return RequirementCount;
}
