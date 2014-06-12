import java.util.*;

public class OutputFile
{
  private ArrayList<Integer> output;
  
  public OutputFile()
  {
    output = new ArrayList<Integer>();
  }
  
  public boolean add (int num)
  {
    return (output.add(num));
  }
  
  public void print ()
  {
    System.out.println("\n\nContents of Output File");
    System.out.println("-------------------------");
    if (output.size()==0)
      System.out.println("Output File is empty");
    else
    {
      for (int i=0; i<output.size(); i++)
      {
        System.out.println(output.get(i));
      }
    }
  }
}