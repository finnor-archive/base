import ij.*;
import ij.process.*;
import ij.gui.*;
import java.awt.*;
import ij.plugin.filter.*;


public class Filters
{
  	public static FloatProcessor laplacian(ImageProcessor ip) 
	 {
		byte[] pixels = (byte[])ip.getPixelsCopy();
   		int width = ip.getWidth();   //M
   		int height = ip.getHeight();   //N
		
    		float sum;
    		float[] output = new float[width*height];
    		int mult;    

    		for (int y=0; y<height; y++)
   		{
     			for (int x=0; x<width; x++)
      			{
        				sum = 0;
        				mult = 0;
        				if (y>0)     //top
        				{
          					sum += pixels[(y-1)*width+x];
          					mult++;
       				}
        				if (y<height-1)     //bottom
        				{
          					sum += pixels[(y+1)*width+x];
          					mult++;
        				}
        				if (x>0)      //left
        				{
          					sum += pixels[y*width+x-1];
          					mult++;
        				}
        				if (x<width-1)     //right
        				{
          					sum += pixels[y*width+x+1];
          					mult++;
        				}
        				sum = sum - mult*pixels[y*width+x];     
        				output[y*width+x] = (short) sum;
      			}
    		}


		ImageProcessor ip2 = new FloatProcessor(width, height, output, null);
		return ((FloatProcessor) ip2);
	}



	public static ByteProcessor sumLaplacian(ImageProcessor ip) {
		
   		int width = ip.getWidth();   //M
   		int height = ip.getHeight();   //N
    		ImageProcessor ip2 = new ByteProcessor(width, height);
    		
		int sum;

   		for (int y=0; y<height; y++)
    		{
     		 	for (int x=0; x<width; x++)
      			{
        				sum = 0;

          				sum += ip.getPixel(x, y-1);
				sum += ip.getPixel(x, y+1);
          				sum += ip.getPixel(x-1, y);
          				sum += ip.getPixel(x+1, y);

        				sum = sum - 4*ip.getPixel(x, y);  
        				ip2.putPixel(x, y, sum);
      			}
    		}


    		for (int y=0; y<height; y++)
    		{
      			for (int x=0; x<width; x++)
      			{
            			ip2.putPixel(x, y, ip.getPixel(x,y) + ip2.getPixel(x, y));
      			}
    		}
		
	return((ByteProcessor) ip2);	
	}


	public static ByteProcessor sobel(ImageProcessor ip) {
	
	int width = ip.getWidth();   //M
   	int height = ip.getHeight();   //N
	ImageProcessor ip2 = new ByteProcessor(width, height);
	int sum1, sum2;
	int multU, multD, multR, multL;
	int temp;
	for (int y=0; y<height; y++)
	{
		for (int x=0; x<width; x++)
		{
			sum1 = 0;
			sum2 = 0;
			multU = 0;
			multL = 0;
			multR = 0;
			multD = 0;

			sum1 += (-1*ip.getPixel(x-1, y-1));
			sum2 += (-1*ip.getPixel(x-1, y-1));

			sum1 += ip.getPixel(x-1, y+1);
			sum2 += (-1*ip.getPixel(x-1, y+1));

			sum2 += (-2*ip.getPixel(x-1, y));

			sum1 += (-1*ip.getPixel(x+1, y-1));
			sum2 += ip.getPixel(x+1, y-1);

			sum1 += ip.getPixel(x+1, y+1);
			sum2 += ip.getPixel(x+1, y+1);

			sum2 += 2*ip.getPixel(x+1, y);

			sum1 += 2*ip.getPixel(x, y+1);

			sum1 += (-2*ip.getPixel(x, y-1));

			temp = (int) Math.sqrt(sum1*sum1+sum2*sum2);
			ip2.putPixel(x, y, temp);
		}
			
	}
	return ((ByteProcessor) ip2);
	}

	public static ByteProcessor average5(ImageProcessor ip)
	 {
	
		int width = ip.getWidth();   //M
   		int height = ip.getHeight();   //N
		ImageProcessor ip2 = new ByteProcessor(width, height);

		int sum;
		int mean;

		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				sum = 0;


				sum += ip.getPixel(x-2, y-2);
				sum += ip.getPixel(x-2, y-1);
				sum += ip.getPixel(x-2, y);
				sum += ip.getPixel(x-2, y+1);
				sum += ip.getPixel(x-2, y+2);
		

				sum += ip.getPixel(x-1, y-2);
				sum += ip.getPixel(x-1, y-1);
				sum += ip.getPixel(x-1, y);
				sum += ip.getPixel(x-1, y+1);
				sum += ip.getPixel(x-1, y+2);


				sum += ip.getPixel(x, y-2);
				sum += ip.getPixel(x, y-1);
				sum += ip.getPixel(x, y);
				sum += ip.getPixel(x, y+1);
				sum += ip.getPixel(x, y+2);


				sum += ip.getPixel(x+1, y-2);
				sum += ip.getPixel(x+1, y-1);
				sum += ip.getPixel(x+1, y);
				sum += ip.getPixel(x+1, y+1);
				sum += ip.getPixel(x+1, y+2);


				sum += ip.getPixel(x+2, y-2);
				sum += ip.getPixel(x+2, y-1);
				sum += ip.getPixel(x+2, y);
				sum += ip.getPixel(x+2, y+1);
				sum += ip.getPixel(x+2, y+2);

				mean = sum/25;
				ip2.putPixel(x, y, mean);
			}
		}
		

		return((ByteProcessor) ip2);
	}




	public static ShortProcessor maskLapSob(ImageProcessor lap, ImageProcessor sob)
	 {
		int width = lap.getWidth();   //M
   		int height = lap.getHeight();   //N
		ImageProcessor ip2 = new ShortProcessor(width, height);
		
		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				ip2.putPixel(x, y, lap.getPixel(x, y) * sob.getPixel(x, y));
			}
		}

		return((ShortProcessor) ip2);
	}


	public static ByteProcessor sumImage(ImageProcessor original, ImageProcessor mask)
	{
		int width = original.getWidth();   //M
   		int height = original.getHeight();   //N
		ImageProcessor ip2 = new ByteProcessor(width, height);
		
		double temp = (mask.getMax()/255);
		int temp2;
		
		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				temp2 = (int) (mask.getPixel(x, y)/temp);
				ip2.putPixel(x, y, original.getPixel(x, y) + temp2);
			}
		}

		return((ByteProcessor) ip2);
	}

	public static ByteProcessor powerLawTransform(ImageProcessor ip, double gamma)
	{
		int width = ip.getWidth();   //M
   		int height = ip.getHeight();   //N
		ImageProcessor ip2 = new ByteProcessor(width, height);
		
		int temp;
		int max = 0;
		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				temp = (int) Math.pow(ip.getPixel(x,y), gamma);
				if (temp>max)
					max = temp;
				ip2.putPixel(x, y, temp);
			}
		}

		double scale = 255/max;
		double temp2;
		for (int y=0; y<height; y++)
		{
			for (int x=0; x<width; x++)
			{
				temp2 = (ip2.getPixel(x, y)*scale);
				ip2.putPixel(x, y, (int) temp2);
			}
		}
		
		return((ByteProcessor) ip2);
	}

}
