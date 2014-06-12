/*Adrian Flannery
 * adrianu2
 * CS303
 * 6/21/10
 */

import java.util.Random;

public class TestSorts 
{

	public static void main(String[] args) 
	{
		int arrayLength=1000;
		int[] testArray = new int[arrayLength];
		long time;
		long numSorts = 1000;
		Random generator = new Random();
		
		
		/*				Testing the sorting algorithms
		for (int i=0; i<arrayLength-1; i++)	//populates array, in this case descending order
		{
			testArray[i] = arrayLength-i;
		}

		
		
		time = System.currentTimeMillis();
		for (int i = 0; i<numSorts-1; i++)
		{
			bSort(testArray, 0, (arrayLength-1));
		}
		time = System.currentTimeMillis() - time;
		
		System.out.println("Time to sort " + testArray.length + 
				" a sorted array in descending order of items " + numSorts + 
				" times with BubbleSort: " + time + "ms");
		
		*/
	}

	
	
	
	public static void qSort(int[] items, int l, int r)
	{
		int[] newArray = items; //copies array so original array can be sorted again 
		if ((r-l)>1)   //case for continuing recursive calls
		{
			int i = partition(newArray, l, r);
			qSort(newArray, l, i-1);
			qSort(newArray, i+1, r);
		}
	}
	
	//partitions the array into <i...i...>i    returns i
	private static int partition(int[] items, int l, int r)
	{
		int i = l-1;                
		int j=r;
		int v = r;
		                  
		for(;;)
		{
			while(items[++i]< v) ;   //skips elements already partitioned
			while(v<items[j--])		//skips elements already partitioned
			{
				if (j==1)          //case for ending loop
					break;
			}
			if(i>=j)	//case for breaking for loop
				break;
			Swap(items, i, j);		//else swap items
		}
		Swap(items, i, r);		//puts partition in middle
		return (i);			
	}
	
	//swaps elements
	private static void Swap(int[] items, int i, int r)
	{
		int temp = i;
		i = r;
		r = temp;
	}
	
	
	
	
	
	
	public static void mSort(int[] values, int l, int r) 
	  {
		int[] newArray = values;         //copies array so original array can be sorted again
	    int[] tempArray = new int[r-l];  
	    mergeSort(newArray, tempArray, 0, (r-l - 1));
	  }
	    
	  //recursive call
	  private static void mergeSort(int [] values, int [] tempArray, int l, int r)
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
	  private static void merge(int [] values, int [] tempArray, int lPos, int rPos, int rEnd) 
	  {
	    int lEnd = rPos - 1;   //sets the boundary for left array
	    int tmpPos = lPos;     
	    int numElements = rEnd - lPos + 1;  
	          
	    while(lPos <= lEnd && rPos <= rEnd)             //sorts the values
	    {
	      if(values[lPos]<values[rPos])
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
	  
	  
	  
	  
	  
	  
	  public static void bSort(int[] items, int l, int r)
	  {
		  int[] newArray = items;		//copies array so original array can be sorted again
		  	for(int i=l; i<r; i++)       //loops from front of array until the end
			{
				for (int j=r; j>i; j--)       //loops from back to i
				{
					CompareAndSwap(newArray, j-1, j);    //compares elements along the way to be swapped
				}
			}
	  }
		
		private static void CompareAndSwap(int[] newArray, int x, int y)
		{
			int temp;
			if (newArray[x]>newArray[y])     //case for swapping
			{
				temp=newArray[x];
				newArray[x]=newArray[y];
				newArray[y]=temp;
			}
		}
}
