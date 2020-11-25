using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace Lesson07._3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Assembly assembly = null;
        public ObservableCollection<BoolStringClass> TheList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            CreateCheckBoxList();
        }

        public void CreateCheckBoxList()
        {
            TheList = new ObservableCollection<BoolStringClass>();
            Array members = Enum.GetValues(typeof(MemberTypes));
            foreach (var item in members)
            {
                TheList.Add(new BoolStringClass { TheText = item.ToString(), IsSelected = false });
            }
            this.DataContext = this;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    assembly = Assembly.LoadFile(openFileDialog.FileName);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (assembly == null)
            {
                MainText.Text = "Файл не выбран";
                return;
            }
            MainText.Text = "";

            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                MainText.Text += $"Тип: {type} {Environment.NewLine} {Environment.NewLine}";
                object[] attributes = type.GetCustomAttributes(false);
                if (attributes.Length > 0 && (bool)checkBoxAtrType.IsChecked)
                {
                    MainText.Text += "Атрибуты типа";
                    foreach (var attr in attributes)
                    {
                        MainText.Text += attr + Environment.NewLine;
                    }
                }

                var members = type.GetMembers();
                if (members != null)
                {
                    for (int i = 0; i < TheList.Count; i++)
                    {
                        if (TheList[i].IsSelected)
                        {
                            object element = Enum.Parse(typeof(MemberTypes), TheList[i].TheText);
                            MemberTypes memberType = (MemberTypes)element;
                            foreach (var member in members)
                            {
                                if (member.MemberType == memberType)
                                {
                                    string methStr = member.MemberType.ToString().ToUpper() + " " + member.Name + "\n";
                                    MainText.Text += methStr + Environment.NewLine;
                                    object[] attributesMeth = member.GetCustomAttributes(false);
                                    if (attributesMeth.Length > 0 && (bool)checkBoxAtrMember.IsChecked)
                                    {
                                        MainText.Text += "Атрибуты метода: ";
                                        foreach (var attr in attributesMeth)
                                        {
                                            MainText.Text += attr + Environment.NewLine;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                MainText.Text += Environment.NewLine;
            }
        }

        public class BoolStringClass
        {
            public string TheText { get; set; }
            public bool IsSelected { get; set; }
        }
    }
}
