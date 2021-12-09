using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace UiThreading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MyButton_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Run(async () =>
            {
                Debug.WriteLine($"On thread {Thread.CurrentThread.ManagedThreadId}");
                var webClient = new HttpClient();
                var html = await webClient.GetStringAsync("http://angelsix.com");
            });
            Debug.WriteLine($"On thread {Thread.CurrentThread.ManagedThreadId}");
            MyButton.Content = "Logged in";
        }
    }
}