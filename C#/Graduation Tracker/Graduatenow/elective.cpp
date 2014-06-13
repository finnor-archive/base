#include "elective.h"

Elective::Elective()
{

}

Elective::Elective(char name[])
{
    for (int i = 0; i < NAMELENGTH; i++ )
    {
        Name[i]  = name[i];
    }
}

bool Elective::ElectiveIsTaken()
{
    for (int i = 0; i < 10; i++)
    {
        if (Courses[i].Taken)
        {
            return true;
        }
    }
    return false;
}
