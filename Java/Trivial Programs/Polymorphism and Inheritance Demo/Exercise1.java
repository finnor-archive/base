import java.util.*;

public class Exercise1
{
   public static void main (String[] args)
   {
      Scanner scan = new Scanner(System.in);
      int i=0;
      String line;
      Building [] p = new Building[10];

      Building.displayHeading(1);

      System.out.println("\n\t1 = House\n\t2 = Apartment\n\t3 = Restaurant" +
                            "\n\t4 = Store");
      System.out.println("\n\nWhat type of building do you wish to place in the array? ");
      System.out.print("(enter empty line to stop): ");
      line = scan.nextLine();
      while (!line.equals(""))  // place up to ten buildings in the array
      {
         if (line.equals("1"))
            p[i] = new House();
         else
            if (line.equals("2"))
              p[i] = new Apartment();
            else
               if (line.equals("3"))
                  p[i] = new Restaurant();
               else
                  if (line.equals("4"))
                     p[i] = new Store();

         i++;
         System.out.println("\n\t1 = House\n\t2 = Apartment\n\t3 = Restaurant" +
                            "\n\t4 = Store");
         System.out.print("\n\nWhat type of building do you wish to place in the array? ");
         line = scan.nextLine();
      }

      pause(scan);

      //display the array
      System.out.println("\n\n******** The array contains ********");
      for (i = 0; i < p.length; i++)
         if (p[i] != null)
            System.out.println(p[i]);

      pause(scan);

      // do any buildings have the same address?
      Building.findSameAddress(p);

      pause(scan);

      // try to find three buildings
      for (i = 0; i < 3; i++)
      {
         System.out.print("\nEnter an address to search for: ");
         String address = scan.nextLine();
         Building r = Building.find(p,address);
         if (r == null)
            System.out.println("\nBuilding with address " + address + " is NOT IN array");
         else
         {
             System.out.println(r);
             if (r instanceof House)  // if building is a House add rooms
             {
                System.out.print("\nEnter new number of rooms to add: ");
                int rooms = scan.nextInt();
                System.out.print("\nEnter additional square footage: ");
                int footage = scan.nextInt();
                scan.nextLine();
                ((House)r).addRooms(rooms,footage);
                System.out.println("\nThe house's new information is:" + r + '\n');
             }
         }
         System.out.println();
     }
     System.out.println("\n\nEnd of Program\n");
   }



   public static void pause(Scanner scan)
   {
      System.out.print("\nPress enter to continue: ");
      scan.nextLine();
   }


 }







