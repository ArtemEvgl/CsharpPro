using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16service
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            this.Installers.Add(new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            });
            this.Installers.Add(new ServiceInstaller
            {
                ServiceName = "===== Deleted Files Logger =====",
                StartType = ServiceStartMode.Automatic
            });
        }
    }
}
