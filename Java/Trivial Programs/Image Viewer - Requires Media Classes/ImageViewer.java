/*********************************************************************
  * Adrian Flannery
  * 10/29/9
  * ImageViewer.java
  ********************************************************************/

import java.awt.Color;

class ImageViewer{
    
    private Picture pictureObject = null;
    
    private int imageWidth = 0;
    private int imageHeight = 0; 
    
    ImageViewer(String fileName ) {
        
        pictureObject = new Picture(fileName);
        
                
       
    }
    
    // Show image
    public void showImage() {
        pictureObject.show();
    }
    
    // return width of image
    public int getWidth() {
        imageWidth = pictureObject.getWidth();
        return imageWidth;
    }
    
    // return height of image
    public int getHeight() {
        imageHeight = pictureObject.getHeight();
        return imageHeight;
    }
    
    // return total pixel of the image
    public int getTotalPixel() {
        int totalPixel = 0;
        
        totalPixel = imageWidth * imageHeight;
        
        return totalPixel;
    }
    
    // count black and white pixels of the image
    public void countBWPixel() {

        Pixel pixelObj = null;
        Color colorObj = null;
        
        int[] blackWhite = {0, 0};

        for (int i=0; i<(getWidth()); i++)
        {
          for (int j=0; j<(getHeight()); j++)
          {
            pixelObj = pictureObject.getPixel(i,j);
            colorObj = pixelObj.getColor();
            if (colorObj.equals(Color.BLACK))
              blackWhite[0]++;
            if (colorObj.equals(Color.WHITE))
              blackWhite[1]++;
          }
        }
        

        
        System.out.println( "Number of white pixels : " +  blackWhite[1]);
        System.out.println( "Number of black pixels : " +  blackWhite[0]);
        System.out.println( "Total pixels : " + getTotalPixel());
    }
    
    
    public void countBWPixelPerRows(){
      
      Pixel pixelObj = null;
      Color colorObj = null;
      int[][] numOfBWPixel = new int[(getHeight())][2];
      int black = 0;
      int white = 0;
      int total = 0;
      
      for (int i=0; i<(getHeight()); i++)
      {
        for (int j=0; j<(getWidth()); j++)
        {
          pixelObj = pictureObject.getPixel(j,i);
          colorObj = pixelObj.getColor();
          if(colorObj.equals(Color.BLACK))
          {
            numOfBWPixel[i][0]++;
            black++;
          }
          if(colorObj.equals(Color.WHITE))
          {
            white++;
            numOfBWPixel[i][1]++; 
          }
          total++;
        }
        System.out.print(i + "th row,");
        System.out.print(" Black: " + numOfBWPixel[i][0]);
        System.out.println("    \tWhite: " + numOfBWPixel[i][1]);
      }
      System.out.println("Total Black: " + black + "     \tWhite: " + white + 
                           "\tTotal: " + total);
    }    
}