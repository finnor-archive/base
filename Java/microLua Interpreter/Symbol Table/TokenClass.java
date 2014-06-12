// TokenClass enumeration definition
// TokenClass is an enumeration to represent lexical token classes in the 
// MicroLua programming language.

public enum TokenClass {
  EOF, 
  // keywords
  DO, ELSE, END, FUNCTION, IF, LIST, LOCAL, NIL, PRINT, REQUIRE, RETURN, THEN,
  WHILE,
  // punctuation
  COMMA, DOT, SEMICOLON, 
  // operators
  LEFTPAREN, RIGHTPAREN, ASSIGN, OR, AND, NOT, CONS, EQLIST, RELOP, 
  PLUS, MINUS, MULTOP, LISTOP,
  // "list", ids and integers
  LISTSTRING, ID, INTEGER
}
