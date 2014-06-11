def adjustRed(pictureObject, amount):
  pixels = getPixels(pictureObject)
  for pixel in pixels:	
    redValue = getRed(pixel)
    pixel = setRed(pixel, redValue*amount)
    
def adjustGreen(pictureObject, amount):
  pixels = getPixels(pictureObject)
  for pixel in pixels:	
    greenValue = getGreen(pixel)
    pixel = setGreen(pixel, greenValue*amount)

def adjustBlue(pictureObject, amount):
  pixels = getPixels(pictureObject)
  for pixel in pixels:	
    blueValue = getBlue(pixel)
    pixel = setBlue(pixel, blueValue*amount)