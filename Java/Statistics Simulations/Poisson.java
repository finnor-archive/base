import java.util.Random;
import java.util.Scanner;
import java.lang.Math;

public class Poisson
{
  public static void main(String[] args)
  {
    double temp;
    double previous = 0;
    double lambda = 3.2;                   //lambda
    double e = Math.E;                     //e
    int[] results = new int[20];           //20 random Poisson numbers
    double mean = 0;                       //mean
    double var=0;                          //variance
    int seed;                             
    boolean found = false;
    double[] cdf = new double[20];         //cumulative distribution function
    Scanner scan = new Scanner(System.in);
    
    System.out.println("Enter a seed: ");
    seed = scan.nextInt();
    
    Random generator = new Random(seed);
    for (int i=0; i<14; i++)
    {
      temp = Math.pow(e, -lambda) * (Math.pow(lambda, i)/factorial(i));
      cdf[i] = previous + temp;                             //produces the cumulative distribution function
      previous = cdf[i];                               
    }
    
    System.out.println("\n20 random numbers from Poisson(3.2): ");
    for (int i=0; i<20; i++)                           //generate 20 Poisson numbers
    {
      temp = generator.nextDouble();                      
      for (int j=0; !found; j++)                        
      {
        if (temp<=cdf[j])
        {
          found = true;
          results[i] = j;                              
          mean += j;                       //adds to sum for mean
          System.out.println(j);
        }
      }
      found = false;
    }
    
    
    mean = mean/20;
    System.out.println("Mean: " + mean);
    
    
    for (int i=0; i<20; i++)                          //calculates variance
    {
      var = (mean-results[i])*(mean-results[i]) + var;
    }
    var = var/20;
    
    System.out.println("Variance: " + var);
    System.out.println("Standard Deviation: " + Math.sqrt(var));
    
    System.out.println("\nExpected Mean: " + lambda);
    System.out.println("Expected Variance: " + lambda);
    System.out.println("Expected Standard Deviation: " + Math.sqrt(lambda));
    
  }
  
  public static int factorial(int x)            //generates a factorial
  {
    int fac=1;
    if (x==0)
      return(1);
    else
    {
      for (int i=1; i<=x; i++)
      {
        fac = fac*i;
      }
    }
    return(fac);
  }
}