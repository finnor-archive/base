import java.util.Arrays;

public class Chp9No19
{
  public static void main (String[] args)
  {
    double[] data = {92.3, 92.8, 106.8, 108.9, 106.6,
      115.2, 94.8, 106.4, 110.0, 90.9, 
      104.6, 72.0, 86.0, 102.4, 99.8, 
      87.5, 111.4, 105.9, 90.7, 99.2,
      97.8, 88.3, 97.5, 97.4, 93.7,
      99.7, 122.7, 100.2, 106.5, 105.5,
      80.7, 107.9, 103.2, 116.4, 101.7,
      84.8, 101.9, 99.1, 102.2, 102.5, 
      111.7, 101.5, 95.1, 92.8, 88.5, 
      74.4, 98.9, 111.9, 96.5, 95.9};
    Arrays.sort(data);
    
    double[] hist = new double[5];
    double[] expected = new double[5];
    double sum = 0;
    double mean;
    double stdDev;
    double temp;
    double chi = 0;

    System.out.println("Min: " + data[0]);
    System.out.println("Max: " + data[data.length-1]);
    
    for (int i=0; i<data.length; i++)
    {
      sum += data[i];
    }
    
   
    mean = sum/50;
    
    sum=0; 
    for (int i=0; i<data.length; i++)
    {
      sum += ((data[i]-mean)*(data[i]-mean));
    }
    
    stdDev = Math.sqrt((sum/50));
    
    System.out.println("Mean: " + mean);
    System.out.println("Standard Deviation: " + stdDev);
    
    for (int i=0; i<data.length; i++)
    {
      sum += data[i];
      if (data[i]<(mean-2*stdDev))
        hist[0]++;
      else if (data[i]<(mean-stdDev))
        hist[1]++;
      else if (data[i]<mean)
        hist[2]++;
      else if (data[i]<(mean+stdDev))
        hist[3]++;
      else
        hist[4]++;
    }
    
    System.out.println("<" + (mean-2*stdDev) + ": " + hist[0]);
    System.out.println((mean-2*stdDev) + "-" + (mean-stdDev) + ": " + hist[1]);
    System.out.println((mean-stdDev) + "-" + (mean) + ": " + hist[2]);
    System.out.println((mean) + "-" + (mean+stdDev) + ": " + hist[3]);
    System.out.println(">" + (mean+2*stdDev) + ": " + hist[4]);
    
    expected[0] = 50.0*(1-0.97725);
    expected[1] = 50.0*(1-0.84134);
    expected[2] = 50.0*(0.5);
    expected[3] = expected[1];
    expected[4] = expected[0];
    
    
     for (int i=0; i<hist.length; i++)
    {
      temp = ((hist[i]-expected[i])*(hist[i]-expected[i]));
      chi += (temp/expected[i]);
    }

    System.out.println("Chi squared: " + chi);
  }
}