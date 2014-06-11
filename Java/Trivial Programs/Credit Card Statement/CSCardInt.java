/*
 * Adrian Flannery
 * adrianu2
 * Spring 2009 CS 201 Introduction to Object Oriented Programming
 * Homework-1 Problem 1
 */

import java.util.Scanner;
import java.text.NumberFormat;

public class CSCardInt
{
  public static void main(String[] args)
  {
    double previousBalance, newCharges, balance, interest;
    double minimumPayment = 0;
    
    Scanner scan = new Scanner(System.in);
    
    // asks user to input previous balance and new charges
    System.out.print("Enter the previous balance: ");
    previousBalance = scan.nextDouble();
    
    System.out.print("Enter the additional charges this month: ");
    newCharges = scan.nextDouble();
    
    
    // formats numbers for displaying monetary figures
    NumberFormat fmt1 = NumberFormat.getCurrencyInstance();
    
    
    // calculates interest
    if (previousBalance != 0)
      interest = ((previousBalance + newCharges)*0.02);
    else 
      interest = 0;

    balance = previousBalance + newCharges + interest;
    
    // calculates minimum payment
    if (balance < 50)
      minimumPayment = 0;
    if ((balance >= 50) && (balance <= 300))
      minimumPayment = 50;
    if (balance >300)
      minimumPayment = balance*0.2;
    
    
    // displays the statement
    System.out.println("CS Card International Statment");
    System.out.println("==============================");
    System.out.println("Previous balance:  \t" + fmt1.format(previousBalance));
    System.out.println("Additional Charges:\t" + fmt1.format(newCharges));
    System.out.println("Interest:          \t" + fmt1.format(interest));
    System.out.println("New Balance:       \t" + fmt1.format(balance));
    System.out.println("Minimum Payment:   \t" + fmt1.format(minimumPayment));    
  }
}
