import java.util.*;

public class Interpreter
{
  private OutputFile output;                            //output file
  private SyntaxTree program;                           //main progam block
  private Stack<Environment> stack;                     //stack of function environments
  private Environment global;                           //global env
  private Environment local;                            //current local env
  private TreeMap<String, ExpressibleValue> currentParameters = new TreeMap<String, ExpressibleValue>();     //values of parameters at current depth
  private Stack<TreeMap<String,ExpressibleValue>> paramStack = new Stack<TreeMap<String,ExpressibleValue>>();        //stack of parameters
    
  //constructor for the interpreter
  public Interpreter(Environment env, SyntaxTree tree)
  {
    output = new OutputFile();
    stack = new Stack<Environment>();
    global = env;
    program = tree;
    local = ((FunctionDenot) global.access("_main")).environment();      //sets up first local env
  }
  
  //begins proceesing
  public OutputFile inter ()
  {
    statement (program);
    return (output);
  }
  
  //begins processing on functions
  public ExpressibleValue functionBody(FunctionDenot func, String name, ArrayList<ExpressibleValue> parameterValues)
  {
    FunctionDenot temp;
    SyntaxTree block = func.functionBody();
    ArrayList<String> parameterList = func.parameterList();
    local = func.environment();                //setup new local env
    
    TreeMap<String, ExpressibleValue> oldParameters = new TreeMap<String, ExpressibleValue>();
    oldParameters.putAll(currentParameters);       //copy previous parameters
    paramStack.push(oldParameters);                //place on stack
    
    currentParameters.clear();
    for (int i=0; i<parameterValues.size(); i++)
    {
      currentParameters.put(parameterList.get(i), parameterValues.get(i));    //get current parameters
      local.update(parameterList.get(i), parameterValues.get(i)); 
    }
    

    statement(block);

    global.update(name, new FunctionDenot(func.parameterList(), func.type(), local, func.functionBody()));
    currentParameters = paramStack.pop();         //get previous parameters
    return(expression(block.middle().left())); 
  }

