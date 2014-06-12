import java.util.Random;
import java.util.Scanner;
import java.lang.Math;
import java.util.LinkedList;

public class HWTest
{
  public static void main(String[] args)
  {
    Random generator = new Random();
    int counter;
    int card;
    double average=0;
    double positive=0;
    int spades;
    int others;
    double s=0;
    
    for (int i=0; i<1000; i++)
    {
      counter = 0;
      s=0;
      spades = 12;
      others = 51;
      while (counter<3)
      {
        card = generator.nextInt(52);
        if (card<=spades)
        {
          spades--;
          others--;
          s++;
          counter++;
        }
        else
        {
          if (card<=others)
          {
            others--;
            counter++;
          }
        }
      }
      average = (average*i + s)/(i+1);
    }
    System.out.print(average);
  }
}