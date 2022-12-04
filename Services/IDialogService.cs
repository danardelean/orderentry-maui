using System;
namespace OrderEntry.Services
{
	public interface IDialogService
	{
		void ShowMessageBox(string title, string message, string cancel);
	}
}

