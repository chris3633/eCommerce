using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerMain
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost myservice = new ServiceHost(typeof(ServerService)); //quale server da far partire
                myservice.Open();
                Console.WriteLine("Server avviato");
                Console.ReadLine();
                myservice.Close();
                Console.WriteLine("Server disattivato");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); 
            }
        }
    }
}
