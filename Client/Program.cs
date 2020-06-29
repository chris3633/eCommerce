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
            //var wcfclient = new ServiceReference1.Service1Client();//wcf client creato

            Console.WriteLine("WCF Client creato");

            Console.WriteLine("WCF client - chiamata al servizio...");

            //wcfclient.DoWork();

            Console.WriteLine("WCF client - chiamata al servizio ok");

            Console.ReadLine();
        }
    }
}
