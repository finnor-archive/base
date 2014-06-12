public class Traversal
{
  private static GraphA G; 
  private static int cnt;
  private static int[] ord;
  
  public static void DFs (int v)
  {
    ord[v] = cnt++;
    AdjList A = G.getAdjList(v);
    for (int t = A.beg(); !A.end(); t = A.nxt())
      if (ord[t] == -1) DFs(t);
  }
    
  public static void DF (GraphA G)
  {
    cnt = 0;
    ord = new int[G.V()];
    for (int t=0; t < G.V(); t++)
      ord[t] = -1;
    DFs(v);
  }
  
  
  public static void BF (Graph g)
  {
    Queue q = new Queue();
    boolean[] visited = new boolean[g.V()];
    ListNode current;
    int temp;
    for(int i=0; i<g.V(); i++)
    {
      if (visited[i] == false)
        q.enqueue(i);
      visited[i] = true;
      while(!q.isEmpty())
      {
        temp = q.dequeue();
        System.out.print(temp + "  ");
        current = g.vert[temp].front;
        while(current!=null)
        {
          if (visited[current.element]==false)
          {
            q.enqueue(current.element);
            visited[current.element] = true;
          }
          current = current.next;
        }
      }
    }
  }
  
}