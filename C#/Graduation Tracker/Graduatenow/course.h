#ifndef COURSE_H
#define COURSE_H

class Course
{
private:
    static const int NAMELENGTH = 50;

public:
    Course();

    Course(bool, int, char[NAMELENGTH], int);
    bool Taken;
    int DefaultSemester;
    char Name[NAMELENGTH];
    int Hours;
};

#endif // COURSE_H
