import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;

public class runCS642Filters implements PlugInFilter {
	ImagePlus imp;

	public int setup(String arg, ImagePlus imp) {
		this.imp = imp;
		return DOES_ALL;
	}

	public void run(ImageProcessor ip) {
		
		ImageProcessor ip2 = Filters.laplacian(ip);
		ImagePlus imp2 = new ImagePlus("Laplacian", ip2);
		imp2.show();	

		ImageProcessor ip3 = Filters.sumLaplacian(ip);
		ImagePlus imp3 = new ImagePlus("Sum of Original with Laplacian", ip3);
		imp3.show();	

		ImageProcessor ip4 = Filters.sobel(ip);
		ImagePlus imp4 = new ImagePlus("Sobel", ip4);
		imp4.show();	

		ImageProcessor ip5 = Filters.average5(ip4);
		ImagePlus imp5 = new ImagePlus("5x5 Average of Sobel", ip5);
		imp5.show();	
	
		ImageProcessor ip6 = Filters.maskLapSob(ip3, ip5);
		ImagePlus imp6 = new ImagePlus("Product of Laplacian Summed Image With Averaged Sobel", ip6);
		imp6.show();	

		ImageProcessor ip7 = Filters.sumImage(ip, ip6);
		ImagePlus imp7 = new ImagePlus("Sharpened Image", ip7);
		imp7.show();	

		ImageProcessor ip8 = Filters.powerLawTransform(ip7, .6);
		ImagePlus imp8 = new ImagePlus("Power Law Transformation, Gamma = 0.6", ip8);
		imp8.show();	
	}
}
