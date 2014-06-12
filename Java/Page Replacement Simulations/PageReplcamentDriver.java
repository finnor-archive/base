//Driver 

import java.util.*;

public class PageReplcamentDriver
{
  public static void main(String[] args)
  {
    Scanner scan = new Scanner(System.in);
    int seed;
    int maxRSize = 10;
    int maxFSize = 90;
    
    System.out.println("Enter a seed: ");
    seed = scan.nextInt();
    
    ReferenceString str = new ReferenceString(seed);
    PageReplacer pageReplacement = new PageReplacer(maxRSize, maxFSize);
    PageReplacerWorst pageReplacementWorst = new PageReplacerWorst(maxRSize, seed);
    
    str.createReferenceStringPoor(110, 10000);
    
    PageReplacerOptimal pageReplacementOptimal = new PageReplacerOptimal(maxRSize, str);
    
    for (int i=0; i<str.size(); i++)
    {
      pageReplacementOptimal.addPage(str.getElement(i), i);
    }
    
    for (int i=0; i<str.size(); i++)
    {
      pageReplacement.addPage(str.getElement(i));
    }
    
    for (int i=0; i<str.size(); i++)
    {
      pageReplacementWorst.addPage(str.getElement(i));
    }
    
    
    System.out.println("\nTotal number of page faults for optimal: " + pageReplacementOptimal.getFaults());
    
    System.out.println("\nNumber of cheap page faults: " + pageReplacement.getCPF());
    System.out.println("Number of expensive page faults: " + pageReplacement.getEPF());
    System.out.println("Total number of page faults: " + (pageReplacement.getEPF() + pageReplacement.getCPF()));
    
    System.out.println("\nNumber of page faults for worst: " + pageReplacementWorst.getPF());
  }
}