namespace OrderEntry.Services;

public static class ServicesExtension
{
	public static void RegisterServices(this IServiceCollection services)
	{
        services.AddSingleton<IProductRepository, MockProductRepository>();
        services.AddSingleton<IDialogService, DialogService>();
    }
}

