/* Adrian Flannery
 * CS455
 * Programming Assignment 1 Part B
 * Program takes a seed for a random
 * number generator and flips a coin until
 * a head appears. This is repeated 100 times */

import java.util.Random;
import java.util.Scanner;
import java.lang.Math;
import java.util.LinkedList;

public class CoinFlip
{
  public static void main(String[] args)
  {
    int coin;
    int[] results = new int[11];
    double mean = 0;
    double variance = 0;
    double stdDev;
    int seed;
    boolean head;
    int place;
    LinkedList<Integer> greaterThanTen = new LinkedList();  //list to hold all values over 10
    Scanner scan = new Scanner(System.in);
    
    System.out.println("Enter a seed: ");
    seed = scan.nextInt();
    
    Random generator = new Random(seed);
    
    for (int i=0; i<100; i++)                 // 100 experiments
    {
      head = false;
      place = 0;
      while(!head)              //loop represents single experiment
      {
        
        coin = generator.nextInt(2);        //1=head; 0= tails
        if (coin == 1)
        {
          head = true;
          if (place>10)                 //if number of flips is greater than ten then place value in list
          {
            results[10]++;
            greaterThanTen.add((place+1));
          }
          else
            results[place]++; 
          
          mean+=(place+1);           // adds number of flips to calculate mean later
        }
        place++;
      }
    }
    
    mean = mean/100;       //calculates mean
    
    for(int i=0; i<10; i++)          //displays results and starts variance calculation
    {
      System.out.println((i+1) + ": " + results[i]);
      variance += ((mean-(i+1))*(mean-(i+1)) * results[i]);
    }
    System.out.println("Over 10: " + results[10]);
    
    while (greaterThanTen.size()!=0)         // continues calculation of variance for values over 10
    {
      place = greaterThanTen.removeFirst();
      variance += ((mean-(place))*(mean-(place)));
    }
    variance = variance/100;
    
    
    System.out.println("\nMean: " + mean);
    System.out.println("Variance: " + variance);
    
    stdDev = Math.sqrt(variance);
    System.out.println("Standard Deviation: " + stdDev);
    
    System.out.println("\nExpected variance: 2");
    System.out.println("Expected standard deviation: 1.4142135623730951"); 
    
  }
}