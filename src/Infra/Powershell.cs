using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace Infra
{
    public class Powershell
    {
        private PowerShell ps;
        public Powershell()
        {
            this.ps = System.Management.Automation.PowerShell.Create();
        }

        public Collection<PSObject> Execute(string command)
        {
            this.ps.AddScript(command);
            var ret = this.ps.Invoke();
            this.ps.Commands.Clear();
            return ret;
        }
    }
}
