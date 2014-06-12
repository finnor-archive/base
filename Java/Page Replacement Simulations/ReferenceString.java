//Reference String


import java.util.*;

public class ReferenceString
{
  private LinkedList<Integer> refString;
  private Random generator;
  
  public ReferenceString(int seed)
  {
    generator = new Random(seed);
  }
  
  public void createReferenceStringTypical(int range, int length)
  {
    refString = new LinkedList<Integer>();
    int num;
    int previous = generator.nextInt(range);
    float place;
    
    refString.add(previous);
    for(float i=1; i<length; i++)
    {
      place = i/length;
      num = this.createPageTypical(place, range, previous);
      refString.add(num);
      if (((num-previous) > 1) || ((num-previous) < -2))         //case for middle to check if simulated function call was taken 
        previous = num;
    }
  }
  
  private int createPageTypical(float place, int range, int previous)
  {
    float random; 
    int rand2;
    int num = 0;  
    boolean fail = true;  
    while (fail)
    {
      random = generator.nextFloat();
      if ((place<0.05) || (place>=0.95))                  //first and last 5% of reference string
      {
        num = generator.nextInt(range);                   //random number
        if (num!=previous)
          fail = false;
      }
      else
      {
        if (random<0.01)                                  //idealized function call
        {
          while(fail)
          {
            num = generator.nextInt(range);
            if (num!=previous)
              fail = false;
          }
        }
        else
        {
          if (random<0.76)                            //go forward 1, 2/3 of the time
          {
            num = 1 + previous;
            if (num<range)
              fail = false;           
          }
          else
          {
            rand2 = generator.nextInt(3) + 1;        //go back 1-3, 1/3 of the time
            num = previous - rand2;
            if (num>0)
              fail = false;
          }
        } 
      }
    } 
    return (num);
  }
  
  
  public void createReferenceStringWell(int range, int length)
  {
    refString = new LinkedList<Integer>();
    int num;
    int previous = generator.nextInt(range);
    for(int i=0; i<length; i++)
    {
      num = this.createPageWell(range, previous);
      refString.add(num);
      previous = num;
    }
  }
  
  private int createPageWell(int range, int previous)
  {
    float random;
    int num = 0;
    int lRange = (int) (range*0.1);
    int hRange = (int) (range*0.9);
    boolean fail = true;
    while(fail)
    {
      random = generator.nextFloat();
      if (random<0.9)
      {
        num = generator.nextInt(lRange);              //90% of time, uses 10% of pages
        if (num!=previous)
          fail = false;
      }
      else
      {
        num = generator.nextInt(hRange) + lRange;     //10% of time, uses other 90%
        if (num!=previous)
          fail = false;
      }
    }
    return (num);
  }
  
  
  public int getElement(int i)
  {
    if (refString.size()>i)
      return(refString.get(i));
    else 
      return (0); 
  }
  
  public void createReferenceStringPoor(int range, int length)
  {
    refString = new LinkedList<Integer>();
    int num;
    for(int i=0; i<length; i++)
    {
      num = this.createPagePoor(range);
      refString.add(num);
    }
  }
  
  private int createPagePoor(int range)         
  {
    return(generator.nextInt(range));            //returns random page number
  }
  
  public int size()
  {
    return (refString.size());
  }
  
  public Integer lookAhead(Integer[] resSet, int place)  //look ahead for optimal
  {
    int numLeft = resSet.length;
    int temp;
    for (int i=place+1; i<this.size(); i++)   //finds last one used
    {
      if (numLeft==1)
        break;
      temp = refString.get(i);
      for (int j=0; j<resSet.length; j++)
      {
        if (resSet[j]==temp)
        {
          numLeft--;
          resSet[j]=0;
        }
      }
    }
    
    for (int i=0; i<resSet.length; i++)    //return last one used
    {
      if(resSet[i]!=0)
        return (resSet[i]);
    }
    return (0);
  }
}