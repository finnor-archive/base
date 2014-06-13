import java.util.Random;

public class ExponentialDistributionProblem
{
  public static void main(String[] args)
  {
    double mean = 3.7;
    double lambda = 1/3.7;
    double[] cdf = new double[20];  
    double eToLam = Math.pow(Math.E, -lambda);
    cdf[19] = 1;             //limits the number of  possible demands to a reasonable amount
    Random gen = new Random();
    double sum=0;
    double temp, rand;
    
    for(int i=0; i<cdf.length-1; i++)
    {
      temp = Math.pow(Math.E, -lambda*i);
      cdf[i] = 1-(temp);
    }
    
    for(int i=0; i<5; i++)            //gives random number 5 times
    {
      rand = gen.nextDouble();
      for(int j =0; j<cdf.length; j++)          //traverses the cdf until it finds the right transform
      {
        if (rand<cdf[j])                    //transform found
        {
          System.out.println("Lead times " + (i+1) + ": " + j);
          sum+=j;
          j=cdf.length;                   //allows loop to go on to next number
        }
      }
    }
    
    System.out.println("\nMean lead times: " + sum/5);
    System.out.println("Expected mean: " + mean);
  }
}
          