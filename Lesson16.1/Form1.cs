using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson16._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, MouseEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.SafeFileName;
            }
        }

        private void ExecuteClick(object sender, EventArgs e)
        {
            var adSetup = new AppDomainSetup { ApplicationBase = Path.GetFullPath(Application.ExecutablePath) };

            // Настраиваем права для  AppDomain. Даем разрешение на выполнение кода.
            // Список прав : http://msdn.microsoft.com/ru-ru/library/24ed02w7.aspx
            var permSet = new PermissionSet(PermissionState.None);
            permSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            permSet.AddPermission(new FileIOPermission(FileIOPermissionAccess.AllAccess, "d:\\"));
            permSet.AddPermission(new UIPermission(UIPermissionWindow.AllWindows, UIPermissionClipboard.AllClipboard));

            var fullTrustAssembly = typeof(Form1).Assembly.Evidence.GetHostEvidence<StrongName>();

            var newDomain = AppDomain.CreateDomain("Sandbox", null, adSetup, permSet, fullTrustAssembly);

            newDomain.ExecuteAssembly(openFileDialog1.FileName);
        }
    }
}
