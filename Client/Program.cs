using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
                    Console.WriteLine("\nScegli una attività:");
                    Console.WriteLine("1-Visualizza catalogo prodotti");
                    Console.WriteLine("2-Effettua il login alla tua area riservata");
                    Console.WriteLine("3-Registrati sulla piattaforma");
                    Console.WriteLine("4-Esci\n");
                    try
                    {
                        attivita = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    switch (attivita)
                    {
                        case 1://navigazione e ricerca dei prodotti presenti nel negozio

                            Visualizza_prodotti();
                            break;
                        case 2://accesso all'area riservata
                            UtenteManager u = new UtenteManager(); //crazione oggetto di tipo utente
                            u = Login();
                            if(u.codice.Length == 11)
                              Area_riservata_venditore(u);
                            else if (u.codice.Length == 16)
                                Area_riservata_cliente(u);
                            else
                                Area_riservata_admin(u);


                            //fare acquisti
                            //visualizzare elenco degli acquisti
                            //aggiungere credito al portafoglio
                            break;
                        case 3://Registrazione utente (cliente/venditore)
                            bool esito = Registrazione();
                            if (esito)
                            {
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Registrazione effettuata con successo!");
                                Console.WriteLine("----------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Impossibile completare la registrazione, si è verificato un problema!");
                                Console.WriteLine("----------------------------------------");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Grazie e arrivederci!");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Valore non consentito!\n");
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
                bool completato = false;

                try
                {
                    bool errore = false;
                    string Codice;
                    string nome;
                    string cognome;
                    string email;
                    string password;
                    string conf_password;
                    string indirizzo;
                    string citta;
                    int tipologia = 0;
                    var wcfclient = new ServiceReference1.ManagerServiceClient();

                    do
                    {
                        if (errore == true) { Console.WriteLine("Si è verificato un errore, riprova!"); }
                        errore = false;

                        Console.WriteLine("\n[REGISTRAZIONE UTENTE]");
                        do
                        {
                            Console.WriteLine("Scegliere la tipologia: 0-Cliente, 1-Venditore\n");
                            tipologia = int.Parse(Console.ReadLine());
                        } while (tipologia != 0 && tipologia != 1);
                        if (tipologia == 0)
                        {
                            Console.WriteLine("Codice Fiscale:");//16 caratteri
                            Codice = Console.ReadLine();
                            if (Codice.Length != 16) { errore = true; }
                        }
                        else
                        {
                            Console.WriteLine("Partita Iva:");//11 caratteri
                            Codice = Console.ReadLine();
                            if (Codice.Length != 11) { errore = true; }
                        }
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
                        Console.WriteLine("Città:");
                        citta = Console.ReadLine();

                    } while (errore == true);

                    UtenteManager u1 = new UtenteManager();//creo utente lato manager
                    u1.codice = Codice;//assegno dati client a utente manager
                    u1.nome = nome;
                    u1.cognome = cognome;
                    u1.email = email;
                    u1.password = password;
                    //u1.credito = u.credito;
                    u1.indirizzo = indirizzo;
                    u1.citta = citta;
                    u1.tipologia = tipologia;

                    completato = wcfclient.Registra(u1);//chiamo il servizio di registrazione del manager

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    completato = false;
                }
                return completato;
            }
            UtenteManager Login()
            {
                UtenteManager u = new UtenteManager();
                try
                {
                    string email, password;
                    bool errore = false;
                    var wcfclient = new ServiceReference1.ManagerServiceClient();
                    do
                    {
                        Console.WriteLine("ACCESSO ALL'AREA RISERVATA");
                        Console.WriteLine("Indirizzo e-mail:");
                        email = Console.ReadLine();
                        Console.WriteLine("Password:");
                        password = Console.ReadLine();
                        errore = wcfclient.Controlla_credenziali(email, password);
                        if (errore == false)
                        {
                            u = wcfclient.Accedi(email, password);
                        }
                        else
                        {
                            Console.WriteLine("Credenziali errate!");
                        }
                    } while (errore == true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }         
                return u;               
            }
            void Visualizza_prodotti()
            {
                try
                {
                    var wcfclient = new ServiceReference1.ManagerServiceClient();
                    int cat = 0;
                    string categoria="";
                    decimal prezzoMax=0;
                    bool pmax=false;
                    bool errore = false;
                    ProdottoManager[] lista = wcfclient.VisualizzaProdotti();//ottengo dal manager un array di prodotti manager

                    do
                    {
                        try
                        {
                            Console.WriteLine("----Impostazione filtri di ricerca----");
                            do
                            {
                                errore = false;
                                Console.WriteLine("Categoria: 0-Tutte, 1-Smartphone, 2-PC, 3-Elettrodomestici, ...");
                                cat = int.Parse(Console.ReadLine());
                                if (cat < 0 || cat > 3)
                                {
                                    errore = true;
                                    Console.WriteLine("Valore categoria errato!");
                                }
                            } while (errore == true) ;
                            
                            Console.WriteLine("Prezzo massimo: ");
                            pmax = decimal.TryParse(Console.ReadLine(), out prezzoMax);//prova a convertire il valore in decimal: esito true/false in pmax e valore restituito in prezzoMax
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errore = true;
                        }
                    } while (errore==true);

                    if (cat == 1) { 
                        categoria = "Smartphone"; 
                    }else if (cat == 2) { 
                        categoria = "PC"; 
                    }else //cat==3
                    { 
                        categoria = "Elettrodomestici"; 
                    }
                    //non piace al prof
                    /*var lista_filtrata=from prod in lista
                                       where prod.categoria.Trim()==categoria && prod.prezzo<=prezzoMax
                                       select prod;*/
                    //piace al prof
                    /*var lista_filtrata = lista.Select(prod => prod)
                        .Where(prod => prod.categoria.Trim() == categoria && prod.prezzo <= prezzoMax);*/
                    var lista_filtrata = lista.Select(prod => prod);
                    if (cat == 1 || cat == 2 || cat == 3)
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)//lista filtrata per categoria
                        .Where(prod => prod.categoria.Trim() == categoria);
                    }
                    if (pmax == true)
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)//lista filtrata per prezzo massimo
                        .Where(prod => prod.prezzo <= prezzoMax);
                    }
                    else
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod);
                    }

                    Console.WriteLine("___________________________________________________________________________________");
                    Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-18} {4,8} {5,-8} {6,-50}", "Codice", "Categoria", "Marca", "Nome", "Prezzo", "Quantità", "Descrizione");//formattazione composita con allineamento es {0,6} posiziona l'elemento 0 in uno spazio di 6 caratteri, il - posiziona a sinistra
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    foreach (var i in lista_filtrata.ToList())
                    {
                        Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-18} {4,8} {5,8} {6,-50}", i.cod_prodotto, i.categoria.Trim(), i.marca.Trim(), i.nome.Trim(), i.prezzo, i.quantita, i.descrizione.Trim());
                        Console.WriteLine("-----------------------------------------------------------------------------------");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            void Area_riservata_cliente(UtenteManager u)
            {
                Console.WriteLine("Benvenuto " + u.nome.Trim() + " " + u.cognome.Trim());//trim rimuove tutti gli spazi iniziali e finali dell'oggetto string (nel db essendoci più caratteri nei vari campi si visualizzerebbero degli spazi vuoti)
                int attivita=0;
                do {
                    Console.WriteLine("\nScegli una attività:");
                    Console.WriteLine("1-Visualizza catalogo prodotti");
                    Console.WriteLine("2-Visualizza dati account");
                    Console.WriteLine("3-Aggiungi credito");
                    Console.WriteLine("4-Visualizza storico ordini");
                    Console.WriteLine("5-Esci\n");
                    try
                    {
                        attivita = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    switch (attivita)
                    {
                        case 1://navigazione e ricerca dei prodotti presenti nel negozio
                            Visualizza_prodotti();
                            break;
                        case 2:
                            
                            break;
                        case 3:
                            
                            break;
                        case 4:
                            
                            break;
                        case 5:
                            Console.WriteLine("Logout effettuato correttamente");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Valore non consentito!\n");
                            break;
                    }

                } while (attivita != 5);
            }
        }

    }

}
