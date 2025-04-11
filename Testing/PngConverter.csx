using System.Drawing;
using System.Linq.Expressions;

#nullable enable

ConvertPpmToPng("../OutputImage/RaytracedImageOutput.ppm", "");
static void ConvertPpmToPng(string inputImagePath, string outputImagePath)
{
    if (string.IsNullOrWhiteSpace(inputImagePath))
    {
        Console.WriteLine("File path is not provided or is empty.");
        return;
    }

    try
    {
        using (StreamReader ppmImage = new(inputImagePath))
        {
            string? imageFormat = ppmImage.ReadLine();
            if (imageFormat == null)
            {
                throw new InvalidDataException("PPM header is missing.");
            }
            if (imageFormat != "P3")
                throw new Exception("Only PPM image format is supported.");

            Console.WriteLine("Image format is: PPM");

            string? imageResolution = ppmImage.ReadLine();
            if (string.IsNullOrWhiteSpace(imageResolution))
            {
                throw new InvalidDataException("PPM file is missing image size information.");
            }

            string[] colorValue = imageResolution.Split();
            Console.WriteLine($"Image width: {colorValue[0]}\nImage height: {colorValue[1]}");

            string? maxColor = ppmImage.ReadLine();
            if (!string.IsNullOrWhiteSpace(maxColor))
            {
                int maxColorValue = int.Parse(maxColor);

                Console.WriteLine($"Max color value is: {maxColorValue}");

            }

        }
    }
    catch (DirectoryNotFoundException noDirectory)
    {
        Console.WriteLine($"Directory not found. {noDirectory.Message}");
    }
    catch (FileNotFoundException noFile)
    {
        Console.WriteLine($"File not found. {noFile.Message}");
    }
    catch (IOException noIO)
    {
        Console.WriteLine($"Error while reading or writing the file. {noIO.Message}");
    }
    catch (Exception error)
    {
        Console.WriteLine($"Unknown error occurred. {error.Message}");
    }

}
