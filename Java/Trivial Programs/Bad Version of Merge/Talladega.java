/*
Adrian Flannery
adrianu2
Fall 2009 CS 201 Introduction to Object Oriented Programming
Homework-2 Problem 1
*/

import java.util.Scanner;

public class Talladega
{
  public static void main(String[] args)
  {
    int[] garage1 = new int[5];
    int[] garage2 = new int[5];
    int[] mergedOrder = new int[10];
    int placement=0;
    Scanner scan = new Scanner(System.in);
    
    //takes the numbers of the cars in garage 1
    System.out.print("Enter the order for garage 1: ");
    garage1[0] = scan.nextInt();
    garage1[1] = scan.nextInt();
    garage1[2] = scan.nextInt();
    garage1[3] = scan.nextInt();
    garage1[4] = scan.nextInt();
    
    //takes the numbers of the cars in garage 2
    System.out.print("Enter the order for garage 2: ");
    garage2[0] = scan.nextInt();
    garage2[1] = scan.nextInt();
    garage2[2] = scan.nextInt();
    garage2[3] = scan.nextInt();
    garage2[4] = scan.nextInt();
       
    
    // determines the position of an element of garage 1 in the merged array
    for(int i=0; i<garage1.length; i++)
    {
      // determines where an element fits against the other garage
      for(int j=0; j<garage2.length; j++)
      {
        if (garage1[i]>garage2[j])
          placement++;
      }
      // determines where an element fits against its own garage
      for(int k=0; k<garage1.length; k++)
      {
        if (garage1[i]>garage1[k])
          placement++;
      }
      // adjusts the order accounting for duplicate numbers
      for (int l=placement; mergedOrder[l]==garage1[i]; l++)
        placement++;
      mergedOrder[placement] = garage1[i];      
      placement=0;
    }
    
    // determines the position of an element of garage 2 in the merged array
    for(int i=0; i<garage2.length; i++)
    {
      // determines where an element fits against the other garage
      for(int j=0; j<garage1.length; j++)
      {
        if (garage2[i]>garage1[j])
          placement++;
      }
      // determines where an element fits against its own garage
      for(int k=0; k<garage2.length; k++)
      {
        if (garage2[i]>garage2[k])
          placement++;
      }
      // adjusts the order accounting for duplicate numbers
      for (int l=placement; mergedOrder[l]==garage2[i]; l++)
        placement++;
      mergedOrder[placement] = garage2[i];
      placement=0;
    }
    
     
    //displays the ordered array
    System.out.println("The final merged order is: ");
    for(int i=0; i<mergedOrder.length; i++)
    {
      System.out.print(mergedOrder[i] + " ");
    }
  }
}
 