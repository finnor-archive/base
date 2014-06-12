public class SymbolTableEntry
{
  private String id;
  private Object value;
  private SymbolTable table;
  private SyntaxTree tree;
  
  public SymbolTableEntry(String inID)                          //constructor for variable
  {
    id = inID;
    value = null;
  }
  
  public SymbolTableEntry(String inID, SymbolTable inTable, SyntaxTree inTree)           //constructor for function
  {
    id = inID;
    table = inTable;
    tree = inTree;
  }
  
  public String getID()
  {
    return id;
  }
  
  public Object getValue()
  {
    return value;
  }
  
  public SymbolTable getTable()
  {
    return table;
  }
  
  public boolean isFunction()
  {
    if (table == null)
      return (false);
    return (true);
  }
  
  
  public void print()                       //prints the entry
  {
    if (table == null)
      System.out.print("Variable ID: " + id + "\t" + "Value: " + value);
    else
    {
      System.out.print("\tFunction ID: " + id + "\n\t" + id + 
        " Symbol Table:\n");
        System.out.print(table.print(true) + "\t" +
                         id + " Syntax Tree:\n\t" + tree);
    }
  }
}
  
  