using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "ServerService" nel codice e nel file di configurazione contemporaneamente.
    public class ServerService : IServerService
    {
        public void DoWork()
        {
            Console.WriteLine("Metodo dowork chiamato");
        }

        /*public int Raddoppia(int n)
        {
            return n * 2;
        }*/
    }
}
