using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

[SupportedOSPlatform("windows")]
public class PpmConverter
{
    public static void ConvertPpmToPng(string inputImagePath, string outputImagePath)
    {
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
                int imageWidth = int.Parse(colorValue[0]);
                int imageHeight = int.Parse(colorValue[1]);
                string? maxColor = ppmImage.ReadLine();
                if (!string.IsNullOrWhiteSpace(maxColor))
                {
                    int maxColorValue = int.Parse(maxColor);

                    Console.WriteLine($"Image width: {imageWidth} \n Image Height: {imageHeight}");
                    Console.WriteLine($"Max color value is: {maxColorValue}");

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        Bitmap bitmappedImage = new(imageWidth, imageHeight);

                        for (int y = 0; y < imageHeight; y++)
                        {
                            for (int x = 0; x < imageWidth; x++)
                            {
                                int red = int.Parse(ppmImage.ReadLine() ?? "0");
                                int green = int.Parse(ppmImage.ReadLine() ?? "0");
                                int blue = int.Parse(ppmImage.ReadLine() ?? "0");

                                bitmappedImage.SetPixel(x, y, Color.FromArgb(red, green, blue));
                            }
                        }
                        bitmappedImage.Save(outputImagePath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        Console.WriteLine("Not supported in this OS.");
                        return;
                    }
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
}
