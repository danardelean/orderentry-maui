using System;
namespace OrderEntry.Services
{
    public class DialogService : IDialogService
    {
        public void ShowMessageBox(string title, string message, string cancel)
        {
            Shell.Current.CurrentPage.DisplayAlert(title, message, cancel);
        }
    }
}

