namespace OrderEntry.View;

public static class ViewExtension
{
    public static void RegisterViews(this IServiceCollection services)
    {
        services.AddTransient<OrderPage>();
        services.AddTransient<ScanPage>();

    }
}

