using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

namespace Lesson06._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Assembly assembly = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    string path = openFileDialog.FileName;
                    assembly = Assembly.LoadFile(path);
                    MainText.Text += "СБОРКА    " + path + "  -  УСПЕШНО ЗАГРУЖЕНА" + Environment.NewLine + Environment.NewLine;
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MainText.Text += "СПИСОК ВСЕХ ТИПОВ В СБОРКЕ:     " + assembly.FullName + Environment.NewLine + Environment.NewLine;

            Type[] types = assembly.GetTypes();

            foreach (var type in types)
            {
                MainText.Text += "Type: " + type + Environment.NewLine;
                MethodInfo[] methodInfos = type.GetMethods();
                if(methodInfos != null)
                {
                    foreach (var method in methodInfos)
                    {
                        string methStr = "Method:" + method.Name + Environment.NewLine;
                        var methodBody = method.GetMethodBody();
                        if (methodBody != null)
                        {
                            var byteArray = methodBody.GetILAsByteArray();
                            foreach (var b in byteArray)
                            {
                                methStr += b + ":";
                            }
                        }
                        MainText.Text += methStr + Environment.NewLine;
                    }
                }
            }
        }
    }
}
