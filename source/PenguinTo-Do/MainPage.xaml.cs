using System;
using Windows.ApplicationModel.Core;
using Windows.System.Profile;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace PenguinTo_Do
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //If acrylic brush is present apply acrylic to background
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.AcrylicBrush"))
            {
                rootGrid.Background = Windows.UI.Xaml.Application.Current.Resources["AcrylicBackgroundFillColorDefaultBrush"] as AcrylicBrush;
            }
            //If device is desktop load custom title bar
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop")
            {
                TitleBarLoader();
            }
            else
            {
                AppTitleBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                
            }
            //Load Home Page
            contentFrame.Navigate(typeof(Pages.Home));
        }

        private void TitleBarLoader()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonHoverBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonPressedBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.InactiveBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;
        }
        private void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                contentFrame.Navigate(typeof(Pages.Settings));
            }
            else
            {
                object pageTag = args.InvokedItemContainer.Tag;
                contentFrame.Navigate(Type.GetType($"PenguinTo_Do.Pages.{pageTag}"));
            }
        }
    }
}