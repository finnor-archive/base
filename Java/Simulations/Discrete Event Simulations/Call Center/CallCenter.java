import java.util.Random;

public class CallCenter
{
  public static void main(String[] args)
  {
    
    Random gen = new Random(1);
    double[] cdfArr = {.25,.65,.85,1};
    double[] cdfAb = {.3,.58,.83,.1};
    double[] cdfBa = {.35,.6,.8,1};
    double temp;
    
    boolean able = true;
    boolean baker = true;
    int timeAFree = 0;
    int timeBFree = 0;
    int totalA = 0;
    int totalB = 0;
    int[] custArr = new int[400];
    
    temp = gen.nextDouble();  
    if (temp<cdfArr[0])
      custArr[0] = 1;
    else if (temp<cdfArr[1])
      custArr[0] = 2;
    else if (temp<cdfArr[2])
      custArr[0] = 3; 
    else 
      custArr[0] = 4;   
    
    for(int i=1;i<400;i++)
    {
      temp = gen.nextDouble();  
      if (temp<cdfArr[0])
        custArr[i] = 1 + custArr[i-1];
      else if (temp<cdfArr[1])
        custArr[i] = 2 + custArr[i-1];
      else if (temp<cdfArr[2])
        custArr[i] = 3 + custArr[i-1]; 
      else 
        custArr[i] = 4 + custArr[i-1];   
    }
    
    for(int i=0; i<400; i++)
    {
      temp = gen.nextDouble();  
      if (custArr[i]>=timeAFree)
        able = true;
      if (custArr[i]>=timeBFree)
        baker = true;
      
      if (able)
      {
        if (temp<cdfAb[0])
          timeAFree = 2 + custArr[i];
        else if (temp<cdfAb[1])
          timeAFree = 3 + custArr[i];
        else if (temp<cdfAb[2])
          timeAFree = 4 + custArr[i];
        else
          timeAFree = 5 + custArr[i];
        able = false;
        totalA++;
      }
      else if (baker)
      {
        if (temp<cdfBa[0])
          timeBFree = 3 + custArr[i];
        else if (temp<cdfBa[1])
          timeBFree = 4 + custArr[i];
        else if (temp<cdfBa[2])
          timeBFree = 5 + custArr[i];
        else
          timeBFree = 6 + custArr[i];
        baker = false;
        totalB++;
      }
      else if (timeAFree<=timeBFree)
      {
        if (temp<cdfAb[0])
          timeAFree += 2;
        else if (temp<cdfAb[1])
          timeAFree += 3;
        else if (temp<cdfAb[2])
          timeAFree += 4;
        else
          timeAFree += 5;
        totalA++;
      }
      else
      {
        if (temp<cdfBa[0])
          timeBFree += 3;
        else if (temp<cdfBa[1])
          timeBFree += 4;
        else if (temp<cdfBa[2])
          timeBFree += 5;
        else
          timeBFree += 6;
        totalB++;
      }
    }
    System.out.println("Able: " + totalA);
    System.out.println("Baker: " + totalB);
  }
}