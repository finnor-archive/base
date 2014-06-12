import java.io.*;


public class PQtest 
{

 
 public static void main(String[] args) 
 {
  PQ testPQ = new PQ(500000); 
  long fs = 0;
     File file = new File("F:\\Files\\school\\summer 10\\cs303\\lab 4\\list.txt");
     try
     {
       BufferedReader in = new BufferedReader(new FileReader(file)); 
       
       String input = in.readLine();         //reads in file
       for(int i=0; i<400000; i++)
       { 
         input = in.readLine();
         testPQ.insert(input);
         fs++;
       } 
       in.close(); 
     }
     catch(FileNotFoundException e)    
     {
       e.printStackTrace();
     } 
     catch (IOException e)
     {
       e.printStackTrace();
     }
     
     System.out.println("Number of elements: " + fs);
  
     long time;
     char temp;
     String toBeIns = "";
     int numberIns = 5000;
     int numberRem = 80000;
     int numberPeek = 8000000;
     
     
     time = System.currentTimeMillis();
     for (int i=0; i<numberPeek; i++)
     {
      
      testPQ.peek();
     }
     time = System.currentTimeMillis()- time;
     
     System.out.println("Time to peek at " + numberPeek + " elements: "
       + time + "ms");
     
     
     
     time = System.currentTimeMillis();
     for (int i=0; i<numberIns; i++)
     {
      temp = (char) i;
      toBeIns += temp;
      testPQ.insert(toBeIns); 
     }
     time = System.currentTimeMillis() - time;
     System.out.println("Time to insert " + numberIns + " elements: "
       + time + "ms");
     
     
     
     time = System.currentTimeMillis();
     for (int i=0; i<numberRem; i++)
     {
      testPQ.getmax(); 
     }
     time = System.currentTimeMillis() - time;
     System.out.println("Time to remove " + numberRem + " elements: "
       + time + "ms");
     
 }
}

 