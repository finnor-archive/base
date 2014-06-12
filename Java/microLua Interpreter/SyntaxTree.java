// SyntaxTree.java

// SyntaxTree is a class to represent a node of a ternary syntax tree.

class SyntaxTree {

  private String node;
  private SyntaxTree left;
  private SyntaxTree middle;
  private SyntaxTree right;

  // constructor functions

  public SyntaxTree () { 
    this (null, null, null, null);
  }

  public SyntaxTree (String nodeValue) {
    this (nodeValue, null, null, null);
  }

  public SyntaxTree (String nodeValue, SyntaxTree leftTree) {
    this (nodeValue, leftTree, null, null);
  }

  public SyntaxTree (String nodeValue, SyntaxTree leftTree, 
      SyntaxTree middleTree) {
    this (nodeValue, leftTree, middleTree, null);
  }

  public SyntaxTree (String nodeValue, SyntaxTree leftTree, 
      SyntaxTree middleTree, SyntaxTree rightTree) {
    node   = nodeValue;
    left   = leftTree;
    middle = middleTree;
    right  = rightTree;
  }

  // selector functions

  public String root ()       { return node; }
  public SyntaxTree left ()   { return left; }
  public SyntaxTree middle () { return middle; }
  public SyntaxTree right ()  { return right; }

  // print prints the tree in Cambridge Polish prefix notation with a heading.

  public void print (String block_name) {
    System . out . println ();
    System . out . println ();
    System . out . println ("Syntax Tree for " + block_name);
    System . out . print ("----------------");
    for (int i = 0; i < block_name . length (); i++)
      System . out . print ("-");
    System . out . println ();
    System . out . print (this);
  }

  // toString returns the tree in Cambridge Polish prefix notation.

  public String toString () {
    if (left == null) 
      return node;
    else if (middle == null)
      return "(" + node + " " + left + ")";
    else if (right == null)
      return "(" + node + " " + left + " " + middle + ")";
    else
      return "(" + node + " " + left + " " + middle + " " + right + ")";
  }

}
