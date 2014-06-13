import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;

public class DFTCentered implements PlugInFilter {
	ImagePlus imp;


	public int setup(String arg, ImagePlus imp) {
		this.imp = imp;
		return DOES_ALL;
	}

	public void run(ImageProcessor ip) {
		
		byte[] pixels = (byte[])ip.getPixelsCopy();
		int width = ip.getWidth();			//M
		int height = ip.getHeight();			//N
		ComplexNumber[] Fxv = new ComplexNumber[width*height]; 
		ComplexNumber[] Fuv = new ComplexNumber[width*height]; 
		double tempSumR = 0;
		double tempSumI = 0;
		double real;
		double imaginary;
		int temp;


		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				temp = (int) Math.pow(-1.0, x+y);
				pixels[y*width + x] = (byte) (pixels[y*width + x]*temp);
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
					tempSumR += (real*pixels[y*width+x]);
					tempSumI += (imaginary*pixels[y*width+x]);
				}
			Fxv[v*width + x] = new ComplexNumber (tempSumR, tempSumI);
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
					tempSumR += Fxv[v*width+x].r*real - Fxv[v*width+x].i*imaginary;
					tempSumI += Fxv[v*width+x].r*imaginary + Fxv[v*width+x].i*real;
				}
			Fuv[v*width + u] = new ComplexNumber(tempSumR, tempSumI);
			tempSumR = 0;
			tempSumI = 0;
			}
		}

			
		double[] magnitude = new double[width*height];
		ImageProcessor ip2  = new ShortProcessor(width, height);
		for (int i=0; i<width*height; i++)
		{
			magnitude[i] =  Math.sqrt(Fuv[i].r*Fuv[i].r + Fuv[i].i*Fuv[i].i);
			ip2.putPixel(i/width, i%width, (int) magnitude[i]);
		}

		ImagePlus imp2 = new ImagePlus("DFT", ip2);
		imp2.setProperty("DFT", ip2);
		imp2.show();
	}


			

}
