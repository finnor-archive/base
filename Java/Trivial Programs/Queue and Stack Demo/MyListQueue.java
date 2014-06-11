/* Adrian Flannery
 * adrianu2
 * CS-302
 * Programming Exercise 2
 * The program codes methods intended for use with list-based queues
 * Methods included are removeElement, moveFront, copyTo, display, and displayHeading
 */


public class MyListQueue <AnyType extends Comparable<AnyType>> extends ListQueue<AnyType>
{
  
  //constructs queue
  public MyListQueue ()
    {
      super();
    }
  
  
  //removes one instance of an element from a queue
  public void removeElement (AnyType p)
  {
    //creates two temporary nodes to keep track of the previous looped over node and the current
    ListNode<AnyType> previous = front;
    ListNode<AnyType> current = front;
    //boolean that is used to keep track of whether an element has been removed yet
    Boolean elementRemoved = false;
    
    //checks to see the queue is empty
    if (front == null)
    {
      System.out.print("No elements to be removed");
      //changes boolean so that a back node is not checked
      elementRemoved = true;
    }
    else
    {
      //loops through the queue except for the back
      while(current!=back)
      {
        // checks to see if an element has been removed and if the current element is the one to be removed
        if (!elementRemoved)
        {
          //checks to see if the element to be removed is equal to the current node
          if ((p.compareTo(current.element)) == 0)
          {
            //special case for if the front is the element to be removed
            if(current==front)
            {
              front = front.next;
            }
            //case for when any other element is to be removed except the back
            else
            {
              previous.next = current.next;
            }
            //boolean is set to true for when an element has been removed
            elementRemoved = true;    
          }
        }
      
        //sets up the two temporary nodes for the next cycle of the loop
        previous = current;
        current = current.next; 
      }
    }
    
    //removes back element if an element has not been removed and the back is to be removed
    if (!elementRemoved && (back.element.compareTo(p) == 0))
    {
      //if the queue has only one node then the queue is emptied
      if (front==back)
      {
        makeEmpty();
      }
      //else the back is changed to the previously checked node
      else
      {
        back = previous;
      }
    }  
  }    
  
  
  
  
  //moves all instances of an element to the front of the queue
  public void moveFront (AnyType p)
  {
    //creates a node equal to the one currently being checked
    ListNode<AnyType> current = this.front;
    //creates a queue of placeholders
    MyListQueue<AnyType> temp = new MyListQueue<AnyType> ();
    
    //checks to see if the queue is empty
    if (front!=null)
    {
      //loops over the queue except for the last element
      while(current!=this.back)
      {
        //cehcks to see if the current element should be moved to the front
        if (p.compareTo(current.element) == 0)
        {
          //moves all elements that meet previous condition behind elements that are equal
          temp.enqueue(current.element);
        }
        //progresses the loop
        current = current.next;
      }
      //checks to see if the back element should be moved
      if (p.compareTo(this.back.element) == 0)
      {
        //moves the back.element behind like elements or to the front if none exist 
        temp.enqueue(this.back.element);
      }
      
      //resets the loop to the front
      current = this.front;
      
      //loops again to queue elements that are not supposed to be at the front
      while(current!=this.back)
      {
        
        //queues an element to back if it does not equal 'p' to temp
        if (p.compareTo(current.element) != 0)
        {
          temp.enqueue(current.element);
        }
        current = current.next;
      }
      
      //queues back element to temp
      if (p.compareTo(current.element) != 0)
      {
        temp.enqueue(this.back.element);
      }
    
      //makes the queue empty
      this.makeEmpty();
    
      //resets the loop to the front
      current = temp.front;
      
      //loops through temp queue and copies values to the instance queue
      while(current!=temp.back)
      {
        this.enqueue(current.element);
        current = current.next;
      }
      this.enqueue(temp.back.element);
    }
  }
  
  
  //copys queue to another queue and does not alias them
  public MyListQueue<AnyType> copyTo (MyListQueue<AnyType> q)
  {
    //checks to see if the instance queue is empty
    if(this.front!=null)
    {
      //emptys the queue that accepts copy
      q.makeEmpty();
      
      ListNode<AnyType> current = front;
      
      //loops through instance queue and queues to the returned queue
      while(current!=back)
      {
        q.enqueue(current.element);
        current = current.next;
      }
      q.enqueue(back.element);
      return(q);
    }
    
    // if instance queue is empty, an empty queue is returned
    else
    {
      q.makeEmpty();
      return(q);
    }
  }
      
    
  //displays queue
  public void display()
  {
    ListNode<AnyType> current = front;
    
    //if queue is empty an appropriate message is printed
    if (front == null)
    {
      System.out.print("Empty queue");
    }
    //else the queue is looped over and each element printed
    else
    {
      //special case: if queue has one element only one element is to be printed
      if (front == back)
      {
        System.out.print(front.element);
      }
      else
      {
        while(current!=back)
        {
          System.out.print(current.element + " ");
          current = current.next;
        }
        System.out.print(back.element);
      }
    }
  }
  
  //prints heading
  public static void displayHeading (int num)
  {
    System.out.println("Name: Adrian Flannery");
    System.out.println("BlazerID: adrianu2");
    System.out.println("CS-302");
    System.out.println("Programming Exercise " + num);
  }
}    