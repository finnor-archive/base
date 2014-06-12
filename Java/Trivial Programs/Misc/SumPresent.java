public class SumPresent
{
  public static void main (String[] args)
  {
    int x = 18;
    int[] set = new int[10];
    int[] newSet = new int[10];
    boolean result = false;
    for (int i=0; i<set.length; i++)
    {
      set[i] = i+1;
      newSet[i] = x - (i+1);
    }
    
    int j = newSet.length-1;
    for (int i=0; i<set.length; i++)
    {
      while (newSet[j]<set[i] && j!=0)
        j--;
      if (newSet[j]==set[i] && i!=j)
      {
        System.out.println("Set " + i + " " + set[i]);
        System.out.println("newSet " + j + " " + newSet[j]);
        result = true;
      }
    }
    
    System.out.println(result);
    
  }
}