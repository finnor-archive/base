public abstract class Business extends Building
{
  String business = "";
  
  public Business ()
  {
    super();
  }
  
  public String toString()
  {
    business = "\n\nBusiness\n\nAddress: " + super.address + "\nSquare Footage: " + super.sqft;
    return(business);
  }
}