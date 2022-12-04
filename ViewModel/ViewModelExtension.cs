namespace OrderEntry.ViewModel;

public static class ViewModelExtension
{
    public static void RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<OrderViewModel>();
        services.AddTransient<ProductScanViewModel>();
    }
}

