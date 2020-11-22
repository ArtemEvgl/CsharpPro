using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Lesson05._4
{
    class SettingRegistory : ISetting
    {
        public Brush BackColor { get; set; }

        public Brush TextColor { get; set; }

        public int TextSize { get; set; }

        public FontFamily TextFont { get; set; }

        RegistryKey myKey;

        public SettingRegistory()
        {
            myKey = Registry.CurrentUser;
            myKey = myKey.OpenSubKey("Software", true);
            string[] keyNameArray = myKey.GetSubKeyNames();
            string key = keyNameArray.FirstOrDefault(x => x == "MyAppSettings");
            if (key == null)
            {
                RegistryKey newKey = myKey.CreateSubKey("MyAppSettings");
                myKey.SetValue("BackColor", "");
                myKey.SetValue("TextColor", "");
                myKey.SetValue("TextSize", "");
                myKey.SetValue("TextFont", "");
            }
            myKey = myKey.OpenSubKey(key, true);
            ReadFromRegistary();

        }

        private void ReadFromRegistary()
        {
            var bc = new BrushConverter();
            string messageException = string.Empty;
            try
            {
                BackColor = (Brush)bc.ConvertFromString(myKey.GetValue("BackColor").ToString());
            } catch (Exception e)
            {
                BackColor = (Brush)bc.ConvertFromString(Colors.AliceBlue.ToString());
                messageException += "Цвет фона задан не верно: " + myKey.GetValue("BackColor") + Environment.NewLine;
            }
            try
            {
                TextColor = (Brush)bc.ConvertFromString(myKey.GetValue("TextColor").ToString());
            }
            catch (Exception)
            {
                TextColor = (Brush)bc.ConvertFromString(Colors.Black.ToString());
                messageException += "Цвет текста задан не верно: " + myKey.GetValue("TextColor") + Environment.NewLine;
            }

            try
            {
                TextSize = Convert.ToInt32(myKey.GetValue("TextSize"));
            }
            catch (Exception)
            {
                TextSize = 12;
                messageException += "Размер текста задан не верно: " + myKey.GetValue("TextSize") + Environment.NewLine;
            }

            try
            {
                TextFont = new FontFamily(myKey.GetValue("TextFont").ToString());
            }
            catch (Exception)
            {
                TextFont = new FontFamily("Segoe UI");
            }

            if (!string.IsNullOrEmpty(messageException))
            {
                MessageBox.Show(messageException);
            }
        }
        public void SaveSettings()
        {
            myKey.SetValue("BackColor", BackColor);
            myKey.SetValue("TextColor", TextColor);
            myKey.SetValue("TextSize", TextSize);
            myKey.SetValue("TextFont", TextFont);
        }
    }
}
