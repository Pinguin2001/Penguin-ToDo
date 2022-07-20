using Microsoft.Toolkit.Uwp.UI.Helpers;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace PenguinTo_Do.Pages
{
    public sealed partial class Home : Page
    {
        private bool LightMode = Application.Current.RequestedTheme == ApplicationTheme.Light;
        public Home()
        {
            InitializeComponent();
            var Listener = new ThemeListener();
            Listener.ThemeChanged += Listener_ThemeChanged;
            ToDoList.Navigate(new Uri("ms-appx-web:///ToDoList.UI/ToDoList.UI.html"));
        }

        private void ToDoView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            ThemeLoader();
        }

        private async void ThemeLoader()
        {
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
            if ((int)e.Key == 13)
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
            InputBox.Text = "";
        }

        private async void Listener_ThemeChanged(ThemeListener sender)
        {
            var theme = sender.CurrentTheme;
            if (theme == ApplicationTheme.Light)
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
    }
}