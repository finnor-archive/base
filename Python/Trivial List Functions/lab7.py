header = """
Adrian Flannery
10/8/09
lab7.py

"""

print header
#***********************************************************************



#***********************************************************************
def print4 (listA):
    if type(listA[0]) == int:
        output = 0
        for index in range(len(listA)):
            output+=(listA[index] * 4)
    if type(listA[0]) == str:
        output = ""
        for index in range(len(listA)):
            output+=(listA[index]*4)
    print output
#***********************************************************************



#***********************************************************************
def itmGrThn2(listB):
    for i in listB:
        if len(i) > 2:
            print i
#***********************************************************************



#***********************************************************************
def doubleList(listC):
    for indexC in range(len(listC)):
        listD = listC[indexC]
        for indexD in range(len(listD)):
            listD[indexD] = listD[indexD] * 2
        listC[indexC] = listD
    print listC
#***********************************************************************



#***********************************************************************
question1 = """
***********************************************************************
Question 1:
Write a range function equivalent to each of the following outputs:

    * [0,1,2,3,4,5,6,7,8,9]
    * [1,3,5,7]
    * [10,8,6,4,2,0]
    * [2,4,6,8,10]
"""

answer1 = """
Answer 1:"""

print question1
print answer1

print "     range(10)"
print range (10)

print "     range (1,8,2)"
print range (1,8,2)

print "     range(10,-1,-2)"
print range (10,-1,-2)

print "     range(2,11,2)"
print range (2,11,2)
print"***********************************************************************"
#***********************************************************************



#***********************************************************************
question2 = """


***********************************************************************
Question 2:
Write a function that returns the following outputs given their corresponding inputs:
    Input	            Output
    ('a','b')	        'aaaabbbb'
    ('a','b','c')	    'aaaabbbbcccc'
    (2,3)             	20
    (2,3,4)           	36
"""

answer2 = """
Answer 2:
def print4 (listA):
    if type(listA[0]) == int:
        output = 0
        for index in range(len(listA)):
            output+=(listA[index] * 4)
    if type(listA[0]) == str:
        output = ""
        for index in range(len(listA)):
            output+=(listA[index]*4)
    print output



    """

print question2
print answer2

print "     print4(('a','b'))"
print4(('a','b'))

print "     print4(('a','b','c'))"
print4(('a','b','c'))

print "     print4((2,3))"
print4((2,3))

print "     print4((2,3,4))"
print4((2,3,4))
print "***********************************************************************"
#***********************************************************************



#***********************************************************************
question3 = """


***********************************************************************
Question 3: Write a function that traverses a list given as input and prints each element in the list if that element is a string of length greater than 2.
            """

answer3 = """
Answer 3:
def itmGrThn2(listB):
    for i in listB:
        if len(i) > 2:
            print i
***********************************************************************
            """

print question3
print answer3
#***********************************************************************



#***********************************************************************
question4 = """


***********************************************************************
Question 4:
Write a funtion that returns the following outputs given their corresponding inputs:
    Input	                         Output
    [[1, 2], [3, 4]]	             [[2, 4], [6, 8]]
    [['a', 'b'], ['c', 'd']] 	    [['aa', 'bb'], ['cc', 'dd']]
    """

answer4 = """
Answer 4:
def doubleList(listC):
    for indexC in range(len(listC)):
        listD = listC[indexC]
        for indexD in range(len(listD)):
            listD[indexD] = listD[indexD] * 2
        listC[indexC] = listD
    print listC

    
"""

print question4
print answer4

print "     doubleList([[1,2],[3,4]])"
doubleList([[1,2],[3,4]])
print "     doubleList([['a','b'],['c','d']])"
doubleList([['a','b'],['c','d']])
print "***********************************************************************"
