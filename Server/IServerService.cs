using System;
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

        [OperationContract]
        bool Controlla_credenziali(string e,string p);

        [OperationContract]
        UtenteServer Accedi(string e, string p);

        [OperationContract]
        List<ProdottoServer> VisualizzaProdotti();

        [OperationContract]
        bool Stato_ordine(List<(ProdottoServer, int)> carrello, string cod_utente);
    }

    public class Persona
    {
        private string codice;
        private string nome;
        private string cognome;
        private string indirizzo;
        private string citta;

        public string Codice { get => codice; set => codice = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Indirizzo { get => indirizzo; set => indirizzo = value; }
        public string Citta { get => citta; set => citta = value; }
    }
    public class UtenteServer : Persona//utente-server
    {
        private string email;
        private string password;
        private decimal credito;
        private int tipologia;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public decimal Credito { get => credito; set => credito = value; }
        public int Tipologia { get => tipologia; set => tipologia = value; }


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
    public class ProdottoServer
    {
        private int cod_prodotto;
        private string categoria;
        private string marca;
        private string nome;
        private decimal prezzo;
        private int quantita;
        private string descrizione;
        private string cod_venditore;

        public int Cod_prodotto { get => cod_prodotto; set => cod_prodotto = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Nome { get => nome; set => nome = value; }
        public decimal Prezzo { get => prezzo; set => prezzo = value; }
        public int Quantita { get => quantita; set => quantita = value; }
        public string Descrizione { get => descrizione; set => descrizione = value; }
        public string Cod_venditore { get => cod_venditore; set => cod_venditore = value; }

    }
    public class OrdineServer
    {
        private int codice_utente;
        private List<(ProdottoServer,int)> carrello;

    }
}
