using System;
using System.Collections.Generic;
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
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Samuele\\Desktop\\eCommerce\\Server\\Database_eCommerce.mdf;Integrated Security=True");//("Server=(localdb)\\MSSQLLocalDB; Database=\"C:\\USERS\\SAMUELE\\DOCUMENTS\\TECNICHE DI SVILPPO SOFTWARE\\WCFTESTSERVER\\DATABASE1.MDF\"; Integrated Security=SSPI"); //("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\SAMUELE\\DOCUMENTS\\TECNICHE DI SVILPPO SOFTWARE\\WCFTESTSERVER\\DATABASE1.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");//
            try
            {
                conn.Open();

                string Codice = u2.codice;
                string nome = u2.nome;
                string cognome = u2.cognome;
                string email = u2.email;
                string password = u2.password;
                string indirizzo = u2.indirizzo;
                string citta = u2.citta;
                int tipologia = u2.tipologia;

                SqlCommand insert = new SqlCommand();
                insert.CommandType = CommandType.Text;
                insert.CommandText = "Insert into Utente (CodiceUtente,Nome,Cognome,Email,Password,Indirizzo,Citta,Venditore) VALUES ('" + Codice + "','" + nome + "', '" + cognome + "', '" + email + "', '" + password + "', '" + indirizzo + "', '" + citta + "', '" + tipologia + "')";

                insert.Connection = conn;
                insert.ExecuteNonQuery();
                completato = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                completato = false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }
            return completato;
        }
        public bool Controlla_credenziali(string e,string p)
        {
            bool errore = false;
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Samuele\\Desktop\\eCommerce\\Server\\Database_eCommerce.mdf;Integrated Security=True");//("Server=(localdb)\\MSSQLLocalDB; Database=\"C:\\USERS\\SAMUELE\\DOCUMENTS\\TECNICHE DI SVILPPO SOFTWARE\\WCFTESTSERVER\\DATABASE1.MDF\"; Integrated Security=SSPI"); //("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\SAMUELE\\DOCUMENTS\\TECNICHE DI SVILPPO SOFTWARE\\WCFTESTSERVER\\DATABASE1.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");//
            try
            {
                conn.Open();
                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("Select Email,Password from Utente where Email='" + e + "' and Password= '"+ p +"'", conn);

                reader = command.ExecuteReader();
                int righe = 0;
                while (reader.Read())
                {
                    righe += 1;//conta i risultati
                }
                reader.Close();
                if (righe >= 1) { errore = false; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                errore = true;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }
            return errore;
        }
        public UtenteServer Accedi(string e, string p)
        {
            UtenteServer u = new UtenteServer();
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Samuele\\Desktop\\eCommerce\\Server\\Database_eCommerce.mdf;Integrated Security=True");//("Server=(localdb)\\MSSQLLocalDB; Database=\"C:\\USERS\\SAMUELE\\DOCUMENTS\\TECNICHE DI SVILPPO SOFTWARE\\WCFTESTSERVER\\DATABASE1.MDF\"; Integrated Security=SSPI"); //("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\SAMUELE\\DOCUMENTS\\TECNICHE DI SVILPPO SOFTWARE\\WCFTESTSERVER\\DATABASE1.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");//
            try
            {
                conn.Open();
                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("Select Email,Password from Utente where Email='" + e + "' and Password= '" + p + "'", conn);
                
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    u.codice = reader["CodiceUtente"].ToString();
                    u.nome = reader["Nome"].ToString();
                    u.cognome = reader["Cognome"].ToString();
                    u.email = reader["Email"].ToString();
                    u.password = reader["Password"].ToString();
                    u.indirizzo=reader["Indirizzo"].ToString();
                    u.citta = reader["Citta"].ToString();
                    u.tipologia = Convert.ToInt32(reader["Venditore"]);
                }
                reader.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return u;
        }
    }
    
}
