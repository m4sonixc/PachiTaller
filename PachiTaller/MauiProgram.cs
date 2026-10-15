using Microsoft.Extensions.Logging;

namespace PachiTaller
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Registrar el servicio Singleton de la Base de Datos SQLite
            builder.Services.AddSingleton<DatabaseService>();

            // Registrar las páginas
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegistroPage>();

            return builder.Build();
        }
    }
}