import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;

public class Averaging implements PlugInFilter {
	ImagePlus imp;

	public int setup(String arg, ImagePlus imp) {
		this.imp = imp;
		return DOES_ALL;
	}


	public void run(ImageProcessor ip) {
		
		int width = ip.getWidth();			//M
		int height = ip.getHeight();			//N
		float sum = 0;
		short[] output = new short[width*height];
		int divider = 1;

		ImageProcessor ip2 = new ShortProcessor(width, height);
		
		for (int u=0; u<width; u++)
		{
			for (int v=0; v<height; v++)
			{
				sum = ip.getPixel(u, v);
				if (u>1)					//top
				{
					divider++;
					sum += ip.getPixel(u-1, v);
				}
				if (u<width-1)					//bottom
				{
					divider++;
					sum += ip.getPixel(u+1, v);
				}	
				if (v>1)						//left
				{
					divider++;
					sum += ip.getPixel(u, v-1);
				}	
				if (v<height-1)					//right
				{
					divider++;
					sum += ip.getPixel(u, v+1);
				}
				if ((u>1) && (v>1))				//topleft
				{
					divider++;
					sum += ip.getPixel(u-1, v-1);
				}
				if ((u>1) && (v<height-1))			//topright
				{
					divider++;
					sum += ip.getPixel(u-1, v+1);
				}
				if ((u<width-1) && (v>1))			//bottomleft
				{
					divider++;
					sum += ip.getPixel(u+1, v-1);
				}
				if ((u<width-1) && (v<height-1))		//bottomright
				{
					divider++;
					sum += ip.getPixel(u+1, v+1);
				}
				ip2.putPixel(u, v, (int) (sum/divider));
				divider=1;
			}
			
		}



		ImagePlus imp2 = new ImagePlus("Averaged", ip2);
		imp2.setProperty("DFT", ip2);
		imp2.show();
	}

}
