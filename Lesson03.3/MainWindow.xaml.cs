using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson03._3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string file;
        public MainWindow()
        {
            InitializeComponent();
            GetLogicalDisks();
        }

        private void GetLogicalDisks()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            List<Disk> drives = new List<Disk>();
            foreach (var item in allDrives)
            {
                if (item.DriveType == DriveType.CDRom)
                {
                    continue;
                }
                drives.Add(new Disk { Name = item.Name });
            }
            lstLogicalDrivers.ItemsSource = drives;
        }

        class Disk
        {
            public string Name { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Disk item in lstLogicalDrivers.SelectedItems)
            {
                if (SearchFile(item.Name, searchFile.Text))
                {
                    output.Text = "Файл " + file + " найден!";
                }
            }
            
        }

        bool SearchFile(string directory, string fileName)
        {
            DirectoryInfo dr = new DirectoryInfo(directory);
            if(!dr.Exists)
            {
                return false;
            }

            FileInfo[] fileInfo = null;
            try
            {
                fileInfo = dr.GetFiles(fileName);
            }
            catch 
            {
                return false;
            }

            if (fileInfo.Length == 0)
            {
                DirectoryInfo[] dirInfo = dr.GetDirectories();
                if(dirInfo.Length == 0)
                {
                    return false;
                }

                foreach (var item in dirInfo)
                {
                    if (item.Attributes.Equals(FileAttributes.System | FileAttributes.Hidden | FileAttributes.Directory))
                    {
                        continue;
                    }
                    if (SearchFile(item.FullName, fileName))
                    {
                        return true;
                    }
                }
                return false;

            } else
            {
                file = fileInfo[0].FullName;
                return true;
            }
        }

        private void Look_Click(object sender, RoutedEventArgs e)
        {
            StreamReader reader = File.OpenText(file);

            output.Text = reader.ReadToEnd();
            reader.Close();
        }

        private void Squeeze_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archive (*.zip)|*.zip";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream source = new FileStream(file, FileMode.Open);
                FileStream destination = File.Create(saveFileDialog.FileName);

                GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);

                int theByte = source.ReadByte();
                while (theByte != -1)
                {
                    compressor.WriteByte((byte)theByte);
                    theByte = source.ReadByte();
                }
                compressor.Close();
            }
        }
    }
}
