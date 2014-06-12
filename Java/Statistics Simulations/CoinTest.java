import java.lang.Math;

public class CoinTest
{
  public static void main(String[] args)
  {
    double[] results = new double[50];
    double mean = 0;
    double variance = 0;
    double stdDev;
    double expected = 50;
    
    for (int i=0; i<50; i++)
    {
      results[i] = expected;
      mean += (expected * (i+1));
      expected = expected * 0.5;
    }
    
    mean = mean/100;
    
    for(int i=0; i<49; i++)
    {
      System.out.println((i+1) + ": " + results[i]);
      variance += ((mean-(i+1))*(mean-(i+1)) * results[i]);
    }
    System.out.println("Over 50: " + results[49]);
    System.out.println("\nMean: " + mean);
    
    variance += ((mean-(51))*(mean-(51)) * results[49]);
    variance = variance/100;
    
    System.out.println("Variance: " + variance);
    if (results[49] > 0)
      System.out.println("Values over 10 are estimated as 12.");  //since 12 is the expected case over 10
    
    stdDev = Math.sqrt(variance);
    System.out.println("Standard Deviation: " + stdDev);
    
  }
}