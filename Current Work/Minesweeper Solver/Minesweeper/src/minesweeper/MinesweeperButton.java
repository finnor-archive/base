/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package minesweeper;

import javax.swing.*;

/**
 *
 * @author Adrian
 */
public class MinesweeperButton extends JButton {
    public int x, y;
    
    public MinesweeperButton(int i, int j)
    {
        super();
        x = i;
        y = j;
    }
}
