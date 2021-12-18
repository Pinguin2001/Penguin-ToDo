using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PenguinTo_Do.Pages
{
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            ToDoView.Navigate(new Uri("ms-appx-web:///Core/app.html"));
        }

        private void ToDoView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            ToDoView.Visibility = Visibility.Collapsed;
        }

        private void ToDoView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            ThemeLoader();
            ToDoView.Visibility = Visibility.Visible;
        }

        public async void ThemeLoader()
        {
            // get System Theme Mode
            bool LightMode = Application.Current.RequestedTheme == ApplicationTheme.Light;
            // apply Theme
            if (LightMode)
            {
                string functionString = "var link = document.createElement('link'); link.rel = 'stylesheet'; link.type = 'text/css';  link.href = 'ms-appx-web:///Themes/day.css'; document.getElementsByTagName('head')[0].appendChild(link); ";
                await ToDoView.InvokeScriptAsync("eval", new string[] { functionString });
            }
            else
            {
                string functionString = "var link = document.createElement('link'); link.rel = 'stylesheet'; link.type = 'text/css';  link.href = 'ms-appx-web:///Themes/night.css'; document.getElementsByTagName('head')[0].appendChild(link); ";
                await ToDoView.InvokeScriptAsync("eval", new string[] { functionString });
            }
        }
    }
}
