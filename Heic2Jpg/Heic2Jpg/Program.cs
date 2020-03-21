using System;
using System.Reflection;
using Heic2Jpg.Common;
using Heic2Jpg.Services.Interfaces;
using SimpleInjector;
using Registration = Heic2Jpg.IoC.Registration;

namespace Heic2Jpg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new Container();
            Registration.Register(container);

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Heic2Jpg Converter v.{version} by ka_res");
            Console.WriteLine("======================================");
            Console.WriteLine();

            var argsValidationService = container.GetInstance<IArgsValidationService>();
            var directoryService = container.GetInstance<IDirectoryService>();
            var conversionService = container.GetInstance<IConversionService>();

            string directoryPath;
            try
            {
                argsValidationService.Validate(args, out directoryPath);
            }
            catch (ValidationException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Args invalid!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("> Press any button to leave");
                Console.ReadKey();
                return;
            }

            directoryService.PrepareOutputDirectory(directoryPath, out var outputDirectoryPath);
            Console.WriteLine("> Output directory prepared");
            
            Console.WriteLine($"> Determined path is: {directoryPath}");
            var heicFilePaths = directoryService.GetHeicFiles(directoryPath);

            Console.WriteLine($"> Found {heicFilePaths.Length} file(s)");

            conversionService.ConvertToJpg(heicFilePaths, outputDirectoryPath);

            Console.WriteLine("> Processing finished");
            Console.WriteLine("> Press any button to leave");
            Console.ReadKey();
        }
    }
}
