import java.util.*;

public class PageReplacerOptimal
{
  private LinkedList<Integer> rSet;                         
  private int rSize;
  private int pageFaults;
  private ReferenceString refString;
  
  public PageReplacerOptimal(int rS, ReferenceString str)
  {
    rSet = new LinkedList<Integer>();  
    rSize = rS;
    refString = str;
    pageFaults = 0;
  }
  
  public boolean addPage (int numPage, int place)
  {
    Integer temp;
    Integer[] type = new Integer[0];
    ListIterator<Integer> iterator = rSet.listIterator(0);
    while (iterator.hasNext())                                      //check to see if page is already in resident set
    {
      temp = iterator.next();
      if (numPage==temp.intValue())
        return(true);
    }
    
    pageFaults++;  
    
    if (rSet.size() < rSize)                                 //checks to see if rSet isn't full
    {
      rSet.add(numPage);
      return(false);
    }                                                
    temp = refString.lookAhead(rSet.toArray(type), place);      // else looks ahead to see which page is used again last
    rSet.remove(temp);
    rSet.add(numPage);
    return(false);
  }
  
  public int getFaults()
  {
    return (pageFaults);
  }
}