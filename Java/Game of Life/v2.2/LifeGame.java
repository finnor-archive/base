public class LifeGame
{
   protected int[][] board0, board1;
   protected int M, N;
   protected int generation_count;
   
   public LifeGame(int m, int n)
   {
        SetUpWorld(m,n );
   }
   
   protected void SetUpWorld(int m, int n)
   {
        board0 = new int[n][n];
        board1 = new int[m][m];
        M = m;
        N = n;
        generation_count = 0;
        
        Set_Board_to_Zero(board0);
        Set_Board_to_Zero(board1);
   }
   
   
   protected void Set_Board_to_Zero(int[][] board)
   {
       for(int i = 0; i < M; i++)
       {
          for(int j = 0; j < N; j++)
          {
             board[i][j] = 0;
          }
       }
   }
   
   protected void printBanner()
   {
      System.out.print("+");
      for(int j = 0; j < N; j++)
      System.out.print("-");
      System.out.println("+");
   }
 
   protected void internalPrintBoard(int[][] board)
   {
      printBanner();
      
      for(int i =0; i < M; i++)
      {
         System.out.print("|");
         for(int j = 0; j < N; j++)
         {
            if(board[i][j] == 1)
               System.out.print('*');
            else
               System.out.print(' ');
         }
         System.out.println("|");
      }
      printBanner();
   }
   
   
   public void setBoardOn(int i, int j)
   {
       board0[i][j] = 1;
   }
   public void setBoardOff(int i, int j)
   {
       board0[i][j] = 0;
   }

   public void printBoard()
   {
      if((generation_count % 2) == 0)
      {
         // print board0
         internalPrintBoard(board0);
         
      }
      else
      {
         // print board1
        internalPrintBoard(board1);
      }
   }
   
   protected void internaldoOneGeneration(int[][] inboard, 
                                        int[][]outboard)
   {
      int Mminus1 = M - 1;
      int Nminus1 = N - 1;

      // do the interior points first:
      for(int i = 1; i < Mminus1; i++)
      {
         for(int j = 1; j < Nminus1; j++)
         {
            // add up how many neighbors I have at cell (i,j):
            int counter = inboard[i][j-1]   /* left */ + inboard[i][j+1]   /* right  */ +
                          inboard[i+1][j]   /* top  */ + inboard[i-1][j]   /* bottom */ +
                          inboard[i+1][j-1] /* UL   */ + inboard[i+1][j+1] /* UR     */ +
                          inboard[i+1][j-1] /* LL   */ + inboard[i+1][j+1] /* LR     */;
            if(((counter == 2)&&(inboard[i][j]==1)) ||
               ((counter == 3)))
            {
               outboard[i][j] = 1;
            }
            else
            {
               outboard[i][j] = 0;
            }  
         }
      }

      // do the left edge (j=0)
      for(int i = 1; i < Mminus1; i++)
      {
           // add up how many neighbors I have at cell (i,j):
            int counter = 0 /* no left */ + inboard[i][0+1] +
                          inboard[i-1][0] + inboard[i+1][0]  +
                          0 /* no UL   */ + inboard[i-1][0+1] +
                          0 /* no LL   */ + inboard[i+1][0+1];
            if(((counter == 2)&&(inboard[i][0]==1)) ||
               ((counter == 3)))
            {
               outboard[i][0] = 1;
            }
            else
            {
               outboard[i][0] = 0;
            }  

      }
      // do the right edge (j=N-1)
      for(int i = 1; i < Mminus1; i++)
      {
           // add up how many neighbors I have at cell (i,j):
            int counter = inboard[i][Mminus1-1]   + 0 /* no right */ +
                          inboard[i-1][Mminus1]   + inboard[i+1][Mminus1]  +
                          inboard[i-1][Mminus1-1] + 0 /* no UR */ +
                          inboard[i+1][Mminus1-1] + 0 /* no LR */;
            if(((counter == 2)&&(inboard[i][Mminus1]==1)) ||
               ((counter == 3)))
             {
               outboard[i][Mminus1] = 1;
            }
            else
            {
               outboard[i][Mminus1] = 0;
            }  
       }

      // do the top edge (i = 0)
      for(int j = 1; j < Nminus1; j++)
      {
           int counter = inboard[0][j-1] + inboard[0][j+1] +
                          0 /* no top */ + inboard[0+1][j]  +
                          0 /* no UL  */ + 0 /* no UR */ +
                          inboard[0+1][j-1] + inboard[0+1][j+1];
            if(((counter == 2)&&(inboard[0][j]==1)) ||
              ((counter == 3)))
             {
               outboard[0][j] = 1;
            }
            else
            {
               outboard[0][j] = 0;
            }  
      }

      // do the bottom edge (i = M - 1 )
      for(int j = 1; j < Nminus1; j++)
      {
           int counter = inboard[Mminus1][j-1]    + inboard[Mminus1][j+1] +
                          inboard[Mminus1-1][j]   + 0 /* no bottom */ +
                          inboard[Mminus1-1][j-1] + inboard[Mminus1-1][j+1] +
                          0 /* no LL */           + 0 /* no LR */;
            if(((counter == 2)&&(inboard[Mminus1][j]==1)) ||
              ((counter == 3)))
            {
               outboard[Mminus1][j] = 1;
            }
            else
            {
               outboard[Mminus1][j] = 0;
            }  
      }

      // do the corners last
      // top left:
      int counter = inboard[0][1] + inboard[1][0] + inboard[1][1];
      if(((counter == 2)&&(inboard[0][0]==1)) ||
              ((counter == 3)))
      {
         outboard[0][0] = 1;
      }
      else
      {
         outboard[0][0] = 0;
      }  

      counter = inboard[0][N-2] + inboard[1][N-1] + 
                    inboard[1][N-2];
      if(((counter == 2)&&(inboard[0][N-1]==1)) ||
              ((counter == 3)))
       {
         outboard[0][N-1] = 1;
      }
      else
      {
         outboard[0][N-1] = 0;
      }  
 
      counter = inboard[M-2][0] + inboard[M-1][1] + 
                    inboard[M-2][1];
      if(((counter == 2)&&(inboard[M-1][0]==1)) ||
              ((counter == 3)))
       {
         outboard[M-1][0] = 1;
      }
      else
      {
         outboard[M-1][0] = 0;
      }  
      
      counter = inboard[M-1][N-2] + inboard[M-2][N-2] + 
                    inboard[M-2][N-1];
      if(((counter == 2)&&(inboard[M-1][N-1]==1)) ||
              ((counter == 3)))
       {
         outboard[M-1][N-1] = 1;
      }
      else
      {
         outboard[M-1][N-1] = 0;
      }  
      
   }
   
   public void doOneGeneration()
   {
      if((generation_count % 2) == 0)
        internaldoOneGeneration(board0,board1);
      else
        internaldoOneGeneration(board1,board0);
      
      ++generation_count;
   }
   
   public void doGenerations(int g)
   {
      for(int i = 0; i < g; i++)
      {
         doOneGeneration();
      }
   }
   
}
