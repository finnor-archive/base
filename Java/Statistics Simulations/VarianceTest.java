import java.lang.Math;

public class VarianceTest
{
  public static void main(String[] args)
  {
    double variance = 0;
    
    
    for(double i=1; i<10; i++)
    {
      variance += ((i-2)*(i-2)*100*(Math.pow(0.5, i)));
      System.out.println(((i-2)*(i-2)*100*(Math.pow(0.5, i))));
    }
    
    variance = variance/100;
    
    System.out.println(variance);
  }
}