using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra;
namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> par = new Dictionary<string, string>();
            par.Add("UserPrincipalName", "Nigga@freshdelmonte.com");
            
            //ad.GetDomain();
            var ps = new Powershell();
            ps.CreateRemoteSession("TESTAD0\\Administrator", "Games4Free", "10.80.1.85");
            var ad = new AD(ps);
         //   ad.CreateOrgranization("Nigga" , new Dictionary<string, string>());
            var ret = ps.Execute("Get-ADDomain");
            
           /* ps.CloseRemoteSession();
            var ret1 = ps.Execute("Get-ADDomain");*/
            Console.ReadLine();
        }

    }
}
