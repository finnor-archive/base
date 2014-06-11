import java.util.Scanner;

public abstract class Residence extends Building
{
  int rooms;
  String resid = "";
  Scanner scan = new Scanner(System.in);
  
  public Residence()
  {
    super();
    System.out.println("Enter the number of rooms: ");
    rooms = scan.nextInt();
  }
  
  protected int getRooms()
  {
    return(rooms);
  }
  
  public String toString()
  {
    resid = "\n\nResidence\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft + "\nNumber of Rooms: " + rooms;
    return(resid);
  }
}
    