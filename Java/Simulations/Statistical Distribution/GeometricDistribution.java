public class GeometricDistributionProblem
{
  public static void main(String[] args)
  {
    double mean = 2.5;
    double p = 1/3.5;
    double q = 1-p;
    double[] cdf = new double[10];
  
    cdf[0] = p;
    
    for(int i=1; i<cdf.length; i++)
    {
      cdf[i] = cdf[i-1] + (p*Math.pow(q, i));
    }
    
    System.out.prinln(cdf[9]);
    
    
  }
}