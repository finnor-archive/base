import java.util.*;

class DumpTruck
{
  public static void main(String[] args)
  {
    int loadQL = 3;
    LinkedList<Integer> load = new LinkedList();
    int trucksL = 2;
    int weighQL = 0;
    LinkedList<Integer> weigh = new LinkedList();
    int trucksW = 1;
    LinkedList<Integer> arriveTimes = new LinkedList();
    int sumResponse = 0;
    int thirtyMin=0;
    int leaves=0;
    int clock = 0;
    int previousC = 0;
    int busyL = 0;
    int busyS = 0;
    int tempEventType;
    Event tempE;
    int temp;
    Random gen = new Random(10000);   
    float rand;
    
    FEL events = new FEL();
    
    //Travel = 5
    //Load queue = 4
    //Loading = 3
    //Weigh queue = 2
    //Weigh = 1
    events.insert(new Event(1, getWT(gen.nextFloat()), 1));
    events.insert(new Event(3, getLT(gen.nextFloat()), 2));
    events.insert(new Event(3, getLT(gen.nextFloat()), 3));
    load.add(4);
    load.add(5);
    load.add(6);
    

    
    while (clock<=100)
    {
      busyS += trucksW * (clock-previousC);
      busyL += trucksL * (clock-previousC);
      
      while((events.peek()).getTime()==clock)
      {
        tempE = events.getNext();
        tempEventType = tempE.getEvent();
        rand = gen.nextFloat();
        switch (tempEventType)
        {
          case(1):                              //if someone is finished weighing
          {
            leaves++;
            if (leaves>6)
            {
              if ((clock - arriveTimes.peek())>=30)
                thirtyMin++;
              sumResponse += (clock - arriveTimes.poll());
            }
            trucksW--;
            events.insert(new Event(5, (getTT(rand)+clock), tempE.getID()));   //schedule travel
            if (weighQL>0)                //if someone is waiting to weigh
            {
              weighQL--;
              trucksW++;
              temp = weigh.poll();
              events.insert(new Event(1, (getWT(rand)+clock), temp));   //schedule weighing
            }
            break;
          }
          case(3):                                //if someone is finished loading
          {
            trucksL--; 
            if (trucksW==0)               //if no one is weighing
            {
              events.insert(new Event (1, (getWT(rand)+clock), tempE.getID()));  //schedule weighing
              trucksW++;
            }
            else                 //else queue weighing
            {
              weighQL++;                           
              weigh.add(tempE.getID());
            }
            if (loadQL>0)                //if someone is waiting to load
            {
              loadQL--;
              trucksL++;
              temp = load.poll();
              events.insert(new Event(3, (getLT(rand)+clock), temp));   //schedule loading
            }
            break;
          }
          case(5):
          {
            arriveTimes.add(clock);
            if (trucksL<2)          // if there is room to load
            {
              trucksL++;
              events.insert(new Event(3, (getLT(rand)+clock), tempE.getID()));   //schedule loading
            }
            else              //else queue to load
            {
              loadQL++;
              load.add(tempE.getID());
            }
            break;
          }
        }
      }
      
                                                                    //display table entry
      ListIterator<Integer> iteratorL = load.listIterator(0); 
      ListIterator<Integer> iteratorW = weigh.listIterator(0); 
      Iterator<Event> iteratorE = events.iterator();
      System.out.print("Clock t: " + clock + "  LQ(t): " + loadQL + "  L(t): " + trucksL + "  WQ(t): " + weighQL + "  W(t): " + trucksW);
      
      System.out.print("  Loader Queue: ");
      while (iteratorL.hasNext())
      {
        System.out.print("DT" + iteratorL.next() + " "); 
      }
      
      System.out.print(" Weigh Queue: ");
      while (iteratorW.hasNext())
      {
        System.out.print("DT" + iteratorW.next() + " "); 
      }
      
      System.out.print(" Future Event List: ");
      while (iteratorE.hasNext())
      {
        tempE = iteratorE.next();
        tempEventType = tempE.getEvent();
        if (tempEventType==1)
          System.out.print(" (EW, ");
        else if (tempEventType==3)
          System.out.print(" (EL, ");
        else
          System.out.print(" (ALQ, ");
        System.out.print(tempE.getTime() + ", DT" + tempE.getID() + ") ");
      }
      
      System.out.println(" BL: " + busyL + "  BS: " + busyS + "\n");
      
      previousC = clock;
      clock = (events.peek()).getTime();
    }
    
    System.out.println("\nMean response time: " + ((float)sumResponse/(leaves-6)));
    System.out.println("\nProportion response time over 30 minutes: " + ((float)thirtyMin/(leaves-6)));
    System.out.println("\nAverage loader utilization: " + ((float)busyL/152));
    System.out.println("\nAverage scale utilization: " + ((float)busyS/76));
  }
  
  public static int getLT(float temp)
  {
    if (temp<0.3)
      return (5);
    else if (temp < 0.8)
      return (10);
    else 
      return (15);
  }
  
  public static int getWT(float temp)
  {
    if (temp<0.7)
      return (12);
    else 
      return (16);
  }
  
  public static int getTT(float temp)
  {
    if (temp<0.4)
      return (40);
    else if (temp < 0.7)
      return (60);
    else if (temp < 0.9)
      return (80);
    else 
      return (100);
  }
}

