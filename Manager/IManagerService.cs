using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Manager
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IManagerService" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IManagerService
    {
        [OperationContract]
        void DoWork();

        //[OperationContract]

        //int Raddoppia(int n);

        [OperationContract]
        bool Registra(UtenteManager u1);

        [OperationContract]
        bool Controlla_credenziali(string e, string p);

        [OperationContract]
        UtenteManager Accedi(string e, string p);
    }
    public class UtenteManager//utente-manager
    {
        public string codice { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string indirizzo { get; set; }
        public string citta { get; set; }
        public int tipologia { get; set; }

        /*public UtenteManager(string cf, string n, string c, string e, string p, string i, string ct)//costruttore
        {
            codice_fiscale = cf;
            nome = n;
            cognome = c;
            email = e;
            password = p;
            indirizzo = i;
            citta = ct;
        }*/
    }
    /*public class UtenteServer 
    {
        public string codice_fiscale { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string indirizzo { get; set; }
        public string citta { get; set; }

        public UtenteServer(string cf, string n, string c, string e, string p, string i, string ct)//costruttore
        {
            codice_fiscale = cf;
            nome = n;
            cognome = c;
            email = e;
            password = p;
            indirizzo = i;
            citta = ct;
        }
    }*/
}
