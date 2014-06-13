import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;

public class MarrHild implements PlugInFilter {
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
    
    	filter[12][12] = sum;

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

	for (int y=0; y<height; y++)
	{
		for (int x=0; x<width; x++)
		{
			sum = ip2.getPixelValue(x-1, y-1);
			sum += ip2.getPixelValue(x, y-1);
			sum += ip2.getPixelValue(x+1, y-1);

			sum += ip2.getPixelValue(x-1, y);
			sum += 8*ip2.getPixelValue(x, y);
			sum += ip2.getPixelValue(x+1, y);

			sum += ip2.getPixelValue(x-1, y+1);
			sum += ip2.getPixelValue(x, y+1);
			sum += ip2.getPixelValue(x+1, y+1);

			ip3.putPixelValue(x, y, sum);
		}
	}



	double diff;
	double max;
	double thres = 0.2*ip3.getMax();
	ImageProcessor ip4 = new FloatProcessor(width, height);
	for (int y=0; y<height; y++)
	{
		for (int x=0; x<width; x++)
		{
			diff = 0;
			max = 0;
			
			if ((ip3.getPixelValue(x-1, y-1)>=0) && (ip3.getPixelValue(x+1, y+1)<0))
				max = ip3.getPixelValue(x-1, y-1) - ip3.getPixelValue(x+1, y+1);
			
			if ((ip3.getPixelValue(x+1, y-1)>=0) && (ip3.getPixelValue(x-1, y+1)<0))
			{
				diff = ip3.getPixelValue(x+1, y-1) - ip3.getPixelValue(x-1, y+1);
				if (diff>max)
					max = diff;
			}

			if ((ip3.getPixelValue(x, y-1)>=0) && (ip3.getPixelValue(x, y+1)<0))
			{
				diff = ip3.getPixelValue(x, y-1) - ip3.getPixelValue(x, y+1);
				if (diff>max)
					max = diff;
			}

			if ((ip3.getPixelValue(x-1, y)>=0) && (ip3.getPixelValue(x+1, y)<0))
			{
				diff = ip3.getPixelValue(x-1, y) - ip3.getPixelValue(x+1, y);
				if (diff>max)
					max = diff;
			}









			if ((ip3.getPixelValue(x-1, y-1)<0) && (ip3.getPixelValue(x+1, y+1)>=0))
			{
				diff = ip3.getPixelValue(x+1, y+1) - ip3.getPixelValue(x-1, y-1);
				if (diff>max)
					max = diff;
			}
			
			if ((ip3.getPixelValue(x+1, y-1)<0) && (ip3.getPixelValue(x-1, y+1)>=0))
			{
				diff = ip3.getPixelValue(x-1, y+1) - ip3.getPixelValue(x+1, y-1);
				if (diff>max)
					max = diff;
			}

			if ((ip3.getPixelValue(x, y-1)<0) && (ip3.getPixelValue(x, y+1)>=0))
			{
				diff = ip3.getPixelValue(x, y+1) - ip3.getPixelValue(x, y-1);
				if (diff>max)
					max = diff;
			}

			if ((ip3.getPixelValue(x-1, y)<0) && (ip3.getPixelValue(x+1, y)>=0))
			{
				diff = ip3.getPixelValue(x+1, y) - ip3.getPixelValue(x-1, y);
				if (diff>max)
					max = diff;
			}

			if (max>thres)
				ip4.putPixelValue(x, y, max);
			else
				ip4.putPixelValue(x, y, 0);	
		}
	}

	ImagePlus imp2 = new ImagePlus("Marr-Hildreth", ip4);
	imp2.show();
	}
}
