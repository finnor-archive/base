import java.awt.*;
import java.awt.event.*;
import java.util.*;

/**
 * Class ShapePanel:  holds a ShapeCanvas and a ButtonPanel for drawing shapes
 * @author Barb Ericson
 * @since 1.1
 */
public class ShapePanel extends Panel
{
  
  /////////////////////// Private Attributes /////////////////////
  
  private ShapeCanvas shapeCanvas = new ShapeCanvas(500,500);
  private ButtonPanel buttonPanel = new ButtonPanel(shapeCanvas);
  
  ////////////////////// Constructors /////////////////////////////
  
  /** A constructor that takes no arguments */
  public ShapePanel ()
  {
    init();
  }
  
  //////////////////// Private Methods /////////////////////////////////
  
  /* Method to initialize the panel */
  private void init()
  {
    // use a border layout
    setLayout(new BorderLayout());
    
    // add the button panel to the north section of the border layout
    add("North", buttonPanel);
    
    // add the shape canvas to the center section of the border layout
    add("Center", shapeCanvas);
  }
  
  ////////////////////// Main Method for Testing ////////////////////////
  public static void main (String argv[])
  {
    // create a frame (main application window)
    Frame frame = new Frame();
    
    // create a Shape Panel
    ShapePanel shapePanel = new ShapePanel();
    
    // when the window closes stop the application
    frame.addWindowListener(new WindowAdapter() {
      public void windowClosing(WindowEvent e) {System.exit(0);}
      
    });
    
    // add the shapePanel to the frame
    frame.add(shapePanel);
    frame.pack();         // shrink to fit preferred size
    frame.setVisible(true); // show the frame
  }
  
}


