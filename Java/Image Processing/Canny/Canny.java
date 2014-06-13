import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;

public class Canny implements PlugInFilter {
	ImagePlus imp;

	public int setup(String arg, ImagePlus imp) {
		this.imp = imp;
		return DOES_ALL;
	}

	public void run(ImageProcessor ip) {

	int width = ip.getWidth();			//M
	int height = ip.getHeight();			//N
	double[][] filter = new double[25][25];
    	double temp;
   	double sum = 0;
	double sum1, sum2;
    
    	for (int y=0; y<13; y++)
  	 {
   	   	for (int x=0; x<13; x++)
     	 	{
        			temp = Math.pow(Math.E, -((x*x)+(y*y))/32.0);
        			filter[x+12][y+12] = temp;
       	 		filter[-x+12][y+12] = temp;
       			filter[x+12][-y+12] = temp;
       			filter[-x+12][-y+12] = temp;
      		}
    	}
    
    	for (int y=0; y<25; y++)
    	{
     		for (int x=0; x<25; x++)
      		{
        			if ((x!=0) && (y!=0))
          				sum += -filter[x][y];
      		}
    	}
    
    	filter[12][12] = sum/10;

	float[] temp2 = new float[25*25];

	for (int y=0; y<25; y++)
	{
		for(int x=0; x<25; x++)
		{
			temp2[y*25+x] = (float) filter[x][y];
		}
	}
	

	ImageProcessor ip2 = new FloatProcessor(width, height);

	for (int y=0; y<height; y++)
	{
		for(int x=0; x<width; x++)
		{
			ip2.putPixelValue(x, y, ip.getPixelValue(x, y));
		}
	}
	ip2.convolve(temp2, 25, 25);



	ImageProcessor ip3 = new FloatProcessor(width, height);
	ImageProcessor direction = new FloatProcessor(width, height);

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

			temp = Math.sqrt(sum1*sum1 + sum2*sum2);
			ip3.putPixelValue(x, y, temp);
	

			temp = Math.toDegrees(Math.atan(sum2/sum1));
			if (temp<-157.5)
				direction.putPixelValue(x, y, 0.0);
			else if (temp<-112.5)
				direction.putPixelValue(x, y, -45.0);
			else if (temp<-67.5)
				direction.putPixelValue(x, y, 90.0);
			else if (temp<-22.5)
				direction.putPixelValue(x, y, 45.0);
			else if (temp<22.5)
				direction.putPixelValue(x, y, 0.0);
			else if (temp<67.5)
				direction.putPixelValue(x, y, -45.0);
			else if (temp<112.5)
				direction.putPixelValue(x, y, 90.0);
			else if (temp<157.5)
				direction.putPixelValue(x, y, 45.0);
			else
				direction.putPixelValue(x, y, 0.0);
		}
	}



	ImageProcessor ip4 = new FloatProcessor(width, height);

	for (int y=0; y<height; y++)
	{
		for (int x=0; x<width; x++)
		{
			if(direction.getPixel(x, y) == 45)
			{
				if ((ip3.getPixelValue(x, y) < ip3.getPixelValue(x-1, y-1)) || (ip3.getPixelValue(x, y) < ip3.getPixelValue(x+1, y+1)))
					ip4.putPixelValue(x, y, 0);
				else
					ip4.putPixelValue(x, y, ip3.getPixelValue(x, y));
			}
			else if(direction.getPixel(x, y) == -45)
			{
				if ((ip3.getPixelValue(x, y) < ip3.getPixelValue(x-1, y+1)) || (ip3.getPixelValue(x, y) < ip3.getPixelValue(x+1, y-1)))
					ip4.putPixelValue(x, y, 0);
				else
					ip4.putPixelValue(x, y, ip3.getPixelValue(x, y));
			}
			else if(direction.getPixel(x, y) == 0)
			{
				if ((ip3.getPixelValue(x, y) < ip3.getPixelValue(x, y-1)) || (ip3.getPixelValue(x, y) < ip3.getPixelValue(x, y-1)))
					ip4.putPixelValue(x, y, 0);
				else
					ip4.putPixelValue(x, y, ip3.getPixelValue(x, y));
			}
			else
			{
				if ((ip3.getPixelValue(x, y) < ip3.getPixelValue(x-1, y)) || (ip3.getPixelValue(x, y) < ip3.getPixelValue(x+1, y)))
					ip4.putPixelValue(x, y, 0);
				else
					ip4.putPixelValue(x, y, ip3.getPixelValue(x, y));
			}
		}
	}

	

	ImageProcessor gHigh = new FloatProcessor(width, height);
	ImageProcessor gLow = new FloatProcessor(width, height);
	double thresH = ip4.getMax()*0.055;
	double thresL = ip4.getMax()*0.025;

	for (int y=0; y<height; y++)
	{
		for (int x=0; x<width; x++)
		{
			if (ip4.getPixelValue(x, y)>thresH)
				gHigh.putPixelValue(x, y, 255);	
			else if (ip4.getPixelValue(x, y)>thresL)
				gLow.putPixelValue(x, y, ip4.getPixelValue(x, y));	
		}
	}



	ImageProcessor canny = new FloatProcessor(width, height);

	for (int y=0; y<height; y++)
	{
		for (int x=0; x<width; x++)
		{
			if (gHigh.getPixelValue(x, y)>0)
			{
				canny.putPixelValue(x, y, gHigh.getPixelValue(x, y));
				if (gLow.getPixelValue(x-1, y-1)>0)
					canny.putPixelValue(x-1, y-1, 255);
				if (gLow.getPixelValue(x, y-1)>0)
					canny.putPixelValue(x, y-1, 255);
				if (gLow.getPixelValue(x+1, y-1)>0)
					canny.putPixelValue(x+1, y-1, 255);
				
				if (gLow.getPixelValue(x-1, y)>0)
					canny.putPixelValue(x-1, y, 255);
				if (gLow.getPixelValue(x+1, y)>0)
					canny.putPixelValue(x+1, y, 255);

				if (gLow.getPixelValue(x-1, y+1)>0)
					canny.putPixelValue(x-1, y+1, 255);
				if (gLow.getPixelValue(x, y+1)>0)
					canny.putPixelValue(x, y+1, 255);
				if (gLow.getPixelValue(x+1, y+1)>0)
					canny.putPixelValue(x+1, y+1, 255);
				
			}
		}
	}



	ImagePlus imp2 = new ImagePlus("Canny", canny);
	imp2.show();

	}
}
