def getPictureFromFile(fileName):
    picturePath = getMediaPath(fileName)
    picture = makePicture(picturePath)
    return picture


def callFunctionOverRange(fileName,topLeft,bottomRight,function):
    picture = getPictureFromFile(fileName)
    for x in range(topLeft[0]+1, bottomRight[0]+1):
      for y in range(topLeft[1]+1, bottomRight[1]+1):
        pixel = getPixel(picture, x, y)
        pixel = function(pixel)

def grayScalePixel(pixel):
    red1 = getRed(pixel)
    green1 = getGreen(pixel)
    blue1 = getBlue(pixel)
    red2 = red1 * 0.299
    green2 = green1 * 0.587
    blue2 = blue1 * 0.114
    pixel = (int(red2), int(green2), int(blue2))