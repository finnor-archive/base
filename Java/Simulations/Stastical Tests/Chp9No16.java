public class Chp9No16
{
  public static void main (String[] args)
  {
    double[] data = {35, 40, 13, 6, 4, 1, 1};
    double[] expected = new double[data.length];
    double mean;
    double alpha;
    double temp = 0;
    double chi = 0;
    int fact = 1;
    
    /*
    for (int i=0; i<data.length; i++)
    {
      sum += (data[i]*i);
    }
    
    mean = sum/100;
    */
    
    mean = 1.0;
    alpha = 1/mean;
    
    for (int i=0; i<data.length; i++)
    {
      expected[i] = 100*(Math.pow(Math.E, -1*alpha)*Math.pow(alpha, i))/fact;
      temp = ((data[i]-expected[i])*(data[i]-expected[i]));
      chi += (temp/expected[i]);
      fact = fact*(i+1);
    }
    
    System.out.println("Alpha: " + alpha);
    System.out.println("Chi squared: " + chi);
  }
}