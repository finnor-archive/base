/*********************************************************************
  * Adrian Flannery
  * 10/29/9
  * ImageViewerMain.java
  ********************************************************************/

class ImageViewerMain {


    
    public static void main( String args[] ) {
        String fileName  = FileChooser.pickAFile();
        
        ImageViewer imageViewer = new ImageViewer(fileName);

        imageViewer.showImage();
        
        // Display width, height, and total pixel of the imange
        System.out.println( "Width of Image: " + imageViewer.getWidth());
        System.out.println( "Height of Image: " + imageViewer.getHeight());
        System.out.println( "Total Pixels in Image: " + imageViewer.getTotalPixel() );
        
        // Count the number of black and white pixels per row in the image
        imageViewer.countBWPixelPerRows();
        
    }
}