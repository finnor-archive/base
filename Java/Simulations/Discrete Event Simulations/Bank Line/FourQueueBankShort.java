import java.util.Random;

public class FourQueueBankShort
{
  public static void main (String[] args)
  {
    Random gen = new Random();
    int transactions = 0;
    int[] servers = new int[4];
    int[] queues = new int[4];
    int busyG = 0;
    int busyB = 0;
    int custBusy = 0;
    int clock = 0;
    int previousClock = 0;
    FEL fel = new FEL();
    
    //Event(x, y, z)
    //x:
    //Arrival 1
    //Departure 2
    //y:
    //time when event
    //z:
    //General queue 0
    //Business queue 1
    
    if (isGeneral(gen.nextFloat()))              //generate first arrival
      fel.insert(new Event(1, clock + genArrival(gen.nextFloat()), 0));
    else
      fel.insert(new Event(1, clock + genArrival(gen.nextFloat()), 1));
                   
    Event current = fel.getNext();
      
    while (transactions<500)
    {        
                                              //collect stats
      custBusy += (servers[0]+servers[1]+servers[2]+servers[3]+queues[0]+queues[1]+queues[2]+queues[3])*(clock-previousClock);
      if(current.getID()<2)
        busyG += (servers[0]+servers[1])*(clock-previousClock);
      else
        busyB += (servers[2]+servers[3])*(clock-previousClock);
      
      
      if (current.getEvent()==1)                  //event is an arrival
      {
        if (current.getID()==0)                  //if general customer         
        {
          if (servers[0]==0)                         //if teller 0 empty, gen depart
          {
            servers[0]++;
            fel.insert(new Event(2, clock + genGeneral(gen.nextFloat()), 0));
          }
          else if (servers[1]==0)               //else if teller 1 empty, gen depart
          {
              servers[1]++;
              fel.insert(new Event(2, clock + genGeneral(gen.nextFloat()), 1));
          }
          else if (queues[0]<queues[1])         //else add to shorter queue
            queues[0]++;
          else
            queues[1]++;
        }
        else
        {
          if (servers[2]==0)                         //if teller 2 empty, gen depart
          {
            servers[2]++;
            fel.insert(new Event(2, clock + genGeneral(gen.nextFloat()), 2));
          }
          else if (servers[3]==0)               //else if teller 3 empty, gen depart
          {
              servers[3]++;
              fel.insert(new Event(2, clock + genGeneral(gen.nextFloat()), 3));
          }
          else if (queues[2]<queues[3])         //else add to shorter queue
            queues[2]++;
          else
            queues[3]++;
        }

        
        
        if (isGeneral(gen.nextFloat()))              //generate a new arrival
          fel.insert(new Event(1, clock + genArrival(gen.nextFloat()), 0));
        else
          fel.insert(new Event(1, clock + genArrival(gen.nextFloat()), 1));

        
        
      }
      else                                //event is a departure
      {
        transactions++;
        
        
        if (queues[current.getID()]==0)        //if queue is empty   
          servers[current.getID()]--;          //then teller is empty
        else                                  //else generate new departure
        {
          if(current.getID()<2)
            fel.insert(new Event(2, clock + genGeneral(gen.nextFloat()), current.getID()));
          else
            fel.insert(new Event(2, clock + genBusiness(gen.nextFloat()), current.getID()));
          queues[current.getID()]--;
        }
      }
      
      previousClock = clock;                        //go to next event
      current = fel.getNext();
      clock = current.getTime();
    }
    
    System.out.println("Average time per customer: " + custBusy/500);
    System.out.println("Percent general teller busy: " + (double) busyG/(2*clock));
    System.out.println("Percent business teller busy: " + (double) busyB/(2*clock));
  
  }
  
  
  //generate interarrival times
  public static int genArrival(float rand)
  {
    return (1 + (int)(rand*3));
  }
  
  
  //generate time to process business customer
  public static int genBusiness(float rand)
  {
    return (5 + (int)(rand*21));
  }
  
  //generate time to process general customer
  public static int genGeneral(float rand)
  {
    return (1 + (int)(rand*11));
  }
  
  //generate whether customer is general or business
  public static boolean isGeneral(float rand)
  {
    if (rand<.333)
      return(false);
    else
      return(true);
  }
  
  //generate which line within type
  public static int whichLine(float rand)
  {
    if (rand<.5)
      return(0);
    else
      return(1);
  }
}