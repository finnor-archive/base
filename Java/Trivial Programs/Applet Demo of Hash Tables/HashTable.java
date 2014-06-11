//**********************************************************
//*                                                        *
//*        CS302  HashTable with Quadratic Probing         *
//*                                                        *
//*                                                        *
//*                  Adrian Flannery                       *
//*                     adrianu2                           *
//*          Builds dictionary hash table and              *
//*         methods to support insertion and find          *
//*                                                        *
//**********************************************************
import java.util.*;
import java.io.*;

public class HashTable
{
   private Scanner outFile;
   private String[] table;
   private int tableSize, sum;
   private File file;

   public HashTable(int size)
   {
      tableSize = size;
      table = new String[tableSize];
   }

   public int hash(String key)
   {
      int hashVal = 0;

      for(int i = 0; i < key.length(); i++)
        hashVal = 37 * hashVal + key.charAt(i);

      hashVal = hashVal % tableSize;

      if (hashVal < 0)
         hashVal = hashVal + tableSize;

      return hashVal;
   }



   public void insert(String key)
   {
      int homeLocation = 0;
      int location = 0;
      int count = 0;
      key = key.toLowerCase();       //makes key lowercase
      
      if (find(key).getLocation() == -1)  // make sure key is not already in the table
      {                                    
        homeLocation = hash(key);          // finds home address
        if (table[homeLocation]==null)           //adds to home address if empty
          table[homeLocation] = key;           
        else 
        {
          location = homeLocation;              //else adds to another cell dictated by quadratic probe
          while(table[(location+(count*count))%tableSize]!=null)
          {
            count++;
          }
          table[(location+(count*count))%tableSize] = key;           
        }
      }
   }



   public Result find(String key)
   {
     int homeLocation = hash(key);
     int location;
     int count = 1;
     if (table[homeLocation]==null)               //checks to see if the home location has a key
     {
       Result result = new Result(-1, homeLocation, count);           //-1 is used to as a tag for a word not in dictionary
       return(result);
     }
     else
     {
       if (table[homeLocation].equals(key))              // checks table to see if home has the key
       {
         Result result = new Result(homeLocation, homeLocation, count);
         return(result);
       }
       else
       {
         while(table[(homeLocation+(count*count))%tableSize]!=null)     //quadratic probes keys to check other cells
         {
           if (table[(homeLocation+(count*count))%tableSize].equals(key))   //checks currently probed cell
           {
             location = (homeLocation+(count*count))%tableSize;
             if (location<0)                                                //makes positive in case of overflow
               location *= -1;
             Result result = new Result(location, homeLocation, count+1);
             return(result);
           }    
           count++;
         }
         
         Result result = new Result(-1, homeLocation, count + 1);       //else key is not in table
         return(result);     
       }
     }
   }


   public void writeTableToFile(int start, int stop)
   {
      String blank = "               ", spaces;

      try
      {
         PrintStream out = new PrintStream(new FileOutputStream("HashFilePrint.txt"));

         for (int i = start; i <= stop; i++)
         {
            out.print("Position: " + i + "\tWord: " + table[i]);
            if (table[i] != null)
            {
               spaces = blank.substring(0,15 - table[i].length());
               out.print(spaces + " Hash Value = " + hash(table[i]));
            }

            out.println();
         }

         out.close();
      }
      catch (FileNotFoundException e)
      {
         e.printStackTrace();
      }

      System.out.println("\n\n*** HashFile.txt written to disk");

   }

}