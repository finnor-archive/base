public class PacketInfo
{
  public String[] myIV;
  public String firstByte;
  private int snap = Integer.parseInt("aa", 16);
  
  public PacketInfo(String[] iv, String encryptedByte)  
  {
    myIV = iv;
    int temp = Integer.parseInt(encryptedByte, 16);
    temp = temp^snap;
    firstByte = Integer.toHexString(temp);
      if (firstByte.length() < 2)
        firstByte = "0" + firstByte;
  }
}