using MathLogic;
using static ClassAliases.Aliases;
internal class Raytracer
{
    static readonly int imageHeight = 512;
    static readonly int imageWidth = 512;

    static readonly string filePath = "../raytracer/OutputImage";
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
                    Console.Error.Write($"\rScanlines remaining: {imageHeight - row} ");
                    Console.Error.Flush();
                    for (int column = 0; column < imageWidth; column++)
                    {
                        double red = (double)column / (imageWidth - 1);
                        double green = (double)row / (imageHeight - 1);
                        double blue = 0.0;

                        var pixelColor = Color(red, green, blue);
                        HandleColor.WriteColor(imageFile, pixelColor);
                    }
                }
                Console.Error.Write("\nFinished Rendering.");
                Console.Error.Flush();
            }
        }

        catch (Exception error)
        {
            Console.Error.WriteLine($"Error writing to file: {error.Message}");
            throw;
        }
    }
}