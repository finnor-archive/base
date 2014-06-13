#include "degreelist.h"

DegreeList::DegreeList()
{
    Count = 0;
}

Degree DegreeList::GetDegree(int Number)
{
    return List[Number];
}

bool DegreeList::AddDegree(Degree degree)
{
    if (Count < MAXSIZE)
    {
        List[Count] = degree;
        Count++;
        return true;
    }

    return false;
}
