public class PoissonDistributionProblem
{
  public static void main(String[] args)
  {
    double lambda = 2.5;
    double[] cdf = new double[20];  
    double eToLam = Math.pow(Math.E, -lambda)
    cdf[0] = eToLam;
    cdf[19] = 1;             //limits the number of  possible demands to a reasonable amount
    double[] rand = {0.94737, 0.08225, 0.35614, 0.24826, 0.88319, 0.05595, 0.58701, 0.57365, 0.74759, 0.87259};
    double sum=0;
    double fact = 1;
    double temp;
    
    for(int i=1; i<cdf.length-1; i++)
    {
      temp = Math.pow(lamda, i);
      fact = fact*i;
      cdf[i] = (temp/fact)*eToLam;
    }
    
    for(int i=0; i<rand.length; i++)            //traverses the list of random numbers
    {
      for(int j =0; j<cdf.length; j++)          //traverses the cdf until it finds the right transform
      {
        if (rand[i]<cdf[j])                    //transform found
        {
          System.out.println("Weekly demand " + (i+1) + ": " + j);
          sum+=j;
          j=cdf.length;                   //allows loop to go on to next number
        }
      }
    }
    
    System.out.println("\nMean demand: " + (sum/10));
    System.out.println("Expected mean: " + mean);
  }
}
          