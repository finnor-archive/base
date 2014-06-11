// *************************************************************
//   Adrian Flannery
//   TestNames.java
//   Tests the name.java class
// *************************************************************

import java.util.Scanner;

public class TestNames
{
    public static void main (String[] args)
    {
      String first, middle, last, first2, middle2, last2, fullName, fullName2;
      Scanner scan = new Scanner(System.in);
      
      System.out.print("Enter first name: ");
      first = scan.nextLine();      
      System.out.print("Enter middle name: ");
      middle = scan.nextLine();      
      System.out.print("Enter last name: ");
      last = scan.nextLine();
      
      System.out.print("Enter another first name: ");
      first2 = scan.nextLine();      
      System.out.print("Enter another middle name: ");
      middle2 = scan.nextLine();      
      System.out.print("Enter another last name: ");
      last2 = scan.nextLine();
            
      Name name = new Name (first, middle, last);
      Name name2 = new Name (first, middle, last);
      
      fullName = first+middle+last;
      fullName2 = first2+middle2+last2;
      
      System.out.println("First-Middle-Last: " + name.firstMiddleLast());
      System.out.println("Last-First-Middle: " + name.lastFirstMiddle());
      System.out.println("Initials: " + name.initials());
      System.out.println("Length of name: " + name.length());
      if (name.equals(fullName, fullName2))
        System.out.print("Names are the same");
      else
        System.out.print("Names are not the same");
    }
}