import ij.*;
import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;

public class DFT {



	public static ComplexNumber[][] DFT(float[][] input) {
		
		int width = input[0].length;		//M
		int height = input.length;			//N
		float[][] pixels = new float[width][height];
		ComplexNumber[][] Fxv = new ComplexNumber[width][height]; 
		ComplexNumber[][] Fuv = new ComplexNumber[width][height]; 
		double tempSumR = 0;
		double tempSumI = 0;
		double real;
		double imaginary;
		int temp;


		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				pixels[x][y] = input[x][y];
			}
		}


		for (int x=0; x<width; x++)
		{
			for (int v=0; v<height; v++)
			{
				for (int y=0; y<height; y++)
				{
					real = Math.cos(2*(Math.PI)*v*y/height);
					imaginary = -1*Math.sin(2*(Math.PI)*v*y/height);
					tempSumR += (real*pixels[x][y]);
					tempSumI += (imaginary*pixels[x][y]);
				}
			Fxv[x][v] = new ComplexNumber (tempSumR, tempSumI);
			tempSumR = 0;
			tempSumI = 0;
			}
		}
		
		for (int u=0; u<width; u++)
		{
			for (int v=0; v<height; v++)
			{
				for (int x=0; x<width; x++)
				{
					real = Math.cos(2*(Math.PI)*x*u/width);
					imaginary = -1*Math.sin(2*(Math.PI)*x*u/width);
					tempSumR += Fxv[x][v].r*real - Fxv[x][v].i*imaginary;
					tempSumI += Fxv[x][v].r*imaginary + Fxv[x][v].i*real;
				}
			Fuv[u][v] = new ComplexNumber(tempSumR/(width*height), tempSumI/(width*height));
			tempSumR = 0;
			tempSumI = 0;
			}
		}

		return (Fuv);
	}


	public static ComplexNumber[][] IDFT(float[][] input) {
		
		int width = input[0].length;		//M
		int height = input.length;			//N
		float[][] pixels = new float[width][height];
		ComplexNumber[][] Fxv = new ComplexNumber[width][height]; 
		ComplexNumber[][] Fuv = new ComplexNumber[width][height]; 
		double tempSumR = 0;
		double tempSumI = 0;
		double real;
		double imaginary;
		int temp;


		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				pixels[x][y] = input[x][y];
			}
		}


		for (int x=0; x<width; x++)
		{
			for (int v=0; v<height; v++)
			{
				for (int y=0; y<height; y++)
				{
					real = -1*Math.cos(2*(Math.PI)*v*y/height);
					imaginary = Math.sin(2*(Math.PI)*v*y/height);
					tempSumR += (real*pixels[x][y]);
					tempSumI += (imaginary*pixels[x][y]);
				}
			Fxv[x][v] = new ComplexNumber (tempSumR, tempSumI);
			tempSumR = 0;
			tempSumI = 0;
			}
		}
		
		for (int u=0; u<width; u++)
		{
			for (int v=0; v<height; v++)
			{
				for (int x=0; x<width; x++)
				{
					real = -1*Math.cos(2*(Math.PI)*x*u/width);
					imaginary = Math.sin(2*(Math.PI)*x*u/width);
					tempSumR += Fxv[x][v].r*real - Fxv[x][v].i*imaginary;
					tempSumI += Fxv[x][v].r*imaginary + Fxv[x][v].i*real;
				}
			Fuv[u][v] = new ComplexNumber(tempSumR, tempSumI);
			tempSumR = 0;
			tempSumI = 0;
			}
		}
		return (Fuv);
	}



	public static ComplexNumber[][] DFTComplexIn(ComplexNumber[][] input) {
		
		int width = input[0].length;		//M
		int height = input.length;			//N
		ComplexNumber[][] pixels = new ComplexNumber[width][height];
		ComplexNumber[][] Fxv = new ComplexNumber[width][height]; 
		ComplexNumber[][] Fuv = new ComplexNumber[width][height]; 
		double tempSumR = 0;
		double tempSumI = 0;
		double real;
		double imaginary;
		int temp;


		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				pixels[x][y] = new ComplexNumber(input[x][y].r, input[x][y].i);
			}
		}


		for (int x=0; x<width; x++)
		{
			for (int v=0; v<height; v++)
			{
				for (int y=0; y<height; y++)
				{
					real = Math.cos(2*(Math.PI)*v*y/height);
					imaginary = -1*Math.sin(2*(Math.PI)*v*y/height);
					tempSumR += pixels[x][v].r*real - pixels[x][v].i*imaginary;
					tempSumI += pixels[x][v].r*imaginary + pixels[x][v].i*real;
				}
			Fxv[x][v] = new ComplexNumber (tempSumR, tempSumI);
			tempSumR = 0;
			tempSumI = 0;
			}
		}
		
		for (int u=0; u<width; u++)
		{
			for (int v=0; v<height; v++)
			{
				for (int x=0; x<width; x++)
				{
					real = Math.cos(2*(Math.PI)*x*u/width);
					imaginary = -1*Math.sin(2*(Math.PI)*x*u/width);
					tempSumR += Fxv[x][v].r*real - Fxv[x][v].i*imaginary;
					tempSumI += Fxv[x][v].r*imaginary + Fxv[x][v].i*real;
				}
			Fuv[u][v] = new ComplexNumber(tempSumR/(width*height), tempSumI/(width*height));
			tempSumR = 0;
			tempSumI = 0;
			}
		}
		return (Fuv);
	}
			
	public static ComplexNumber[][] IDFTComplexIn(ComplexNumber[][] input) {
		
		int width = input[0].length;		//M
		int height = input.length;			//N
		ComplexNumber[][] pixels = new ComplexNumber[width][height];
		ComplexNumber[][] Fxv = new ComplexNumber[width][height]; 
		ComplexNumber[][] Fuv = new ComplexNumber[width][height]; 
		double tempSumR = 0;
		double tempSumI = 0;
		double real;
		double imaginary;
		int temp;


		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				pixels[x][y] = new ComplexNumber(input[x][y].r, input[x][y].i);
			}
		}


		for (int x=0; x<width; x++)
		{
			for (int v=0; v<height; v++)
			{
				for (int y=0; y<height; y++)
				{
					real = -1*Math.cos(2*(Math.PI)*v*y/height);
					imaginary = Math.sin(2*(Math.PI)*v*y/height);
					tempSumR += pixels[x][v].r*real - pixels[x][v].i*imaginary;
					tempSumI += pixels[x][v].r*imaginary + pixels[x][v].i*real;
				}
			Fxv[x][v] = new ComplexNumber (tempSumR, tempSumI);
			tempSumR = 0;
			tempSumI = 0;
			}
		}
		
		for (int u=0; u<width; u++)
		{
			for (int v=0; v<height; v++)
			{
				for (int x=0; x<width; x++)
				{
					real = -1*Math.cos(2*(Math.PI)*x*u/width);
					imaginary = Math.sin(2*(Math.PI)*x*u/width);
					tempSumR += Fxv[x][v].r*real - Fxv[x][v].i*imaginary;
					tempSumI += Fxv[x][v].r*imaginary + Fxv[x][v].i*real;
				}
			Fuv[u][v] = new ComplexNumber(tempSumR, tempSumI);
			tempSumR = 0;
			tempSumI = 0;
			}
		}
		return (Fuv);
	}

}
