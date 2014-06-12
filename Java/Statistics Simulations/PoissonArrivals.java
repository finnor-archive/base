import java.util.Random;
import java.util.Scanner;
import java.lang.Math;

public class PoissonArrivals
{
  public static void main(String[] args)
  {
    int seed, numberWait;
    int arrivals = 0;
    double waitTime;
    double arrivalsDay = 0;
    double arrivalsTotal = 0;
    double overallTime = 0;
    boolean numNotFound;
    double lambda = 0.95;
    double e = Math.E;                     //e
    double rand;
    Scanner scan = new Scanner(System.in);
    
    
    
    System.out.println("Enter a seed: ");
    seed = scan.nextInt();
    System.out.println("lambda = " + lambda);
    Random generator = new Random(seed);
    
    for (int i=0; i<100; i++)               //loop through days
    {
      numberWait = 0;                      // 0 waiting at beginning of the day
      waitTime = 0;                        // wait time for day set to 0
      arrivalsDay = 0;
      for (int j=0; j<1000; j++)
      {
        numNotFound = true;
        waitTime += numberWait;
        rand = generator.nextDouble(); 
        for (int k=0; numNotFound; k++)
        {
          rand -= (Math.pow(e, -lambda) * (Math.pow(lambda, k)/factorial(k)));
          if (rand<=0)
          {
            arrivals = k;
            arrivalsDay += k;
            arrivalsTotal += k;
            numNotFound = false;
          }
        }
        
        numberWait += arrivals;
        if (numberWait > 0)
          numberWait--;
      }
      while (numberWait > 1)
      {
        numberWait--;
        waitTime += numberWait;
      }
      System.out.println("Day: " + (i+1) + "\tTime: " + (waitTime/arrivalsDay));
      overallTime += waitTime;
    }
    System.out.println("\nTotal: " + (overallTime/arrivalsTotal));    
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