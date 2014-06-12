// Environment.java

// Environment is a class to represent the environment for MicroLua programs.

import java.util.*;

class Environment {

  private TreeMap <String, DenotableValue> map;
  private int maxIdLength = 2; // for heading "Id"

  public Environment () {
    map = new TreeMap <String, DenotableValue> ();
  }

  public TreeMap <String, DenotableValue> map () { return map; }

  public DenotableValue access (String id) {
    return map . get (id);
  }
  
  public boolean containsKey (String id)
  {
    return (map.containsKey(id));
  }
  
  public TreeMap getEnvironment()
  {
    return(map);
  }
  
  public void putAll(Environment tempMap)
  {
    map.putAll(tempMap.getEnvironment());
  }

  public void update (String id, DenotableValue denotVal) {
    DenotableValue currentDenotVal = map . get (id);
    if (id . length () > maxIdLength)
      maxIdLength = id . length ();
    map . put (id, denotVal);
  }

  public void print (String blockName) {
    System . out . println ();
    System . out . println ();
    System . out . println ("Identifier Table for " + blockName);
    System . out . print ("---------------------");
    for (int i = 0; i < blockName . length (); i++) 
      System . out . print ("-");
    System . out . println ();
    System . out . println ();
    System . out . print ("Id");
    for (int i = 0; i < maxIdLength - 2; i++)
      System . out . print (" ");
    System . out . print ("  ");
    System . out . print ("Category");
    System . out . print ("  ");
    System . out . print ("Type");
    System . out . print ("  ");
    System . out . println ("Value");
    System . out . print ("--");
    for (int i = 0; i < maxIdLength - 2; i++)
      System . out . print (" ");
    System . out . print ("  ");
    System . out . print ("--------");
    System . out . print ("  ");
    System . out . print ("----");
    System . out . print ("  ");
    System . out . println ("-----");
    Iterator <Map . Entry <String, DenotableValue>> envIterator = 
      map . entrySet () . iterator ();
    TreeMap <String, FunctionDenot> functionList = 
      new TreeMap <String, FunctionDenot> ();
    while (envIterator . hasNext ()) {
      Map . Entry <String, DenotableValue> envEntry = envIterator . next ();
      String entryId = envEntry . getKey ();
      System . out . print (entryId);
      for (int i = 0; i <= maxIdLength - entryId . length (); i++)
        System . out . print (" ");
      System . out . print (" ");
      DenotableValue entryDenotVal = envEntry . getValue ();
      if (entryDenotVal instanceof ExpressibleValue) { // variable
        System . out . print ("variable");
        System . out . print ("  ");
        System . out . println (entryDenotVal);
      }
      else { // function
        System . out . print ("function");
        System . out . print ("  ");
        System . out . println (entryDenotVal . type ());
 functionList . put (entryId, (FunctionDenot) entryDenotVal);
      }
    }
    Iterator <Map . Entry <String, FunctionDenot>> funcIterator = 
      functionList . entrySet () . iterator ();
    while (funcIterator . hasNext ()) {
      Map . Entry <String, FunctionDenot> funcEntry = funcIterator . next ();
      String funcId = funcEntry . getKey ();
      funcEntry . getValue () . print (funcId);
    }
  }

}

// DenotableValue is a class to represent the denotable values of identifiers
// a MicroLua program. A denotable value is either an expressible value or a 
// function denotation.

class DenotableValue {

  protected Type type;

  public int getType () { return type.getType(); }    //returns type value

  public Type type () { return type; }
  
  public String toString () {
    return type . toString ();
  }

}

// ExpressibleValue is a class to represent the values of expressions in
// a MicroLua program.

class ExpressibleValue extends DenotableValue {

  private Object value; // used as parent class of Integer and ArrayList

  public ExpressibleValue () {
    this . type = null;
    this . value = null;
  }

  public ExpressibleValue (Type type, Object value) {
    this . type  = type;
    this . value = value;
  }

  public Object value () { return value; }

  public String toString () { return type + "  " + value; }

}

// FunctionDenot is a class to represent the components of a MicroLua 
// function.

class FunctionDenot extends DenotableValue {

  private ArrayList <String> parameter;
  private Environment env;
  private SyntaxTree syntaxTree;

  public FunctionDenot (ArrayList <String> funcParameter, Type funcType,
      Environment funcEnv, SyntaxTree funcSyntaxTree) {
    parameter = funcParameter;
    type = funcType;
    env = funcEnv;
    syntaxTree  = funcSyntaxTree;
  }

  public ArrayList <String> parameterList () { return parameter; }
  public Environment environment () { return env; }
  public SyntaxTree functionBody () { return syntaxTree; }

  public void changeEnv (Environment newEnv)           //updates function env
  {
    env = newEnv;
  }
  
  public void print (String functionName) {
    syntaxTree . print (functionName);
    env . print (functionName);
  }

}

// Type is a class to represent the types of values in a MicroLua program.

class Type {

  public static final int INTEGER = 0;
  public static final int LIST    = 1;
  public static final int BOOLEAN = 2;
  public static final int VOID    = 3;

  private int type;

  public Type (int type) {
    this . type = type;
  }

  public int getType () { return type; }

  public String toString () {
    switch (type) {
      case INTEGER : return "int ";
      case LIST    : return "list";
      case BOOLEAN : return "bool";
      case VOID    : return "void";
      default      : return null;
    }
  }  

}
