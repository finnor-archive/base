import java.util.Scanner;

public class Restaurant extends Business
{
  String type;
  int capacity;
  String restaurant = "";
  Scanner scan = new Scanner(System.in);
  
  public Restaurant ()
  {
    super();
    System.out.println("Enter the seating capacity: ");
    capacity = scan.nextInt();                     
    System.out.println("Enter the type of food: ");
    type = scan.nextLine();   
  }
  
  public String toString()
  {
    restaurant = "\n\nRestaurant\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft + "\nType of Food: " + type + "\nCapacity: " + capacity;
    return(restaurant);
  }
}