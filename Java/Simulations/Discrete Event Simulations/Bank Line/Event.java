public class Event
{
  private int time;            //How long the event will take
  private int eve;             //Event type
  private int id;              //id performing event
  
  public Event (int e, int t, int i)
  {
    eve = e;
    time = t;
    id = i;
  }
  
  public int getTime()
  {
    return time;
  }
  
  public int getID()
  {
    return id;
  }
  
  public int getEvent()
  {
    return eve;
  }
  
  public String toString()
  {
    return("(" + eve + ", " + time + ", " + id + ")");
  }
    
}