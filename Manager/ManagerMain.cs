using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    class ManagerMain
    {
        static void Main(string[] args)
        {
            try
            {//commento
                ServiceHost myservice = new ServiceHost(typeof(ManagerService)); //quale server da far partire
                myservice.Open();
                Console.WriteLine("Manager avviato");
                Console.ReadLine();
                myservice.Close();
                Console.WriteLine("Manager disattivato");
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
    }
}
