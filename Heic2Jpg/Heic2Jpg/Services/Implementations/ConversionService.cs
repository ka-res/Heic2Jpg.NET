using System;
using System.IO;
using Heic2Jpg.Common;
using Heic2Jpg.Services.Interfaces;
using ImageMagick;

namespace Heic2Jpg.Services.Implementations
{
    public class ConversionService : IConversionService
    {
        public void ConvertToJpg(string[] heicFilePaths, string outputPath)
        {
            var filesCount = heicFilePaths.Length;
            var sourcePath = outputPath.ToSourcePath();
            for (var i = 1; i <= heicFilePaths.Length; i++)
            {
                var filePath = heicFilePaths[i - 1];
                Console.WriteLine($"\t* Processing file {i} of {filesCount} ({filePath})");

                try
                {
                    PerformConversionCore(filePath, sourcePath, outputPath);
                }
                catch (ConversionException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\t* Error while processing file {i} of {filesCount} ({filePath})");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    continue;
                }

                Console.WriteLine($"\t* Finished processing of file {i} of {filesCount} ({filePath})");
                Console.WriteLine();
            }
        }

        private static void PerformConversionCore(string filePath, string sourcePath, string outputPath)
        {
            // ReSharper disable once ConvertToUsingDeclaration
            using (var image = new MagickImage(filePath))
            {
                var jpgExtension = FileType.Jpg.ToString().ToLower();
                var newFile = filePath.Replace(Path.GetExtension(filePath), $".{jpgExtension}");
                var outputRedirectedFilePath = newFile.Replace(sourcePath, outputPath);
                image.Write(outputRedirectedFilePath);
            }
        }
    }
}
