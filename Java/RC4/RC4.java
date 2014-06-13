import java.util.*;

public class RC4
{
  private String[] hexKey;
  private String[] ivG;
  private String[] key;
  
  public RC4(String[] hKey)
  {
    hexKey = hKey;
    key = new String[8];
  }
  
  public RC4()
  {
    key = new String[8];
  }
  
  
  //intializes a state array with a certain iv
  public String[] init (String[] initV)
  {
    String[] stateArray = new String[256];
    int tempInt1, tempInt2, tempInt3;
    for (int i=0; i<8; i++)
    {
      if (i<3)
        key[i] = initV[i];
      else
        key[i] = hexKey[i-3];
    }
    
    String temp;
    for (int i=0; i<256; i++)
    {
      temp = Integer.toHexString(i);
      if (temp.length() < 2)
        temp = "0" + temp;
      stateArray[i] = temp;   
    }
    
    int j=0;
    for (int i=0; i<256; i++)
    {
      tempInt1 = Integer.parseInt(stateArray[i], 16);
      tempInt3 = i%8;
      tempInt2 = Integer.parseInt(key[tempInt3], 16);
      j = (j + tempInt1 + tempInt2)%256;
      temp = stateArray[i];
      stateArray[i] = stateArray[j];
      stateArray[j] = temp;
    }
    return(stateArray);
  }
  
  
  //takes a list of ivs, generates the first keystream byte, and encrypts the SNAP message 0xaa
  public LinkedList<PacketInfo> getFirstCipherByte(LinkedList<String[]> ivList)
  {
    ListIterator iterator = ivList.listIterator(0);
    LinkedList<PacketInfo> packets = new LinkedList();
    String[] stateArray;
    String[] myIV;
    String keyStreamByte;
    String tempString;
    int tempInt, tempInt2, tempInt3;
    int cipherText;
    int snap = Integer.parseInt("aa", 16);
    while (iterator.hasNext())
    {
      myIV = (String[])iterator.next();
      stateArray = init(myIV);
      tempString = stateArray[1];
      tempInt = Integer.parseInt(tempString, 16);
      tempString = stateArray[tempInt];
      tempInt2 = Integer.parseInt(tempString, 16);
      tempInt3 = (tempInt + tempInt2)%256;
      keyStreamByte = stateArray[tempInt3];
      tempInt = Integer.parseInt(keyStreamByte, 16);
      cipherText = tempInt ^ snap;
      tempString = Integer.toHexString(cipherText);
      if (tempString.length() < 2)
          tempString = "0" + tempString;
      packets.add(new PacketInfo(myIV, tempString));
    }
   
      
    return packets;
  }
  
  
  //attempts to reconstruct a key
  public String[] reconstructKey(LinkedList<PacketInfo> packets)
  {
    PacketInfo myPacket;
    LinkedList<String>[] keyBytes = new LinkedList[5];
    String[] stateArray;
    String tempString; 
    String[] retKey = new String[5];
    String keyStreamByte;
    int keyStreamByteInt;
    int snap = Integer.parseInt("aa", 16);
    int tempInt2, tempInt3;
    int j;
    int out;
    ListIterator iterator;
    
    //attempt to recover key byte one at a time
    for (int keyByte=0; keyByte<5; keyByte++)
    {
      LinkedList<String> currentList = new LinkedList();
      iterator = packets.listIterator(0);
      
      //loops across the packets
      while (iterator.hasNext())
      {
        myPacket = (PacketInfo)iterator.next();
        key[0] = myPacket.myIV[0];
        key[1] = myPacket.myIV[1];
        key[2] = myPacket.myIV[2];
        j = 0;
        stateArray = initiatlizeArrayOne();
        
        //go through setup of state array
        for (int i=0; i<3+keyByte; i++)
        {
          tempInt2 = Integer.parseInt(stateArray[i], 16);
          tempInt3 = Integer.parseInt(key[i], 16);
          j = (j + tempInt2 + tempInt3)%256;
          tempString = stateArray[i];
          stateArray[i] = stateArray[j];
          stateArray[j] = tempString;
        }
        
        keyStreamByteInt = Integer.parseInt(myPacket.firstByte, 16);
        keyStreamByteInt = keyStreamByteInt ^ snap;
        keyStreamByte = Integer.toHexString(keyStreamByteInt);
        if (keyStreamByte.length() < 2)
          keyStreamByte = "0" + keyStreamByte;
        
        
        //calculate guess at keybyte
        out = search(keyStreamByte, stateArray);
        tempInt3 = Integer.parseInt(stateArray[3+keyByte], 16);  
        tempInt2 = (out - j - tempInt3)%256;
        if (tempInt2<0)
          tempInt2+=256;
        tempString = Integer.toHexString(tempInt2);
        if (tempString.length() < 2)
          tempString = "0" + tempString;
        currentList.add(tempString);
      }
      keyBytes[keyByte] = currentList;
      tempString = getMode(currentList);
      key[keyByte+3] = tempString;
      retKey[keyByte]= tempString;
      
    }
  
    return retKey;
  }
   
  
  
  
  
