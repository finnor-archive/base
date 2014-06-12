// Assign8 class 
// This class is a MicroLua parser which reads a MicroLua source 
// program and outputs the set of syntax trees comprising that program's 
// executable functions. 

public class Assign10 {

  public static void main (String args []) throws java.io.IOException {

    System . out . println ("Source Program");
    System . out . println ("--------------");
    System . out . println ();

    ParserWithSymbolTable parser = new ParserWithSymbolTable ();
    parser . chunk ();

  }

}
