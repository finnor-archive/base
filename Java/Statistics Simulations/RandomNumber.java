/* Adrian Flannery
 * CS455
 * Programming Assignment 1 Part A
 * Program takes a seed for a random
 * number generator and generates
 * 20 random numbers [1.5-5.5), their mean,
 * and standard deviation */

import java.util.Random;
import java.util.Scanner;
import java.lang.Math;

public class RandomNumber
{
  public static void main(String[] args)
  {
    int integer;
    double floating;
    double[] numbers = new double[20];
    double mean = 0;
    double stdDev=0;
    int seed;
    Scanner scan = new Scanner(System.in);
    
    System.out.println("Enter a seed: ");
    seed = scan.nextInt();
    
    Random generator = new Random(seed);
    System.out.println("\n20 random numbers from 1.5 to 5.5: ");
    for (int i=0; i<20; i++)
    {
      integer = generator.nextInt(4);                        //generates the numbers
      floating = generator.nextDouble();
      numbers[i] = floating + integer + 1.5;
      mean+=numbers[i];                                      //sums the numbers
      System.out.println(numbers[i]);
    }
    mean = mean/20;                                   //generates the mean
    System.out.println("Mean: " + mean);
   
    for (int i=0; i<20; i++)
    {
      stdDev=((mean-numbers[i])*(mean-numbers[i])) + stdDev;         //computes the variance
    }
    stdDev = stdDev/20;
    stdDev = Math.sqrt(stdDev);                                     //computes the std dev
    System.out.println("Standard Deviation: " + stdDev);
  }
}