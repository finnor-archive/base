/* Adrian Flannery
 * CS303
 * 6/14/10
 * sequentialSearch.java
 */

import java.util.Random;

public class sequentialSearch<AnyType extends Comparable<? super AnyType>>
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
			n = generator.nextInt(20000);
			found = sSearch(n, list);
			if (found)			
				fnd++;			//counts hits
			else
				nfnd++;			//counts misses
		}
		time = System.currentTimeMillis() - time;	//takes time by difference
		
		System.out.println("\nTime taken to search for " + searchs + " random items in sorted array: " + time + "ms");
		System.out.println("Number of hits: " + fnd);		//for this specific case there should be approximately 1/2 hits
		System.out.println("Number of misses: " + nfnd);	
	}
	
	public static boolean sSearch (int n, int[] list)
	{
		for (int i=0; (i<list.length); i++)		//loops through array until it reaches end or finds the value
		{
			if (list[i]==n)		
			{
				return(true);
			}
		}
		
		return (false);   // returns false for a miss
	}
}
