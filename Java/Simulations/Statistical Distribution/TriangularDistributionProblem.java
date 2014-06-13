import java.util.Random;

public class TriangularDistributionProblem
{
  public static void main (String[] args)
  {
    Random gen = new Random();
    double mean=0;
    double rand;
    double x;
    
    for (int i=0; i<1000; i++)
    {
      rand = gen.nextDouble();
      if (rand<.25)
        x = Math.sqrt(4*rand) + 2;
      else
        x = -1* Math.sqrt(-12*(rand-1)) + 6;
      mean += x;
      System.out.print(x + " | ");
    }
    mean = mean/1000;
    System.out.println("\nSample mean = " + mean);
    System.out.println("Expected mean = " + (2.0+3+6)/3);
  }
}