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
                if (imageFormat == null || imageFormat != "P3")
                {
                    throw new InvalidDataException("PPM header is missing.");
                }

                Console.WriteLine("Image format is: PPM");

                string[] imageResolution = ppmImage.ReadLine().Split();
                if (imageResolution.Length == 2)
                {
                    int imageWidth = int.Parse(imageResolution[0]);
                    int imageHeight = int.Parse(imageResolution[1]);
                    int numberOfLines = imageWidth * imageHeight;

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
                                    string[] pixelColor = new string[3];
                                    pixelColor = ppmImage.ReadLine().Split();
                                    int red = int.Parse(pixelColor[0]);
                                    int green = int.Parse(pixelColor[1]);
                                    int blue = int.Parse(pixelColor[2]);

                                    bitmappedImage.SetPixel(x, y, System.Drawing.Color.FromArgb(red, green, blue));
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
                else
                {
                    throw new InvalidDataException("PPM file is missing image size information.");

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
