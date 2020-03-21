using Heic2Jpg.Services.Implementations;
using Heic2Jpg.Services.Interfaces;
using SimpleInjector;

namespace Heic2Jpg.IoC
{
    public static class Registration
    {
        public static void Register(Container container)
        {
            container.Register<IDirectoryService, DirectoryService>();
            container.Register<IArgsValidationService, ArgsValidationService>();
            container.Register<IConversionService, ConversionService>();
        }
    }
}
