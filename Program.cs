using System;
using System.IO;
internal class Program
{
    static readonly int imageHeight = 512;
    static readonly int imageWidth = 512;

    static readonly string filePath = "../raytracer/obj/";
    private static void Main()
    {
        WriteToFile("RaytracedImageOutput.ppm");
    }

    static private void WriteToFile(string fileName)
    {
        try
        {
            using (StreamWriter imageFile = new($"{filePath}/{fileName}"))
            {
                // PPM image header
                imageFile.WriteLine("P3");
                imageFile.WriteLine($"{imageWidth} {imageHeight}");
                imageFile.WriteLine("255");

                // for pixel color values
                for (int row = 0; row < imageHeight; row++)
                {
                    for (int column = 0; column < imageWidth; column++)
                    {
                        double red = (double)column / (imageWidth - 1);
                        double green = (double)row / (imageHeight - 1);
                        double blue = 0.0;

                        int intRed = (int)(255.999 * red);
                        int intGreen = (int)(255.999 * green);
                        int intBlue = (int)(255.999 * blue);

                        imageFile.WriteLine($"{intRed} {intGreen} {intBlue}");
                    }
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}