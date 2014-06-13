import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;

public class ThresGrad implements PlugInFilter {
	ImagePlus imp;

	public int setup(String arg, ImagePlus imp) {
		this.imp = imp;
		return DOES_ALL;
	}

	public void run(ImageProcessor ip) {

		int width = ip.getWidth();			//M
		int height = ip.getHeight();			//N
		double sum, sum1, sum2;
		double temp;
	

		ImageProcessor ip2 = new FloatProcessor(width, height);

		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				sum = ip.getPixelValue(x, y);		//center
				
				sum += ip.getPixelValue(x-2, y-2);	//topleft
				sum += ip.getPixelValue(x-1, y-2);	
				sum += ip.getPixelValue(x, y-2);		//midtop
				sum += ip.getPixelValue(x+1, y-2);	
				sum += ip.getPixelValue(x+2, y-2);	//topright
		
				sum += ip.getPixelValue(x-2, y-1);	//2nd row
				sum += ip.getPixelValue(x-1, y-1);	
				sum += ip.getPixelValue(x, y-1);		
				sum += ip.getPixelValue(x+1, y-1);	
				sum += ip.getPixelValue(x+2, y-1);	

				sum += ip.getPixelValue(x-2, y);		//left
				sum += ip.getPixelValue(x-1, y);	
				sum += ip.getPixelValue(x+1, y);	
				sum += ip.getPixelValue(x+2, y);		//right

				sum += ip.getPixelValue(x-2, y+1);	//4th row
				sum += ip.getPixelValue(x-1, y+1);	
				sum += ip.getPixelValue(x, y+1);		
				sum += ip.getPixelValue(x+1, y+1);	
				sum += ip.getPixelValue(x+2, y+1);

				sum += ip.getPixelValue(x-2, y+2);	//botleft
				sum += ip.getPixelValue(x-1, y+2);	
				sum += ip.getPixelValue(x, y+2);		//midbot
				sum += ip.getPixelValue(x+1, y+2);	
				sum += ip.getPixelValue(x+2, y+2);	//botright

				ip2.putPixelValue(x, y, (sum/25.0));
			}	
		}


		ImageProcessor ip3 = new FloatProcessor(width, height);

		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{

				sum1 = (-1.0*ip2.getPixelValue(x-1, y-1));
				sum2 = (-1.0*ip2.getPixelValue(x-1, y-1));

				sum1 += ip2.getPixelValue(x-1, y+1);
				sum2 += (-1.0*ip2.getPixelValue(x-1, y+1));

				sum2 += (-2.0*ip2.getPixelValue(x-1, y));

				sum1 += (-1.0*ip2.getPixelValue(x+1, y-1));
				sum2 += ip2.getPixelValue(x+1, y-1);

				sum1 += ip2.getPixelValue(x+1, y+1);
				sum2 += ip2.getPixelValue(x+1, y+1);

				sum2 += 2.0*ip2.getPixelValue(x+1, y);

				sum1 += 2.0*ip2.getPixelValue(x, y+1);

				sum1 += (-2.0*ip2.getPixelValue(x, y-1));

				temp = Math.abs(sum1) + Math.abs(sum2);
				ip3.putPixelValue(x, y, temp);
			}
		}

		

		ImageProcessor ip4 = new FloatProcessor(width, height);;

		double  thres = 0.2*(ip3.getMax());

		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				if (ip3.getPixelValue(x, y)>thres)
					ip4.putPixelValue(x, y, ip3.getMax());	
				else
					ip4.putPixelValue(x, y, 0);
			}
		}


		ImagePlus imp2 = new ImagePlus("Thresholded Gradient of Smoothed Image", ip4);
		imp2.show();	

	}

}
