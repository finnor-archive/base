import java.awt.*;
import java.awt.event.*;
import java.util.*;

/**
 * Class ButtonPanel:  holds buttons to pick the current shape and to clear
 * the shapes.
 * @author Barb Ericson
 */
public class ButtonPanel extends Panel
{
  
  ///////////////////// Public Attributes ////////////////////////
  
  ////////////////////// Private Attributes //////////////////////
  
  private Button rectButton;  // rectangle button
  private Button ovalButton;  // oval button
  private Button clearButton;  // clear button
  private ShapeInterface handler = null; // the shape interface handler
  
  //////////////////////// Constructors ////////////////////////////
  
  /** A constructor that takes no arguments */
  public ButtonPanel ()
  {
    // initialize the panel
    init();
  }
  
  /** A constructor that uses the default size but takes the handler
   * @param theHandler    the handler of shape interface type
   */
  public ButtonPanel (ShapeInterface theHandler)
  {
    // set the handler
    handler = theHandler;
    
    // initialize the panel
    init();
  }
  
  /////////////////// Private Methods ///////////////////////////////
  
  /** Method to initialize the panel */
  private void init()
  {
    // create the rectangle button
    rectButton = new Button("Rectangle");
    add(rectButton);
    rectButton.addActionListener(new ActionListener() {
      public void actionPerformed (ActionEvent e) {
        if (handler != null)
          handler.setShape(Shape.RECTANGLE);
      }
    });
    
    // create the oval button
    ovalButton = new Button("Oval");
    add(ovalButton);
    ovalButton.addActionListener(new ActionListener() {
      public void actionPerformed (ActionEvent e) {
        if (handler != null)
          handler.setShape(Shape.OVAL);
      }
    });
    
    
    // create the clear button
    clearButton = new Button("Clear");
    add(clearButton);
    clearButton.addActionListener(new ActionListener() {
      public void actionPerformed (ActionEvent e) {
        if (handler != null)
          handler.clearShapes();
      }
    });
  }
  
  ///////////////////// Main Method for Testing /////////////////////////
  public static void main (String argv[])
  {
    // create a frame
    Frame frame = new Frame();
    
    // create a ButtonPanel
    ButtonPanel buttonPanel = new ButtonPanel();
    
    // add the buttonPanel to the frame
    frame.add(buttonPanel);
    frame.pack(); // shrink to fit preferred size
    frame.setVisible(true); // show the frame
  }
  
}


