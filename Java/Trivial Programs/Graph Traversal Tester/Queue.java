public class Queue extends List
{
  public Queue()
  {
    super();
  }
  
  public void enqueue(int x)
  {
    ListNode a = new ListNode(x);
    if (front==null)
    {
      front = a;
      back = a;
    }
    else
    {
      back.next = a;
      back = a;
    }
  }
  
  public int dequeue ()
  {
    if (front!=null)
    {
      int temp = front.element;
      front = front.next;
      return (temp);
    }
    else
      return(-1);
  }
  
  public int peek()
  {
    return(front.element);
  }
  
  public boolean isEmpty()
  {
   return (super.isEmpty()); 
  }
}