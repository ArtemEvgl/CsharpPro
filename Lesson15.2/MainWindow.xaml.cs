using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;


namespace Lesson15._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += timer_Tick;
        }

        async void timer_Tick(object sender, EventArgs e)
        {
            TextBox.Text += await GetDataAsync();
            TextBox.ScrollToEnd();
        }

        private Task<string> GetDataAsync()
        {
            return Task.Run(() => { return "data received" + Environment.NewLine; });
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            ConnectButton.IsEnabled = false;
            TextBox.Text += await ConnectDbAsync();
            DisconnectButton.IsEnabled = true;
        }

        private Task<string> ConnectDbAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "Connected" + Environment.NewLine;
            });
        }

        private async void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            DisconnectButton.IsEnabled = false;
            TextBox.Text += await DisconnectDbAsync();
            ConnectButton.IsEnabled = true;
        }

        private async Task<string> DisconnectDbAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                return "Disconnected" + Environment.NewLine;
            });
        }
    }
}
