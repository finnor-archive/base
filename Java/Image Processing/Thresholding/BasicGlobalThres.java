import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;

public class BasicGlobalThres implements PlugInFilter {
	ImagePlus imp;

	public int setup(String arg, ImagePlus imp) {
		this.imp = imp;
		return DOES_ALL;
	}

	public void run(ImageProcessor ip) {

	int width = ip.getWidth();			//M
	int height = ip.getHeight();			//N
	double thres = 50;
	double prev = 0;
	double sumLower;
	double sumHigher;
	double numLow;
	double numHigh;
	double temp;

	while(Math.abs(thres-prev)>1)
	{
		sumLower = 0;
		sumHigher = 0;
		numLow = 0;
		numHigh = 0;
		for (int y=0; y<height; y++)
		{
			for(int x=0; x<width; x++)
			{
				temp = ip.getPixelValue(x, y);
				if (temp>thres)
				{
					sumHigher += temp;
					numHigh++;
				}
				else
				{
					sumLower += temp;
					numLow++;
				}
			}
		}
		prev = thres;
		thres = 0.5*((sumHigher/numHigh) + (sumLower/numLow));
	}


	ImageProcessor ip2 = new FloatProcessor(width, height);	

	for (int y=0; y<height; y++)
	{
		for(int x=0; x<width; x++)
		{
			temp = ip.getPixelValue(x, y);
			if (temp<=thres)
				ip2.putPixelValue(x, y, 0);
			else
				ip2.putPixelValue(x, y, 1);
		}
	}

	ImagePlus imp2 = new ImagePlus("Basic Global Thresholding", ip2);
	imp2.show();
	}
}
