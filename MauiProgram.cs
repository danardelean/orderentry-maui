namespace OrderEntry;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont(filename: "materialdesignicons-webfont.ttf", alias: "MaterialDesignIcons");
            })
            ;

#if IOS || ANDROID
        builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddBarcodeScannerHandler();
            });
#else
			builder.UseBarcodeReader();
#endif

        builder.Services.RegisterServices();
        builder.Services.RegisterViews();
        builder.Services.RegisterViewModels();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

