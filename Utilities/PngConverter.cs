using System.Drawing;
using System.Linq.Expressions;

class PpmConverter
{
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
