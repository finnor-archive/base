import java.io.*;
import java.util.*;

public class LifeGameDriverIO2
{
   public static void main(String[] args) throws IOException
   {
     String FileName;
     Scanner scan = new Scanner(System.in);
     System.out.println("Enter Input FileName: ");
     FileName = scan.nextLine();
     System.out.println("Enter Output Filename: ");
     String OutFileName = scan.nextLine();
     System.out.println("Enter number of generations: ");
     int NumGenerations = scan.nextInt();
 
     System.out.println("Will write the results to " + OutFileName );
 
     LifeGameIO game1 = new LifeGameIO(FileName); 
     game1.printBoard();

     for(int i = 0; i < NumGenerations; i++)
     {
        game1.doOneGeneration();
        game1.printBoard();
     }
   
     game1.PrintBoardToFile(OutFileName);
   }
}
