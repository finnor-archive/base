//********************************************************************
//*                                                                  *
//*                         CS302                                    *
//*                                                                  *
//*                     DeckOfCards.java                             *
//*                                                                  *
//********************************************************************

import java.util.Random;

public class DeckOfCards
{
   private Card[] deck = new Card[52];
   private int cardsDealt;
   private Random generator = new Random();

   public DeckOfCards()
   {
      int i = 0;

      for (int value = 2; value <= 14; value++) // Jack = 11, Queen = 12, King = 13, Ace = 14
         for (int suit = 1; suit <= 4; suit++) // 1 = Clubs, 2 = Hearts. 3 = Spades, 4 = Diamonds
         {
            deck[i] = new Card(value,suit);
            i++;
         }

      cardsDealt = 0;
   }


  //  Arrange cards in deck in random order
  public void shuffle()
  {
     Card temp;
     int random;

     for (int i = 0; i < 3; i++)
        for (int j = 0; j < 52; j++)
        {
           random = generator.nextInt(52);
           temp = deck[random];
           deck[random] = deck[j];
           deck[j] = temp;
        }

     cardsDealt = 0;
  }


  public Card deal()
  {
     if (cardsDealt == 52)
        shuffle();

     return deck[cardsDealt++]; // add 1 to cardsDealt after accessing deck array
  }

}




