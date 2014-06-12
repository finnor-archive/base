// Token class definition
// Token is a class to represent lexical tokens in the MicroLua programming 
// language, described in Algorithms + Data Structures = Programs by
// Niklaus Wirth, Prentice-Hall, 1976.

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
      case REQUIRE :   return "(keyword, require) ";
      case LISTQ :     return "(keyword, \"List\") ";
      case FUNCTION :  return "(keyword, function) ";
      case RETURN :    return "(keyword, return) ";
      case END :       return "(keyword, end) ";
      case DO :        return "(keyword, do) ";
      case LOCAL :     return "(keyword, local) ";
      case IF :        return "(keyword, if) ";
      case THEN :      return "(keyword, then) ";
      case ELSE :      return "(keyword, else) ";
      case WHILE :     return "(keyword, while) ";
      case PRINT :     return "(keyword, print) ";
      case OR :        return "(operator, or) ";
      case AND :       return "(operator, and) ";
      case NOT :       return "(operator, not) ";
      case LIST :      return "(keyword, List) ";
      case EQLIST :    return "(keyword, eqlist) ";
      case NIL :       return "(keyword, nil) ";
      case HEAD :      return "(keyword, head) ";
      case TAIL :      return "(keyword, tail) ";
      case CONS :      return "(keyword, cons) ";
      case ASSIGN :    return "(operator, =) ";
      case PLUS :      return "(operator, +) ";
      case MINUS :     return "(operator, -) ";
      case TIMES :     return "(operator, *) ";
      case SLASH :     return "(operator, /) ";
      case EQ :        return "(operator, ==) ";
      case LT :        return "(operator, <) ";
      case GT :        return "(operator, >) ";
      case NE :        return "(operator, ~=) ";
      case LE :        return "(operator, <=) ";
      case GE :        return "(operator, >=) ";
      case LPAREN :    return "(operator, () ";
      case RPAREN :    return "(operator, )) ";
      case COMMA :     return "(punctuation, ,) ";
      case PERIOD :    return "(punctuation, .) ";
      case SEMICOLON : return "(punctuation, ;) ";
      case ID :        return "(identifier, " + lexeme + ") ";
      case INTEGER :   return "(integer, " + lexeme + ") ";
      case COMMENT :   return "(comment, " + lexeme + ") ";
      default : 
 ErrorMessage . print (0, "Unrecognized token");
        return null;
    }
  }

}
