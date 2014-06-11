
// Basic node stored in a linked list
// Note that this class is not accessible outside
// of package weiss.nonstandard

class ListNode<AnyType>
{
      // Constructors
    public ListNode( AnyType theElement )
    {
        this( theElement, null );
    }

    public ListNode( AnyType theElement, ListNode<AnyType> n )
    {
        element = theElement;
        next    = n;
    }

    public AnyType   element;
    public ListNode<AnyType> next;
}
