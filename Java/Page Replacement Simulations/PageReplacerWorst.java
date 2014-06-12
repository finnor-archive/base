//random page replacement


import java.util.*;

public class PageReplacerWorst
{
  private LinkedList<Integer> rSet;                         
  private int rSize;
  private int pageFaults;
  private Random generator;
  
  public PageReplacerWorst (int rS, int seed)
  {
    rSet = new LinkedList<Integer>();  
    rSize = rS;
    pageFaults = 0;
    generator = new Random(seed);
  }
  
  public boolean addPage (Integer pageNum)
  {
    Integer temp;
    int temp2;
    Integer toBeReplaced;
    
    ListIterator<Integer> iterator = rSet.listIterator(0);
    while (iterator.hasNext())                        //check to see if page is already in resident set
    {
      temp = iterator.next();
      if (pageNum.intValue()==temp.intValue())
      { 
        return(true);
      }
    }
    
    pageFaults++;
    
    if (rSet.size()<rSize)                               //check to see if the resident set is not full
    {
      rSet.addFirst(pageNum);
      return(false);
    }
    else
    {
      temp2 = generator.nextInt(rSize);                             //else replaces a random page
      toBeReplaced = rSet.remove(temp2);
      rSet.addFirst(pageNum);
      return(false); 
    } 
  }
  
  public int getPF()
  {
    return (pageFaults);
  }
  
}
  
  
    
    