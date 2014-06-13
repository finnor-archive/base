public class Test
{
  public static void main(String[] args)
  {
    FEL list = new FEL();
    list.insert(new Event(1, 12, 1));
    list.insert(new Event(3, 5, 2));
    list.insert(new Event(1, 14, 3));
    list.insert(new Event(2, 3, 4));
    list.insert(new Event(1, 3, 6));
    list.insert(new Event(3, 3, 7));
    list.insert(new Event(4, 16, 5));
    list.insert(new Event(3, 15, 1));
    
    System.out.println("Future Event List: " + list);
    System.out.println("Queue size: " + list.length());
    System.out.println("Top element: " + list.peek());
    System.out.println("2nd element: " + list.get(1));
    System.out.println("3rd element: " + list.get(2));
    
    System.out.println("\n\nFuture Event List by getNext(): ");
    
    int tempL = list.length();
    for(int i=0; i<tempL; i++)
    {
      System.out.println(list.getNext());
    }
    
  }
}
    