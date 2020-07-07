using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var wcfclient = new ServiceReference1.ManagerServiceClient();//wcf client creato

                Console.WriteLine("WCF Client creato");

                Console.WriteLine("WCF client - chiamata al servizio...");

                //wcfclient.DoWork();

                //Console.WriteLine(wcfclient.Raddoppia(5));

                int attivita = 0;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Benvenuto sulla piattaforma di eCommerce");
                Console.WriteLine("----------------------------------------");
                do
                {
                    Console.WriteLine("Scegli una attivita:");
                    Console.WriteLine("1-Ricerca un prodotto");
                    Console.WriteLine("2-Effettua il login alla tua area riservata");
                    Console.WriteLine("3-Registrati sulla piattaforma");
                    Console.WriteLine("4-Esci");
                    attivita = int.Parse(Console.ReadLine());
                    switch (attivita)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            bool esito=Registrazione();
                            if (esito) {
                                Console.WriteLine("Registrazione effettuata con successo!");
                            }
                            else { 
                                Console.WriteLine("Errore: l'utente non è stato registrato"); 
                            }
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    }

                } while (attivita != 4);

                Console.WriteLine("WCF client - chiamata al servizio ok");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {

            }

            bool Registrazione()
            {
                var wcfclient = new ServiceReference1.ManagerServiceClient();
                bool completato = false;
                bool errore = false;
                string CF;
                string nome;
                string cognome;
                string email;
                string password;
                string conf_password;
                string indirizzo;
                string citta;
                do
                {
                    if (errore == true) { Console.WriteLine("Si è verificato un errore, riprova!"); }
                    errore = false;
                    Console.WriteLine("REGISTRAZIONE UTENTE");
                    Console.WriteLine("Codice Fiscale:");
                    CF = Console.ReadLine();
                    if (CF.Length != 16) { errore = true; }
                    Console.WriteLine("Nome:");
                    nome = Console.ReadLine();
                    Console.WriteLine("Cognome:");
                    cognome = Console.ReadLine();
                    Console.WriteLine("Indirizzo E-mail:");
                    email = Console.ReadLine();
                    Console.WriteLine("Password:");
                    password = Console.ReadLine();
                    Console.WriteLine("Conferma password:");
                    conf_password = Console.ReadLine();
                    if (password != conf_password) { errore = true; }
                    Console.WriteLine("Indirizzo:");
                    indirizzo = Console.ReadLine();
                    Console.WriteLine("Citta:");
                    citta = Console.ReadLine();
                    
                } while (errore);

                UtenteClient u = new UtenteClient(CF, nome, cognome, email, password, indirizzo, citta);

                UtenteManager u1 = new UtenteManager();//persona lato server
                u1.codice_fiscale = u.codice_fiscale;
                u1.nome = u.nome;//assegno dati client a persona server
                u1.cognome = u.cognome;
                u1.email = u.email;
                u1.password = u.password;
                u1.credito = u.credito;
                u1.indirizzo = u.indirizzo;
                u1.citta = u.citta;
                //completato=wcfclient.Registra(u)
                return completato;
            }
        }
        public class UtenteClient
        {
            public string codice_fiscale { get; set; }
            public string nome { get; set; }
            public string cognome { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public int credito { get; set; }
            public string indirizzo { get; set; }
            public string citta { get; set; }

            public UtenteClient(string cf, string n, string c, string e, string p, string i, string ct)//costruttore
            {
                codice_fiscale = cf;
                nome = n;
                cognome = c;
                email = e;
                password = p;
                indirizzo = i;
                citta = ct;
            }
        }
}
    
}
