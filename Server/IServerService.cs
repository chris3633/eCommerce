﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IServerService" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IServerService
    {
        [OperationContract]
        void DoWork();

        //[OperationContract]
        //int Raddoppia(int n);

        [OperationContract]
        bool Registra(UtenteServer u2);
    }

    
    public class UtenteServer//utente-server
    {
        public string codice { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string indirizzo { get; set; }
        public string citta { get; set; }
        public int tipologia { get; set; }


        /*public UtenteServer(string cf, string n, string c, string e, string p, string i, string ct)//costruttore
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
}
