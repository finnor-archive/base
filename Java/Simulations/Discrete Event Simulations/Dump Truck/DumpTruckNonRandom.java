import java.util.*;

class DumpTruckNonRandom
{
  public static void main(String[] args)
  {
    int loadQL = 3;
    LinkedList<Integer> load = new LinkedList();
    int trucksL = 2;
    int weighQL = 0;
    LinkedList<Integer> weigh = new LinkedList();
    int trucksW = 1;
    int clock = 0;
    int previousC = 0;
    int busyL = 0;
    int busyS = 0;
    int tempEventType;
    Event tempE;
    int temp;
    int[] nonrand = {5,10,15,60,12,100,12,40,16,40,12,80,16,10,10};   //events
    int x=-1;
    
    FEL events = new FEL();
    
    //Travel = 50
    //Load queue = 40
    //Loading = 30
    //Weigh queue = 20
    //Weigh = 10
    //Truck# = + #
    events.insert(new Event(1, 12, 1));
    events.insert(new Event(3, 10, 2));
    events.insert(new Event(3, 5, 3));
    load.add(4);
    load.add(5);
    load.add(6);
    
        

    
    while (clock<77)
    {
      busyS += trucksW * (clock-previousC);
      busyL += trucksL * (clock-previousC);
      
      while((events.peek()).getTime()==clock)
      {
        tempE = events.getNext();
        tempEventType = tempE.getEvent();
        switch (tempEventType)
        {
          case(1):                              //if someone is finished weighing
          {
            trucksW--;
            x++;
            events.insert(new Event(5, (nonrand[x]+clock), tempE.getID()));   //schedule travel
            if (weighQL>0)                //if someone is waiting to weigh
            {
              weighQL--;
              trucksW++;
              temp = weigh.poll();
              x++;
              events.insert(new Event(1, (nonrand[x]+clock), temp));   //schedule weighing
            }
            break;
          }
          case(3):                                //if someone is finished loading
          {
            trucksL--; 
            if (trucksW==0)               //if no one is weighing
            {
              x++;
              events.insert(new Event (1, (nonrand[x]+clock), tempE.getID()));  //schedule weighing
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
              x++;
              events.insert(new Event(3, (nonrand[x]+clock), temp));   //schedule loading
            }
            break;
          }
          case(5):
          {
            if (trucksL<2)          // if there is room to load
            {
              trucksL++;
              x++;
              events.insert(new Event(3, (nonrand[x]+clock), tempE.getID()));   //schedule loading
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
    
    System.out.println("\nAverage loader utilization: " + ((float)busyL/152));
    System.out.println("\nAverage scale utilization: " + ((float)busyS/76));
  }
}

