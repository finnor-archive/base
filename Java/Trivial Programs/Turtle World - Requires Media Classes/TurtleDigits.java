/*
 * Adrian Flannery
 * adrianu2
 * Fall 2009 CS 201 Introduction to Object Oriented Programming
 * Homework-1 Problem 2
 */

import java.util.Scanner;

public class TurtleDigits
{
  public static void main(String[] args)
  {
    int input;
    
    Scanner scan = new Scanner(System.in);
    
    // asks user to input number to be drawn    
    System.out.print("Enter a number 0-9: ");
    input = scan.nextInt();
    

    World w = new World();
    Turtle t = new Turtle(w);

    // draws the number the user has selected
    switch(input)
    {
      case(0):
      {
        t.drawZero(t);
        break;
      }
      case (1):
      {
        t.drawOne(t);
        break;
      }
      case(2):
      {
        t.drawTwo(t);
        break;
      }
      case(3):
      {
        t.drawThree(t);
        break;
      }
      case(4):
      {
        t.drawFour(t);
        break;
      }
      case(5):
      {
        t.drawFive(t);
        break;
      }
      case(6):
      {
        t.drawSix(t);
        break;
      }
      case(7):
      {
        t.drawSeven(t);
        break;
      }
      case(8):
      {
        t.drawEight(t);
        break;
      }
      case(9):
      {
        t.drawNine(t);
        break;
      }
      
      // does not draw a number if user enters improper input
      default:
      {
        System.out.println("Wrong input.");
        break;
      }
    }
    t.hide();
  }
}