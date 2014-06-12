import java.io.*;
import java.util.*;

public class LifeGameIO extends LifeGame
{
   public LifeGameIO(int m, int n)
   {
      super(m, n);
   }
   
   public LifeGameIO(String FileName) throws IOException
   {
       super(0,0); // default construction
       
       if(readLifeGame(FileName) == true) // true if it failed
       {
          M = -1;
          N = -1;
       }
    }
   
   protected boolean readLifeGame(String InputFileName)  throws IOException
   {
       boolean failed = false;
       Scanner scanner = new Scanner(System.in); // temp. initialization for now
       
       try
       {
             scanner = new Scanner(new File(InputFileName));
       }
       catch (IOException ex)
       {
          failed = true;
          System.out.println("Sorry, file not found: " + InputFileName);
          // System.err.println("I caught the exception!");
          // ex.printStackTrace();
       }
       
       if(failed == false)
       {
          int m = scanner.nextInt();
          int n = scanner.nextInt();
          // System.out.println("m = " + m + ", n = " + n);
          SetUpWorld(m,n); // Redo the default construction with correct sizes.
          
          String ignoreBorder = scanner.nextLine();
          // System.out.println("try1: Border = [" + ignoreBorder + "]");
          ignoreBorder = scanner.nextLine();
          // System.out.println("try2: Border = [" + ignoreBorder + "]");
          
          for(int i = 0; i < m; i++)
          {  
             // read line of life world, convert:
             String lifeLine = scanner.nextLine();
             // System.out.println("Here is line: [ " + lifeLine + " ]");
             for(int j = 1; j < (lifeLine.length()-1); j++)
             {
                char value = lifeLine.charAt(j);
                
                board0[i][j-1] = (value == '*') ? 1 : 0;
             }
          } // for
       }  // if
       return failed;
    } // readlifeGame  
   
    protected void printBannerToFile(PrintWriter out)
    {
      out.print("+");
      for(int j = 0; j < N; j++)
        out.print("-");
      out.println("+");
    }
 
   protected void internalPrintBoardToFile(PrintWriter out, int[][] board)
   {
      printBannerToFile(out);
      
      for(int i =0; i < M; i++)
      {
         out.print("|");
         for(int j = 0; j < N; j++)
         {
            if(board[i][j] == 1)
               out.print('*');
            else
               out.print(' ');
         }
         out.println("|");
      }
      printBannerToFile(out);
   }

   public void PrintBoardToFile(String FileName) throws IOException
   {
      PrintWriter out = null;
      
      // we need to open the file:
      try
      { 
         FileWriter outFile = new FileWriter(FileName);
         out = new PrintWriter(outFile);
      } 
      catch (IOException e)
      {
          System.out.println("Bad File Writing Situation!"); 
          //   e.printStackTrace();
      }
 
      int[][] theboard;
      if((generation_count % 2) == 0)
         theboard = board0;
      else
         theboard = board1;
      
      out.println(M + " " + N );
      internalPrintBoardToFile(out, theboard);
      out.close();
   }
   
} // whole class


