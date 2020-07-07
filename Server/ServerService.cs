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

                string CF = u2.codice_fiscale;
                string nome = u2.nome;
                string cognome = u2.cognome;
                string email = u2.email;
                string password = u2.password;
                string indirizzo = u2.indirizzo;
                string citta = u2.citta;

                SqlCommand insert = new SqlCommand();
                insert.CommandType = CommandType.Text;
                insert.CommandText = "Insert into Utente (CodiceFiscale,Nome,Cognome,Email,Password,Credito,Indirizzo,Citta) VALUES ('" + CF + "','" + nome + "', '" + cognome + "', '" + email + "', '" + password + ", '" + indirizzo + "', '" + citta + "')";

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
    }
}
