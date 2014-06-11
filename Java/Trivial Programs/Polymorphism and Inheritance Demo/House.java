import java.util.Scanner;

public class House extends Residence
{
  double price;
  String house="";
  Scanner scan = new Scanner(System.in);
  
  public House()
  {
    super();
    System.out.println("Enter the selling price: ");
    price = scan.nextDouble();
  }
  
  protected double getPrice()
  {
    return(price);
  }
  
  protected void addRooms(int rmsAdd, int ftAdd)
  {
    super.rooms = (super.rooms) + rmsAdd;
    super.sqft = (super.sqft) + ftAdd;
  }
  
  public String toString()
  {
    house = "\n\nHouse\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft + "\nNumber of Rooms: " + super.rooms + "\nPrice: " + price;
    return(house);
  }
}