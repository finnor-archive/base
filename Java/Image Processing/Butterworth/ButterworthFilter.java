import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;

public class ButterworthFilter implements PlugInFilter {
	ImagePlus imp;

	public int setup(String arg, ImagePlus imp) {
		this.imp = imp;
		return DOES_ALL;
	}

	public void run(ImageProcessor ip) {
		
		float[][] pixels = ((ByteProcessor) ip).toFloatArrays();
		int width = ip.getWidth();
		int height =  ip.getHeight();
		
		float[][] input = new float[width][height];

		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				input[x][y] = pixels[0][y*width+x];
			}
		}
			

		float[][] paddedf = new float[2*width][2*height];

		for (int y=0; y<2*height; y++)
		{
			for (int x=0; x<2*width; x++)
			{
				if ((x>width/2) && (x<(3*width/2)) && (y>height/2) && (y<(3*height/2)))
					paddedf[x][y] = input[x-(width/2)][y-(height/2)];
				else
					paddedf[x][y] = 0;
			}
		}
	
		for (int y=0; y<2*height; y++)
		{
			for (int x=0; x<2*width; x++)
			{
				paddedf[x][y] = ((float) Math.pow(-1, x+y)) * paddedf[x][y];
			}
		}

		ComplexNumber[][] Fuv = DFT.DFT(paddedf);

		
		float[][] Huv = new float[width][height];
		double Duv;
		for(int v=height/2; v<(3*height/2); v++)
		{
			for(int u=width/2; u<(3*width/2); u++)
			{
				Duv = Math.sqrt((u-width)*(u-width) + (v-height)*(v-height));
				Huv[u-(width/2)][v-(width/2)] = (float)(1/(1+Math.pow((Duv/16), 2)));
			}
		}


		for (int v=0; v<height; v++)
		{
			for (int u=0; u<width; u++)
			{
				Huv[u][v] = ((float) Math.pow(-1, u+v)) * Huv[u][v];
			}
		}

		ComplexNumber[][] hxy = DFT.IDFT(Huv);

		ComplexNumber[][] paddedh = new ComplexNumber[2*width][2*height];

		for (int y=0; y<2*height; y++)
		{
			for (int x=0; x<2*width; x++)
			{
				if ((x>width/2) && (x<(3*width/2)) && (y>height/2) && (y<(3*height/2)))
					paddedh[x][y] = hxy[x-(width/2)][y-(height/2)];
				else
					paddedh[x][y] = new ComplexNumber(0, 0);
			}
		}

		ComplexNumber[][] Heuv = DFT.DFTComplexIn(paddedh);

		ComplexNumber[][] Geuv = new ComplexNumber[2*width][2*height];
		double tempSumR;
		double tempSumI;
		for (int v=0; v<2*height; v++)
		{
			for (int u=0; u<2*width; u++)
			{
				tempSumR = (Heuv[u][v].r*Fuv[u][v].r) - (Heuv[u][v].i*Fuv[u][v].i);
				tempSumI = (Heuv[u][v].r*Fuv[u][v].i) + (Heuv[u][v].i*Fuv[u][v].r);
				Geuv[u][v] = new ComplexNumber(tempSumR, tempSumI);
			}
		}

		ComplexNumber[][] gexy = DFT.IDFTComplexIn(Geuv);
	

		float[][] gexyReal = new float[2*width][2*height];
		for (int y=0; y<2*height; y++)
		{
			for (int x=0; x<2*width; x++)
			{
				gexyReal[x][y] = (float) gexy[x][y].r;
			}
		}

		float[][] out = new float[width][height];

		for (int y=height/2; y<(3*height/2); y++)
		{
			for (int x=width/2; x<(3*width/2); x++)
			{
				out[x-(width/2)][y-(height/2)] = gexyReal[x][y];
			}
		}		

		ImageProcessor ip10 = new FloatProcessor(out);
		ImagePlus imp10 = new ImagePlus("Filtered Image", ip10);
		imp10.show();
	}

}
