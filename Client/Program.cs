using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var wcfclient = new ServiceReference1.ManagerServiceClient();//wcf client creato

            Console.WriteLine("WCF Client creato");

            Console.WriteLine("WCF client - chiamata al servizio...");

            wcfclient.DoWork();

            //Console.WriteLine(wcfclient.Raddoppia(5));

            Console.WriteLine("WCF client - chiamata al servizio ok");

            Console.ReadLine();
        }
    }
}
