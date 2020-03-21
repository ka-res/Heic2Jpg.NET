using System.IO;

namespace Heic2Jpg.Common
{
    public static class Helpers
    {
        public static string ToOutputPath(this string path, bool isFile = false)
        {
            var outputPath = Path.Combine(path, Constants.OutputDirName);

            return outputPath;
        }

        public static string ToSourcePath(this string path)
        {
            var sourcePath = Path.GetDirectoryName(path);

            return sourcePath;
        }
    }
}
