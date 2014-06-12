import java.util.Random;

public class Encrypt
{
  private static long sharedKey;
  
  
  /**
   * Encrypts an int[][] array
   * parameter int[][]
   * return int[][]
   */
  public static int[][] encryptInt(int[][] input)
  {
    Random generator = new Random(sharedKey);        // key = password
    int keystream;                             // current value in keystream
    
    for (int i=0; i<input.length; i++)
    {
      for (int j=0; j<input[i].length; j++)
      {
        keystream = generator.nextInt(256);         //generate keystream
        input[i][j] = input[i][j] ^ keystream;     // encrypt / decrypt
      }
    }
    return(input);
  }
  
  
  /**Checks the pass phrase to see if it is correct and allow permission
   * parameter String
   * return boolean
   */
  public static boolean checkKey(String pass)
  {
    if (pass.equals("admin"))            // checks password
    {
      sharedKey = 124632;               // sets key
      return (true);
    }
    else
      return (false);
        
  }
  
  
}