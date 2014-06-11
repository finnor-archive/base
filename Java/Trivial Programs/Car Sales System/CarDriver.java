// **********************************************************
// Adrian Flannery
// CarDriver.java
// Drives the Car class to display info about a car
// **********************************************************

public class CarDriver
{
  public static void main(String[] args)
  {
    int cost = 14000;
    int id = 1245632;
    String date = "October 11, 2008";
    
    Car car = new Car(cost, id, date);
    
    System.out.print(car);
  }
}
    