def adjustColor(pictureObject, color, amount):
  pixels = getPixels(pictureObject)
  if color == "green"
    for pixel in pixels:	
      greenValue = getGreen(pixel)
      pixel = setGreen(pixel, greenValue*amount)
  if color == "blue"
    for pixel in pixels:	
      blueValue = getBlue(pixel)
      pixel = setBlue(pixel, blueValue*amount)
  if color == "red"
  for pixel in pixels:	
      redValue = getRed(pixel)
      pixel = setRed(pixel, redValue*amount)
  return pictureObject
