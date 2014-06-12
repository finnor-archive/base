// Parser is a class to represent a recursive descent parser for the 
// MicroLua programming language.  The parser also constructs a 
// syntax tree representation of all executable constructions.

import java.util.*;

public class Parser {

  protected MicroLuaLexer lexer;  // lexical analyzer
  protected Token token;           // current token
  protected SymbolTable table = new SymbolTable();
  protected SymbolTable funcTable = new SymbolTable();

  public Parser () throws java.io.IOException {
    lexer = new MicroLuaLexer (System . in);
    getToken ();
  }

  protected void getToken () throws java.io.IOException {
    token = lexer . nextToken ();
  }

  // chunk parses MicroLua chunks.

  public void chunk () throws java.io.IOException {
    String functionId;
    SyntaxTree blockTree = null, expressionTree, returnTree;
    if (token . symbol () != TokenClass . REQUIRE)  // require
      ErrorMessage . print ("require EXPECTED");
    getToken ();
    if (token . symbol () != TokenClass . LISTSTRING)   // "List"
      ErrorMessage . print ("\"List\" EXPECTED");
    getToken ();
    if (token . symbol () != TokenClass . SEMICOLON)    // ;
      ErrorMessage . print ("; EXPECTED");
    getToken ();
    localVarDecl ("");                                                                   //localvardecl for main block
    while (token . symbol () == TokenClass . FUNCTION) { // { function
      getToken ();
      funcTable = new SymbolTable();                                                      //clears new funcTable
      if (token . symbol () != TokenClass . ID)   // identifier
        ErrorMessage . print ("identifier EXPECTED");
      functionId = token . lexeme ();
      getToken ();
      if (token . symbol () != TokenClass . LEFTPAREN)  // (
        ErrorMessage . print ("( EXPECTED");
      getToken ();
      funcTable.addID(token.lexeme());                                                 //adds parameter to funcTable
      if (token . symbol () == TokenClass . ID) {  // [ identifier
        getToken ();
        while (token . symbol () == TokenClass . COMMA) { // { ,
          getToken ();
          funcTable.addID(token.lexeme());                                                   //adds parameter to funcTable
          if (token . symbol () != TokenClass . ID)   // identifier
            ErrorMessage . print ("identifier EXPECTED");
          getToken ();
        }       // }
      }       // ]
      if (token . symbol () != TokenClass . RIGHTPAREN) // )
        ErrorMessage . print (") EXPECTED");
      getToken ();
      if (token . symbol () != TokenClass . RETURN)   // [ 
        blockTree = block (functionId);     // block ]
      if (token . symbol () != TokenClass . RETURN)   // return
        ErrorMessage . print ("return EXPECTED");
      getToken ();
      expressionTree = addExp ();    // addexp
      returnTree = new SyntaxTree ("return", expressionTree);
      if (blockTree == null)
        blockTree = returnTree;
      else
        blockTree = new SyntaxTree (";", blockTree, returnTree);
      if (token . symbol () != TokenClass . SEMICOLON)  // ;
        ErrorMessage . print ("; EXPECTED");
      table.addFuncID(functionId, funcTable, blockTree);                                        //add function identfier
      getToken ();
      if (token . symbol () != TokenClass . END)  // end
        ErrorMessage . print ("end EXPECTED");
      blockTree . print (functionId);
      getToken ();
    }        // }
    if (token . symbol () != TokenClass . DO)     // do
      ErrorMessage . print ("do EXPECTED");
    getToken ();
    blockTree = block ("");     // block
    if (token . symbol () != TokenClass . END)   // end
      ErrorMessage . print ("end EXPECTED");
    getToken ();      
    blockTree . print ("main");
    System . out . println ();
    
    
    System.out.println("\nMain Symbol Table:\n--------------------");
    table.print(false);
  }

  // localVarDecl parses local variable declarations.

