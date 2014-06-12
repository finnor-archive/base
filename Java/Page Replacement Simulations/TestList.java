import java.util.*;

public class TestList
{
  public static void main(String[] args)
  {
    LinkedList<Integer> test = new LinkedList();
    Integer num = new Integer(0);
    test.addFirst(num);
    System.out.println("Size: " + test.size());
    System.out.println("Object: " + test.getFirst() + " - " + test.get(0) + " - " + test.get(1));
  }
}
                       