namespace Heic2Jpg.Services.Interfaces
{
    public interface IConversionService
    {
        void ConvertToJpg(string[] heicFilePaths, string outputPath);
    }
}
