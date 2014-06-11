public class HourlyWorker {

   ////////////// fields ////////////////////////
  
   private String name;
   private String socSecNum;
   private double hourlyRate;

   ///////////// constructors ////////////////////

   public HourlyWorker(String theName, String theSocSecNum, 
                       double theRate)
   {
      this.name = theName;
      this.socSecNum = theSocSecNum;
      this.hourlyRate = theRate;
   }

   //////////////// methods //////////////////////

   public double computeNetPay(double hoursWorked)
   {
     // calcuate the gross pay
      double grossPay = hoursWorked * this.hourlyRate;
      
      // calculate the tax percent
      double taxPercent;
      if (grossPay < 100)
         taxPercent = 0.25;
      else if (grossPay < 300)
         taxPercent = 0.35;
      else if (grossPay < 400)
         taxPercent = 0.45;
      else
         taxPercent = 0.5;

      // calculate the tax
      double tax = grossPay * taxPercent;

      // calculate the net pay
      double netPay = grossPay - tax;
      
      // print the information
      System.out.println("Worker: " + this.name + 
                         " SS#: " + this.socSecNum + 
                         " Gross Pay: " + grossPay +
                         " Net Pay: " + netPay);

      return netPay;
   }
   
   /**
    * Main method for testing
    */
   public static void main (String[] args)
   {
     // create an hourly worker 
     HourlyWorker worker1 = new HourlyWorker("Fred Firestone", "000-00-0001", 5.50);
     worker1.computeNetPay(40);
     HourlyWorker worker2 = new HourlyWorker("Wilma Firestone", "000-00-0002", 4.75);
     worker2.computeNetPay(45);
   }
}