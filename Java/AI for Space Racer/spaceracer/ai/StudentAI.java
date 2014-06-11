/*
 * Adrian Flannery
 * adrianu2
 * Spring 2009 CS 201 Introduction to Object Oriented Programming
 * Homework-1 Problem 3
 */

package ai;

import mvc.Control;
import spaceracer.Asteroid;
import spaceracer.Comet;
import spaceracer.Constants;
import spaceracer.PowerUp;
import spaceracer.Range;
import spaceracer.Spaceship;
import spaceracer.SpaceshipRadar;
import start.Startup;

public class StudentAI implements Control {

 private Spaceship myShip; 
 private SpaceshipRadar myRadar;
 
 public StudentAI(Spaceship ship) {
  myShip = ship;
  myRadar = myShip.getRadar();
 }
  
 
 public void moveShip() {
   double speed=0;
   double clearY=0;
   double y = 0;
   
   y = myShip.getY();
   
   // determine if the current path will not encounter an asteroid
   if ((myRadar.isAsteroidAhead()) == false)
    {
      myShip.accelerate();
      myShip.yStop();
      speed = myShip.getSpeedX();
    }
   else
   {
     // if an asteroid is approaching but not imminent it makes a decision on best course of action
     if ((myRadar.collisionImminent()) == false)
     {
       while(speed>0)
       {
         myShip.decelerate();
       }
       
       // if a clear line exists it till move up or down to avoid to reach it
       if ((myRadar.clearSpotsExist()) == true)
       {
         clearY = myRadar.getClosestClearSpot();
         if (clearY<=y)
         {
           myShip.moveDown();
           myShip.yStop();
         }
         else
         {
           myShip.moveUp();
           myShip.yStop();
         }
       }
     }
       // if the asteroid is unavoidable it activates the shield
       else
       {
         myShip.activateShield();
       }
     }
     
 } 
 public static void main(String[] args) {
  Startup.main(args);
 }

}
