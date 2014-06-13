#include "degreeplanner.h"

DegreePlanner::DegreePlanner()
{

}

void DegreePlanner::FillDegreeList(DegreeList list, Degree degree, Semester semester, int semesterNo)
{
    int reqs = degree.GetRequirementCount();
    int elect = degree.GetElectiveCount();
    int total = reqs + elect;
}