  public void localVarDecl (String blockName) throws java.io.IOException {
    while (token . symbol () == TokenClass . LOCAL) {  // { local
      getToken ();
      if(blockName.equals(""))
        table.addID(token.lexeme());                                        //add identifier to main table
      else
        funcTable.addID(token.lexeme());                                    //add identifier to function table
      if (token . symbol () != TokenClass . ID)   // identifier
        ErrorMessage . print ("identifier EXPECTED");
      getToken ();
      while (token . symbol () == TokenClass . COMMA) { // { ,
        getToken ();
        if(blockName.equals(""))
          table.addID(token.lexeme());                                      //add identifier to main table
        else
          funcTable.addID(token.lexeme());                                  //add identifier to function table
        if (token . symbol () != TokenClass . ID)   // identifier
          ErrorMessage . print ("identifier EXPECTED");
        getToken ();
      }       // }
      if (token . symbol () != TokenClass . SEMICOLON)  // ;
        ErrorMessage . print ("; EXPECTED");
      getToken ();
    }        // }
  }

  // block parses blocks.

  public SyntaxTree block (String blockName) throws java.io.IOException {
    SyntaxTree syntaxTree;
    localVarDecl (blockName);      // localvardecl
    syntaxTree = statList ();     // { stat ; }
    return syntaxTree;
  }

  // statList parses statement lists.

  public SyntaxTree statList () throws java.io.IOException {
    SyntaxTree statementTree, syntaxTree = null;
    while (token . symbol () == TokenClass . ID ||
        token . symbol () == TokenClass . WHILE ||
        token . symbol () == TokenClass . IF ||
        token . symbol () == TokenClass . PRINT) {  // {
      statementTree = stat ();     // stat
      if (syntaxTree == null)
        syntaxTree = statementTree;
      else
        syntaxTree = new SyntaxTree (";", syntaxTree, statementTree);
      if (token . symbol () != TokenClass . SEMICOLON)  // ;
        ErrorMessage . print ("; EXPECTED");
      getToken ();
    }        // }
    return syntaxTree;
  }

  // stat parses statements.

  public SyntaxTree stat () throws java.io.IOException {
    SyntaxTree expressionTree, idTree, syntaxTree = null;
    SyntaxTree statementTree = null, statement1Tree, statement2Tree;

    switch (token . symbol ()) {

      case ID  :        // id
        idTree = new SyntaxTree (token . lexeme ());
        getToken ();
        if (token . symbol () != TokenClass . ASSIGN)    // =
          ErrorMessage . print ("= EXPECTED");
        getToken ();     
        expressionTree = addExp ();      // addexp
        syntaxTree = new SyntaxTree ("=", idTree, expressionTree);
        break;

      case WHILE :       // while
        getToken (); 
        expressionTree = orExp ();        // orexp
        if (token . symbol () != TokenClass . DO)    // do
          ErrorMessage . print ("do EXPECTED");
        getToken ();     
        statementTree = statList ();     // { stat ; }
        if (token . symbol () != TokenClass . END)    // end
          ErrorMessage . print ("end EXPECTED");
        getToken ();     
        syntaxTree = 
          new SyntaxTree ("while", expressionTree, statementTree);
        break;

      case IF :        // if
        getToken ();
        expressionTree = orExp ();        // orexp
        if (token . symbol () != TokenClass . THEN)    // then
          ErrorMessage . print ("then EXPECTED");
        getToken ();     
        statement1Tree = statList ();     // { stat ; }
        if (token . symbol () == TokenClass . ELSE) {   // [ else
     getToken ();      
     statement2Tree = statList ();              // { stat ; }
        }
        else
          statement2Tree = null;      // ]
        syntaxTree = 
     new SyntaxTree ("if", expressionTree, statement1Tree, statement2Tree);
        if (token . symbol () != TokenClass . END)    // end
          ErrorMessage . print ("end EXPECTED");
        getToken ();     
        break;
  
      case PRINT :       // print
        getToken ();
        if (token . symbol () != TokenClass . LEFTPAREN)  // (
          ErrorMessage . print ("( EXPECTED");
        getToken ();     
        expressionTree = addExp ();      // addexp
        if (token . symbol () != TokenClass . RIGHTPAREN) // )
          ErrorMessage . print (") EXPECTED");
        getToken ();     
        syntaxTree = new SyntaxTree ("print", expressionTree);
        break;

      default :
        ErrorMessage . print ("STATEMENT EXPECTED");
    }
  
    return syntaxTree;
  }