  //processes statement
  private void statement (SyntaxTree tree)
  {
    ExpressibleValue temp;
    DenotableValue temp2;
    DenotableValue temp3;
    if ((tree.root()).equals(";"))   
    {
      statement(tree.left());
      statement(tree.middle());
    }
    else if ((tree.root()).equals("="))          //assignment statements
    {
      if (local.containsKey(tree.left().root()))
      {
        if (currentParameters.size()>0)         //check parameters
        {
          if (currentParameters.containsKey(tree.left().root()))
          {
            temp2 = currentParameters.get(tree.left().root());
            temp = expression(tree.middle());
            if (temp2.type()==null)
              {
                currentParameters.put(tree.left().root(), temp);
                local.update(tree.left().root(), temp); 
              }
              else if (temp2.getType()==temp.getType()) 
              {
                currentParameters.put(tree.left().root(), temp);
                local.update(tree.left().root(), temp); 
              }
              else
                ErrorMessage . print ("Type Error");
            }
            else                                        //check local env
            {
              temp2 = local.access(tree.left().root());
              temp = expression(tree.middle());
              if (temp2.type()==null)
                local.update(tree.left().root(), temp);
              else if (temp2.getType()==temp.getType())
                local.update(tree.left().root(), temp); 
              else
                ErrorMessage . print ("Type Error");
            }
          }
          else
          {
            temp2 = local.access(tree.left().root());
            temp = expression(tree.middle());
            if (temp2.type()==null)
              local.update(tree.left().root(), expression(tree.middle())); 
            else if (temp2.getType()==temp.getType())
              local.update(tree.left().root(), expression(tree.middle())); 
            else
              ErrorMessage . print ("Type Error");
          }
        }
        else if (global.containsKey(tree.left().root()))
        {
          temp2 = global.access(tree.left().root());
          temp = expression(tree.middle());
          if (temp2.type()==null)
            global.update(tree.left().root(), temp);
          else if (temp2.getType()==temp.getType())
            global.update(tree.left().root(), temp); 
          else
            ErrorMessage . print ("Type Error");
        }
        else
          ErrorMessage . print ("Undeclared Error");
    } 
    else if ((tree.root()).equals("if"))                  //routine for if
    {
      temp = expression(tree.left());
      if (temp.getType()!=2)
        ErrorMessage . print ("Type Error");
      else
      {
        if ((Boolean) temp.value())
          statement(tree.middle());
        else
        {
          if (tree.right()!=null)
            statement(tree.right());
        }
      }
    }
    else if ((tree.root()).equals("while"))           //routine for while
    {
      temp = expression(tree.left());
      if (temp.getType()!=2)
        ErrorMessage . print ("Type Error");
      else
      {
        while ((Boolean) temp.value())
        {
          statement(tree.middle());
          temp = expression(tree.left());
        }
      }
    }
    else if ((tree.root()).equals("print"))                    //add to output file
    {
      temp = expression(tree.left());  
      if (temp.getType()==0)
        output.add((Integer)temp.value());
      else
        ErrorMessage . print ("Type Error");
    }
  }
  
  
  //processes expresssions
  private ExpressibleValue expression(SyntaxTree tree)
  {
    ExpressibleValue temp1, temp2;
    DenotableValue temp3;
    LinkedList<Integer> temp4;
    FunctionDenot tempFunc;
    if ((tree.root()).equals("and"))                          //processes and
    {
      temp1 = expression(tree.left());
      temp2 = expression(tree.middle());
      if (temp1.getType() != 2 || temp1.getType() != 2)
        ErrorMessage . print ("Type Error");
      else
      {
        if ((Boolean) temp1.value() && (Boolean) temp2.value())
          return (new ExpressibleValue(new Type(2), true));
        else
          return (new ExpressibleValue(new Type(2), false));
      }
    }
    else if ((tree.root()).equals("or"))                  //processes or
    {
      temp1 = expression(tree.left());
      temp2 = expression(tree.middle());
      if (temp1.getType() != 2 || temp1.getType() != 2)
        ErrorMessage . print ("Type Error");
      else
      {
        if ((Boolean) temp1.value() && (Boolean) temp2.value())
          return (new ExpressibleValue(new Type(2), true));
        else
          return (new ExpressibleValue(new Type(2), false));
      }
    }
    else if ((tree.root()).equals("not"))                //processes not
    {
      temp1 = expression(tree.left());
      if (temp1.getType() != 2)
        ErrorMessage . print ("Type Error");
      else
        return(new ExpressibleValue(new Type(2), !((Boolean) temp1.value())));
    }
    else if ((tree.root()).equals("=="))                  //processes ==
    {
      temp1 = expression(tree.left());
      temp2 = expression(tree.middle());
      if (temp2.getType() == 0)                                //comparing integers
      {
        if (temp1.value() == temp2.value())
          return (new ExpressibleValue(new Type(2), true));
        else
          return (new ExpressibleValue(new Type(2), false));
      }
      else if (temp2.getType() == 1)                              //comparing lists
      {
        int sizeTemp2 = ((LinkedList)temp2.value()).size();
        int sizeTemp1;
        if (temp1.value()==null && sizeTemp2==0)                      
          return (new ExpressibleValue(new Type(2), true));
        else if (temp1.value()==null)
          return (new ExpressibleValue(new Type(2), true));
        else
          sizeTemp1 = ((LinkedList)temp1.value()).size();
        if (sizeTemp2 != sizeTemp1)
          return (new ExpressibleValue(new Type(2), false));
        else
        {
          for(int i=0; i< sizeTemp2; i++)
          {
            if (((LinkedList)temp1.value()).get(i)!=(((LinkedList)temp2.value()).get(i)))
              return (new ExpressibleValue(new Type(2), false));
          }
          return (new ExpressibleValue(new Type(2), true));
        }
      }
      else
        ErrorMessage . print ("Type Error");
    }
    else if ((tree.root()).equals("~="))                     //processes !=
    {
      temp1 = expression(tree.left());
      temp2 = expression(tree.middle());
      if (temp2.getType() == 0)                               //comparing integers
      {
        if (temp1.value() != temp2.value())
          return (new ExpressibleValue(new Type(2), true));
        else
          return (new ExpressibleValue(new Type(2), false));
      }
      else if (temp2.getType() == 1)                         //comparing lists
      {
        if (temp1.value() != temp2.value())
          return (new ExpressibleValue(new Type(2), true));
        else
          return (new ExpressibleValue(new Type(2), false));
      }
      else
        ErrorMessage . print ("Type Error");
    }  
    else if ((tree.root()).equals("<") || (tree.root()).equals(">") || (tree.root()).equals("<=") || (tree.root()).equals(">="))        //processes other comparisons
      return (relop(tree.left(), tree.middle(), tree.root()));
    else if ((tree.root()).equals("-") && tree.middle()==null)              //unary operator -
    {
      temp1 = expression(tree.left());
      if (temp1.getType() != 0)
        ErrorMessage . print ("Type Error");
      else
        return(new ExpressibleValue(new Type(0), (-1 * (Integer) temp1.value())));
    }
    else if ((tree.root()).equals("+") || (tree.root()).equals("-") || (tree.root()).equals("*") || (tree.root()).equals("/"))       //processes math operators
      return (addop(tree.left(), tree.middle(), tree.root()));
    else if (tree.root().equals("cons"))                            //cons function
    {
      temp1 = expression(tree.left());
      temp2 = expression(tree.middle());
      if (temp2.type()!=null)
      {
        if (temp1.getType() == 0 && temp2.getType() == 1)
        {
          LinkedList<Integer> tempList = new LinkedList<Integer>();
          temp4 = ((LinkedList<Integer>) temp2.value());
          if (temp4!=null)
            tempList.addAll(temp4);
          tempList.addFirst((Integer) temp1.value());
          return (new ExpressibleValue(new Type(1), tempList));
        }
        else 
          ErrorMessage . print ("Type Error");
      }
      else
      {
        LinkedList<Integer> tempList = new LinkedList<Integer>();
        temp4 = ((LinkedList<Integer>) temp2.value());
        if (temp4!=null)
          tempList.addAll(temp4);
        tempList.addFirst((Integer) temp1.value());
        return (new ExpressibleValue(new Type(1), tempList));
      }
    }
    else if (tree.root().equals("head"))                    //head operation
    {
      temp1 = expression(tree.left());
      temp4 = new LinkedList<Integer>((LinkedList<Integer>) temp1.value());
      if (temp1.getType() == 1 && temp4.getFirst() != null)
      {
        return (new ExpressibleValue(new Type(0), temp4.getFirst()));
      }
      else
        ErrorMessage . print ("Error");
    }
    else if (tree.root().equals("tail"))                     //tail operation
    {
      temp1 = expression(tree.left());
      LinkedList<Integer> newList = new LinkedList<Integer>();
      temp4 = new LinkedList<Integer>((LinkedList<Integer>) temp1.value());
      newList.addAll(temp4);
      if (temp1.getType() == 1 && newList.getFirst() != null)
      {
        newList.removeFirst();
        return (new ExpressibleValue(new Type(1), newList));
      }
      else
        ErrorMessage . print ("Error");
    }
    else if (tree.root().equals("apply"))                 //proceses function calls
      {
        Environment tempEnv = new Environment();
        if (local.containsKey(tree.left().root()))          //checks local env for function
        {
          ArrayList<ExpressibleValue> parameters = getParameters(tree.middle());
          tempFunc = (FunctionDenot) local.access(tree.left().root());                                             
          tempEnv = local;                                                                                            
          stack.push(tempEnv);                                          //pushs previous local env
          temp1 = functionBody(tempFunc, tree.left().root(), parameters);   //calls function
          local = stack.pop();                                          //gets previous local env
          return (temp1);
        }
        else if (global.containsKey(tree.left().root()))                 //checks global env for function
        {
          ArrayList<ExpressibleValue> parameters = getParameters(tree.middle());
          tempFunc = (FunctionDenot) global.access(tree.left().root()); 
          tempEnv = local;
          stack.push(tempEnv);                                            //pushs previous local env 
          temp1 = functionBody(tempFunc, tree.left().root(), parameters);      //calls function
          local = stack.pop();                                            //gets previous local env
          return (temp1);
        }
        else
          ErrorMessage . print ("Undeclared Function Error");
    }
    else if (local.containsKey(tree.root()))                     //look for variable id
    {
      if (currentParameters.containsKey(tree.root()))         //checks parameters
        temp3 = currentParameters.get(tree.root());
      else                                                     //checks local
        temp3 = local.access(tree.root());;
      temp1 = ((ExpressibleValue) temp3);
      return (new ExpressibleValue(((ExpressibleValue) temp3).type(), ((ExpressibleValue) temp3).value()));
    }
    else if (global.containsKey(tree.root()))                  //checks global
    {
      temp3 = global.access(tree.root());
      temp1 = ((ExpressibleValue) temp3);
      return (new ExpressibleValue(((ExpressibleValue) temp3).type(), ((ExpressibleValue) temp3).value()));
    }
    else if (tree.root().equals("Nil"))
      return (new ExpressibleValue(new Type(1), new LinkedList()));          //new list
    else
    {
      return (new ExpressibleValue(new Type(0), Integer.parseInt(tree.root())));   //else integer
    }
    
    return (null); 
  }
    
