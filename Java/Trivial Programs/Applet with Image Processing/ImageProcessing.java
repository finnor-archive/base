/*********************************************************************
 * Adrian Flannery
 * adrianu2
 * CS-302
 * Programming Exercise 3
 * The program codes methods intended to manipulate images
 ********************************************************************/

import java.awt.*;
import java.awt.image.*;

public class ImageProcessing
{
  //*******************************************************************
  //clears all red from the image
   public static BufferedImage clearRed(BufferedImage img)
   {
      int w = img.getWidth();
      int h = img.getHeight();

      BufferedImage newImg = new BufferedImage(w, h, img.getType());

      for (int x = 0; x < w; x++)
      {
         for (int y = 0; y < h; y++)
         {
            int  c = img.getRGB(x,y);
            int  r = (c & 0x00ff0000) >> 16;
            int  g = (c & 0x0000ff00) >> 8;
            int  b = c & 0x000000ff;

            Color col = new Color(0, g, b);

            newImg.setRGB(x, y, col.getRGB());
         }
      }
      return newImg;
   }
   //*******************************************************************
   
   
   
   //*******************************************************************
   //takes the dominant color in a pixel and makes the pixel that color
   public static BufferedImage primaryColors(BufferedImage image)
   {
     //gets the width and height of the image
     int w = image.getWidth();
     int h = image.getHeight();
     
     Color col = null;
     
     //creates a new image to store the manipulated image to be returned
     BufferedImage newImg = new BufferedImage(w, h, image.getType());

     //loops through each pixel in an image
      for (int x = 0; x < w; x++)
      {
         for (int y = 0; y < h; y++)
         {
           //gets the color of the pixel being looped through
           int  c = image.getRGB(x,y);
           int  r = (c & 0x00ff0000) >> 16;
           int  g = (c & 0x0000ff00) >> 8;
           int  b = c & 0x000000ff;
           
           //if red is dominant then the pixel is made red
            if(r > g && r > b)
            {
              col = new Color(255, 0, 0);
            }
            else
            {
              //else if green is dominant then the pixel is made green
              if(g>b)
              {
                col = new Color(0, 255, 0);
              }
              else
              {
                //else if blue is dominant then the pixel is made blue
                if(b>g)
                {
                  col = new Color(0, 0, 255);
                }
                //else the pixel is made black
                else
                {
                  col = new Color(0, 0, 0);
                }
              }
            }
            // stores color in current pixel
            newImg.setRGB(x, y, col.getRGB());             
         }
      }
      return newImg;
   }
   //*******************************************************************
   
   
   
   //*******************************************************************
   //returns the image as a negative
   public static BufferedImage negative(BufferedImage image)
   {
     // gets width and height
      int w = image.getWidth();
      int h = image.getHeight();

      BufferedImage newImg = new BufferedImage(w, h, image.getType());

      //loops through the pixels
      for (int x = 0; x < w; x++)
      {
         for (int y = 0; y < h; y++)
         {
           //gets the color for the pixel
            int  c = image.getRGB(x,y);
            int  r = (c & 0x00ff0000) >> 16;
            int  g = (c & 0x0000ff00) >> 8;
            int  b = c & 0x000000ff;

            //creates the negative color
            Color col = new Color(255-r, 255-g, 255-b);

            //sets the color for the pixel
            newImg.setRGB(x, y, col.getRGB());
         }
      }
      return newImg;
   }
   //*******************************************************************
   
   
   
