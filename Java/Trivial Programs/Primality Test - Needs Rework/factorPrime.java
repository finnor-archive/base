import java.lang.Math;
import java.lang.Long;


public class factorPrime
{
  public static void main(String[] args)
  {
    long number = 62765129083L;
    long x=0;
    long y=0;
    Boolean found = false;
    
    for (int i=1; !found; i+=2)
    {
      if (isPrime(i))
      {
        if ((number%i) == 0)
        {
          y = number/i;
          if (isPrime(y))
          {
            found = true;
            x=i;
          }
        }
      }
    }
    
    System.out.print("x = " + x + ";  y = " + y);
  }
  
  
  
  public static boolean isPrime(long n) {
  boolean prime = true;
  for (long i = 3; i <= Math.sqrt(n); i += 2)
   if (n % i == 0) {
    prime = false;
    break;
   }
  if (( n%2 !=0 && prime && n > 2) || n == 2) {
   return true;
  } else {
   return false;
  }
 }

 
  
  
}
                     
   