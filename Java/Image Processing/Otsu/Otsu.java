import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;

public class Otsu implements PlugInFilter {
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
	double sum = 0;
	double num = 0;
	double probK;
	double meanK;
	int maxK = 0;
	double maxSigma = 0;
	int temp;
	double temp1, temp2;
	double meanG;
	double[] hist = new double[256];

	for (int y=0; y<height; y++)
	{
		for(int x=0; x<width; x++)
		{
			temp = ip.getPixel(x, y);
			sum += ((double)temp);
			hist[temp]++;
			num++;
		}
	}
	meanG = sum/num;


	for(int i=0; i<256; i++)
	{
		hist[i] = hist[i]/num;
	}

	for (int k=1; k<255; k++)
	{
		meanK = 0;
		probK = 0;
		for (int i=0; i<=k; i++)
		{
			probK += hist[i];
		}
		if ((probK>0.0) && (probK<1.0))
		{
			for (int i=0; i<=k; i++)
			{
				meanK += (((double) i)*hist[i]);
			}
			//meanK = meanK / probK;
			temp1 = (meanG*probK - meanK)*(meanG*probK - meanK);
			temp2 = probK*(1.0-probK);
			temp1 = temp1/temp2;
			if (temp1>maxSigma)
			{
				maxSigma = temp1;
				maxK = k;
			}
		}
	}

	ImageProcessor ip2 = new FloatProcessor(width, height);	

	for (int y=0; y<height; y++)
	{
		for(int x=0; x<width; x++)
		{
			temp1 = ip.getPixelValue(x, y);
			if (temp1<=maxK)
				ip2.putPixelValue(x, y, 0);
			else
				ip2.putPixelValue(x, y, 1);
		}
	}

	ImagePlus imp2 = new ImagePlus("Otsu", ip2);
	imp2.show();
	}
}
