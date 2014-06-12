import java.util.*;

public class LifeGameDriver
{
   public static void main(String[] args)
   {
     LifeGame game1 = new LifeGame(20,20);
   
     game1.setBoardOn(5,5);
     game1.setBoardOn(5,6);
     game1.setBoardOn(5,7);

     game1.setBoardOn(9,10);
     game1.setBoardOn(10,10);
     game1.setBoardOn(11,10);
     
     game1.setBoardOn(13,13);
     game1.setBoardOn(13,14);
     game1.setBoardOn(14,13);
     game1.setBoardOn(14,14);

     game1.setBoardOn(1,1);
     game1.setBoardOn(1,2);
     game1.setBoardOn(1,3);
     game1.setBoardOn(2,1);
     game1.setBoardOn(3,2);

     game1.printBoard();
     game1.doOneGeneration();
     game1.printBoard();
     game1.doOneGeneration();
     game1.printBoard();
     game1.doOneGeneration();
     game1.printBoard();
     game1.doOneGeneration();
     game1.printBoard();


   }
}
