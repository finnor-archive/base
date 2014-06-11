//****************************************************************
//*                                                              *
//*                       CS302                                  *
//*                     Exercise 5                               *
//*                                                              *
//*               MyBinarySearchTree.java                        *
//*                                                              *
//*                  Adrian Flannery                             *
//*                     adrianu2                                 *
//*       Defines methods to use with a binary search tree       *      
//****************************************************************
public class MyBinarySearchTree<AnyType extends Comparable<AnyType>>
                                extends BinarySearchTree<AnyType>
{
    private int index;


    public void lvr(AnyType[] array)
    {
        index = 0;

        if( root != null )
           lvr(root, array);
    }


    public void lvr(BinaryNode<AnyType> t, AnyType[] array)
    {
        if( t != null )
        {
           lvr(t.left, array);
           array[index++] =  t.element;
           lvr(t.right, array);
        }
    }


    public int height()
    {
        return height(root);
    }


    private int height(BinaryNode<AnyType>  t)
    {
        if (t == null)
            return -1;
        else
            return 1 + max(height(t.left),height(t.right));
    }


    private int max(int x, int y)
    {
        if (x > y)
            return x;
        else
            return y;
    }
  
    //method gets all sibling elements into an array
  public void siblings(AnyType[] array)
  {
    index = 0;
    
    //checks to see if there is a left subtree and goes down it
    if (root.left!=null)
    {
      siblings(root.left, array);
    }
    //if two nodes have the same parent then they are siblings
    if (root.left!=null && root.right!=null)
    {
      array[index++] =  root.left.element;
      array[index++] =  root.right.element;
    }  
    //checks to see if there is a right subtree and goes down it
    if (root.right!=null)
    {
      siblings(root.right, array);
    }
  }
  
  //method for recursive part of the siblings method
  public void siblings(BinaryNode<AnyType> t, AnyType[] array)
  {
    //checks to see if there is a left subtree and goes down it
    if (t.left!=null)
    {
      siblings(t.left, array);
    }
    // if two nodes have the same parent then they are siblings
    if (t.left!=null && t.right!=null)
    {
      array[index++] =  t.left.element;
      array[index++] =  t.right.element;
    }  
    //checks to see if there is a right subtree and goes down it
    if (t.right!=null)
    {
      siblings(t.right, array);
    }
  }
  
  //method finds all the leaves and places them in an array
  public void leaves(AnyType[] array)
  {
    index = 0;
    //checks to see if there is a left subtree and goes down it
    if (root.left!=null)
    {
      leaves(root.left, array);
    }
    //if a node has no children it is a leaf
    if (root.left==null && root.right==null)
    {
      array[index++] =  root.element;
    }  
    //checks to see if there is a right subtree and goes down it
    if (root.right!=null)
    {
      leaves(root.right, array);
    }
  }
  
  //recursive part of the leaves method
  public void leaves(BinaryNode<AnyType> t, AnyType[] array)
  {
    //checks to see if there is a left subtree and goes down it
    if (t.left!=null)
    {
      leaves(t.left, array);
    }
    //if a node has no children it is a leaf
    if (t.left==null && t.right==null)
    {
      array[index++] =  t.element;
    }  
    //checks to see if there is a right subtree and goes down it
    if (t.right!=null)
    {
      leaves(t.right, array);
    }
  }
  
  public void leftNodes(AnyType[] array)
  {
    index = 0;
    //places the left child in arrray and traverses the left subtree
    if(root.left!=null)
    {
      array[index++] =  root.left.element;
      leftNodes(root.left, array);
    }
    //checks to see if there is a right subtree and goes down it
    if(root.right!=null)
    {
      leftNodes(root.right, array);
    }
  }
  
  //recursive part of LeftNodes method
  public void leftNodes(BinaryNode<AnyType> t, AnyType[] array)
  {
    //places the left child in arrray and traverses the left subtree
    if(t.left!=null)
    {
      array[index++] =  t.left.element;
      leftNodes(t.left, array);
    }
    //checks to see if there is a right subtree and goes down it
    if(t.right!=null)
    {
      leftNodes(t.right, array);
    }
  }
  
  //method finds nodes whose elements are less than a key
  public void lessThan(AnyType value, AnyType[] array)
  {
    index = 0;
    //if current node is less than the key it is placed in the array
    if (root.element.compareTo(value)<0)
    {
      array[index++] =  root.element;
    }
    //checks to see if there is a left subtree and goes down it
    if (root.left!=null)
    {
      lessThan(root.left, value, array);
    }
    //checks to see if there is a right subtree and goes down it
    if (root.right!=null)
    {
      lessThan(root.right, value, array);
    } 
  }
  
  //recursive part of the lessThan method
  public void lessThan(BinaryNode<AnyType> t, AnyType value, AnyType[] array)
  {
    //if current node is less than the key it is placed in the array
    if (t.element.compareTo(value)<0)
    {
      array[index++] =  t.element;
    }
    //checks to see if there is a left subtree and goes down it
    if (t.left!=null)
    {
      lessThan(t.left, value, array);
    }
    //checks to see if there is a right subtree and goes down it
    if (t.right!=null)
    {
      lessThan(t.right, value, array);
    } 
  }
  
  //method gets the level-order traversal
  public void levelOrder(AnyType[] array)
  {
    index = 0;
    ListQueue<BinaryNode> q = new ListQueue();
    
    //places the root into the array
    array[index++] = root.element;
    
    //if there is a left subtree then it is enqueued
    if (root.left != null)
    {
      q.enqueue(root.left);
    }
    // if there is a right subtree then it is enqueued
    if (root.right != null)
    {
      q.enqueue(root.right);
    }
    //traverses the tree
    levelOrder(array, q);
  }
  
  //traverses the rest of the tree outside the root
  public void levelOrder(AnyType[] array, ListQueue<BinaryNode> q)
  {
    BinaryNode<AnyType> t = null;
    
    //traverses the tree until every node has been placed in the array
    while(!q.isEmpty())
    {
      //dequeues the node and places it in the array
      t = q.dequeue();
      array[index++] = t.element;
      
      //enqueues the children of the current node
      if (t.left != null)
      {
        q.enqueue(t.left);
      }
      if (t.right != null)
      {
        q.enqueue(t.right);
      }
    }
  }
        
}
