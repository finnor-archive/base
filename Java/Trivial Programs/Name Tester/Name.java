// *************************************************************
//   Adrian Flannery
//   Name.java
//   Uses classes to manipulate names
// *************************************************************

public class Name
{
 private String first;
 private String middle;
 private String last;
 private String initials;
 private String firstMiddleLast;
 private String lastFirstMiddle;
 private String fullName;
 private String fullName2;
 private int length;
 
  public Name (String firstName, String middleName, String lastName)
  {
    first = firstName;
    middle = middleName;
    last = lastName;
  }
    
  public String getFirst()
  {
    return first;
  }
  
  public String getMiddle()
  {
    return middle;
  }
  
  public String getLast()
  {
    return last;
  }
  
  public String firstMiddleLast()
  {
    firstMiddleLast = first + " " + middle + " " + last;
    return firstMiddleLast;
  }
  
  public String lastFirstMiddle()
  {
    lastFirstMiddle = last + ", " + first + " " + middle;
    return lastFirstMiddle;
  }
  
  public boolean equals (String name, String otherName)
  {
    fullName = name;
    fullName2 = otherName;
    return (fullName.equalsIgnoreCase(fullName2));
  }
      
    
  public String initials()
  {
    initials = (first.substring(0,1)) + (middle.substring(0,1)) + (last.substring(0,1));
    initials = initials.toUpperCase();
    return initials;
  }
  
  public int length()
  {
    fullName = firstMiddleLast();
    int length = (fullName.length()) - 2;
    return length;
  }
}
    