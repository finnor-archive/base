public class GraphA
{
  private int vcnt, ecnt;
  private Node[] adj;
  private boolean digraph;
  
  public GraphA(int v, boolean d)
  {
    adj = new Node[v];
    vcnt = v;
    digraph = d;
    ecnt=0;
  }
  
  private class Node
  {
    int v;
    Node next;
    Node (int x, Node t)
    {
      v = x;
      next = t;
    }
  }
  
  public int V()
  {
    return (vcnt);
  }
  
  public int E()
  {
    return (ecnt);
  }
  
  public boolean digraph()
  {
    return(digraph);
  }
  
  public static void show(GraphA G)
  {
    for (int s = 0; s < G.V(); s++)
    {
      System.out.print(s + ": ");
      AdjList A = G.getAdjList(s);
      for (int t = A.beg(); !A.end(); t = A.nxt())
      {
        System.out.print(t + " ");
      }
      System.out.println();
    }
  }
  
  public void insert(Edge e)
  {
    int v = e.v;
    int w = e.w;
    adj[v] = new Node(w, adj[v]);
    if (!digraph)
      adj[w] = new Node(v, adj[w]);
      ecnt++;
  }
  
  public AdjList getAdjList(int v)
  {
    return (new AdjLinkedList(v));
  }

  private class AdjLinkedList implements AdjList
  {
    private int v;
    private Node t;
    AdjLinkedList(int v)
    {
      this.v = v;
      t = null;
    }
    public int beg()
    {
      t = adj[v];
      return t == null ? -1 : t.v;
    }
  
    public int nxt()
    {
      if (t!=null)
        t = t.next;
      return t == null ? -1 : t.v;
    }
  
    public boolean end()
    {
      return t == null;
    }
  }
  
  
}