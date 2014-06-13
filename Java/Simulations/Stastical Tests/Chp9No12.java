public class Chp9No12
{
  public static void main (String[] args)
  {
    double[] data = {1.691, 1.437, 8.22, 5.976, 1.116, 4.435, 2.345, 1.782, 3.810, 4.589, 
      5.313, 10.90, 2.649, 2.432, 1.581, 2.432, 1.843, 2.466, 2.833, 2.361};
    double sum = 0;
    double mean;
    double theta;
    double m;
    double temp = 0;
    
    for (int i=0; i<data.length; i++)
    {
      sum += data[i];
      temp += Math.log(data[i]);
    }
    
    mean = sum/data.length;
    theta = 1/mean;
    m = Math.log(mean) - (1/data.length)*temp;
    
    System.out.println("Mean: " + mean);
    System.out.println("Theta: " + theta);
    System.out.println("1/M: " + (1/m));
  }
}