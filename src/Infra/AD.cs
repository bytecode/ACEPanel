using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class AD : Role
    {
        private Powershell ps;
        private string RootOU;
        private string RootOUPath;
        private string Domain;
        private string DomainPath;
        private string Organization;
        private string OrganizationPath;
        public AD(Powershell ps)
        {
            this.ps = ps;
            // import AD Module
            this.ps.Execute("Import-Module ActiveDirectory");
        }
        public void GetDomain()
        {
            string Command = "Get-ADDomain";
            var ret = ps.Execute(Command);
            this.DomainPath = ret[0].Members["DistinguishedName"].Value.ToString();
            var d = "";

        }
        public void CreateOrgranization(string Name, Dictionary<string, string> Properties)
        {
            string Command = "New-ADOrganizationalUnit " + Name;
            Command += this.PropertiesToParam(Properties);
            this.ps.Execute(Command);
        }
        public void CreateUser(string Name, Dictionary<string, string> Properties)
        {
            string Command = "New-AdUser " + Name;
            Command += this.PropertiesToParam(Properties);
            this.ps.Execute(Command);

        }

        public void UpdateUser()
        {

        }
        public void DeleteUser()
        {

        }
        private string PropertiesToParam(Dictionary<string, string> Properties)
        {
            string Command = "";
            foreach (var item in Properties)
            {
                Command += " -" + item.Key + " " + item.Value;
            }
            return Command;
        }
    }
}
