using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lesson05._4
{
    interface ISetting
    {
        Brush BackColor { get; set; }

        Brush TextColor { get; set; }

        int TextSize { get; set; }

        FontFamily TextFont { get; set; }

        void SaveSettings();
    }
}
