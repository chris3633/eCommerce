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
            var servizio = new Server.ServerServiceClient(); //servizio per comunicare con il server
            UtenteServer u2 = new UtenteServer();//creazione utente server da passare al server
            u2.Codice = u1.Codice;//assegno i dati all'utente del server
            u2.Nome=u1.Nome;
            u2.Cognome=u1.Cognome;
            u2.Email=u1.Email;
            u2.Password=u1.Password;
            u2.Indirizzo=u1.Indirizzo;
            u2.Citta=u1.Citta;
            u2.Tipologia = u1.Tipologia;
            return servizio.Registra(u2);
        }

        public bool Controlla_credenziali(string e,string p)
        {
            var servizio = new Server.ServerServiceClient();
            return servizio.Controlla_credenziali(e,p);
        }
        public UtenteManager Accedi(string e,string p)
        {
            var servizio = new Server.ServerServiceClient();
            UtenteManager u1 = new UtenteManager();
            UtenteServer u2 = new UtenteServer();
            u2=servizio.Accedi(e, p);
            u1.Codice = u2.Codice;
            u1.Nome = u2.Nome;
            u1.Cognome = u2.Cognome;
            u1.Email = u2.Email;
            u1.Password = u2.Password;
            u1.Indirizzo = u2.Indirizzo;
            u1.Citta = u2.Citta;
            u1.Credito = u2.Credito;
            u1.Tipologia = u2.Tipologia;
            return u1;
        }
        public List<ProdottoManager> VisualizzaProdotti()
        {
            var servizio = new Server.ServerServiceClient();
            //ProdottoManager p = new ProdottoManager();
            List<ProdottoManager> prodotti = new List<ProdottoManager>();
            
            ProdottoServer[] lista = servizio.VisualizzaProdotti();
            var prod = lista.ToList();
            foreach (var i in prod) //servizio.VisualizzaProdotti() restituisce una lista di oggetti di tipo ProdottoServer
            {
                prodotti.Add(new ProdottoManager//aggiungo alla lista di prodotti-manager un nuovo prodotto con valori presi dai prodotti-server
                {
                    Cod_prodotto = i.Cod_prodotto,
                    Categoria = i.Categoria,
                    Marca = i.Marca,
                    Nome = i.Nome,
                    Prezzo = i.Prezzo,
                    Quantita = i.Quantita,
                    Descrizione = i.Descrizione,
                    Cod_venditore = i.Cod_venditore
                });
            }
            return prodotti;
        }
    }
}
