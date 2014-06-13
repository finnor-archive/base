import java.util.Random;

public class Bank
{
  public static void main(String[] args)
  {
    Random gen = new Random(1);
    boolean someInQ = false;
    int current = 3;
    double temp;
    double[] cdfArr = {.09,.26,.53,.73,.88,1};
    double[] cdfSer = {.2,.6,.88,1};
    int[] custSer = new int[10];
    int[] custArr = new int[10];
    for(int i=1;i<10;i++)
    {
      temp = gen.nextDouble();
      if (temp<cdfSer[0])
        custSer[i] = 1;
      else if ((temp<cdfSer[1]))
        custSer[i] = 2;
      else if ((temp<cdfSer[2]))
        custSer[i] = 3; 
      else 
        custSer[i] = 4; 
     
      
      temp = gen.nextDouble();  
      if (temp<cdfArr[0])
        custArr[i] = 0;
      else if (temp<cdfArr[1])
        custArr[i] = 1;
      else if (temp<cdfArr[2])
        custArr[i] = 2; 
      else if (temp<cdfArr[3])
        custArr[i] = 3 ;
      else if (temp<cdfArr[4])
        custArr[i] = 4; 
      else 
        custArr[i] = 5;   
    }
    
    custSer[0]=3;
    custArr[0]=0;
    custArr[1]=0;
      
    
    int numToBeServed = 10;
    int custServed=1;
    int inside = 0;
    int timeSer = 3;
    int timeQu = 3;
    
    
    
    
    for (int i=1;i<10;i++)
    {
      current+=custArr[i];
      
      if (current>timeQu)
      {
        timeSer = current;
        timeQu = current;
        someInQ = false;
      }
        
      if (current<=timeSer)
      {
        if(someInQ)
          inside++;
        else
        {
          someInQ = true;
          custServed++;
          timeQu = timeSer + custSer[i];
        }
      }
      else
      {
        if(someInQ)
        {
          timeSer = timeQu;
          if (timeQu>=current)
            timeQu +=custSer[i];
          else
            timeQu = current + custSer[i];
          custServed++;
        }
        else
          timeSer = current + custSer[i];
      }
    }
          
    
    System.out.println("Customers that went inside: " + inside);
    System.out.println("Customers that were served: " + custServed);
        
          
      
    for(int i=0; i<10;i++)
    {
      System.out.print(custSer[i] + " " + custArr[i] + " ");
    }
    
    



      
  }
}