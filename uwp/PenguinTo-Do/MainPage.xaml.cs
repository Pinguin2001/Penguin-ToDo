using System;
using Windows.ApplicationModel.Core;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace PenguinTo_Do
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            // If device is desktop or runs windows core load custom title bar
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop" || AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Core") { TitleBarLoader(); }
            // Load Home
            contentFrame.Navigate(typeof(Pages.Home));
        }

        private void TitleBarLoader()
        {
            // Load Title bar
            this.FindName("AppTitleBar");
            // Extend view into titlebar
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            // Set colors
            titleBar.BackgroundColor = Colors.Transparent;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.InactiveBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }

        private void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            // Get invoked item
            object pageTag = args.InvokedItemContainer.Tag;
            // Navigate to selected page
            contentFrame.Navigate(Type.GetType($"PenguinTo_Do.Pages.{pageTag}"));
        }
    }
}