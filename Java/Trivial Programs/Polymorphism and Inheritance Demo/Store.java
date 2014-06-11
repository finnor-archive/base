import java.util.Scanner;

public class Store extends Business
{
  String items;
  String store = "";
  Scanner scan = new Scanner(System.in);
  
  public Store ()
  {
    super();
    System.out.println("Enter the product sold: ");
    items = scan.nextLine();
  }
  
  public String toString()
  {
    store = "\n\nStore\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft + "\nProduct Sold: " + items;
    return(store);
  }
}