   //*******************************************************************
   //returns the image in grayscale
   public static BufferedImage grayscale(BufferedImage image)
   {
     //gets the width and height
      int w = image.getWidth();
      int h = image.getHeight();

      BufferedImage newImg = new BufferedImage(w, h, image.getType());

      //loops through the pixels
      for (int x = 0; x < w; x++)
      {
         for (int y = 0; y < h; y++)
         {
           //gets the color for the current pixel
            int  c = image.getRGB(x,y);
            int  r = (c & 0x00ff0000) >> 16;
            int  g = (c & 0x0000ff00) >> 8;
            int  b = c & 0x000000ff;
            
            //gets the luminance for the pixel's color
            int l = (11*r + 16*g + 5*b)/32;

            Color col = new Color(l, l, l);

            //sets the color for the pixel
            newImg.setRGB(x, y, col.getRGB());
         }
      }
      return newImg;
   }
   //*******************************************************************
   
   
   //*******************************************************************
   //rotates the image 90 degrees
   public static BufferedImage rotate90(BufferedImage image)
   {
     //gets the width and height
      int w = image.getWidth();
      int h = image.getHeight();

      BufferedImage newImg = new BufferedImage(h, w, image.getType());

      //loops through the pixels
      for (int x = 0; x < w; x++)
      {
         for (int y = 0; y < h; y++)
         {
           //gets the color for the current pixel
           int  c = image.getRGB(x,y);
           int  r = (c & 0x00ff0000) >> 16;
           int  g = (c & 0x0000ff00) >> 8;
           int  b = c & 0x000000ff;
           
           Color col = new Color(r, g, b);
           
           //moves the current pixel 90 degrees
           newImg.setRGB(y, w-x-1, col.getRGB());
         }
      }
      return newImg;
   }
   //*******************************************************************
   
   
   
   //*******************************************************************
   //rotates the image 180 degrees
   public static BufferedImage rotate180(BufferedImage image)
   {
     //gets the height and width
      int w = image.getWidth();
      int h = image.getHeight();

      BufferedImage newImg = new BufferedImage(w, h, image.getType());

      //loops through the pixels
      for (int x = 0; x < w; x++)
      {
         for (int y = 0; y < h; y++)
         {
           //gets the color of the current pixel
           int  c = image.getRGB(x,y);
           int  r = (c & 0x00ff0000) >> 16;
           int  g = (c & 0x0000ff00) >> 8;
           int  b = c & 0x000000ff;
           
           Color col = new Color(r, g, b);
           
           //rotates the pixel 180 degrees
           newImg.setRGB(w-x-1, h-y-1, col.getRGB());
         }
      }
      return newImg;
   }
   //*******************************************************************
   
   
   
   //*******************************************************************
   //mirrors the image
   public static BufferedImage mirror(BufferedImage image)
   {
     //gets the height and the width
      int w = image.getWidth();
      int h = image.getHeight();

      BufferedImage newImg = new BufferedImage(w, h, image.getType());

      //loops through the pixels
      for (int x = 0; x < w; x++)
      {
         for (int y = 0; y < h; y++)
         {
           //gets the color for the current pixel
           int  c = image.getRGB(x,y);
           int  r = (c & 0x00ff0000) >> 16;
           int  g = (c & 0x0000ff00) >> 8;
           int  b = c & 0x000000ff;
           
           Color col = new Color(r, g, b);
           
           //mirrors the pixel
           newImg.setRGB(w-x-1, y, col.getRGB());
         }
      }
      return newImg;
   }
   //*******************************************************************
   
   
   
   //*******************************************************************
   //mirrors the image across the vertical axis
   public static BufferedImage mirrorVertical(BufferedImage image)
   {
     //gets the height and width
      int w = image.getWidth();
      int h = image.getHeight();

      BufferedImage newImg = new BufferedImage(w, h, image.getType());

      //loops through the first half of pixels on the left side and copies to the same position
      for (int x = 0; x < w/2; x++)
      {
         for (int y = 0; y < h; y++)
         {
           //gets the color for the current pixel
           int  c = image.getRGB(x,y);
           int  r = (c & 0x00ff0000) >> 16;
           int  g = (c & 0x0000ff00) >> 8;
           int  b = c & 0x000000ff;
           
           Color col = new Color(r, g, b);
           
           //copys the pixel into the image
           newImg.setRGB(x, y, col.getRGB());
         }
      }
      
      //loops through the first half of pixels on the left side and copies to the same position
      for (int x = 0; x < w/2; x++)
      {
         for (int y = 0; y < h; y++)
         {
           //gets the color for the current pixel
           int  c = image.getRGB((w/2)-x,y);
           int  r = (c & 0x00ff0000) >> 16;
           int  g = (c & 0x0000ff00) >> 8;
           int  b = c & 0x000000ff;
           
           Color col = new Color(r, g, b);
           
           //mirrors the pixel to the other half
           newImg.setRGB((w/2)+x, y, col.getRGB());
         }
      }
      return newImg;
   }
   //*******************************************************************
   
   
   
