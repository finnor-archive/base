def removeRed(pictureObject):
  pixels = getPixels(pictureObject)
  for pixel in pixels:
    pixel = setRed(pixel, 0)
  return pictureObject

def removeBlue(pictureObject):
  pixels = getPixels(pictureObject)
  for pixel in pixels:
    pixel = setBlue(pixel, 0)
  return pictureObject

def removeGreen(pictureObject):
  pixels = getPixels(pictureObject)
  for pixel in pixels:
    pixel = setGreen(pixel, 0)
  return pictureObject

