using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra
{
    public class Server
    {
        public Dictionary<string, Role> Roles = new Dictionary<string, Role>();
        public string User;
        public string Password;
        public string Computer;
        private Powershell ps;
        public Server()
        {

        }
        public void Connect()
        {
            this.ps = new Powershell();
        }
    }
}
