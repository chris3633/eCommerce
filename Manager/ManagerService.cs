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
            u1.codice = u2.codice;
            u1.nome = u2.nome;
            u1.cognome = u2.cognome;
            u1.email = u2.email;
            u1.password = u2.password;
            u1.indirizzo = u2.indirizzo;
            u1.citta = u2.citta;
            u1.credito = u2.credito;
            u1.tipologia = u2.tipologia;
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
                    cod_prodotto = i.cod_prodotto,
                    categoria = i.categoria,
                    marca = i.marca,
                    nome = i.nome,
                    prezzo = i.prezzo,
                    quantita = i.quantita,
                    descrizione = i.descrizione,
                    cod_venditore = i.cod_venditore
                });
            }
            return prodotti;
        }
    }
}