  // orExp parses or expressions. 
   
  public SyntaxTree orExp () throws java.io.IOException {
    SyntaxTree andExpTree, syntaxTree;
    syntaxTree = andExp ();     // andexp
    while (token . symbol () == TokenClass . OR) {    // { or
      getToken ();
      andExpTree = andExp ();     // andexp
      syntaxTree = new SyntaxTree ("or", syntaxTree, andExpTree);
    }        // }
    return syntaxTree;
  }

  // andExp parses and expressions. 
   
  public SyntaxTree andExp () throws java.io.IOException {
    SyntaxTree relExprTree, syntaxTree;
    syntaxTree = relExpr ();     // relexpr
    while (token . symbol () == TokenClass . AND) {    // { and
      getToken ();
      relExprTree = relExpr ();    // relexpr
      syntaxTree = new SyntaxTree ("and", syntaxTree, relExprTree);
    }        // }
    return syntaxTree;
  }

  // relExpr parses relational expressions. 
   
  public SyntaxTree relExpr () throws java.io.IOException {
    String relop;
    SyntaxTree expressionTree, syntaxTree;
    if (token . symbol () == TokenClass . NOT) { // not
      getToken ();
      if (token . symbol () != TokenClass . LEFTPAREN) // (
        ErrorMessage . print ("( EXPECTED");
      getToken ();
      expressionTree = orExp ();    // orexp
      if (token . symbol () != TokenClass . RIGHTPAREN) // )
        ErrorMessage . print (") EXPECTED");
      getToken ();
      syntaxTree = new SyntaxTree ("not", expressionTree);
    }
    else {
      syntaxTree = addExp ();     // addexp
      if (token . symbol () == TokenClass . RELOP) { // [ relop
        relop = token . lexeme ();
        getToken ();
        expressionTree = addExp ();    // addexp
        syntaxTree = new SyntaxTree (relop, syntaxTree, expressionTree);
      }       // ]
    }
    return syntaxTree;
  }
  
  // addExp parses additive expressions. 
   
  public SyntaxTree addExp () throws java.io.IOException {
    String addop;
    SyntaxTree mulExpTree, syntaxTree;
    syntaxTree = mulExp ();     // mulexp
    while (token . symbol () == TokenClass . PLUS ||  // { addop
        token . symbol () == TokenClass . MINUS) {  
      addop = token . lexeme ();
      getToken ();
      mulExpTree = mulExp ();     // mulexp
      syntaxTree = new SyntaxTree (addop, syntaxTree, mulExpTree);
    }        // }
    return syntaxTree;
  }
  
  // mulExp parses multiplicative expressions. 
   
  public SyntaxTree mulExp () throws java.io.IOException {
    String mulop;
    SyntaxTree syntaxTree, unaryExpTree;
    syntaxTree = unaryExp ();     // unaryexp
    while (token . symbol () == TokenClass . MULTOP) {  // { mulop
      mulop = token . lexeme ();
      getToken ();
      unaryExpTree = unaryExp ();    // unaryexp
      syntaxTree = new SyntaxTree (mulop, syntaxTree, unaryExpTree);
    }        // }
    return syntaxTree;
  }
  
  // unaryExp parses unary expressions.
  
  public SyntaxTree unaryExp () throws java.io.IOException {
    SyntaxTree primaryTree, syntaxTree;
    if (token . symbol () == TokenClass . MINUS) {  // -
      getToken ();
      primaryTree = primary ();    // primary
      syntaxTree = new SyntaxTree ("-", primaryTree);
    }
    else
      syntaxTree = primary ();                // primary
    return syntaxTree;
  }

