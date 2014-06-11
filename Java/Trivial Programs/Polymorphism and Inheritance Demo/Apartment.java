import java.util.Scanner;

public class Apartment extends Residence
{
  double rent;
  String apart="";
  Scanner scan = new Scanner(System.in);
  
  public Apartment()
  {
    super();
    System.out.println("Enter the amount of rent: ");
    rent = scan.nextDouble();
  }
  
  protected double getRent()
  {
    return(rent);
  }
  
  public String toString()
  {
    apart = "\n\nApartment\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft + "\nNumber of Rooms: " + super.rooms + "\nRent: " + rent;
    return(apart);
  }
}