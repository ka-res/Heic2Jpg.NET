using System.IO;
using Heic2Jpg.Common;
using Heic2Jpg.Services.Interfaces;

namespace Heic2Jpg.Services.Implementations
{
    public class DirectoryService : IDirectoryService
    {
        public void PrepareOutputDirectory(string directoryPath, out string outputDirectoryPath)
        {
            outputDirectoryPath = directoryPath.ToOutputPath();
            var directoryInfo = new DirectoryInfo(outputDirectoryPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }

        public string[] GetHeicFiles(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);
            if (!directoryInfo.Exists)
            {
                return null;
            }

            var heicFiles = Directory.GetFiles(directoryPath, $"*.{FileType.Heic.ToString()}", SearchOption.AllDirectories);

            return heicFiles;
        }
    }
}
