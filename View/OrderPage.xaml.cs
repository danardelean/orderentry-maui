namespace OrderEntry.View;

public partial class OrderPage : ContentPage
{
	OrderViewModel _vm;

    public OrderPage(OrderViewModel vm)
	{
		BindingContext = _vm = vm;
		InitializeComponent();
	}
}
