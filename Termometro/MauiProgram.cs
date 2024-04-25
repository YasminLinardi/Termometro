using Microsoft.Extensions.Logging;


namespace Termometro;

public static class MauiProgram
{

    public static MauiApp CreateMauiApp()
    {
    var builder = MauiApp.CreateBuilder();
    builder
         .UseMauiApp<App>()
         .ConfigureFonts(fonts =>
         {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpensSans-Semibold.ttf", "OpenSansSemibold");
         });

#if DEBUG
    builder.Logging.AddDebug();
#endif
   
    return builder.Build();
    }
}