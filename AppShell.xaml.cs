namespace OrderEntry;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("Scan", typeof(ScanPage));
	}
}

