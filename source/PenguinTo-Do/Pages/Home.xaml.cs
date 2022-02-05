using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace PenguinTo_Do.Pages
{
    public sealed partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            ToDoList.Navigate(new Uri("ms-appx-web:///ToDoList.UI/ToDoList.UI.html"));
        }

        private void ToDoView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            ToDoList.Visibility = Visibility.Collapsed;
        }

        private void ToDoView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            ThemeLoader();
            ToDoList.Visibility = Visibility.Visible;
            InputBox.Text = "";
        }

        private async void ThemeLoader()
        {
            // get System Theme Mode
            bool LightMode = Application.Current.RequestedTheme == ApplicationTheme.Light;
            // apply Theme
            if (LightMode)
            {
                string functionString = "var link = document.createElement('link'); link.rel = 'stylesheet'; link.type = 'text/css';  link.href = 'ms-appx-web:///ToDoList.UI/Themes/day.css'; document.getElementsByTagName('head')[0].appendChild(link); ";
                await ToDoList.InvokeScriptAsync("eval", new string[] { functionString });
            }
            else
            {
                string functionString = "var link = document.createElement('link'); link.rel = 'stylesheet'; link.type = 'text/css';  link.href = 'ms-appx-web:///ToDoList.UI/Themes/night.css'; document.getElementsByTagName('head')[0].appendChild(link); ";
                await ToDoList.InvokeScriptAsync("eval", new string[] { functionString });
            }
        }

        private void InputBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                AddTask();
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTask();
        }

        private void AddTask()
        {
            ToDoList.Navigate(new Uri("ms-appx-web:///ToDoList.UI/ToDoList.UI.html?inputBoxValue=" + InputBox.Text));
        }
    }
}