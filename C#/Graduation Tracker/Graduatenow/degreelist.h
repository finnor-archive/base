#ifndef DEGREELIST_H
#define DEGREELIST_H
#include "degree.h"

class DegreeList
{
private:
    static const int MAXSIZE = 10000;
    Degree List[MAXSIZE];
    int Count;
public:
    DegreeList();
    Degree GetDegree(int Number);
    bool AddDegree(Degree degree);

};

#endif // DEGREELIST_H
