namespace OrderEntry.ViewModel;


public partial class OrderViewModel:BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    private ObservableCollection<OrderRowViewModel> _orderRows;

    IProductRepository _productRepository;
    IDialogService _dialogService;

    public OrderViewModel(IProductRepository productRepository,IDialogService dialogService)
	{
        _productRepository = productRepository;
        _dialogService = dialogService;
        _orderRows = new ObservableCollection<OrderRowViewModel>();

        Title = AppResources.TitleOrderPage;

        

    }

    [RelayCommand(AllowConcurrentExecutions =false,  IncludeCancelCommand = true)]
    private async Task NavigateToScanPageAsync(CancellationToken cancelToken)
    {
#if IOS || ANDROID
        bool allowed = false;
        allowed = await BarcodeScanner.Mobile.Maui.Methods.AskForRequiredPermission();
        if (!allowed)
            return;
#endif
        // Code to save the user details
        await Shell.Current.GoToAsync("/Scan");
    }

    [RelayCommand]
    private void IncrementProduct(OrderRowViewModel product)
    {
        product.Qty++;
    }

    [RelayCommand]
    private void DecrementProduct(OrderRowViewModel product)
    {
        product.Qty--;
        if (product.Qty <= 0)
            OrderRows.Remove(product);
    }

    [RelayCommand]
    private void DeleteProduct(OrderRowViewModel product)
    {
        OrderRows.Remove(product);
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
       if (query.ContainsKey("Barcode"))
        {
            var barcode = (string)query["Barcode"];
            query.Remove("Barcode");
            await AddProductWithBarcodeAsync(barcode);
        }
    }

    async Task AddProductWithBarcodeAsync(string barcode)
    {
        IsBusy = true;
        var orderRow = _orderRows.Where(r => r.Product.Barcode == barcode).FirstOrDefault();
        if (orderRow != null)
            orderRow.Qty++;
        else
        {
            var product = await _productRepository.GetProductAsync(barcode);
            if (product != null)
                OrderRows.Add(new OrderRowViewModel { Product = product, Qty = 1 });
            else
                OrderRows.Add(new OrderRowViewModel
                {
                    Product = new Product
                    {
                        Barcode = barcode,
                        Id=int.MaxValue,
                        Description=AppResources.UnknownProduct
                    },
                    Qty=1
                }) ;
            //{
            //    _dialogService.ShowMessageBox(AppResources.TitleError, string.Format(AppResources.ProductNotFound, barcode), AppResources.ButtonOk);
            //}
        }
        IsBusy = false;
    }

#if DEBUG
    async Task SimulateScanAsync()
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await AddProductWithBarcodeAsync("0WXCBU");
            await AddProductWithBarcodeAsync("0WXCBU");
            await AddProductWithBarcodeAsync("0WXCBU");
            await AddProductWithBarcodeAsync("0WXCBU");
            await AddProductWithBarcodeAsync("8022966312005");
            await AddProductWithBarcodeAsync("8022966312005");
            await AddProductWithBarcodeAsync("8022966312005");
        });
    }
#endif
}

