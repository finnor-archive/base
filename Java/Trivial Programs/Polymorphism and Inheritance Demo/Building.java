//
//   Adrian Flannery
//   adrianu2@uab.edu
//
//   CS-302
//   Spring 2008
//
//   Programming Exercise 1
//
//   The program creates several classes whose objects represent types of buildings
//   utilizing inheritance and polymorphism, and is driven by Exercise1.java
//


import java.util.Scanner;
import java.text.DecimalFormat;


//**************************************************************************************************************************
//**************************************************************************************************************************
//**************************************************************************************************************************


//the building class is the top most superclass from which all are derived
public abstract class Building implements Comparable
{
  protected String address;
  protected int sqft;
  private String building = "";
  Scanner scan = new Scanner(System.in);
  
  
  //constructor for the building
  public Building()
  {
    System.out.println("Enter the address: ");
    address = scan.nextLine();
    System.out.println("Enter the square footage: ");
    sqft = scan.nextInt();
  }
  
  //returns the address of the building
  protected String getAddress()
  {
    return(address);
  }
  
  
  //returns the square footage
  protected int getFootage()
  {
    return(sqft);
  }
  
  //compares two buildings on the basis of address
  public int compareTo(Object build2)
  {
    String add1 = this.address;
    String add2 = ((Building)build2).address;
    if (add1.equalsIgnoreCase(add2))
    {
      return(1);
    }
    else
    {
      return(0);
    }
  }
  
  //overrides toString and returns the instance data
  public String toString()
  {
    building = "\n\nBuilding\n\nAddress: " + address + "\nSquare Footage: " + sqft;
    return(building);
  }
  
  //displays the heading for the program
  protected static void displayHeading(int num)
  {
    System.out.println("Adrian Flannery");
    System.out.println("adrianu2");
    System.out.println("CS-302");
    System.out.println("Program Exercise 1\n");
  }
  
  //searches the array for two buildings of the same address and prints the buildings
  public static void findSameAddress(Building[] p)
  {
    //compares each building to each succeeding building
    for(int i=0; i+1<p.length; i++)
    {
      for(int j=i+1; j<p.length; j++)
      {
        //tests to see if the index refers to a null value
        if(p[j]!=null)
        {
          if(p[i].compareTo(p[j])==1)
          {
            System.out.println("**********************************\n");
            System.out.println(p[i] + "\n");
            System.out.println("\nIS THE SAME BUILDING AS");
            System.out.println(p[j]);
            System.out.println("\n**********************************");
          }
        }
      }
    }
  }
  
  //searches the array of buildings if the given address is present
  public static Building find(Building[] p, String address2)
  {
    String address1;
    for(int i=0; i<p.length; i++)
    {
      if (p[i] != null)
      {
        address1 = p[i].address;
        if(address1.equalsIgnoreCase(address2))
        {
          return(p[i]);
        }
      }
    }
    //if the address is not present a null value is returned
    return(null);
  }
          
}


//**************************************************************************************************************************
//**************************************************************************************************************************
//**************************************************************************************************************************


//Residence is a subclass to building and a superclass to House and Apartment
abstract class Residence extends Building
{
  protected int rooms;
  private String resid = "";
  Scanner scan = new Scanner(System.in);
  
  //constructor for Residence
  public Residence()
  {
    super();
    System.out.println("Enter the number of rooms: ");
    rooms = scan.nextInt();
  }
  
  //returns the number of rooms
  protected int getRooms()
  {
    return(rooms);
  }
  
  
  //returns the instance data as a string
  public String toString()
  {
    resid = "\n\nResidence\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft + "\nNumber of Rooms: " + rooms;
    return(resid);
  }
}


//**************************************************************************************************************************
//**************************************************************************************************************************
//**************************************************************************************************************************


//House is a subclass of Residence
class House extends Residence
{
  protected double price;
  private String house="";
  Scanner scan = new Scanner(System.in);
  DecimalFormat money = new DecimalFormat("$#,###,###.##");
  
  //constructor of house
  public House()
  {
    super();
    System.out.println("Enter the selling price: ");
    price = scan.nextDouble();
  }
  
  
  //returns the price of the house
  public double getPrice()
  {
    return(price);
  }
  
  //a mutator that adds rooms and square footage to a house
  protected void addRooms(int rmsAdd, int ftAdd)
  {
    super.rooms = (super.rooms) + rmsAdd;
    super.sqft = (super.sqft) + ftAdd;
  }
  
  //returns the instance data of the object as a string
  public String toString()
  {
    house = "\n\nHouse\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft + "\nNumber of Rooms: " + super.rooms + "\nPrice: " 
                         + money.format(price);
    return(house);
  }
}


//**************************************************************************************************************************
//**************************************************************************************************************************
//**************************************************************************************************************************


//Apartment is a subclass of Residence
class Apartment extends Residence
{
  protected double rent;
  private String apart="";
  Scanner scan = new Scanner(System.in);
  DecimalFormat money = new DecimalFormat("$#,###,###.##");
  
  //constructor for Apartment
  public Apartment()
  {
    super();
    System.out.println("Enter the amount of rent: ");
    rent = scan.nextDouble();
  }
  
  //returns the rent
  public double getRent()
  {
    return(rent);
  }
  
  //returns the instance data of the object of the string
  public String toString()
  {
    apart = "\n\nApartment\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft + "\nNumber of Rooms: " + super.rooms + "\nRent: " 
                         + money.format(rent);
    return(apart);
  }
}


//**************************************************************************************************************************
//**************************************************************************************************************************
//**************************************************************************************************************************


//Business is a subclass of Building and a superclass of Store and Restaurant
abstract class Business extends Building
{
  private String business = "";
  
  //constructor of Business
  public Business ()
  {
    super();
  }
  
  //returns the instance data of the object as a string
  public String toString()
  {
    business = "\n\nBusiness\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft;
    return(business);
  }
}


//**************************************************************************************************************************
//**************************************************************************************************************************
//**************************************************************************************************************************


//Restaurant is a subclass of Business
class Restaurant extends Business
{
  protected String type;
  protected int capacity;
  private String restaurant = "";
  Scanner scan1 = new Scanner(System.in);
  
  //Constructor for Apartment
  public Restaurant ()
  {
    super();
    System.out.println("Enter the seating capacity: ");
    capacity = scan.nextInt();                     
    System.out.println("Enter the type of food: ");
    //for some reason I don't understand I couldn't get the input to be taken without the the extra scan on the next line
    scan.nextLine();
    type=scan.nextLine();
  }
  
  //returns the type of restaurant
  public String getType()
  {
    return(type);
  }
  
  //returns the capacity of the restaurant
  public int getCapacity()
  {
    return(capacity);
  }
  
  
  //returns the instance data of the object as a string
  public String toString()
  {
    restaurant = "\n\nRestaurant\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft + "\nType of Food: " + type + "\nCapacity: " + capacity;
    return(restaurant);
  }
}


//**************************************************************************************************************************
//**************************************************************************************************************************
//**************************************************************************************************************************


//Store is a subclass of Business
class Store extends Business
{
  protected String items;
  private String store = "";
  Scanner scan = new Scanner(System.in);
  
  //Constructor for store
  public Store ()
  {
    super();
    System.out.println("Enter the product sold: ");
    items = scan.nextLine();
  }
  
  //returns the items sold
  public String getItems()
  {
    return(items);
  }
  
  //returns the instance data of the object as a string
  public String toString()
  {
    store = "\n\nStore\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft + "\nProduct Sold: " + items;
    return(store);
  }
}