using Manager.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace Manager
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "ManagerService" nel codice e nel file di configurazione contemporaneamente.
    public class ManagerService : IManagerService
    {
        public void DoWork()
        {
            var servizio = new Server.ServerServiceClient();
            servizio.DoWork();
            Console.WriteLine("Metodo dowork del manager chiamato");

        }

        /*public int Raddoppia(int n) riceve intero dal client
        {
            var servizio = new Server.ServerServiceClient(); crea servizio
            
            return servizio.Raddoppia(n); servizio passa al server valore, server lo raddoppia, il valore viene ritornato al manager che lo ritorna al client
        }*/

        public bool Registra(UtenteManager u1)
        {
            var servizio = new Server.ServerServiceClient();
            UtenteServer u2 = new UtenteServer();//creazione utente server da passare al server
            u2.codice = u1.codice;//assegno i dati all'utente del server
            u2.nome=u1.nome;
            u2.cognome=u1.cognome;
            u2.email=u1.email;
            u2.password=u1.password;
            u2.indirizzo=u1.indirizzo;
            u2.citta=u1.citta;
            u2.tipologia = u1.tipologia;
            return servizio.Registra(u2);
        }
    }
}
