using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PenguinTo_Do.Pages
{
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        private async void ResetToDoList_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Do you really want to reset your To-Do List?",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "No",
                DefaultButton = ContentDialogButton.Primary
            };

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                await WebView.ClearTemporaryWebDataAsync();
            }
        }
    }
}
