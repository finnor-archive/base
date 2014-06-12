/*Adrian Flannery
 * Lab 1
 * CS303
 * 6/7/10         */


import java.io.*;

public class mergeSort 
{
  public static void main(String[] args)
  {
    String [] values = new String[446000]; //approximate size of dictionary
 
    File file = new File("Z:\\CS303L\\list.txt");
    try
    {
      BufferedReader in = new BufferedReader(new FileReader(file)); 
      
      
      String input = in.readLine();         //reads in file
      for(int i=0; (input != null); i++)
      { 
        input = in.readLine();
        values[i] = input; 
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
 
    int length = 0;                   //gets length of the array
    while(values[length] !=null)
    {
      length++;
    }
  
    mergeSort(values, length);
  }


  //base case for recursive call
  public static void mergeSort(String[] values, int length) 
  {
    String [] tempArray = new String[length];
    mergeSort(values, tempArray, 0, length - 1);
  }
    
  //recursive call
  private static void mergeSort(String [] values, String [] tempArray, int l, int r)
  {
    if(l < r)           //checks to see if finished 
    {
      int center = (l + r) / 2;           
      mergeSort( values, tempArray, l, center );       //recursive call for left side
      mergeSort( values, tempArray, center + 1, r );   //recursive call for right side
      merge(values, tempArray, l, center + 1, r );     //call to merge every temporary array generated
    }
  }
    
  //merges several arrays
  private static void merge(String [] values, String [] tempArray, int lPos, int rPos, int rEnd) 
  {
    int lEnd = rPos - 1;   //sets the boundary for left array
    int tmpPos = lPos;     
    int numElements = rEnd - lPos + 1;  
          
    while(lPos <= lEnd && rPos <= rEnd)             //sorts the values
    {
      if(values[lPos].compareTo(values[rPos]) <= 0)
        tempArray[tmpPos++] = values[lPos++];
      else
        tempArray[tmpPos++] = values[rPos++];
    }
        
    while(lPos <= lEnd)    //copies the rest of left half
      tempArray[tmpPos++] = values[lPos++];
        
    while(rPos <= rEnd)  //copies the rest of right half
      tempArray[tmpPos++] = values[rPos++];
        
    //copies tempArray back
    for(int i = 0; i < numElements; i++, rEnd--)
      values[rEnd] = tempArray[rEnd];
  }
}