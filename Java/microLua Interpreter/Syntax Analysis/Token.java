// Token class definition
// Token is a class to represent lexical tokens in the MicroLua programming 
// language.

public class Token {

  private TokenClass symbol; // current token
  private String lexeme; // lexeme

  public Token () { }

  public Token (TokenClass symbol) {
    this (symbol, null);
  }

  public Token (TokenClass symbol, String lexeme) {
    this . symbol = symbol;
    this . lexeme  = lexeme;
  }

  public TokenClass symbol () { return symbol; }

  public String lexeme () { return lexeme; }

  public String toString () {
    switch (symbol) {
      case DO :           return "(keyword, do) ";
      case ELSE :         return "(keyword, else) ";
      case END :          return "(keyword, end) ";
      case FUNCTION :     return "(keyword, function) ";
      case IF :           return "(keyword, if) ";
      case THEN :         return "(keyword, then) ";
      case LIST :         return "(keyword, List) ";
      case LOCAL :        return "(keyword, local) ";
      case NIL :          return "(keyword, nil) ";
      case PRINT :        return "(keyword, print) ";
      case REQUIRE :      return "(keyword, require) ";
      case RETURN :       return "(keyword, return) ";
      case WHILE :        return "(keyword, while) ";
      case COMMA :        return "(punctuation, ,) ";
      case DOT :          return "(punctuation, .) ";
      case SEMICOLON :    return "(punctuation, ;) ";
      case LEFTPAREN :    return "(operator, () ";
      case RIGHTPAREN :   return "(operator, )) ";
      case ASSIGN :       return "(operator, =) ";
      case AND :          return "(operator, and) ";
      case NOT :          return "(operator, not) ";
      case OR :           return "(operator, or) ";
      case ADDOP :        return "(operator, " + lexeme + ") ";
      case MULTOP :       return "(operator, " + lexeme + ") ";
      case RELOP :        return "(operator, " + lexeme + ") ";
      case LISTOP :       return "(operator, " + lexeme + ") ";
      case LISTSTRING :   return "(string, \"List\") ";
      case ID :           return "(identifier, " + lexeme + ") ";
      case INTEGER :      return "(integer, " + lexeme + ") ";
      default :           ErrorMessage . print (0, "Unrecognized token");
                          return null;
    }
  }

}
