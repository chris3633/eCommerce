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

        /*public int Raddoppia(int n)
        {
            return n * 2;
        }*/

        public bool Registra(UtenteServer u2)
        {
            bool completato = false;
            try
            {
                string Codice = u2.codice;
                string nome = u2.nome;
                string cognome = u2.cognome;
                string email = u2.email;
                string password = u2.password;
                string indirizzo = u2.indirizzo;
                string citta = u2.citta;
                int tipologia = u2.tipologia;

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
                                u.codice = reader.GetString(0);
                                u.nome = reader.GetString(1);
                                u.cognome = reader.GetString(2);
                                u.email = reader.GetString(3);
                                u.password = reader.GetString(4);
                                u.indirizzo = reader.GetString(5);
                                u.citta = reader.GetString(6);
                                u.credito = reader.GetDecimal(7);
                                u.tipologia = reader.GetInt32(8);
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
                                    cod_prodotto = reader.GetInt32(0),
                                    categoria = reader.GetString(1),
                                    marca = reader.GetString(2),
                                    nome = reader.GetString(3),
                                    prezzo = reader.GetDecimal(4),
                                    quantita = reader.GetInt16(5),
                                    descrizione = reader.GetString(6),
                                    cod_venditore = reader.GetString(7)
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
    }
}