  // primary parses primaries.
  
  public SyntaxTree primary () throws java.io.IOException {
    String listop;
    SyntaxTree addExpTree, exprListTree, idTree, primaryTree1, primaryTree2;
    SyntaxTree syntaxTree = null;

    switch (token . symbol ()) {

      case NIL :      // nil
        syntaxTree = new SyntaxTree ("Nil");
        getToken ();
        break;

      case INTEGER :      // integer
        syntaxTree = new SyntaxTree (token . lexeme ());
        getToken ();
        break;

      case LEFTPAREN :      // (
        getToken ();
        syntaxTree = addExp ();     // addexp
        if (token . symbol () != TokenClass . RIGHTPAREN) // )
          ErrorMessage . print (") EXPECTED");
        getToken ();
        break;

      case ID :      // id
        idTree = new SyntaxTree (token . lexeme ());
        getToken ();   
        if (token . symbol () != TokenClass . LEFTPAREN)  
          syntaxTree = idTree;    
        else {       // (
          getToken ();
          exprListTree = null;
          if (token . symbol () != TokenClass . RIGHTPAREN)  { // [
            exprListTree = addExp ();   // addexp
            while (token . symbol () == TokenClass . COMMA) { // { , 
              getToken ();
              addExpTree = addExp ();   // addexp
              exprListTree = new SyntaxTree (",", exprListTree, addExpTree);
            }      // }
            if (token . symbol () != TokenClass . RIGHTPAREN) // )
              ErrorMessage . print (") EXPECTED");
          }       // ]
          getToken ();
          syntaxTree = new SyntaxTree ("apply", idTree, exprListTree);
        }
        break;

      case LIST :      // List
        getToken ();
        if (token . symbol () != TokenClass . DOT)  // .
          ErrorMessage . print (". EXPECTED");
        getToken ();
        if (token . symbol () == TokenClass . LISTOP) { // head | tail
          listop = token . lexeme ();
          getToken ();
          if (token . symbol () != TokenClass . LEFTPAREN) // (
            ErrorMessage . print ("( EXPECTED");
          getToken ();
          primaryTree1 = primary ();    // primary
          if (token . symbol () != TokenClass . RIGHTPAREN) // )
            ErrorMessage . print (") EXPECTED");
          getToken ();
          syntaxTree = new SyntaxTree (listop, primaryTree1);
        }
        else if (token . symbol () == TokenClass . CONS) { // cons
          getToken ();
          if (token . symbol () != TokenClass . LEFTPAREN) // (
            ErrorMessage . print ("( EXPECTED");
          getToken ();
          addExpTree = addExp ();    // addexp
          if (token . symbol () != TokenClass . COMMA)  // ,
            ErrorMessage . print (", EXPECTED");
          getToken ();
          primaryTree1 = primary ();    // primary
          if (token . symbol () != TokenClass . RIGHTPAREN) // )
            ErrorMessage . print (") EXPECTED");
          getToken ();
          syntaxTree = new SyntaxTree ("cons", addExpTree, primaryTree1);
        }
        else if (token . symbol () == TokenClass . EQLIST) { // eqlist
          getToken ();
          if (token . symbol () != TokenClass . LEFTPAREN) // (
            ErrorMessage . print ("( EXPECTED");
          getToken ();
          primaryTree1 = primary ();    // primary
          if (token . symbol () != TokenClass . COMMA)  // ,
            ErrorMessage . print (", EXPECTED");
          getToken ();
          primaryTree2 = primary ();    // primary
          if (token . symbol () != TokenClass . RIGHTPAREN) // )
            ErrorMessage . print (") EXPECTED");
          getToken ();
          syntaxTree = new SyntaxTree ("eqlist", primaryTree1, primaryTree2);
        }
        else
          ErrorMessage . print ("LIST OPERATION EXPECTED");
        break;

      default :
        ErrorMessage . print ("PRIMARY EXPECTED");
    }        

    return syntaxTree;
  }

}
