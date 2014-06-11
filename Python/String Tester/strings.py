def p():
  for x in range (1,101):
    print(x)


def testme(p,q,r):
  if q > 50:
    print r
  value = 10
  for i in range(1,p):
    print "Hello"
    value = value - 1
  print value
  print r


def newFunction(a, b, c):
  print a
  list1 = range(1,5)
  value = 0
  for x in list1:
    print b
    value = value + 1
  print c
  print value


def g():
  testme(5,51,"Hello back to you!")
  print "---------------------------------"
  newFunction("I","you","walrus")


def ex():
  s = "test"
  print s

  print s.capitalize()

  s = "AbCdEf"
  print s
  print s.swapcase()
  print s.upper()
  print s.lower()

  s = "this is a title"
  print s
  print s.title()

  s = "Hello"
  print s
  if s.isalpha():
    print s,  " is all alphabetic"
  else:
    print s, " is not all alphabetic"

  s = "Hello!"
  print s
  if s.isalpha():
    print s,  " is all alphabetic"
  else:
    print s, " is not all alphabetic"  

  s = "123456"
  if s.isdigit():
    print s , "is all digits"
  else:
    print s , "is not all digits"

  s = "123 456"  #contains a space
  if s.isdigit():
    print s , "is all digits"
  else:
    print s , "is not all digits"


