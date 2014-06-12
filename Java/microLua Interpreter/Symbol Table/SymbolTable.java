import java.util.*;



public class SymbolTable
{
  private LinkedList<SymbolTableEntry> table = new LinkedList();
  
  public SymbolTable ()                          
  {
  }
  
  public void addID (String id)                    //adds variable identfier 
  {
    table.add(new SymbolTableEntry(id));
  }
  
  public void addFuncID (String id, SymbolTable funcTable, SyntaxTree funcTree)    //adds function identifier
  {
    table.add(new SymbolTableEntry(id, funcTable, funcTree));
  }
   
  public Object getValue (String id)                              //gets either value for var or symbol table fro function 
  {
    SymbolTableEntry entry = this.getEntry(id);
    if (entry.isFunction())
      return(entry.getTable());
    return (entry.getValue());
  }
      
  
  public SymbolTableEntry getEntry (String id)                   //gets SymbolTableEntry object  
  {
    ListIterator<SymbolTableEntry> iterator = table.listIterator(0);
    SymbolTableEntry entry = null;
    
    while (iterator.hasNext())
    {
      entry = iterator.next();
      if (entry.getID().equals(id))
        return (entry);
    }
    return(null);
  }
  
  public String print(boolean func)                              //prints the symbol table
  {
    ListIterator<SymbolTableEntry> iterator = table.listIterator(0);
    SymbolTableEntry entry = null;
    String toS = "";
    
    if (func)                           //if it is a function then the entry is tabbed
    {
      while (iterator.hasNext())                  
      {
        entry = iterator.next();
        System.out.print("\t");
        entry.print();
        System.out.println();
      }
    }
    else                                 //else not tabbed
    {
      while (iterator.hasNext())
      {
        entry = iterator.next();
        entry.print();
        System.out.println();
      }
    }   
    return (toS);
  }
 
}
