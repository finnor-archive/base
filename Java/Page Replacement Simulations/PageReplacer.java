//LRUA Page Replacement

import java.util.*;

public class PageReplacer
{
  private LinkedList<Integer> rSet;              
  private LinkedList<Integer> fList;            
  private int rSize;
  private int fSize;
  private int cheapPageFaults;
  private int expensivePageFaults;
  
  public PageReplacer (int rS, int fS)
  {
    rSet = new LinkedList<Integer>();  
    rSize = rS;
    fList = new LinkedList<Integer>();  
    fSize = fS;
    cheapPageFaults = 0;
    expensivePageFaults = 0;
  }
  
  public boolean addPage (Integer pageNum)
  {
    Integer temp;
    ListIterator<Integer> iterator = rSet.listIterator(0);
    while (iterator.hasNext())                        //check to see if page is already in resident set
    {
      temp = iterator.next();
      if (pageNum.intValue()==temp.intValue())
      { 
        iterator.remove();                            //move to top of resident set
        rSet.addFirst(pageNum);
        return(true);
      }
    }
    
    if (rSet.size()<rSize)                               //check to see if the resident set is not full
    {
      rSet.addFirst(pageNum);
      expensivePageFaults++;
      return(false);
    }
    else                                              //check free list and add to resident set
    {
      if (this.getFromFreeList(pageNum))
        cheapPageFaults++;
      else 
      {
        expensivePageFaults++;
      }
      temp = rSet.removeLast();            //takes last of resident and adds to free list
      fList.addFirst(temp);
      if (fList.size()>fSize)
        fList.removeLast();                //if free list is full then takes last element out
      rSet.addFirst(pageNum);
      return(false);
    }
  }
  
  private boolean getFromFreeList(int pageNum)
  {
    Integer temp;
    ListIterator<Integer> iterator = fList.listIterator(0);
    while (iterator.hasNext())               //checks free list to see if the page is present
    {
      temp = iterator.next();
      if (temp.intValue()==pageNum)
      {
        iterator.remove();
        return(true);
      }
    }
    return(false);
  }
  
  public int getCPF()
  {
    return (cheapPageFaults);
  }
  
  public int getEPF()
  {
    return (expensivePageFaults);
  }
}