namespace OrderEntry.ViewModel;

public class ProductScanViewModel : BaseViewModel
{
    public ProductScanViewModel()
    {
        Title = AppResources.TitleProductScanPage;
    }

    public Task OnBarcodeScanned(string barcode)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Barcode",  barcode}
        };
        return MainThread.IsMainThread? Shell.Current.GoToAsync("..", navigationParameter):MainThread.InvokeOnMainThreadAsync(()=> Shell.Current.GoToAsync("..", navigationParameter));
    }
}

