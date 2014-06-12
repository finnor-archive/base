// TokenClass enumeration definition
// TokenClass is an enumeration to represent lexical token classes in the 
// MicroLua programming language.

public enum TokenClass {
  EOF, 
  // keywords
  REQUIRE, LISTQ, FUNCTION, RETURN, END, DO, LOCAL, IF, THEN , ELSE, WHILE, PRINT, LIST, EQLIST, NIL, HEAD, TAIL, CONS,
  // punctuation
  COMMA, PERIOD, SEMICOLON,
  // operators
  OR, AND, NOT, ASSIGN, PLUS, MINUS, TIMES, SLASH, EQ, LT, GT, NE, LE, GE, LPAREN, RPAREN, 
  // ids and integers
  ID, INTEGER,
  // comment
  COMMENT
}