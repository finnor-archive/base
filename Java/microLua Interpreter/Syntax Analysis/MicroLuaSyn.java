class MicroLuaSyn {

  public static void main (String args []) throws java.io.IOException {

    System . out . println ("Source Program");
    System . out . println ("--------------");
    System . out . println ("");

    SyntaxAnalyzer lua = new SyntaxAnalyzer ();
    String[] syntax;
    syntax = lua . chunk ();

    System . out . println ("");
    System . out . println ("");
    System . out . println ("PARSE SUCCESSFUL");
    
    for (int i=0; i<10; i++)
    {
      if (syntax[i]!=null)
        System.out.println("\n\nBlock: " + (i+1) + "\n" + syntax[i]);
    }
  }

}
