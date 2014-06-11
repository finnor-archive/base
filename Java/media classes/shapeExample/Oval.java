import java.awt.*;

/**
 * Class Oval:  inherits from Shape and handles oval shapes
 * @author Barb Ericson
 */
public class Oval extends Shape
{
  
  ///////////////////// Constructors ///////////////////////////////
  
  /** No argument constructor */
  public Oval ()
  {
    super();  // use parent constructor
  }
  
  /**
   * Constructor that takes two points
   * @param firstPoint  the first point for defining the shape
   * @param lastPoint   a second point for defining the shape
   */
  public Oval (Point firstPoint, Point lastPoint)
  {
    super(firstPoint,lastPoint); // use shape constructor
  }
  
  /**
   * Constructor that takes x1,y1,x2,y2
   * @param x1  x value for the first point for defining the shape
   * @param y1  y value for the first point defining the shape
   * @param x2  x value for the second point defining the shape
   * @param y2  y value for the second point defining the shape
   */
  public Oval (int x1, int y1, int x2, int y2)
  {
    super(x1,y1,x2,y2);  // use shape constructor
  }
  
  //////////////////////// Public Methods //////////////////////////////
  
  /**
   * Draw the shape
   * @param g   the graphics context to draw to
   */
  public void draw(Graphics g)
  {
    // set the color to draw the shape in
    g.setColor(color);
    
    // draw the shape given the top left corner of the enclosing
    // rectangle and the width and height
    g.drawOval(getMinX(),getMinY(),getWidth(),getHeight());
  }
  
}


