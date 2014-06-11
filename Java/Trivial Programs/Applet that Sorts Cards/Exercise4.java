//********************************************************************
//*                                                                  *
//*                                                                  *
//*                          CS 302                                  *
//*                                                                  *
//*                       Excerise4.java                             *
//*                                                                  *
//*                                                                  *
//*            			  Adrian Flannery                            *
//*                          adrianu2                                *
//*                           CS-302                                 *
//*                    Programming Exercise 4                        *
//*   	The program creates an applet that deals 20 random cards    *
//*              and can sort them by suit or value                  *
//*                                                                  *
//********************************************************************
import java.awt.*;
import java.awt.event.*;
import java.applet.*;
import java.io.File;

public class Exercise4 extends Applet implements MouseListener
{
   private DeckOfCards deck;
   private Card[] hand = null;
   private Font font;
   private Image[] imageArray = new Image[52];
   private String dealMessage = "Deal 20";
	private char up = '\u2191'; // holds the unicode value for the up arrow
	private char down = '\u2193'; //holds the unicode value for the down arrow
	private String sortValueUp = "Sort Value " + up;
	private String sortValueDown = "Sort Value " + down;
	private String sortSuitUp = "Sort Suit " + up;
	private String sortSuitDown = "Sort Suit " + down;
	private String nameBlazerID = "     Adrian Flannery           adrianu2";


   public void init() // initializes applet and automatically calls method paint
   {
      setBackground(new Color(38,115,100));
      addMouseListener(this);
      font = new Font("Serif", Font.BOLD, 14);
      deck = new DeckOfCards();
      readCardImageFiles(imageArray,"CardImages"); //read card image files into imageArray
   }


   //
   //  Method readCardImageFiles
   //
   //  read individual card image files into imageArray from the given directory
   //
   private void readCardImageFiles(Image[] imageArray, String directory)
   {
       File file = new File (directory);
       String[] fileNames = file.list(); // get all file names in directory
       Image im = null;
       int index;

       if (!file.isDirectory())
          System.out.println("\nError: " + directory + " is NOT a directory");
       else
          for (int i = 0; i < imageArray.length; i++)
          {
             im  = getImage(getCodeBase(),directory + "\\" +fileNames[i]);
             index = Integer.parseInt(fileNames[i].replace(".gif",""));
             index = (((index / 100) - 1) * 13) + (index % 100 - 2);
             imageArray[index] = im;
          }
   }


   //
   //  Method mousePressed
   //
   //  Since the applet is registered to listen for mouse clicks on
   //  itself, the system will call this method when the user presses
   //  the mouse on the applet.
   //
   public void mousePressed(MouseEvent evt)
   {
      int x = evt.getX();  // convenient name for x co-ordinate of mouse
      int y = evt.getY();  // convenient name for y co-ordinate of mouse
		Card temp = null;

      if (x > 30 && x < 90 && y > 420 && y < 450)  // deal twenty cards
      {
			deal(20);
		}
			
		if (x > 105 && x < 195 && y > 420 && y < 450)  // sorts the values in ascending order
			{
			for(int i=0; i < hand.length - 1; i++) // loop structure compares each card to all other cards
			{
				for(int j=i+1; j < hand.length; j++)
				{
					if(hand[i].getValue() > hand[j].getValue())
					{
						temp = hand[i];
						hand[i] = hand[j];
						hand[j] = temp;
					}
					else // sorts cards of equal values by suit
					{
						if(hand[i].getValue() == hand[j].getValue() && hand[i].getSuit() > hand[j].getSuit() )
						{
							temp = hand[i];
							hand[i] = hand[j];
							hand[j] = temp;
						}
					}							
				}
			}
			repaint();
		}
		
		if (x > 210 && x < 300 && y > 420 && y < 450)  // sorts the values in descending order
		{
			for(int i=0; i < hand.length - 1; i++) // loop structure compares each card to all other cards
			{
				for(int j=i+1; j < hand.length; j++)
				{
					if(hand[i].getValue() < hand[j].getValue())
					{
						temp = hand[i];
						hand[i] = hand[j];
						hand[j] = temp;
					}
					else //sorts cards of equal values by suits
					{
						if(hand[i].getValue() == hand[j].getValue() && hand[i].getSuit() > hand[j].getSuit() )
						{
							temp = hand[i];
							hand[i] = hand[j];
							hand[j] = temp;
						}
					}
				}
			}
			repaint();
		}
		
		if (x > 310 && x < 390 && y > 420 && y < 450)  // sorts the suits in ascending order
		{
			for(int i=0; i < hand.length - 1; i++) // loop structure compares each card to all other cards
			{
				for(int j=i+1; j < hand.length; j++)
				{
					if(hand[i].getSuit() > hand[j].getSuit())
					{
						temp = hand[i];
						hand[i] = hand[j];
						hand[j] = temp;
					}
					else //sorts cards of equal suits by value
					{
						if(hand[i].getSuit() == hand[j].getSuit() && hand[i].getValue() > hand[j].getValue() )
						{
							temp = hand[i];
							hand[i] = hand[j];
							hand[j] = temp;
						}
					}
				}
			}
			repaint();
		}	
		
		if (x > 400 && x < 480 && y > 420 && y < 450)  // sorts the suits in descending order
		{
			for(int i=0; i < hand.length - 1; i++) // loop structure compares each card to all other cards
			{
				for(int j=i+1; j < hand.length; j++)
				{
					if(hand[i].getSuit() < hand[j].getSuit())
					{
						temp = hand[i];
						hand[i] = hand[j];
						hand[j] = temp;
					}
					else //sorts cards of equal suits by value
					{
						if(hand[i].getSuit() == hand[j].getSuit() && hand[i].getValue() > hand[j].getValue() )
						{
							temp = hand[i];
							hand[i] = hand[j];
							hand[j] = temp;
						}
					}
				}
			}
			repaint();
		}	
		
   }


