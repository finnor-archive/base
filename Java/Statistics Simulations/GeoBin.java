import java.util.Random;
import java.util.Scanner;
import java.lang.Math;
import java.util.LinkedList;

public class GeoBin
{
  public static void main(String[] args)
  {
    double n=7;
    double p=.3;
    double sumGeo=0;
    double sumBin;
    
    
    for (double i=n; i<1000; i++)
    {
      sumGeo = p*Math.pow((1-p), i) + sumGeo;
    }
    
    sumBin = Math.pow((1-p), n);
    
    System.out.println("Geo: " + sumGeo);
    System.out.println("Bin: " + sumBin);
  }
}