  //processes relative operators
  public ExpressibleValue relop(SyntaxTree l, SyntaxTree r, String op)
  {
    ExpressibleValue temp1, temp2;
    temp1 = expression(l);
    temp2 = expression(r);
    if (temp1.getType() == 0 && temp2.getType() == 0)
    {
      if(op.equals("<"))                     
      {
        if ((Integer) temp1.value() < (Integer) temp2.value())
          return (new ExpressibleValue(new Type(2), true));
        else
          return (new ExpressibleValue(new Type(2), false));
      }
      else if(op.equals(">"))
      {
          if ((Integer) temp1.value() > (Integer) temp2.value())
            return (new ExpressibleValue(new Type(2), true));
          else
            return (new ExpressibleValue(new Type(2), false));
      }
      else if(op.equals(">="))
      {
        if ((Integer) temp1.value() >= (Integer) temp2.value())
          return (new ExpressibleValue(new Type(2), true));
        else
          return (new ExpressibleValue(new Type(2), false));
      }
      else if ((Integer) temp1.value() <= (Integer) temp2.value())
        return (new ExpressibleValue(new Type(2), true));
      else
        return (new ExpressibleValue(new Type(2), false));
    }
    else
      ErrorMessage . print ("Type Error");
    return (null);
  }
    
  //processes arithmetic operations
  public ExpressibleValue addop(SyntaxTree l, SyntaxTree r, String op)
  {
    ExpressibleValue temp1, temp2;
    temp1 = expression(l);
    temp2 = expression(r);
    
    if (temp1.getType() == 0 && temp2.getType() == 0)
    {
      if(op.equals("+"))
        return(new ExpressibleValue(new Type(0), ((Integer) temp1.value()) + ((Integer) temp2.value())));
      else if(op.equals("-"))
        return(new ExpressibleValue(new Type(0), ((Integer) temp1.value()) - ((Integer) temp2.value())));
      else if(op.equals("*"))
        return(new ExpressibleValue(new Type(0), ((Integer) temp1.value()) * ((Integer) temp2.value())));
      else
        return(new ExpressibleValue(new Type(0), ((Integer) temp1.value()) / ((Integer) temp2.value())));
    }
    else
      ErrorMessage . print ("Type Error");
    return(null);
  }
  
  
  //gets parameter values from current environments
  public ArrayList<ExpressibleValue> getParameters(SyntaxTree param)
  {
    ArrayList<ExpressibleValue> parameters = new ArrayList<ExpressibleValue>();
    parameters = getParametersR(param, parameters);
    return (parameters);
  }
  
  //recursive calls 
  public ArrayList<ExpressibleValue> getParametersR(SyntaxTree param, ArrayList<ExpressibleValue> temp)
  {
    ExpressibleValue tempVal;
    if (param.root().equals(","))         //checks to see if more recursion is necessary
    {
      temp = getParametersR(param.left(), temp);
      if (param.middle()!=null)
        temp = getParametersR(param.middle(), temp);
    }
    else if (local.containsKey(param.root()))              //checks agaisnt local
    {
      tempVal = ((ExpressibleValue) local.access(param.root()));
      temp.add(tempVal);
    }
    else if (global.containsKey(param.root()))            //checks against global
    {
      tempVal = ((ExpressibleValue) global.access(param.root()));
      temp.add(tempVal); 
    }
    else                                   //otherwise it is an addop
    {
      tempVal = addop(param.left(), param.middle(), param.root());
      temp.add(tempVal); 
    }
    return (temp);
  } 
}