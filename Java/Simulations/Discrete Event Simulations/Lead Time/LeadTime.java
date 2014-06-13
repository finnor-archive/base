import java.util.Random;

public class LeadTime
{
  public static void main(String[] args)
  {
    double[] cdfO = {.2,.55,.85,1};
    double[] cdfN = {.25,.5,.75,1};
    double[] cdfLead = {.36,.78,1};
    Random gen = new Random(2);
    int sumO = 0;
    int sumN = 0;
    int iter;
    int tempDay;
    int[] demandsO = new int[16];
    int[] demandsN = new int[16];
    double temp;
    
    for(int i=0; i<400;i++)
    {
      temp = gen.nextDouble();
      if (temp<cdfLead[0])
        iter = 1;
      else if (temp<cdfLead[1])
        iter = 2;
      else
        iter = 3;
      tempDay=0;
      for(int j=0;j<iter;j++)
      {
        temp = gen.nextDouble();
        if (temp<cdfO[0])
          tempDay+=3;
        else if (temp<cdfO[1])
          tempDay+=4;
        else if (temp<cdfO[2])
          tempDay+=5;
        else
          tempDay+=6;
      }
      sumO+=tempDay;
      demandsO[tempDay-3]++;
    }
      
    for(int i=0; i<400;i++)
    {
      temp = gen.nextDouble();
      if (temp<cdfLead[0])
        iter = 1;
      else if (temp<cdfLead[1])
        iter = 2;
      else
        iter = 3;
      tempDay=0;
      for(int j=0;j<iter;j++)
      {
        temp = gen.nextDouble();
        if (temp<cdfN[0])
          tempDay+=3;
        else if (temp<cdfN[1])
          tempDay+=4;
        else if (temp<cdfN[2])
          tempDay+=5;
        else
          tempDay+=6;
      }
      sumN+=tempDay;
      demandsN[tempDay-3]++;
    }
    
    for(int i=0; i<16;i++)
    {
      System.out.println("Old lead time frequency " + (i+3) + ": " + demandsO[i]);
      System.out.println("New lead time frequency " + (i+3) + ": " + demandsN[i]+ "\n");
    }
    double avgO = ((double)sumO)/400;
    double avgN = ((double)sumN)/400;
    System.out.println("Old average: " + avgO + " " + sumO);
    System.out.println("New average: " + avgN + " " + sumN);
  }
}
    