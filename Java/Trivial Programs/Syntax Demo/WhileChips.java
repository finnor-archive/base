// ************************************************************
// WhileChips.java
// Adrian Flannery
// Uses the while loop to create a message
// ************************************************************

public class WhileChips
{
     public static void main (String[] args)
    {
        int numChips = 1;
        System.out.println("I open the bag and ...");
        while (numChips < 4)
         {
            System.out.println(" eat chip no. " + numChips);
            numChips = numChips + 1;
         }
        System.out.println("I JUST CAN'T STOP!");
    }
}
