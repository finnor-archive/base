public class List
{
  public ListNode front, back;
  
  public List()
  {
    front = back = null;
  }
  
  public void add(int x)
  {
    ListNode i = new ListNode(x);
    if (!isEmpty())
    {
      back.next= i;
      back = i;
    }
    else
    {
      front = i;
      back = i;
    }
  }
  
  public boolean remove(int x)
  {
    if (!this.isEmpty())
    {
      if (front.element==x)
      {
        front = front.next;
        return (true);
      }
      else
      {
        ListNode current = front.next;
        ListNode previous = front;
        while (current!=null)
        {
          if (current.element==x)
          {
            previous.next = current.next;
            return (true);
          }
          current = current.next;
        }
      } 
    }
    return(false);
  }
  
  
  public boolean isEmpty()
  {
    if (front == null)
      return (true);
    else
      return (false);
  }
  
  public void print()
  {
    if (!this.isEmpty())
    {
      ListNode current = front;
      while (current!=null)
      {
        System.out.print(current.element + " ");
        current = current.next;
      }
    }
  }
  
  public boolean isPresent(int v)
  {
    ListNode current = front;
    while (current!=null)
    {
      if (current.element == v)
        return (true);
      current = current.next;
    }
    return (false);
  }
}