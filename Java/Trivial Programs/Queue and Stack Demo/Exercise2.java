import java.util.Scanner;

public class Exercise2
{
   public static void main (String[] args)
   {
      Scanner scan = new Scanner (System.in);
      String str;
      int j;

      MyListQueue<String>  q1 = new MyListQueue<String>(),
                           q2 = new MyListQueue<String>();

      MyListQueue.displayHeading(2);

      System.out.println("\nEnter strings one per line (enter an empty string to stop):\n");
      str = scan.nextLine();
      while (str.length()!= 0)
      {
         q1.enqueue(str);
         str = scan.nextLine();
      }

      System.out.println("\nq1 contains:\n");
      q1.display();

      for (j = 0; j < 3; j++)
      {
         System.out.print("\nEnter a string to remove from q1: ");
         str = scan.nextLine();
         q1.removeElement(str);
         System.out.println("\n*** After calling q1.removeElement(" + str + ") q1 contains:\n");
         q1.display();
      }

      for (j = 0; j < 3; j++)
      {
         System.out.print("\nEnter a string to move to the front of q1: ");
         str = scan.nextLine();
         q1.moveFront(str);
         System.out.println("\n*** After calling q1.moveFront(" + str + ") q1 contains:\n");
         q1.display();
      }

      System.out.println("\n\nEnter strings to enqueue into queue q2 " +
                         "(enter an empty string to stop)");
      str = scan.nextLine();
      while (str.length()!= 0)
      {
         q2.enqueue(str);
         str = scan.nextLine();
      }

      System.out.println("\n*** q2 contains:\n");
      q2.display();

      q1.copyTo(q2);
      q1.enqueue("Java");
      q2.enqueue("C++");
      System.out.println("\n*** After calling q1.copyTo(q2), q1.enqueue(\"Java\")," +
                         " q2.enqueue(\"C++\"):");
      System.out.println("\nq1 contains:\n");
      q1.display();
      System.out.println("\nq2 contains:\n");
      q2.display();
      System.out.println();

      System.out.println("\n\nEnd of Program\n");
   }

}



