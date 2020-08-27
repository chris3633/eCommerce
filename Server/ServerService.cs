using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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


        public bool Registra(UtenteServer u2)
        {
            bool completato = false;
            try
            {
                string Codice = u2.Codice;
                string nome = u2.Nome;
                string cognome = u2.Cognome;
                string email = u2.Email;
                string password = u2.Password;
                string indirizzo = u2.Indirizzo;
                string citta = u2.Citta;
                int tipologia = u2.Tipologia;

                string stringa = ConfigurationManager.ConnectionStrings["stringaConnessione"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(stringa))
                {
                    conn.Open();
                    using (SqlCommand insert = conn.CreateCommand())
                    {
                        insert.CommandText = "Insert into Utente (CodiceUtente,Nome,Cognome,Email,Password,Indirizzo,Citta,Venditore) VALUES ('" + Codice + "','" + nome + "', '" + cognome + "', '" + email + "', '" + password + "', '" + indirizzo + "', '" + citta + "', '" + tipologia + "')";
                        insert.ExecuteNonQuery();
                        completato = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                completato = false;
            }
            return completato;
        }
        public bool Controlla_credenziali(string e, string p)
        {
            bool errore = false;
            try
            {
                string stringa = ConfigurationManager.ConnectionStrings["stringaConnessione"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(stringa))
                {
                    conn.Open();
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "Select Email,Password from Utente where Email='" + e + "' and Password= '" + p + "'";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int righe = 0;
                            while (reader.Read())
                            {
                                righe += 1;//conta i risultati
                            }
                            if (righe == 1)
                            {
                                errore = false;
                            }
                            else
                            {
                                errore = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return errore;
        }
        public UtenteServer Accedi(string e, string p)
        {
            UtenteServer u = new UtenteServer();
            try
            {
                string stringa = ConfigurationManager.ConnectionStrings["stringaConnessione"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(stringa))
                {
                    conn.Open();
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "Select CodiceUtente,Nome,Cognome,Email,Password,Indirizzo,Citta,Credito,Venditore from Utente where Email='" + e + "' and Password= '" + p + "'";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                u.Codice = reader.GetString(0);
                                u.Nome = reader.GetString(1);
                                u.Cognome = reader.GetString(2);
                                u.Email = reader.GetString(3);
                                u.Password = reader.GetString(4);
                                u.Indirizzo = reader.GetString(5);
                                u.Citta = reader.GetString(6);
                                u.Credito = reader.GetDecimal(7);
                                u.Tipologia = Convert.ToInt32(reader.GetBoolean(8));//reader.GetInt32(8); sollevava eccezione di invalid cast
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return u;
        }
        public List<ProdottoServer> VisualizzaProdotti()
        {
            //SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Samuele\\Desktop\\eCommerce\\Server\\Database_eCommerce.mdf;Integrated Security=True");//("Server=(localdb)\\MSSQLLocalDB; Database=\"C:\\USERS\\SAMUELE\\DOCUMENTS\\TECNICHE DI SVILPPO SOFTWARE\\WCFTESTSERVER\\DATABASE1.MDF\"; Integrated Security=SSPI"); //("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\SAMUELE\\DOCUMENTS\\TECNICHE DI SVILPPO SOFTWARE\\WCFTESTSERVER\\DATABASE1.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");//
            List<ProdottoServer> prodotti = new List<ProdottoServer>();
            try
            {
                string stringa = ConfigurationManager.ConnectionStrings["stringaConnessione"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(stringa))
                {
                    conn.Open();
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "Select CodiceProdotto, Categoria, Marca, Nome, Prezzo, Quantita, Descrizione, CodiceVenditore from Prodotto";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                prodotti.Add(new ProdottoServer
                                {
                                    Cod_prodotto = reader.GetInt32(0),
                                    Categoria = reader.GetString(1),
                                    Marca = reader.GetString(2),
                                    Nome = reader.GetString(3),
                                    Prezzo = reader.GetDecimal(4),
                                    Quantita = reader.GetInt16(5),
                                    Descrizione = reader.GetString(6),
                                    Cod_venditore = reader.GetString(7)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return prodotti;
        }
        public bool Stato_ordine(List<(ProdottoServer, int)> carrello, string cod_utente)
        {
            bool completato;
            double totale = 0.0;
            int id_ordine = 0;

            try
            {
                string stringa = ConfigurationManager.ConnectionStrings["stringaConnessione"].ConnectionString;

                foreach (var i in carrello) //ciclo di test
                {
                    Console.WriteLine(i.Item1.Cod_prodotto);//
                    Console.WriteLine(i.Item2);//
                    Console.WriteLine(cod_utente);//
                    totale += (double)i.Item1.Prezzo * i.Item2;
                }
                Console.WriteLine(totale);
                float tot = (float)totale;

   

                using (SqlConnection conn = new SqlConnection(stringa))
                {
                    conn.Open();
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "Insert into Ordine(Totale,CodiceUtente) VALUES ('" + tot + "', '" + cod_utente + "')";
                        command.ExecuteNonQuery();//viene inserito un nuovo Ordine, ma dobbiamo recuperare l'id dell'ordine generato dal db
                        Console.WriteLine("Test");
                        command.CommandText = "Select Top 1 Id,Data,Totale,CodiceUtente From Ordine Where Totale ='" + totale + "' AND CodiceUtente ='" + cod_utente + "' ORDER BY Data DESC";
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id_ordine = reader.GetInt32(0);
                            }
                        }

                        foreach (var i in carrello)
                        {
                            Console.WriteLine(i.Item1.Nome);
                            Console.WriteLine(i.Item1.Cod_prodotto);
                            Console.WriteLine(i.Item2);
                            Console.WriteLine(cod_utente);
                            command.CommandText = "Insert into DettagliOrdine (IdOrdine,IdArticolo,Quantita,Prezzo) VALUES ('" + id_ordine + "', '" + i.Item1.Cod_prodotto + "', '" + i.Item2 + "', '" + Convert.ToDouble(i.Item1.Prezzo) + "')";
                            command.ExecuteNonQuery();
                            command.CommandText = "Update Prodotto Set Quantita=Quantita-'" +i.Item2 + "' Where CodiceProdotto ='" + i.Item1.Cod_prodotto + "'";
                            command.ExecuteNonQuery();//la quantità del prodotto presente nel catalogo viene diminuita della quantità che è stata acquistata dal cliente
                            command.CommandText= "Update Utente Set Credito=Credito+'" + Convert.ToDouble(i.Item1.Prezzo)*i.Item2 + "' Where  CodiceUtente='" + i.Item1.Cod_venditore + "'";
                            command.ExecuteNonQuery();//il credito del venditore viene aumentato del prezzo dell'articolo venduto moltiplicato per la quantità acquistata
                        }
                        command.CommandText = "Update Utente Set Credito=Credito-'" + totale + "' Where CodiceUtente ='" + cod_utente + "'";
                        command.ExecuteNonQuery();//il credito del cliente viene diminuito del prezzo totale dell'ordine
                    }
                }
                completato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                completato = false;
            }
            return completato;
        }
        public bool Aggiungi_credito(double importo, string cod_utente)
        {
            bool completato;
            try
            {
                string stringa = ConfigurationManager.ConnectionStrings["stringaConnessione"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(stringa))
                {
                    conn.Open();
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "Update Utente Set Credito=Credito+'" + importo + "' Where  CodiceUtente='" + cod_utente + "'";
                        command.ExecuteNonQuery();
                    }
                }
                completato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                completato = false;
            }
            return completato;


        }
        public List<OrdineServer> Storico_ordini(string cod_utente)
        {
            List<OrdineServer> ordini = new List<OrdineServer>();
            try
            {
                string stringa = ConfigurationManager.ConnectionStrings["stringaConnessione"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(stringa))
                {
                    conn.Open();
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "Select Id,Data,Totale,CodiceUtente from Ordine Where CodiceUtente='"+cod_utente+"'";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ordini.Add(new OrdineServer
                                {
                                    Id_ordine = reader.GetInt32(0),
                                    Data = reader.GetDateTime(1),
                                    Totale = reader.GetDecimal(2),
                                    Codice_utente = reader.GetString(3),
                                    
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ordini;
        }
    }
}
