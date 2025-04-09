using MathLogic;

public static class HandleColor
{
    public static void WriteColor(StreamWriter outStream, Vector3 pixelColor)
    {
        double red = pixelColor[0];
        double green = pixelColor[1];
        double blue = pixelColor[2];

        int redValue = (int)(255.999 * red);
        int greenValue = (int)(255.999 * green);
        int blueValue = (int)(255.999 * blue);

        outStream.WriteLine($"{redValue} {greenValue} {blueValue}");
    }
}