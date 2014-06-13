import java.util.*;

public class EventComparator implements Comparator<Event>
{
  public EventComparator()
  {
    super();
  }
  
  //compare elements on time; in case of tie, compare on event type
  public int compare(Event x, Event y)
  {
    if (x.getTime() < y.getTime())
      return -1;
    else if (x.getTime() == y.getTime())
    {
      if (x.getEvent() > y.getEvent())
        return -1;
      else
        return 1;
    }
    else 
      return 1;
  }
}