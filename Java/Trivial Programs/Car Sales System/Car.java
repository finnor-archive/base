// **********************************************************
// Adrian Flannery
// Car.java
// Displays information about a car 
// **********************************************************

public class Car
{
  protected int dealerCost;
  protected int idNumber;
  protected String dateArrived;
  
  public Car (int cost, int id, String date)
  {
    dealerCost = cost;
    idNumber = id;
    dateArrived = date;
  }
    
  public int getDealerCost()
  {
    return(dealerCost);
  }
  
  public int getIdNumber()
  {
    return(idNumber);
  }
  
  public String getDateArrived()
  {
    return(dateArrived);
  }
  
  public String toString()
  {
    return("Dealer cost = " + dealerCost + "\nId number = " 
            + idNumber + "\nDate arrived = " + dateArrived);
  }
}