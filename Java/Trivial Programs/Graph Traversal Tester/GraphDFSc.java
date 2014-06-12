class GraphDFSc
{
  private static GraphA G; 
  private static int cnt;
  private static int[] ord;
  
  public static void searchC (int v)
  {
    ord[v] = cnt++;
    AdjList A = G.getAdjList(v);
    for (int t = A.beg(); !A.end(); t = A.nxt())
    {
      if (ord[t] == -1) searchC(t);
      System.out.print(t + " ");
    }
  }
    
  public static void GraphDFSc (GraphA x, int v)
  {
    G = x; cnt = 0;
    ord = new int[G.V()];
    for (int t=0; t < G.V(); t++)
    {
      ord[t] = -1;
    }
    searchC(v);
  }
  
  public static int count()
  {
    return (cnt);
  }
  
  public static int order (int v)
  {
    return (ord[v]);
  }
}