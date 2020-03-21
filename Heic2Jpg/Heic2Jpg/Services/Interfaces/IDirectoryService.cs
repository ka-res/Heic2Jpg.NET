namespace Heic2Jpg.Services.Interfaces
{
    public interface IDirectoryService
    {
        void PrepareOutputDirectory(string directoryPath, out string outputDirectoryName);
        string[] GetHeicFiles(string directoryPath);
    }
}
