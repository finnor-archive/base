import java.util.Random;

public class NormalDistributionProblem
{
  public static void main (String[] args)
  {
    Random gen = new Random();
    double mean=0;
    double r1, r2;
    double temp;
    double z1, z2;
    int[] frequencies = new int[10];
    double x1, x2;
    
    for (int i=0; i<500; i++)
    {
      r1 = gen.nextDouble();
      r2 = gen.nextDouble();
      temp = Math.sqrt(-2*Math.log(r1));
      z1 = temp*Math.cos(2*Math.PI*r2);
      z2 = temp*Math.cos(2*Math.PI*r2);
      
      if (z1<=-4)
        frequencies[0]++;
      else if (z1<=-3)
        frequencies[1]++;
      else if (z1<=-2)
        frequencies[2]++;
      else if (z1<=-1)
        frequencies[3]++;
      else if (z1<=0)
        frequencies[4]++;
      else if (z1<=1)
        frequencies[5]++;
      else if (z1<=2)
        frequencies[6]++;
      else if (z1<=3)
        frequencies[7]++;
      else if (z1<=4)
        frequencies[8]++;
      else
        frequencies[9]++;
      
      
      if (z2<=-4)
        frequencies[0]++;
      else if (z2<=-3)
        frequencies[1]++;
      else if (z2<=-2)
        frequencies[2]++;
      else if (z2<=-1)
        frequencies[3]++;
      else if (z2<=0)
        frequencies[4]++;
      else if (z2<=1)
        frequencies[5]++;
      else if (z2<=2)
        frequencies[6]++;
      else if (z2<=3)
        frequencies[7]++;
      else if (z2<=4)
        frequencies[8]++;
      else
        frequencies[9]++;
        
      System.out.print(z1 + " | " + z2 + " | ");
    }
    
    double[] prob = new double[10];
    for(int i=0; i<frequencies.length; i++)
    {
      for (int j=0; j<=i; j++)
       prob[i] += frequencies[j];
      prob[i] = prob[i]/1000;
    }
    
    System.out.println("\n\nSample Frequencies: \t<=-4 \t<=-3 \t<=-2 \t<=-1 \t<=0 \t<=1 \t<=2 \t<=3 \t<=4 \t>4");
    System.out.print("\t\t");
    for (int i=0; i<frequencies.length; i++)
    {
      System.out.print(prob[i] + "\t");
    }
    
    System.out.println("\n\nExpected Frequencies: ");
    System.out.println("\t\t" + 0.00003 + "\t" + 0.00135 + "\t" + 0.02275 + "\t" + 0.15866 + "\t" + 0.5 + "\t" 
                         + 0.84134 + "\t" + 0.97725 + "\t" + 0.99865 + "\t" + 0.99997 + "\t" + 1.0);
  }
}