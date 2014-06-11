//********************************************************************
//*                                                                  *
//*                         CS302                                    *
//*                                                                  *
//*                       Card.java                                  *
//*                                                                  *
//********************************************************************

public class Card
{
    private int num, suit;

    public Card (int num, int suit)
    {
       this.num = num;
       this.suit = suit;
    }


    public int getValue()
    {
       return num;
    }


    public int getSuit()
    {
       return suit;
    }


    public String toString()
    {
       String result = "";

       switch (num)
       {
         case  2: result  = "  2    "; break;
         case  3: result  = "  3    "; break;
         case  4: result  = "  4    "; break;
         case  5: result  = "  5    "; break;
         case  6: result  = "  6    "; break;
         case  7: result  = "  7    "; break;
         case  8: result  = "  8    "; break;
         case  9: result  = "  9    "; break;
         case 10: result  = "  10   "; break;
         case 11: result  = "  Jack "; break;
         case 12: result  = "  Queen"; break;
         case 13: result  = "  King "; break;
         case 14: result  = "  Ace  ";
       }

       switch (suit)
       {
         case  1: result = result + " of Clubs";  break;
         case  2: result = result + " of Hearts"; break;
         case  3: result = result + " of Spades"; break;
         case  4: result = result + " of Diamonds";
       }
       return result;
     }

 }

