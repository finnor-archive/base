// TokenClass enumeration definition
// TokenClass is an enumeration to represent lexical token classes in the 
// MicroLua programming language.

public enum TokenClass {
  EOF, 
  // keywords
  DO, ELSE, END, FUNCTION, IF, THEN, LIST, LOCAL, NIL, PRINT, REQUIRE, RETURN, WHILE,
  // punctuation
  COMMA, DOT, SEMICOLON, 
  // operators
  LEFTPAREN, RIGHTPAREN, ASSIGN, OR, AND, NOT, RELOP, ADDOP, MULTOP, 
  LISTOP,
  // "list", ids and integers
  LISTSTRING, ID, INTEGER
}
