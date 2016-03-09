using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Security;

namespace Infra
{
    public class Powershell
    {
        private PowerShell ps;
        private string ShellURI = "http://schemas.microsoft.com/powershell/Microsoft.PowerShell";
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
        public void CreateRemoteSession(string User, string Pass, string Host)
        {

            SecureString ssLoginPassword = new SecureString();
            foreach (char x in Pass)
                ssLoginPassword.AppendChar(x);
            PSCredential remoteMachineCredentials = new PSCredential(User, ssLoginPassword);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri("http://" + Host + ":5985/wsman"), this.ShellURI, remoteMachineCredentials);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Negotiate;

            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            runspace.Open();
            ps.Runspace = runspace;

        /*    string Command = "$username = \"" + User + "\";";
            Command += "$password = \"" + Pass + "\";";
            Command += "$secpass = New-Object -TypeName System.Security.SecureString;";
            Command += "$password.ToCharArray() | ForEach-Object {$secstr.AppendChar($_)};";
            Command += "$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $secpass;";
            Command += "$rsess = New-PSSession -ComputerName " + Host + " -Credential $cred";
            Command += "Enter-PSSession $rsess";
            this.Execute(Command);*/
        }
        public void CloseRemoteSession()
        {
            string Command = "exit";
            Command += "Get-PSSession | Remove-PSSession";
            this.Execute(Command);
        }
    }
}
