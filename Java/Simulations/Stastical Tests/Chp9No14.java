import java.util.Arrays;

public class Chp9No14
{
  public static void main (String[] args)
  {
    double[] data = {88.3, 40.7, 36.3, 27.3, 36.8,
      91.7, 67.3, 7.0, 45.2, 23.3,
      98.8, 90.1, 17.2, 23.7, 97.4,
      32.4, 87.8, 69.8, 62.6, 99.7,
      20.6, 73.1, 21.6, 6.0, 45.3,
      76.6, 73.2, 27.3, 87.6, 87.2};
    Arrays.sort(data);
    double max = data[data.length-1];
    double maxPlus = 0;
    double maxMinus = 0;
    double dTest;
    double temp;
    
    for (int i=1; i<=data.length; i++)
    {
      temp = (i/data.length) - (data[i-1]/max);
      if (temp>maxPlus)
        maxPlus=temp;
      
      temp = (data[i-1]/max) - ((i-1.0)/data.length);
      if (temp>maxMinus)
        maxMinus=temp;
    }
    
    if (maxPlus>maxMinus)
      dTest = maxPlus;
    else
      dTest = maxMinus;
    
    
    System.out.println("D: " + dTest);
  }
}