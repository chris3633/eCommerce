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

        [OperationContract]
        bool Registra(UtenteManager u1);

        [OperationContract]
        bool Controlla_credenziali(string e, string p);

        [OperationContract]
        UtenteManager Accedi(string e, string p);

        [OperationContract]
        List<ProdottoManager> VisualizzaProdotti();

        [OperationContract]
        bool Stato_ordine(List<(ProdottoManager, int)> carrello, string cod_utente);

        [OperationContract]
        bool Aggiungi_credito(double importo,string cod_utente);

        [OperationContract]
        List<OrdineManager> Storico_ordini(string cod_utente);

        [OperationContract]
        bool Aggiungi_prodotto(ProdottoManager p);

        [OperationContract]
        bool Rimozione_prodotto(ProdottoManager p);

        [OperationContract]
        List<VenditeManager> Storico_vendite(string cod_utente);

        [OperationContract]
        bool Aggiungi_quantita(int quantita, int codice);
        [OperationContract]
        UtenteManager Visualizza_dati(string cod_utente);
        [OperationContract]
        List<UtenteManager> VisualizzaUtenti();
        [OperationContract]
        bool Rimozione_utente(string cod_utente);

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
    
    public class UtenteManager : Persona//utente-manager
    {
        private string email;
        private string password;
        private decimal credito;
        private int tipologia;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public decimal Credito { get => credito; set => credito = value; }
        public int Tipologia { get => tipologia; set => tipologia = value; }
    }
    public class ProdottoManager
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
    public class OrdineManager
    {
        private int id_ordine;
        private string codice_utente;
        private DateTime data;
        private decimal totale;

        public int Id_ordine { get => id_ordine; set => id_ordine = value; }
        public string Codice_utente { get => codice_utente; set => codice_utente = value; }
        public DateTime Data { get => data; set => data = value; }
        public decimal Totale { get => totale; set => totale = value; }
    }
    public class VenditeManager : OrdineManager
    {
        private string nome_utente;
        private string cognome_utente;
        private int id_articolo;
        private int quantita;
        private string nome_articolo;

        public string Nome_utente { get => nome_utente; set => nome_utente = value; }
        public string Cognome_utente { get => cognome_utente; set => cognome_utente = value; }
        public int Id_articolo { get => id_articolo; set => id_articolo = value; }
        public int Quantita { get => quantita; set => quantita = value; }
        public string Nome_articolo { get => nome_articolo; set => nome_articolo = value; }
    }

}