   //*******************************************************************
   //mirrors the image across the horizontal plane
   public static BufferedImage mirrorHorizontal(BufferedImage image)
   {
     //gets the height and width
      int w = image.getWidth();
      int h = image.getHeight();

      BufferedImage newImg = new BufferedImage(w, h, image.getType());

      //loops through the top half of the image and copies the pixels
      for (int x = 0; x < w; x++)
      {
         for (int y = 0; y < (h/2); y++)
         {
           //gets the current pixel's color
           int  c = image.getRGB(x,y);
           int  r = (c & 0x00ff0000) >> 16;
           int  g = (c & 0x0000ff00) >> 8;
           int  b = c & 0x000000ff;
           
           Color col = new Color(r, g, b);
           
           //copies the pixels
           newImg.setRGB(x, y, col.getRGB());
         }
      }
      
      //loops through top half of the image and mirrors the pixels
      for (int x = 0; x < w; x++)
      {
         for (int y = 0; y < (h/2); y++)
         {
           //gets the color for the current pixel
           int  c = image.getRGB(x,(h/2)-y);
           int  r = (c & 0x00ff0000) >> 16;
           int  g = (c & 0x0000ff00) >> 8;
           int  b = c & 0x000000ff;
           
           Color col = new Color(r, g, b);
           
           //mirrors the pixel to the other half
           newImg.setRGB(x, (h/2)+y, col.getRGB());
         }
      }
      return newImg;
   }
   //*******************************************************************
   
   
   
   //*******************************************************************
   //reduces the dimensions of the image in half
   public static BufferedImage reduce(BufferedImage image)
   {
     //gets the width and height
      int w = image.getWidth();
      int h = image.getHeight();

      //new image has half the width and height
      BufferedImage newImg = new BufferedImage(w/2, h/2, image.getType());

      //loops through 4 pixel blocks and takes the average color and sets it to the corresponding position
      for (int x = 0; x < w-1; x+=2)
      {
         for (int y = 0; y < h-1; y+=2)
         {
           //colors for the 4 pixel blocks
           int  c0 = image.getRGB(x,y);
           int  r0 = (c0 & 0x00ff0000) >> 16;
           int  g0 = (c0 & 0x0000ff00) >> 8;
           int  b0 = c0 & 0x000000ff;
           int  c1 = image.getRGB(x+1,y);
           int  r1 = (c1 & 0x00ff0000) >> 16;
           int  g1 = (c1 & 0x0000ff00) >> 8;
           int  b1 = c1 & 0x000000ff;
           int  c2 = image.getRGB(x,y+1);
           int  r2 = (c2 & 0x00ff0000) >> 16;
           int  g2 = (c2 & 0x0000ff00) >> 8;
           int  b2 = c2 & 0x000000ff;
           int  c3 = image.getRGB(x+1,y+1);
           int  r3 = (c3 & 0x00ff0000) >> 16;
           int  g3 = (c3 & 0x0000ff00) >> 8;
           int  b3 = c3 & 0x000000ff;
           
           //gets the average color
           int r = (r0 + r1 + r2 + r3) / 4;
           int g = (g0 + g1 + g2 + g3) / 4;
           int b = (b0 + b1 + b2 + b3) / 4;
             
           Color col = new Color(r, g, b);
           
           //sets average color to corresponding position
           newImg.setRGB(x/2, y/2, col.getRGB());
         }
      }
      return newImg;
   }
}
//*******************************************************************