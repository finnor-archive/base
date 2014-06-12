import java.util.Random;

public class GraphTest
{
  public static void main(String[] args)
  {
    int gSize = 20;
    int ecnt = 40;
    long time1, time2;
    GraphA g = new GraphA(gSize, true);
    Edge e;
    Random generator = new Random();
    for(int i=0; i<(ecnt-1); i++)
    {
      e = new Edge(generator.nextInt(gSize), generator.nextInt(gSize));
      g.insert(e);
    }
    System.out.println("Graph: ");
    g.show(g);
    System.out.print("\nNumber of edges: " + g.E());
    
    System.out.print("\n\nDepth-First Traversal: ");
    
    time1 = System.currentTimeMillis();
    GraphDFSc.GraphDFSc(g, 0);
    time1 = System.currentTimeMillis() - time1;
    
    System.out.print("\n\nBreadth-First Traversal: ");
    /*
    time2 = System.currentTimeMillis();
    Traversal.BF(g);
    time2 = System.currentTimeMillis() - time2;
    
    System.out.println("\n\nDF time: " + time1 + "ms    BF time: " + time2 + "ms");
    */
  }
}