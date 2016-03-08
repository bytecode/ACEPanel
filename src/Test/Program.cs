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
            var ad = new AD();
            ad.GetDomain();
            Console.ReadLine();
        }

    }
}
