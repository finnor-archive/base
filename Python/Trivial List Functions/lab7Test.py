#listC = [[1,2],[3,4]]
listC = [['a','b'],['c','d']]

def doublelist(listC):
    for indexC in range(len(listC)):
        listD = listC[indexC]
        for indexD in range(len(listD)):
            listD[indexD] = listD[indexD] * 2
        listC[indexC] = listD
    print listC

doublelist(listC)
