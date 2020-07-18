﻿using System;
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

        [OperationContract]
        List<ProdottoManager> VisualizzaProdotti();

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
        public decimal credito { get; set; }
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
    public class ProdottoManager
    {
        public int cod_prodotto { get; set; }
        public string categoria { get; set; }
        public string marca { get; set; }
        public string nome { get; set; }
        public decimal prezzo { get; set; }
        public int quantita { get; set; }
        public string descrizione { get; set; }
        public string cod_venditore { get; set; }
    }


}
