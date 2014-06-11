
public class Result
{
   private int location;
   private int homeLocation;
   private int locationsExamined;

   public Result(int location, int homeLocation, int locationsExamined)
   {
      this.location = location;
      this.homeLocation = homeLocation;
      this.locationsExamined = locationsExamined;
   }

   public int getLocation()
   {
      return location;
   }

   public int getHomeLocation()
   {
      return homeLocation;
   }

   public int getLocationsExamined()
   {
      return locationsExamined;
   }

}