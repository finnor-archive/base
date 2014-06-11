// **********************************************************
// Adrian Flannery
// SoldCar.java
// Displays information about a sold car
// **********************************************************

public class SoldCar extends Car
{
  private String customerName;
  private int price;
  private String dateSold;
  
  public SoldCar(int cost, int id, String dateA, String customer, int price0, String dateS)
  {
    super(cost, id, dateA);
    customerName = customer;
    price = price0;
    dateSold = dateS;
  }
  
  public int getPrice()
  {
    return(price);
  }
  
  public String getCustomer()
  {
    return(customerName);
  }
  
  public String getDateSold()
  {
    return(dateSold);
  }
  
  public int calculateProfit()
  {
    return(price - dealerCost);
  }
  
  public String toString()
  {
    return("Dealer cost = " + dealerCost + "\nId number = " 
            + idNumber + "\nDate arrived = " + dateArrived +
            "\n" + "Price = " + price + "\nCustomer = " 
            + customerName + "\nDate sold = " +dateSold);
  }
}
     
      