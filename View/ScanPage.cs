namespace OrderEntry.View;

public partial class ScanPage : ContentPage
{
#if ANDROID || IOS
    BarcodeScanner.Mobile.Maui.CameraView scanner;
#else
    CameraBarcodeReaderView scanner;
#endif
    ProductScanViewModel _vm;

    public ScanPage(ProductScanViewModel vm)
    {
        BindingContext = _vm = vm;
#if ANDROID || IOS
        scanner = new BarcodeScanner.Mobile.Maui.CameraView
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            TorchOn = false,
            VibrationOnDetected = false,
            IsScanning = true
        };
        scanner.OnDetected += Scanner_OnDetected;
#else
        scanner = new CameraBarcodeReaderView();
        scanner.BarcodesDetected += Scanner_BarcodesDetected;

        scanner.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true,
        };
        scanner.IsDetecting = true;
        scanner.AutoFocus();
#endif
        Content = scanner;
    }


#if ANDROID || IOS
    private void Scanner_OnDetected(object sender, BarcodeScanner.Mobile.Core.OnDetectedEventArg e)
    {
        scanner.IsScanning = false;
        List<BarcodeResult> obj = e.BarcodeResults;
        if (obj.Count > 0)
            _vm.OnBarcodeScanned(obj[0].RawValue);
    }
#else
    private async void Scanner_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        scanner.IsDetecting = false;
        if (e.Results != null && e.Results.Length > 0)
            await _vm.OnBarcodeScanned(e.Results[0].Value);
    }
#endif
}
