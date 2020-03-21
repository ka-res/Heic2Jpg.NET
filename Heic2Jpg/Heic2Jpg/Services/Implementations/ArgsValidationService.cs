using Heic2Jpg.Common;
using Heic2Jpg.Services.Interfaces;

namespace Heic2Jpg.Services.Implementations
{
    public class ArgsValidationService : IArgsValidationService
    {
        public void Validate(string[] args, out string directoryPath)
        {
            var isArgsCountValid = args.Length == 1;
            if (!isArgsCountValid)
            {
                throw new ValidationException();
            }

            directoryPath = args[0];
        }
    }
}
