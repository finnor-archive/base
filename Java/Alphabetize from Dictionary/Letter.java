class Letter
{
  private int letter, position;
  
  public Letter(int inLetter, int inPosition)
  {
    letter = inLetter;
    position = inPosition;
  }
  
  public int getLetter()
  {
    return(letter);
  }
  
  public int getPosition()
  {
    return(position);
  }
  
  public void setPosition(int inPosition)
  {
    position = inPosition;
  }
  
  public void decPosition()
  {
    position--;
  }
}