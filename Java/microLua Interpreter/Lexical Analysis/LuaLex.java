// LuaLex class 
// This class is a MicroLua lexical analyzer which reads a MicroLua source program 
// and outputs the list of tokens comprising that program. 

public class LuaLex {

  private static final int MAX_TOKENS = 100;

  public static void main (String args []) throws java.io.IOException {

    int i, n;
    Token [] token = new Token [MAX_TOKENS];
    LuaLexer lexer = new LuaLexer (System . in);

    System . out . println ("Source Program");
    System . out . println ("--------------");
    System . out . println ();

    n = -1;
    do {
      if (n < MAX_TOKENS)
        token [++n] = lexer . nextToken ();
      else
 ErrorMessage . print (0, "Maximum number of tokens exceeded");
    } while (token [n] . symbol () != TokenClass . EOF);

    System . out . println ();
    System . out . println ("List of Tokens");
    System . out . println ("--------------");
    System . out . println ();
    for (i = 0; i < n; i++)
      System . out . println (token [i]);
    System . out . println ();
  }

}