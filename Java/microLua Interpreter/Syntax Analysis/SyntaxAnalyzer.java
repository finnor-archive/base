class SyntaxAnalyzer {

  protected MicroLuaLexer lexer; // lexical analyzer
  protected Token token; // current token
  private Token temp;
  private String[] syntax = new String[10];
  private int pos = 0;

  public SyntaxAnalyzer () throws java.io.IOException {
    lexer = new MicroLuaLexer (System . in);
    getToken ();
  }

  private void getToken () throws java.io.IOException { 
    token = lexer . nextToken (); 
  }

  public String[] chunk () throws java.io.IOException
  {
    if (token . symbol () == TokenClass . REQUIRE)
      getToken ();
    else
      ErrorMessage . print (lexer . position (), "require expected");
    if (token . symbol () == TokenClass . LISTSTRING)
      getToken ();
    else
      ErrorMessage . print (lexer . position (), "\"List\"");
    if (token . symbol () == TokenClass . SEMICOLON)
      getToken ();
    else
      ErrorMessage . print (lexer . position (), "; expected");
    localvardecl();
    while (token . symbol () != TokenClass . DO)
    {
      if (token . symbol () == TokenClass . FUNCTION)
        getToken ();
      else
        ErrorMessage . print (lexer . position (), "function expected");
      if (token . symbol () == TokenClass . ID)
        getToken ();
      else
        ErrorMessage . print (lexer . position (), "identifier expected");
      if (token . symbol () == TokenClass . LEFTPAREN)
        getToken ();
      else
        ErrorMessage . print (lexer . position (), "( expected");
      if (token . symbol () != TokenClass . RIGHTPAREN)
      {
        if (token . symbol () == TokenClass . ID)
          getToken ();
        else
          ErrorMessage . print (lexer . position (), "identifier expected");
        while (token . symbol () != TokenClass . RIGHTPAREN)
        {
          if (token . symbol () == TokenClass . COMMA)
            getToken();
          else
            ErrorMessage . print (lexer . position (), ", expected");
          if (token . symbol () == TokenClass . ID)
            getToken ();
          else
            ErrorMessage . print (lexer . position (), "identifier expected");
        }
      }
      getToken();
      if (token . symbol () != TokenClass . RETURN)
        block();
      if (token . symbol () == TokenClass . RETURN)
        getToken();
      else
        ErrorMessage . print (lexer . position (), "return expected");
      syntax[pos]+= "(return " + addexp();
      if (token . symbol () == TokenClass . SEMICOLON)
        getToken();
      else
        ErrorMessage . print (lexer . position (), "; expected");
      if (token . symbol () == TokenClass . END)
        getToken();
      else
        ErrorMessage . print (lexer . position (), "end expected");
      pos++;
    }
    getToken();
    block();
    if (token . symbol () == TokenClass . END)
      getToken();
    else
        ErrorMessage . print (lexer . position (), "end expected");
    if (token . symbol () != TokenClass . EOF)
      ErrorMessage . print (lexer . position (), "Instructions after end");
    return (syntax);
  }

  public void localvardecl () throws java.io.IOException 
  {
    if (token . symbol () == TokenClass . LOCAL)
    {
      getToken ();
      if (token . symbol () == TokenClass . ID)
        getToken ();
      else
        ErrorMessage . print (lexer . position (), "identifier expected");
      while (token . symbol () != TokenClass . SEMICOLON)
      {
        if (token . symbol () == TokenClass . COMMA)
          getToken();
        else
          ErrorMessage . print (lexer . position (), ", expected");
        if (token . symbol () == TokenClass . ID)
          getToken ();
        else
          ErrorMessage . print (lexer . position (), "identifier expected");
      }
      getToken();
    }   
  }

  public void block () throws java.io.IOException 
  {
    boolean condition;
    localvardecl();
    
    condition = (token . symbol () == TokenClass . ID) || (token . symbol () == TokenClass . WHILE) || (token . symbol () == TokenClass . IF) || (token . symbol () == TokenClass . PRINT);
    while (condition)
    {
      if (syntax[pos] == (null))
        syntax[pos] = "(" + stat() + ")";
      else
        syntax[pos] = syntax[pos] + "(" + stat() + ")";
      if (token . symbol () == TokenClass . SEMICOLON)
        getToken();
      else
        ErrorMessage . print (lexer . position (), "; expected");
      condition = (token . symbol () == TokenClass . ID) || (token . symbol () == TokenClass . WHILE) || (token . symbol () == TokenClass . IF) || (token . symbol () == TokenClass . PRINT);
    }
  }

  public String stat () throws java.io.IOException 
  {
    boolean condition;
    String tempS = "";
    String temp2 = "";
    
    if (token . symbol () == TokenClass . WHILE)
    {
      temp2 = ")";
      getToken();
      tempS = "while( " + orexp() + ")do(";
      if (token . symbol () == TokenClass . DO)
      {
        getToken();
        while ((token . symbol () != TokenClass . END))
        {
          tempS = tempS + "(" + stat();
          temp2 = temp2 + ")";
          if (token . symbol () == TokenClass . SEMICOLON)
            getToken();
          else
            ErrorMessage . print (lexer . position (), "; expected");
        }
        getToken();
      }
      else
          ErrorMessage . print (lexer . position (), "do expected");
      return (tempS + temp2);
    }
    else
    {
      if (token . symbol () == TokenClass . IF)
      {
        getToken();
        tempS = "then(if(";
        tempS = tempS + orexp() + ")";
        if (token . symbol () == TokenClass . THEN)
        {
          getToken();
          condition = (token . symbol () != TokenClass . END) && (token . symbol () != TokenClass . ELSE);
          while (condition)
          {
            tempS = tempS + "(" + stat();
            temp2 = temp2 + ")";
            if (token . symbol () == TokenClass . SEMICOLON)
              getToken();
            else
              ErrorMessage . print (lexer . position (), "; expected");
            condition = (token . symbol () != TokenClass . END) && (token . symbol () != TokenClass . ELSE);
          }
          tempS = tempS + temp2;
          if (token . symbol () == TokenClass . ELSE)
          {
            temp2 = ")";
            tempS = tempS + " else(";
            getToken();
            while (token . symbol () != TokenClass . END)
            {
              tempS = tempS + "(" + stat();
              temp2 = temp2 + ")";
              if (token . symbol () == TokenClass . SEMICOLON)
                getToken();
              else
                ErrorMessage . print (lexer . position (), "; expected");
            }
            tempS = tempS + temp2;
          }
          getToken();
        }
        else
              ErrorMessage . print (lexer . position (), "then expected");
      }
      else
      {
        if (token . symbol () == TokenClass . PRINT)
        {
          getToken(); 
          if (token . symbol () == TokenClass . LEFTPAREN)
            getToken();
          else
              ErrorMessage . print (lexer . position (), "( expected");
          tempS = "print(" + addexp() + ")";
          if (token . symbol () == TokenClass . RIGHTPAREN)
            getToken();
          else
              ErrorMessage . print (lexer . position (), ") expected");
        }
        else
        {
          if (token . symbol () == TokenClass . ID)
          {
            tempS = "= " + token.lexeme() + " "; 
            getToken ();
            if (token . symbol () == TokenClass . ASSIGN)
              getToken();
            else
              ErrorMessage . print (lexer . position (), "= expected");
            tempS = tempS + "(" + addexp() + ")";
          }
        }
      }
    }
    return (tempS);
  }
  
      
  public String orexp () throws java.io.IOException 
  {
    String tempS;
    String temp2 = "";
    tempS = andexp();
    while (token . symbol () == TokenClass . OR) 
    { 
      tempS = "(or" + tempS;
      temp2 = temp2 + ")";
      getToken ();
      tempS = tempS + andexp();
    } 
    return (tempS + temp2);
  }

  public String andexp () throws java.io.IOException 
  {
    String tempS;
    String temp2 = "";
    tempS = relexp();
    while (token . symbol () == TokenClass . AND) 
    { 
      tempS = "(and " + tempS;
      temp2 = temp2 + ")";
      getToken ();
      tempS = tempS + relexp();
    } 
    return (tempS + temp2);
  }
  
  public String relexp () throws java.io.IOException 
  {
    String tempS;
    String temp2 = "";
    if (token . symbol () == TokenClass . NOT) 
    { 
      getToken ();
      if (token . symbol () == TokenClass . LEFTPAREN)
        getToken();
      else
        ErrorMessage . print (lexer . position (), "( expected");
      tempS = "(not" + orexp() + ")";
      if (token . symbol () == TokenClass . RIGHTPAREN)
        getToken();
      else
        ErrorMessage . print (lexer . position (), ") expected");
      return (tempS);
    }
    else
    { 
      tempS = addexp();
      if (token . symbol () == TokenClass . RELOP)
      {
        tempS = token.lexeme() + " " + tempS;
        getToken ();
        tempS = tempS + addexp();
      }
      return (tempS);
    }
  }        
  
  
  public String relop () throws java.io.IOException 
  {
    String tempS = "";
    if (token . symbol () == TokenClass . RELOP)
    {
      tempS = token.lexeme();
      getToken ();
    }
    else
      ErrorMessage . print (lexer . position (), "relop expected");
    return (tempS);
  }
  
  public String addexp () throws java.io.IOException 
  {
    String tempS;
    String temp2 = "";
    tempS = mulexp();
    
    while (token . symbol () == TokenClass . ADDOP) 
    { 
      tempS = "(" + token.lexeme() + tempS;
      temp2 = temp2 + ")";
      getToken ();
      tempS = tempS + mulexp();
    } 
    return (tempS + temp2);
  }
  
  public String addop () throws java.io.IOException 
  {
    String tempS = "";
    if (token . symbol () == TokenClass . ADDOP) 
    {
      tempS = token.lexeme();
      getToken ();
    }
    else
      ErrorMessage . print (lexer . position (), "addop expected");
    return (tempS);
  }
  
  public String mulexp () throws java.io.IOException 
  {
    String tempS;
    String temp2 = "";
    tempS = unaryexp();
    while (token . symbol () == TokenClass . MULTOP) 
    { 
      tempS = "(" + token.lexeme() + tempS;
      temp2 = temp2 + ")";
      getToken ();
      tempS = tempS + unaryexp();
    } 
    return (tempS +temp2);
  }
  
  public String mulop () throws java.io.IOException 
  {
    String tempS = "";
    if (token . symbol () == TokenClass . MULTOP) 
    {
      tempS = token.lexeme();
      getToken ();
    }
    else
      ErrorMessage . print (lexer . position (), "mulop expected");
    return (tempS);
  }
  
  public String unaryexp () throws java.io.IOException 
  {
    String tempS = "";
    temp = new Token (TokenClass.ADDOP, "-");
    if (token == (temp))
    {
      tempS = "- ";
      getToken ();
    }
    return ("(" + tempS + primary() + ")");
  }
  
  public String primary () throws java.io.IOException 
  {
    String tempS;
    String temp2 = ")";
    if (token . symbol () == TokenClass . NIL) 
    {
      getToken ();
      return ("nil");
    }     
    else
    {
      if (token . symbol () == TokenClass . ID) 
      {
        tempS = token.lexeme();
        getToken ();
        if (token . symbol () == TokenClass . LEFTPAREN) 
        {
          getToken();
          if (token . symbol () != TokenClass . RIGHTPAREN)
          {
            tempS = tempS + "(" + addexp();
            while (token . symbol () != TokenClass . RIGHTPAREN)
            {
              if (token . symbol () == TokenClass . COMMA)
                getToken();
              else
                ErrorMessage . print (lexer . position (), ", expected");
              tempS = tempS + "(, " + addexp();
              temp2 = temp2 + ")";
            }
            tempS = tempS + temp2;
            getToken();
          }
        }
        return(tempS);
      }
      else
      {
        if (token . symbol () == TokenClass . INTEGER) 
        {
          tempS = token.lexeme();
          getToken ();
          return (tempS);
        }
        else
        {
          if (token . symbol () == TokenClass . LEFTPAREN)
          {
            getToken ();
            tempS = addexp();
            if (token . symbol () == TokenClass . RIGHTPAREN)
              getToken();
            else
                ErrorMessage . print (lexer . position (), ") expected");
            return (tempS);
          }
          else 
          {
            if (token . symbol () == TokenClass . LIST)
            {
              getToken();
              if (token . symbol () == TokenClass . DOT)
                getToken();
              else
                ErrorMessage . print (lexer . position (), ". expected");
              tempS = "List.";
              if (token . lexeme () .equals ("cons"))
              {
                tempS = tempS +"cons";
                getToken();
                if (token . symbol () == TokenClass . LEFTPAREN)
                  getToken();
                else
                  ErrorMessage . print (lexer . position (), "( expected");
                tempS = tempS + "(, "; 
                tempS = tempS + "(" + addexp() + ")"; 
                if (token . symbol () == TokenClass . COMMA)
                  getToken();
                else
                  ErrorMessage . print (lexer . position (), ", expected");
                tempS = tempS + " " + primary() + ")";
                if (token . symbol () == TokenClass . RIGHTPAREN)
                  getToken();
                else
                  ErrorMessage . print (lexer . position (), ") expected");
                return(tempS);
              }
              else
              {
                if (token . lexeme ().equals ("eqlist"))
                {
                  tempS = tempS + "eqlist";
                  getToken();
                  if (token . symbol () == TokenClass . LEFTPAREN)
                    getToken();
                  else
                    ErrorMessage . print (lexer . position (), "( expected");
                  tempS = tempS + "(, " + primary();
                  if (token . symbol () == TokenClass . COMMA)
                    getToken();
                  else
                    ErrorMessage . print (lexer . position (), ", expected");
                  tempS = tempS + primary() + ")";
                  if (token . symbol () == TokenClass . RIGHTPAREN)
                    getToken();
                  else
                    ErrorMessage . print (lexer . position (), ") expected");
                  return (tempS);
                }
                else
                {
                  if (token . symbol () == TokenClass . LISTOP)
                  {
                    tempS = tempS + token.lexeme() + "(, ";
                    getToken();
                    if (token . symbol () == TokenClass . LEFTPAREN)
                      getToken();
                    else
                      ErrorMessage . print (lexer . position (), "( expected");
                    tempS = tempS + primary() + ")";
                    if (token . symbol () == TokenClass . RIGHTPAREN)
                      getToken();
                    else
                      ErrorMessage . print (lexer . position (), ") expected");
                    return (tempS);
                  }
                }
              }
            }
            else 
              ErrorMessage . print (lexer . position (), "Primary expected");
          }
        }
      }
    }
    return("");
  }
}
