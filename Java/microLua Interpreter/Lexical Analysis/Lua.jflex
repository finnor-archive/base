%%
%{
  private void echo () { System . out . print (yytext ()); }

  public int position () { return yycolumn; }
%}

%class    LuaLexer
%function nextToken
%type   Token
%unicode
%line
%column
%eofval{
  { return new Token (TokenClass . EOF); }
%eofval}

Comment    = --(.*)
Identifier = [:letter:]([:letter:] | [:digit:])* ([:"_":]?([:letter:] | [:digit:])+)*        
Integer    = [:digit:] [:digit:]*

%%
[ \t\n]  { echo (); }
{Comment} { echo (); return new Token (TokenClass . COMMENT, yytext ()); }
";"  { echo (); return new Token (TokenClass . SEMICOLON); }
"."  { echo (); return new Token (TokenClass . PERIOD); }
","  { echo (); return new Token (TokenClass . COMMA); }
"<"  { echo (); return new Token (TokenClass . LT); }
"<="  { echo (); return new Token (TokenClass . LE); }
">"  { echo (); return new Token (TokenClass . GT); }
">="  { echo (); return new Token (TokenClass . GE); }
"=="  { echo (); return new Token (TokenClass . EQ); }
"~="  { echo (); return new Token (TokenClass . NE); }
"("  { echo (); return new Token (TokenClass . LPAREN); }
")"  { echo (); return new Token (TokenClass . RPAREN); }
"+"  { echo (); return new Token (TokenClass . PLUS); }
"-"  { echo (); return new Token (TokenClass . MINUS); }
"*"  { echo (); return new Token (TokenClass . TIMES); }
"/"  { echo (); return new Token (TokenClass . SLASH); }
"="  { echo (); return new Token (TokenClass . ASSIGN); }
require  { echo (); return new Token (TokenClass . REQUIRE); }
\"List\"  { echo (); return new Token (TokenClass . LISTQ); }
function  { echo (); return new Token (TokenClass . FUNCTION); }
return  { echo (); return new Token (TokenClass . RETURN); }
end  { echo (); return new Token (TokenClass . END); }
do  { echo (); return new Token (TokenClass . DO); }
local  { echo (); return new Token (TokenClass . LOCAL); }
while { echo (); return new Token (TokenClass . WHILE); }
then  { echo (); return new Token (TokenClass . THEN); }
if  { echo (); return new Token (TokenClass . IF); }
else  { echo (); return new Token (TokenClass . ELSE); }
print  { echo (); return new Token (TokenClass . PRINT); }
or  { echo (); return new Token (TokenClass . OR); }
and  { echo (); return new Token (TokenClass . AND); }
not  { echo (); return new Token (TokenClass . NOT); }
List  { echo (); return new Token (TokenClass . LIST); }
eqlist  { echo (); return new Token (TokenClass . EQLIST); }
nil  { echo (); return new Token (TokenClass . NIL); }
head  { echo (); return new Token (TokenClass . HEAD); }
tail  { echo (); return new Token (TokenClass . TAIL); }
cons  { echo (); return new Token (TokenClass . CONS); }
{Integer} { echo (); return new Token (TokenClass . INTEGER, yytext ()); }
{Identifier} { echo (); return new Token (TokenClass . ID, yytext ()); }
.  { echo (); ErrorMessage . print (yychar, "Illegal character"); }
