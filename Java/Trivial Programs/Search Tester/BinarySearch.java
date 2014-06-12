/* Adrian Flannery
 * CS303
 * 6/14/10
 * BinarySearch.java
 */

import java.util.Random;

public class BinarySearch
{
	public static void main(String[] args)
	{
		int n; 							//item that will be searched for
		int[] list = new int[10000];	//list that will occupy values 0-10000 for this case
		boolean found;					//boolean that records fins
		long time;						//time in ms
		long fnd=0;						// counter for # of times found
		long nfnd=0;					// counter for # of times not found
		long searchs = 100000;			//# of searches to be performed
		Random generator = new Random();
		
		for (int i=0; i<list.length; i++)	//populates array
		{
			list[i] = i*2;
		}
		
		time = System.currentTimeMillis();	//starts timer
		for(long i = 0; i<searchs; i++)
		{
			n = generator.nextInt(100000);
			found = bSearch(n, list);
			if (found)
				fnd++;
			else
				nfnd++;
		}
		time = System.currentTimeMillis() - time;	//takes time by difference
		
		System.out.println("\nTime taken to search for " + searchs + " random items in sorted array: " + time + "ms");
		System.out.println("Number of hits: " + fnd);		//for this specific case there should be approximately 1/2 hits
		System.out.println("Number of misses: " + nfnd);
	}
	
	
	public static boolean bSearch(int n, int[] list)
	{
		boolean found = false;
		int low = 0;
		int high = list.length - 1;
		int mid;
		while(low<=high)		//case to continue search
		{
		    mid = (low+high)/2;		//next guess at position

		    if(list[mid]>n)			//position is too high
		        high = mid-1;
		    else
		    {
		    	if(list[mid]<n)		//position is too low
		    	   low = mid+1;
		    	else
		    	{
		    		return true;	//successful find
		    	}
		    }
		}
		return(found);		//miss
	}
}



