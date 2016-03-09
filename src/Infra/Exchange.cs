using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra
{
    
    public class Exchange : Role
    {
        private string PSURL;
        private Powershell ps;

        public Exchange()
        {
            this.ps = new Powershell();

        }
    }
}
