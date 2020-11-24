using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson07._1
{
    enum AccessLevelControl
    {
        FullControl, MediumControl, LowControl
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class AccessLevelAttribute : Attribute
    {
        private readonly AccessLevelControl accessLevelControl;
        public AccessLevelAttribute(AccessLevelControl accessLevelControl)
        {
            this.accessLevelControl = accessLevelControl;
        }
        public AccessLevelControl AccessLevel { get { return accessLevelControl; } }
    }
}
