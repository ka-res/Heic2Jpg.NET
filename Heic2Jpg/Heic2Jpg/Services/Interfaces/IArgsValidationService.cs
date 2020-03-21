namespace Heic2Jpg.Services.Interfaces
{
    public interface IArgsValidationService
    {
        void Validate(string[] args, out string directoryPath);
    }
}