   //
   //  Method deal(int num)
   //
   //  Shuffle the deck of cards, deal num cards
   //
   void deal(int num)
   {
      deck.shuffle();
      hand = new Card[num];

      for (int i = 0; i < hand.length; i++)
         hand[i] = deck.deal();

      repaint();
   }


   //
   //  Method paint
   //
   //  This method is called by the system when the applet needs to be repainted.
   //  This applet draws the cards and the messages in the applet.
   //
   public void paint(Graphics g)
   {
      setSize (520,500);

      int width = getSize().width;
      int height = getSize().height;
      FontMetrics fm = getFontMetrics(font);
      int w, xpos, ypos;

      g.setColor( Color.red );            // Draw a border around the applet.
      g.drawRect(0,0,width-1,height-1);

		//creates button for dealing 20 cards
      g.setColor(new Color(220,220,255));
      g.fillRect(30,420,60,30);
      g.setColor( Color.red );
      g.drawRect(30,420,59,29);
      g.setFont( font );		
      w = fm.stringWidth(dealMessage);  // width of string
      g.drawString(dealMessage, 60- w/2, 440 );
		
		//creates button for sorting cards by value in ascending order
		g.setColor(new Color(220,220,255));
      g.fillRect(105,420,90,30);
      g.setColor( Color.red );
      g.drawRect(105,420,89,29);		
		w = fm.stringWidth(sortValueUp);  // width of string
      g.drawString(sortValueUp, 150- w/2, 440 );
		
		//creates button for sorting cards by value in descending order
		g.setColor(new Color(220,220,255));
      g.fillRect(210,420,90,30);
      g.setColor( Color.red );
      g.drawRect(210,420,89,29);
		w = fm.stringWidth(sortValueDown);  // width of string
      g.drawString(sortValueDown, 255- w/2, 440 );
		
		//creates button for sorting cards by suit in ascending order
		g.setColor(new Color(220,220,255));
      g.fillRect(310,420,80,30);
      g.setColor( Color.red );
      g.drawRect(310,420,79,29);
		w = fm.stringWidth(sortSuitUp);  // width of string
      g.drawString(sortSuitUp, 350- w/2, 440 );
		
		//creates button for sorting cards by suit in descending order
		g.setColor(new Color(220,220,255));
      g.fillRect(400,420,80,30);
      g.setColor( Color.red );
      g.drawRect(400,420,79,29);
		w = fm.stringWidth(sortSuitDown);  // width of string
      g.drawString(sortSuitDown, 440- w/2, 440 );
		
		//creates label with name and blazerid
		g.setColor(new Color(255,255,255));
      g.fillRect(130,460,260,30);
      g.setColor( Color.red );
      g.drawRect(130,460,259,29);
		w = fm.stringWidth(nameBlazerID);  // width of string
      g.drawString(nameBlazerID, 243- w/2, 480 );
		
		
		

      if (hand != null)
      {
         xpos = 60;
         ypos = 10;

         for (int i = 0; i < hand.length; i++)   //paint cards in hand array
    		{        
				drawCard( g, hand[i], xpos, ypos);
				if(xpos<304)
					xpos += 81;
				else
				{
					xpos = 60;
					ypos += 101;
				}
			}
      }

   }


    //
    //  Method drawCard
    //
    //  Draws a card as a 71 by 96 (pixel) rectangle with
    //  upper left corner at (x,y).  The card is drawn
    //  in the graphics context g.
    //
    void drawCard(Graphics g, Card card, int x, int y)
    {
       g.drawImage(imageArray[(card.getSuit() - 1) * 13 + card.getValue() - 2],
                   x, y, x+71, y+96, 0, 0, 71, 96, this);
    }



   //
   //  Other mouse routines required by the MouseListener interface.
   //  They are not used in this applet
   //
   public void mouseClicked(MouseEvent evt)  { }
   public void mouseReleased(MouseEvent evt) { }
   public void mouseEntered(MouseEvent evt)  { }
   public void mouseExited(MouseEvent evt)   { }

}
