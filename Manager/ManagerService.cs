using Manager.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
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

        public bool Registra(UtenteManager u1)
        {
            var servizio = new Server.ServerServiceClient(); //servizio per comunicare con il server
            UtenteServer u2 = new UtenteServer();//creazione utente server da passare al server
            u2.Codice = u1.Codice;//assegno i dati all'utente del server
            u2.Nome = u1.Nome;
            u2.Cognome = u1.Cognome;
            u2.Email = u1.Email;
            u2.Password = u1.Password;
            u2.Indirizzo = u1.Indirizzo;
            u2.Citta = u1.Citta;
            u2.Tipologia = u1.Tipologia;
            return servizio.Registra(u2);
        }

        public bool Controlla_credenziali(string e, string p)
        {
            var servizio = new Server.ServerServiceClient();
            return servizio.Controlla_credenziali(e, p);
        }
        public UtenteManager Accedi(string e, string p)
        {
            var servizio = new Server.ServerServiceClient();
            UtenteManager u1 = new UtenteManager();
            UtenteServer u2 = new UtenteServer();
            u2 = servizio.Accedi(e, p);
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
            List<ProdottoManager> prodotti = new List<ProdottoManager>();

            List<ProdottoServer> lista = servizio.VisualizzaProdotti();
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
        public bool Stato_ordine(List<(ProdottoManager, int)> carrello, string cod_utente)
        {

            List<(ProdottoServer, int)> carrello_convertito = new List<(ProdottoServer, int)>();
            foreach (var i in carrello)
            {
                carrello_convertito.Add((new ProdottoServer //aggiungo alla lista di prodotti-manager un nuovo prodotto con valori presi dai prodotti-server
                {
                    Cod_prodotto = i.Item1.Cod_prodotto,
                    Categoria = i.Item1.Categoria,
                    Marca = i.Item1.Marca,
                    Nome = i.Item1.Nome,
                    Prezzo = i.Item1.Prezzo,
                    Quantita = i.Item1.Quantita,
                    Descrizione = i.Item1.Descrizione,
                    Cod_venditore = i.Item1.Cod_venditore
                }, i.Item2));

            }
            var servizio = new Server.ServerServiceClient();

            return servizio.Stato_ordine(carrello_convertito, cod_utente);


        }
        public bool Aggiungi_credito(double importo, string cod_utente)
        {
            var servizio = new Server.ServerServiceClient();

            return servizio.Aggiungi_credito(importo, cod_utente);
        }
        public List<VenditeManager> Storico_ordini(string cod_utente)
        {
            var servizio = new Server.ServerServiceClient();
            List<VenditeManager> ordini_manager = new List<VenditeManager>();

            List<VenditeServer> ordini_server = servizio.Storico_ordini(cod_utente);

            var ord = ordini_server.ToList();
            foreach (var i in ord) //servizio.VisualizzaProdotti() restituisce una lista di oggetti di tipo ProdottoServer
            {
                ordini_manager.Add(new VenditeManager//aggiungo alla lista di prodotti-manager un nuovo prodotto con valori presi dai prodotti-server
                {
                    Id_ordine = i.Id_ordine,
                    Codice_utente = i.Codice_utente,
                    Data = i.Data,
                    Totale = i.Totale,
                    Id_articolo = i.Id_articolo,
                    Nome_articolo = i.Nome_articolo,
                    Quantita = i.Quantita
                });
            }
            return ordini_manager;
        }
        public List<VenditeManager> Storico_vendite(string cod_utente)
        {
            var servizio = new Server.ServerServiceClient();
            List<VenditeManager> vendite_manager = new List<VenditeManager>();

            List<VenditeServer> vendite_server = servizio.Storico_vendite(cod_utente);

            var ord = vendite_server.ToList();
            foreach (var i in ord)
            {
                vendite_manager.Add(new VenditeManager
                {
                    Id_ordine = i.Id_ordine,
                    Data = i.Data,
                    Totale = i.Totale,
                    Codice_utente = i.Codice_utente,
                    Nome_utente = i.Nome_utente,
                    Cognome_utente = i.Cognome_utente,
                    Id_articolo = i.Id_articolo,
                    Nome_articolo = i.Nome_articolo,
                    Quantita = i.Quantita
                });
            }
            return vendite_manager;
        }
        public bool Aggiungi_prodotto(ProdottoManager p)
        {
            var servizio = new Server.ServerServiceClient();
            ProdottoServer prod_server = new ProdottoServer();
            prod_server.Categoria = p.Categoria;
            prod_server.Cod_venditore = p.Cod_venditore;
            prod_server.Descrizione = p.Descrizione;
            prod_server.Nome = p.Nome;
            prod_server.Marca = p.Marca;
            prod_server.Prezzo = p.Prezzo;
            prod_server.Quantita = p.Quantita;
            return servizio.Aggiungi_prodotto(prod_server);
        }
        public bool Rimozione_prodotto(ProdottoManager p)
        {
            var servizio = new Server.ServerServiceClient();
            ProdottoServer prod_server = new ProdottoServer();
            prod_server.Cod_prodotto = p.Cod_prodotto;
            prod_server.Categoria = p.Categoria;
            prod_server.Cod_venditore = p.Cod_venditore;
            prod_server.Descrizione = p.Descrizione;
            prod_server.Nome = p.Nome;
            prod_server.Marca = p.Marca;
            prod_server.Prezzo = p.Prezzo;
            prod_server.Quantita = p.Quantita;
            return servizio.Rimozione_prodotto(prod_server);
        }
        public bool Aggiungi_quantita(int quantita, int codice)
        {
            var servizio = new Server.ServerServiceClient();
            return servizio.Aggiungi_quantita(quantita, codice);
        }
        public UtenteManager Visualizza_dati(string cod_utente)
        {
            var servizio = new Server.ServerServiceClient();
            UtenteManager u1 = new UtenteManager();
            UtenteServer u2 = new UtenteServer();
            u2 = servizio.Visualizza_dati(cod_utente);
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
        public List<UtenteManager> VisualizzaUtenti()
        {
            var servizio = new Server.ServerServiceClient();
            List<UtenteManager> lista_um = new List<UtenteManager>();

            List<UtenteServer> lista_us = servizio.VisualizzaUtenti();
            var utenti = lista_us.ToList();
            foreach (var i in utenti) //servizio.VisualizzaProdotti() restituisce una lista di oggetti di tipo ProdottoServer
            {
                lista_um.Add(new UtenteManager//aggiungo alla lista di prodotti-manager un nuovo prodotto con valori presi dai prodotti-server
                {
                    Codice = i.Codice,
                    Nome = i.Nome,
                    Cognome = i.Cognome,
                    Email = i.Email,
                    Password = i.Password,
                    Indirizzo = i.Indirizzo,
                    Citta = i.Citta,
                    Credito = i.Credito,
                    Tipologia = i.Tipologia
                });
            }
            return lista_um;
        }
        public bool Rimozione_utente(string cod_utente)
        {
            var servizio = new Server.ServerServiceClient();
            return servizio.Rimozione_utente(cod_utente);
        }

    }
}
