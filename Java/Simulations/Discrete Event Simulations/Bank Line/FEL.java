import java.util.*;

public class FEL
{
  private PriorityQueue<Event> events;
  private Comparator comparator;
  
  //constructor
  public FEL()
  {
    comparator = new EventComparator();
    events = new PriorityQueue<Event>(10, comparator);
  }
  
  //return front of the FEL
  public Event getNext()
  {
    return(events.poll());
  }
  
  //returns nth priority element
  public Event get(int numElement)
  {
    Event temp;
    LinkedList<Event> tempEvents= new LinkedList();
    for (int i=0; events.peek()!=null ; i++)    //removes the top n times and stores in a list
    {
      temp = events.poll();
      tempEvents.offer(temp);      
      if (i==numElement)                        //at nth element, readd the previous elements
      {
        ListIterator<Event> iterator = tempEvents.listIterator(0);
        while (iterator.hasNext())
        {
          events.offer(iterator.next());
        }
        return (temp);                    
      }
    }
    return(null);                            //element does not exist
  }
  
  
  //insert event into FEL
  public void insert (Event eve) 
  {
    events.offer(eve);
  }
  
  public int length()
  {
    return (events.size());
  }
  
  //return length of FEL
  public Event peek()
  {
    return(events.peek());
  }
  
  //printable FEL
  public String toString()
  {
    String temp = "";
    Iterator<Event> iter = events.iterator();
    while(iter.hasNext())
    {
      temp += iter.next() + " ";
    }
    return temp;
  }
  
  public Iterator iterator()
  {
    return(events.iterator());
  }
}
      