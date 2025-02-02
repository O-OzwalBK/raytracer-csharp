using System;
using System.IO;

class Program
{
    readonly int imageHeight = 512;
    readonly int imageWidth = 512;

    static readonly string filePath = "../raytracer/obj/";
    static private void Main()
    {
        Program program = new();
        program.WriteToFile("RaytracedImageOutput.ppm");
    }

    private void WriteToFile(string fileName)
    {
        using (StreamWriter imageFile = new($"{filePath}/{fileName}"))
        {
            imageFile.WriteLine($"P3\n{imageWidth} {imageHeight}\n255");
        }
    }
}