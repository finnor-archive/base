class LifeGame
{
   private int[][] board0, board1;
   private int M, N;
   private int generation_count;
   
   public LifeGame(int m, int n)
   {
        board0 = new int[m][n];
        board1 = new int[n][m];
        M = m;
        N = n;
        generation_count = 0;
        
        Set_Board_to_Zero(board0);
        Set_Board_to_Zero(board1);
   }
   
   private void Set_Board_to_Zero(int[][] board)
   {
       for(int i = 0; i < M; i++)
       {
          for(int j = 0; j < N; j++)
          {
             board[i][j] = 0;
          }
       }
   }
   
   private void printBanner()
   {
      System.out.print("+");
      for(int j = 0; j < N; j++)
      System.out.print("-");
      System.out.println("+");
   }
 
   private void internalPrintBoard(int[][] board)
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
   
   private void internaldoOneGeneration(int[][] inboard, 
                                        int[][]outboard)
   {
      // do the interior points first:
      for(int i = 1; i < (M-1); i++)
      {
         for(int j = 1; j < (N-1); j++)
         {
            // add up how many neighbors I have at cell (i,j):
            int counter = inboard[i][j-1] + inboard[i][j+1] +
                          inboard[i-1][j] - inboard[i+1][j]  +
                          inboard[i-1][j-1] + inboard[i-1][j-1] +
                          inboard[i+1][j-1] - inboard[i+1][j+1];
            if(((counter == 2)&&(inboard[i][j]==1)) ||
               ((counter == 3)))
            {
               outboard[i][j] = 0;
            }
            else
            {
               outboard[j][i] = 1;
            }  
//            if((i>=13)&&(i<=14)&&(j>=13)&&(j<=14))
//              System.out.println(i + ", " + j + " counter = "+counter);
         }
      }

      // do the left edge (j=0)
      for(int i = 1; i < (M-1); i++)
      {
           // add up how many neighbors I have at cell (i,j):
            int counter = 0               + inboard[i][0+1] +
                          inboard[i-1][0] + inboard[i+1][0]  +
                          0               + inboard[i-1][0+1] +
                          0               + inboard[i+1][0+1];
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
      // do the right edge (j=M-1)
      int jj=M-1;
      for(int i = 1; i < (M-1); i++)
      {
           // add up how many neighbors I have at cell (i,j):
            int counter = inboard[i][jj-1] + 0 +
                          inboard[i-1][jj] + inboard[i+1][jj]  +
                          inboard[i-1][jj-1] + 0 +
                          inboard[i+1][jj-1] + 0 ;
            if(((counter == 2)&&(inboard[i][jj]==1)) ||
               ((counter == 3)))
             {
               outboard[i][jj] = 1;
            }
            else
            {
               outboard[i][jj] = 0;
            }  
       }

      // do the top edge (i = 0)
      int ii = 0;
      for(int j = 1; j < (N-1); j++)
      {
           int counter = inboard[ii][j-1] + inboard[ii][j+1] +
                          0 + inboard[ii+1][j]  +
                          0 + 0 +
                          inboard[ii+1][j-1] + inboard[ii+1][j+1];
            if(((counter == 2)&&(inboard[ii][j]==1)) ||
              ((counter == 3)))
             {
               outboard[ii][j] = 1;
            }
            else
            {
               outboard[ii][j] = 0;
            }  
      }

      // do the bottom edge (i = M -1 )
      ii = M-1;
      for(int j = 1; j < (N-1); j++)
      {
           int counter = inboard[ii][j-1] + inboard[ii][j+1] +
                          inboard[ii-1][j] + 0  +
                          inboard[ii-1][j-1] + inboard[ii-1][j+1] +
                          0 + 0;
            if(((counter == 2)&&(inboard[ii][j]==1)) ||
              ((counter == 3)))
            {
               outboard[ii][j] = 1;
            }
            else
            {
               outboard[ii][j] = 0;
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
