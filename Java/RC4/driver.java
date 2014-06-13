//import java.io.*;
import java.util.*;
public class driver
{
  public static void main(String[]args)
  {
    String[] key= new String[5];
    String[] iv= new String[3];
    String[] sArray;
    String temp;
    Scanner scan = new Scanner(System.in);
    //System.out.println("Input Key: ");
    //temp = scan.nextLine();
    temp = "a76c0fc477";
    for (int i=0; i<5; i++)
    {
      key[i] = temp.substring(i*2, i*2 + 2);
    }
    RC4 rc = new RC4(key);
        
    
    LinkedList<String[]> ivsByByte = new LinkedList();
    String[] ivs = new String[500];
    for (int i=0; i<100; i++)
    {
      temp = Integer.toHexString(i);
      if (temp.length() < 2)
          temp = "0" + temp;
      ivs[i] = "03FF" + temp;
    }
    
    for (int i=0; i<100; i++)
    {
      temp = Integer.toHexString(i);
      if (temp.length() < 2)
          temp = "0" + temp;
      ivs[i+100] = "04FF" + temp;
    }
    for (int i=0; i<100; i++)
    {
      temp = Integer.toHexString(i);
      if (temp.length() < 2)
          temp = "0" + temp;
      ivs[i+200] = "05FF" + temp;
    }
    for (int i=0; i<100; i++)
    {
      temp = Integer.toHexString(i);
      if (temp.length() < 2)
          temp = "0" + temp;
      ivs[i+300] = "06FF" + temp;
    }
    for (int i=0; i<100; i++)
    {
      temp = Integer.toHexString(i);
      if (temp.length() < 2)
          temp = "0" + temp;
      ivs[i+400] = "07FF" + temp;
    }    
    
    for (int i=0; i<500; i++)
    {
      temp = ivs[i];
      for (int j=0; j<3; j++)
      {    
        iv[j] = temp.substring(j*2, j*2 + 2);
      }
      ivsByByte.add(iv);
      iv = new String[3];
    }
    
    LinkedList<PacketInfo> packets = rc.getFirstCipherByte(ivsByByte);
    
    
    key = rc.reconstructKey2(packets);
    System.out.println(key[0] + ":" + key[1] + ":" + key[2] + ":" + key[3] + ":" + key[4]);
    
    
    //System.out.println("Input IV: ");
    //temp = scan.nextLine();
    //temp = "04FF00";
    //for (int i=0; i<3; i++)
    //{
    //  iv[i] = temp.substring(i*2, i*2 + 2);
    //}
    
    //sArray = rc.init(iv);
    
    //for(int i=0; i<sArray.length; i++)
    //{
    //  System.out.print(sArray[i] + " : ");
    //}
    
  }
}