using System;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Lesson16._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceController controller;
        static readonly string filePath = @"D:\deletedFiles.txt";
        static readonly string servicePath = @"D:\Lesson16service.exe";
        static readonly string serviceName = "===== Deleted Files Logger =====";
        Timer timer;

        public MainWindow()
        {
            InitializeComponent();
            controller = new ServiceController { ServiceName = serviceName };
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += TimerTick;
            timer.Start();
        }

        private async void TimerTick(object sender, EventArgs e)
        {
            try
            {
                TextBox.Text = await ReadFileAsync();
                TextBox.ScrollToEnd();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                timer.Stop();
            }
        }

        private async void Install_Click(object sender, RoutedEventArgs e)
        {
            Install.IsEnabled = false;
            await Task.Factory.StartNew(InstallService);
            Uninstall.IsEnabled = true;
            Start.IsEnabled = true;
        }

        private void InstallService()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new[] { servicePath });
                System.Windows.MessageBox.Show("Service installed");
            } catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private async Task<string> ReadFileAsync()
        {
            using (var stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Write))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    string str = await streamReader.ReadToEndAsync();
                    return str;
                }
            }
        }

        private async void Uninstall_Click(object sender, RoutedEventArgs e)
        {
            Uninstall.IsEnabled = false;
            Start.IsEnabled = false;

            await Task.Run(UninstallSerive);
            Install.IsEnabled = true;
        }

        private void UninstallSerive()
        {
            if (!IsServiceInstalled(serviceName))
            {
                return;
            }
            try
            {
                ManagedInstallerClass.InstallHelper(new[] { @"/u", servicePath });
                System.Windows.MessageBox.Show("Service uninstalled");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.Start();
                System.Windows.MessageBox.Show("Service started");
                Start.IsEnabled = false;
                Stop.IsEnabled = true;
            } catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.Stop();
                System.Windows.MessageBox.Show("Service stopped");
                Stop.IsEnabled = true;
                Start.IsEnabled = true;
                Uninstall.IsEnabled = true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private bool IsServiceInstalled(string serviceName)
        {
            var controller = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == serviceName);
            return controller != null;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (timer.Enabled) timer.Stop();
            UninstallSerive();
        }
    }
}