  //search the state array by element to return key
  public int search(String firstByte, String[] stateArray)
  {
    for (int i=0; i<stateArray.length; i++)
    {
      if (firstByte.compareToIgnoreCase(stateArray[i])==0)
        return i;
    }
    return 0;
  }
  
    
  
  
  // initializes the state array to first state
  public String[] initiatlizeArrayOne()
  {
    String temp;
    String[] stateArray = new String[256];
    for (int i=0; i<256; i++)
    {
      temp = Integer.toHexString(i);
      if (temp.length() < 2)
        temp = "0" + temp;
      stateArray[i] = temp;      
    }
    return stateArray;
  }
  
  
  
  
  
  //gets the most common guess at a keybyte
  public String getMode(LinkedList<String> possBytes) 
  {
    HashMap<String,Integer> freqs = new HashMap<String,Integer>();
    String temp;
    ListIterator iterator = possBytes.listIterator(0);
    while (iterator.hasNext())
    {
      temp = (String)iterator.next();
      Integer freq = freqs.get(temp);
      if (freq==null)
        freqs.put(temp, 1);
      else
        freqs.put(temp, freq+1);
    }

    String mode = "";
    int maxFreq = 0;

  for (Map.Entry<String,Integer> entry : freqs.entrySet()) 
  {
    int freq = entry.getValue();
    if (freq > maxFreq) {
      maxFreq = freq;
      mode = entry.getKey();
    }
  }                     
  return mode;
}
  
  /*
  public void encryptOne()
  {
    String[] stateArray;
    String[] myIV = {"1b", "db","46"};
    String keyStreamByte;
    String temp;
    int tempInt, tempInt2;
    int cipherText;
    int snap = Integer.parseInt("aa", 16);

    stateArray = init(myIV);
    
    temp = stateArray[1];
    tempInt = Integer.parseInt(temp, 16) %256;
    temp = stateArray[tempInt];
    tempInt2 = Integer.parseInt(temp, 16) %256;
    keyStreamByte = stateArray[(tempInt + tempInt2)%256];
    cipherText = Integer.parseInt(keyStreamByte, 16);
    cipherText = cipherText ^ snap;
    temp = Integer.toHexString(cipherText);
    if (temp.length() < 2)
      temp = "0" + temp;   
    System.out.println(temp);
  }  
  */
  
  
  public String[] reconstructKey2(LinkedList<PacketInfo> packets)
  {
    PacketInfo myPacket;
    LinkedList<String>[] keyBytesList = new LinkedList[5];
    String[] stateArray;
    String tempString; 
    String[] retKey = new String[5];
    String keyStreamByte;
    int keyStreamByteInt;
    int snap = Integer.parseInt("aa", 16);
    int tempInt2, tempInt3, tempInt4;
    int j;
    int out;
    ListIterator iterator;
    
    //attempt to recover key byte one at a time
    for (int keyByte=0; keyByte<5; keyByte++)
    {
      LinkedList<String> currentList = new LinkedList();
      iterator = packets.listIterator(0);
      while (iterator.hasNext())
      {    
        myPacket = (PacketInfo)iterator.next();
        key[0] = myPacket.myIV[0];
        key[1] = myPacket.myIV[1];
        key[2] = myPacket.myIV[2];
        
        
        tempInt2 = Integer.parseInt(myPacket.firstByte, 16);
        keyStreamByteInt = tempInt2 ^ snap;
        keyStreamByte = Integer.toHexString(keyStreamByteInt);
        if (keyStreamByte.length() < 2)
          keyStreamByte = "0" + keyStreamByte;
        //System.out.println(keyStreamByte);
        
        stateArray = initiatlizeArrayOne();
        j=0;
        for (int i=0; i<3+keyByte; i++)
        {
          tempInt2 = Integer.parseInt(stateArray[i], 16);
          tempInt3 = Integer.parseInt(key[i], 16);
          tempInt4 = j + tempInt2 + tempInt3;
          j = tempInt4 %256;
          tempString = stateArray[i];
          stateArray[i] = stateArray[j];
          stateArray[j] = tempString;
        }
        
        out = search(keyStreamByte, stateArray);
        tempInt3 = Integer.parseInt(stateArray[keyByte+3], 16);
        tempInt2 = (out - j - tempInt3)%256;
        if (tempInt2<0)
          tempInt2+=256;
        tempString = Integer.toHexString(tempInt2);
        if (tempString.length() < 2)
          tempString = "0" + tempString;
        currentList.add(tempString);
      }
      keyBytesList[keyByte] = currentList;
      tempString = getMode(currentList);
      key[keyByte+3] = tempString;
      retKey[keyByte]= tempString;
    }
    return retKey;    
  }
}