def sqrt (n):
 approx = n/2.0
 better = (approx + n/approx)/2.0
 while better != approx:
    print better
    approx = better
    better = (approx + n/approx)/2.0

sqrt(25)

