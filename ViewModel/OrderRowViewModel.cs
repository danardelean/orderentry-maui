using System;
namespace OrderEntry.ViewModel
{
	public partial class OrderRowViewModel : ObservableObject
    {
        [ObservableProperty]
        private Product product;

        [ObservableProperty]
        private int qty;
    }
}

