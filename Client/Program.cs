using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            UtenteManager u = new UtenteManager();
            u = null;
            try
            {
                var wcfclient = new ServiceReference1.ManagerServiceClient();//wcf client creato

                //Console.WriteLine("WCF Client creato");

                //Console.WriteLine("WCF client - chiamata al servizio...");
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
                            try
                            {
                                u = Login();
                                if (u == null) throw new NullReferenceException();//viene lanciata una eccezione quando l'oggetto è nullo
                                if (u.Codice.Trim().Length == 11)
                                    Area_riservata_venditore(u);
                                else if (u.Codice.Trim().Length == 16)
                                    Area_riservata_cliente(u);
                                else
                                    Area_riservata_admin(u);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }

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

                //Console.WriteLine("WCF client - chiamata al servizio ok");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
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

                    UtenteManager u1 = new UtenteManager();//viene creato un utente tipo manager
                    u1.Codice = Codice;//assegno dati all'utente manager
                    u1.Nome = nome;
                    u1.Cognome = cognome;
                    u1.Email = email;
                    u1.Password = password;
                    u1.Indirizzo = indirizzo;
                    u1.Citta = citta;
                    u1.Tipologia = tipologia;

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
                        errore = wcfclient.Controlla_credenziali(email, password);//controlla che le credenziali siano presenti nel db
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
                    string categoria = "";
                    decimal prezzoMax = 0;
                    bool pmax = false;
                    bool errore = false;
                    List<ProdottoManager> lista = wcfclient.VisualizzaProdotti();//ottengo dal manager un array di prodotti manager

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
                                if (cat != 0 && cat != 1 && cat != 2 && cat != 3)
                                {
                                    errore = true;
                                    Console.WriteLine("Valore categoria errato!");
                                }
                            } while (errore == true);

                            Console.WriteLine("Prezzo massimo: ");
                            pmax = decimal.TryParse(Console.ReadLine(), out prezzoMax);//prova a convertire il valore in decimal: esito true/false in pmax e valore restituito in prezzoMax

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errore = true;
                        }
                    } while (errore == true);

                    if (cat == 1)
                    {
                        categoria = "Smartphone";
                    }
                    else if (cat == 2)
                    {
                        categoria = "PC";
                    }
                    else //cat==3
                    {
                        categoria = "Elettrodomestici";
                    }

                    var lista_filtrata = lista.Select(prod => prod);
                    if (cat == 1 || cat == 2 || cat == 3)
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)//lista filtrata per categoria
                        .Where(prod => prod.Categoria.Trim() == categoria);
                    }
                    if (pmax == true)
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)//lista filtrata per prezzo massimo
                        .Where(prod => prod.Prezzo <= prezzoMax);
                    }
                    else
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod);
                    }

                    Console.WriteLine("__________________________________________________________________________________________");
                    Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,-8} {6,-50}", "Codice", "Categoria", "Marca", "Nome", "Prezzo", "Quantità", "Descrizione");//formattazione composita con allineamento es {0,6} posiziona l'elemento 0 in uno spazio di 6 caratteri, il - posiziona a sinistra
                    Console.WriteLine("------------------------------------------------------------------------------------------");
                    foreach (var i in lista_filtrata.ToList())
                    {
                        Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,8} {6,-50}", i.Cod_prodotto, i.Categoria.Trim(), i.Marca.Trim(), i.Nome.Trim(), i.Prezzo, i.Quantita, i.Descrizione.Trim());
                        Console.WriteLine("------------------------------------------------------------------------------------------");
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            void Visualizza_Acquista_prodotti()
            {
                try
                {
                    var wcfclient = new ServiceReference1.ManagerServiceClient();
                    bool completato;
                    int cat = 0;
                    string categoria = "";
                    decimal prezzoMax = 0;
                    bool pmax = false;
                    bool errore = false;
                    List<ProdottoManager> lista = wcfclient.VisualizzaProdotti();//ottengo dal manager una lista di prodotti manager

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
                            } while (errore == true);

                            Console.WriteLine("Prezzo massimo: ");
                            pmax = decimal.TryParse(Console.ReadLine(), out prezzoMax);//prova a convertire il valore in decimal: esito true/false in pmax e valore restituito in prezzoMax

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errore = true;
                        }
                    } while (errore == true);

                    if (cat == 1)
                    {
                        categoria = "Smartphone";
                    }
                    else if (cat == 2)
                    {
                        categoria = "PC";
                    }
                    else //cat==3
                    {
                        categoria = "Elettrodomestici";
                    }

                    var lista_filtrata = lista.Select(prod => prod);
                    if (cat == 1 || cat == 2 || cat == 3)
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)//lista filtrata per categoria
                        .Where(prod => prod.Categoria.Trim() == categoria);
                    }
                    if (pmax == true)
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)//lista filtrata per prezzo massimo
                        .Where(prod => prod.Prezzo <= prezzoMax);
                    }
                    else
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod);
                    }

                    Console.WriteLine("__________________________________________________________________________________________");
                    Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,-8} {6,-50}", "Codice", "Categoria", "Marca", "Nome", "Prezzo", "Quantità", "Descrizione");//formattazione composita con allineamento es {0,6} posiziona l'elemento 0 in uno spazio di 6 caratteri, il - posiziona a sinistra
                    Console.WriteLine("------------------------------------------------------------------------------------------");
                    foreach (var i in lista_filtrata.ToList())
                    {
                        Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,8} {6,-50}", i.Cod_prodotto, i.Categoria.Trim(), i.Marca.Trim(), i.Nome.Trim(), i.Prezzo, i.Quantita, i.Descrizione.Trim());
                        Console.WriteLine("------------------------------------------------------------------------------------------");
                    }
                    int codice = 0, quantita = 0;
                    decimal totale_carrello = 0;
                    ConsoleKeyInfo risposta;
                    List<(ProdottoManager, int)> carrello = new List<(ProdottoManager, int)>();//carrello formato da coppie (prodotto,quantità)
                    ProdottoManager p = new ProdottoManager();

                    if (lista_filtrata.Count() == 0)
                        Console.WriteLine("La ricerca non ha prodotto alcun risultato.");
                    else
                    {
                        Console.WriteLine("Effettua ordine");
                        Console.WriteLine("Aggiungi prodotti al carrello");
                        do
                        {
                            Console.WriteLine("Inserisci codice prodotto");
                            codice = int.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci quantità prodotto");
                            quantita = int.Parse(Console.ReadLine());
                            if (quantita > 0)
                            {
                                foreach (var i in lista_filtrata.ToList())
                                {
                                    if (codice == i.Cod_prodotto)
                                    {
                                        if (quantita <= i.Quantita)
                                        {

                                            carrello.Add((new ProdottoManager
                                            {
                                                Cod_prodotto = i.Cod_prodotto,
                                                Categoria = i.Categoria,
                                                Marca = i.Marca,
                                                Nome = i.Nome,
                                                Prezzo = i.Prezzo,
                                                Quantita = i.Quantita,
                                                Descrizione = i.Descrizione,
                                                Cod_venditore = i.Cod_venditore
                                            }, quantita));
                                            totale_carrello += i.Prezzo * quantita;
                                            Console.WriteLine("Prodotto aggiunto al carrello");
                                            Console.WriteLine("Totale parziale " + totale_carrello);
                                        }
                                        else Console.WriteLine("Quantita' non disponibile, sono rimasti " + i.Quantita + " prodotti");
                                    }

                                }
                            }
                            else Console.WriteLine("Quantità inserita uguale a zero");
                            Console.WriteLine("Vuoi aggiungere un altro prodotto? Y/N");
                            risposta = Console.ReadKey();
                            Console.WriteLine();
                            while (risposta.Key != ConsoleKey.Y && risposta.Key != ConsoleKey.N)
                            {
                                Console.WriteLine("Tasto non corretto. Inserire Y/N");
                                risposta = Console.ReadKey();
                                Console.WriteLine();
                            }
                        } while (risposta.Key == ConsoleKey.Y);

                        
                            Console.WriteLine("Procedere con l'ordine? Y/N");
                            risposta = Console.ReadKey();
                            Console.WriteLine();
                            while (risposta.Key != ConsoleKey.Y && risposta.Key != ConsoleKey.N)
                            {
                                Console.WriteLine("Tasto non corretto. Inserire Y/N ");
                                risposta = Console.ReadKey();
                                Console.WriteLine();
                            }


                        if (risposta.Key == ConsoleKey.Y && totale_carrello != 0)
                        {
                            if (u.Credito >= totale_carrello)
                            {

                                Console.WriteLine("Ordine effettuato per un totale di " + totale_carrello);
                                foreach (var i in carrello)
                                {
                                    Console.WriteLine(i.Item1.Nome+" Quantita' "+i.Item2);
                                }
                                completato = wcfclient.Stato_ordine(carrello, u.Codice);

                                Console.WriteLine("Salvare il riepilogo dell'ordine? Y/N");
                                risposta = Console.ReadKey();
                                Console.WriteLine();
                                while (risposta.Key != ConsoleKey.Y && risposta.Key != ConsoleKey.N)
                                {
                                    Console.WriteLine("Tasto non corretto. Inserire Y/N ");
                                    risposta = Console.ReadKey();
                                    Console.WriteLine();
                                }
                                if(risposta.Key == ConsoleKey.Y) { Salva_riepilogo_ordine(u.Codice,u.Nome,u.Cognome); }
                                

                            }
                            else { Console.WriteLine("Credito non sufficiente!"); }

                        }
                        else Console.WriteLine("Il tuo carrello è vuoto, non è quindi possibile procedere con l'ordine!");

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            void Salva_riepilogo_ordine(string cod_utente,string nome_utente,string cognome_utente)
            {
                try
                {
                    string documenti = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//percorso della cartella Documenti
                    string docPath = Path.Combine(documenti, "RiepilogoOrdini_eCommerce");//percorso della cartella Documenti a cui viene aggiunta la cartella RiepilogoOrdini
                    if (!Directory.Exists(docPath))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(docPath);//se la cartella non esiste, viene creata
                    }
                    
                    List<VenditeManager> ordini_manager = new List<VenditeManager>();
                    var wcfclient = new ServiceReference1.ManagerServiceClient();
                    ordini_manager = wcfclient.Storico_ordini(cod_utente);
                    string nameFile="";
                    decimal totale=0;
                    DateTime data=DateTime.Now;
                    
                    var idMax=ordini_manager.Select(ord => ord).Max(ord=>ord.Id_ordine);//trovo l'ultimo id dell'ordine inserito ossia il massimo

                    foreach (var i in ordini_manager)
                    {
                        if (i.Id_ordine == idMax) { 
                            nameFile = "RiepilogoOrdine_" + Convert.ToString(i.Id_ordine) + "_" + i.Data.ToString("yyyyMMddHHmmss") + ".txt";//creazione del nome del file
                            totale = i.Totale;
                            data = i.Data;
                        }
                        
                    }
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, nameFile)))//scrive informazioni su file
                    {
                        outputFile.WriteLine("--------------------------------------------------");
                        outputFile.WriteLine("\t       Negozio di eCommerce");
                        outputFile.WriteLine("--------------------------------------------------\n");
                        outputFile.WriteLine("Riepilogo ordine numero " + idMax.ToString());
                        outputFile.WriteLine("Data: " + data.ToString());
                        outputFile.WriteLine("CLIENTE");
                        outputFile.WriteLine(nome_utente.Trim() + " " + cognome_utente.Trim() + ", C.F.: " + cod_utente);
                        
                        foreach (var i in ordini_manager)
                        {
                            if (i.Id_ordine == idMax)
                            {
                                outputFile.WriteLine("------------------------");
                                outputFile.WriteLine("Id articolo: " + i.Id_articolo);
                                outputFile.WriteLine("Nome articolo: " + i.Nome_articolo);
                                outputFile.WriteLine("Prezzo articolo: " + i.Prezzo);
                                outputFile.WriteLine("Quantita': " + i.Quantita);
                            }
                            
                        }
                        outputFile.WriteLine("________________________");
                        outputFile.WriteLine("Prezzo totale: " + totale.ToString());
                    }
                    Console.WriteLine("File salvato in Documenti, nella cartella RiepilogoOrdini_eCommerce");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("ERRORE: file non salvato!");
                }
            }
            void Storico_ordini(string cod_utente)
            {
                List<VenditeManager> ordini_manager = new List<VenditeManager>();
                var wcfclient = new ServiceReference1.ManagerServiceClient();
                ordini_manager = wcfclient.Storico_ordini(cod_utente);
                foreach (var i in ordini_manager)
                {
                    Console.WriteLine("Numero dell'ordine: " + i.Id_ordine);
                    Console.WriteLine("Data: " + i.Data);
                    Console.WriteLine("Prezzo totale: " + i.Totale);
                    Console.WriteLine("Id articolo: " + i.Id_articolo);
                    Console.WriteLine("Nome articolo: " + i.Nome_articolo);
                    Console.WriteLine("Prezzo articolo: " + i.Prezzo);
                    Console.WriteLine("Quantita': " + i.Quantita);
                    Console.WriteLine("------------------------");
                }
            }
            bool Aggiungi_prodotto()
            {
                int cat, quantita;
                string categoria, marca, nome, descr;
                Decimal prezzo;
                var wcfclient = new ServiceReference1.ManagerServiceClient();
                do
                {
                    Console.WriteLine("Inserisci la categoria dell'oggetto /  1-Smartphone, 2-PC, 3-Elettrodomestici ");
                    cat = int.Parse(Console.ReadLine());
                } while (cat != 1 && cat != 2 && cat != 3);
                if (cat == 1)
                    categoria = "Smartphone";
                else if (cat == 2)
                    categoria = "PC";
                else categoria = "Elettrodomestici";

                Console.WriteLine("Inserisci la marca ");
                marca = Console.ReadLine();
                Console.WriteLine("Inserisci nome prodotto ");
                nome = Console.ReadLine();
                Console.WriteLine("Inserisci prezzo prodotto");
                prezzo = Decimal.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci quantità prodotto ");
                quantita = int.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci descrizione prodotto ");
                descr = Console.ReadLine();

                ProdottoManager p = new ProdottoManager();

                p.Categoria = categoria;
                p.Marca = marca;
                p.Nome = nome;
                p.Prezzo = prezzo;
                p.Quantita = quantita;
                p.Descrizione = descr;
                p.Cod_venditore = u.Codice;


                return wcfclient.Aggiungi_prodotto(p);
            }
            bool Rimuovi_prodotto(string cod_venditore)
            {
                bool completato = false;
                try
                {
                    var wcfclient = new ServiceReference1.ManagerServiceClient();

                    int cat = 0;
                    string categoria = "";
                    bool errore = false;
                    List<ProdottoManager> lista = wcfclient.VisualizzaProdotti();//ottengo dal manager una lista di prodotti manager

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
                            } while (errore == true);


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errore = true;
                        }
                    } while (errore == true);

                    if (cat == 1)
                    {
                        categoria = "Smartphone";
                    }
                    else if (cat == 2)
                    {
                        categoria = "PC";
                    }
                    else //cat==3
                    {
                        categoria = "Elettrodomestici";
                    }

                    var lista_filtrata = lista.Select(prod => prod);
                    if (cat == 1 || cat == 2 || cat == 3)
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)//lista filtrata per categoria
                        .Where(prod => prod.Categoria.Trim() == categoria && prod.Cod_venditore == cod_venditore);
                    }
                    else
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)
                         .Where(prod => prod.Cod_venditore == cod_venditore);
                    }

                    Console.WriteLine("__________________________________________________________________________________________");
                    Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,-8} {6,-50}", "Codice", "Categoria", "Marca", "Nome", "Prezzo", "Quantità", "Descrizione");//formattazione composita con allineamento es {0,6} posiziona l'elemento 0 in uno spazio di 6 caratteri, il - posiziona a sinistra
                    Console.WriteLine("------------------------------------------------------------------------------------------");
                    foreach (var i in lista_filtrata.ToList())
                    {
                        Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,8} {6,-50}", i.Cod_prodotto, i.Categoria.Trim(), i.Marca.Trim(), i.Nome.Trim(), i.Prezzo, i.Quantita, i.Descrizione.Trim());
                        Console.WriteLine("------------------------------------------------------------------------------------------");
                    }
                    int codice = 0;
                    char risposta = 'Y';
                    ProdottoManager p = new ProdottoManager();


                    if (lista_filtrata.Count() == 0)
                        Console.WriteLine("La ricerca non ha prodotto alcun risultato.");
                    else
                    {
                        Console.WriteLine("Procedura di rimozione di un prodotto");

                        Console.WriteLine("Inserisci codice prodotto");
                        codice = int.Parse(Console.ReadLine());


                        foreach (var i in lista_filtrata.ToList())
                        {
                            if (codice == i.Cod_prodotto)
                            {
                                p.Cod_prodotto = i.Cod_prodotto;
                                p.Categoria = i.Categoria;
                                p.Marca = i.Marca;
                                p.Nome = i.Nome;
                                p.Prezzo = i.Prezzo;
                                p.Quantita = i.Quantita;
                                p.Descrizione = i.Descrizione;
                                p.Cod_venditore = i.Cod_venditore;
                            }
                        }

                        Console.WriteLine("Procedere con la rimozione? Y/N");
                        risposta = Convert.ToChar(Console.ReadLine());

                        while(risposta != 'N' && risposta != 'Y' && risposta != 'n' && risposta != 'y')
                        {
                            Console.WriteLine("Tasto non corretto! Procedere con la rimozione? Y/N");
                            risposta = Convert.ToChar(Console.ReadLine());
                        } 


                        if ((risposta == 'Y' || risposta == 'y') && p.Cod_prodotto != 0)
                        {
                            Console.WriteLine("risposta Y");
                            completato = wcfclient.Rimozione_prodotto(p);

                        }
                        else completato = false;

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    completato = false;
                }
                return completato;
            }
            bool Rimuovi_prodotto_admin()
            {
                bool completato = false;
                try
                {
                    var wcfclient = new ServiceReference1.ManagerServiceClient();
                    int cat = 0;
                    string categoria = "";
                    bool errore = false;
                    List<ProdottoManager> lista = wcfclient.VisualizzaProdotti();//ottengo dal manager una lista di prodotti manager

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
                            } while (errore == true);


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errore = true;
                        }
                    } while (errore == true);

                    if (cat == 1)
                    {
                        categoria = "Smartphone";
                    }
                    else if (cat == 2)
                    {
                        categoria = "PC";
                    }
                    else //cat==3
                    {
                        categoria = "Elettrodomestici";
                    }

                    var lista_filtrata = lista.Select(prod => prod);
                    if (cat == 1 || cat == 2 || cat == 3)
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)//lista filtrata per categoria
                        .Where(prod => prod.Categoria.Trim() == categoria);
                    }

                    Console.WriteLine("__________________________________________________________________________________________");
                    Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,-8} {6,-50}", "Codice", "Categoria", "Marca", "Nome", "Prezzo", "Quantità", "Descrizione");//formattazione composita con allineamento es {0,6} posiziona l'elemento 0 in uno spazio di 6 caratteri, il - posiziona a sinistra
                    Console.WriteLine("------------------------------------------------------------------------------------------");
                    foreach (var i in lista_filtrata.ToList())
                    {
                        Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,8} {6,-50}", i.Cod_prodotto, i.Categoria.Trim(), i.Marca.Trim(), i.Nome.Trim(), i.Prezzo, i.Quantita, i.Descrizione.Trim());
                        Console.WriteLine("------------------------------------------------------------------------------------------");
                    }
                    int codice = 0;
                    char risposta = 'Y';
                    ProdottoManager p = new ProdottoManager();


                    if (lista_filtrata.Count() == 0)
                        Console.WriteLine("La ricerca non ha prodotto alcun risultato.");
                    else
                    {
                        Console.WriteLine("Procedura di rimozione di un prodotto");

                        Console.WriteLine("Inserisci codice prodotto");
                        codice = int.Parse(Console.ReadLine());


                        foreach (var i in lista_filtrata.ToList())
                        {
                            if (codice == i.Cod_prodotto)
                            {
                                p.Cod_prodotto = i.Cod_prodotto;
                                p.Categoria = i.Categoria;
                                p.Marca = i.Marca;
                                p.Nome = i.Nome;
                                p.Prezzo = i.Prezzo;
                                p.Quantita = i.Quantita;
                                p.Descrizione = i.Descrizione;
                                p.Cod_venditore = i.Cod_venditore;
                            }
                        }

                        Console.WriteLine("Procedere con la rimozione? Y/N");
                        risposta = Convert.ToChar(Console.ReadLine());

                        while (risposta != 'N' && risposta != 'Y' && risposta != 'n' && risposta != 'y')
                        {
                            Console.WriteLine("Tasto non corretto! Procedere con la rimozione? Y/N");
                            risposta = Convert.ToChar(Console.ReadLine());
                        }


                        if ((risposta == 'Y' || risposta == 'y') && p.Cod_prodotto != 0)
                        {
                            Console.WriteLine("risposta Y");
                            completato = wcfclient.Rimozione_prodotto(p);

                        }
                        else completato = false;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    completato = false;
                }
                return completato;
            }
            void Storico_ordini_venditore(string cod_utente)
            {
                List<VenditeManager> vendite_manager = new List<VenditeManager>();
                var wcfclient = new ServiceReference1.ManagerServiceClient();
                vendite_manager = wcfclient.Storico_vendite(cod_utente);//lista di ordini
                foreach (var i in vendite_manager)
                {

                    Console.WriteLine("Numero dell'ordine: " + i.Id_ordine);
                    Console.WriteLine("Data dell'ordine: " + i.Data);
                    Console.WriteLine("Totale dell'ordine: " + i.Totale);
                    Console.WriteLine("Codice Utente: " + i.Codice_utente);
                    Console.WriteLine("Nome cliente: " + i.Nome_utente);
                    Console.WriteLine("Cognome cliente: " + i.Cognome_utente);
                    Console.WriteLine("ID articolo: " + i.Id_articolo);
                    Console.WriteLine("Nome articolo: " + i.Nome_articolo);
                    Console.WriteLine("Quantita' dell'ordine: " + i.Quantita);
                    Console.WriteLine("----------------------------------------- ");
                }
            }
            bool Aggiorna_quantita(string cod_utente)
            {
                bool completato = false; ;
                try
                {
                    int quantita;
                    var wcfclient = new ServiceReference1.ManagerServiceClient();
                    int cat = 0;
                    string categoria = "";
                    bool errore = false;
                    List<ProdottoManager> lista = wcfclient.VisualizzaProdotti();//ottengo dal manager una lista di prodotti manager

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
                            } while (errore == true);


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errore = true;
                        }
                    } while (errore == true);

                    if (cat == 1)
                    {
                        categoria = "Smartphone";
                    }
                    else if (cat == 2)
                    {
                        categoria = "PC";
                    }
                    else //cat==3
                    {
                        categoria = "Elettrodomestici";
                    }

                    var lista_filtrata = lista.Select(prod => prod);
                    if (cat == 1 || cat == 2 || cat == 3)
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)//lista filtrata per categoria
                        .Where(prod => prod.Categoria.Trim() == categoria && prod.Cod_venditore == cod_utente);
                    }
                    else
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)
                         .Where(prod => prod.Cod_venditore == cod_utente);
                    }

                    Console.WriteLine("__________________________________________________________________________________________");
                    Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,-8} {6,-50}", "Codice", "Categoria", "Marca", "Nome", "Prezzo", "Quantità", "Descrizione");//formattazione composita con allineamento es {0,6} posiziona l'elemento 0 in uno spazio di 6 caratteri, il - posiziona a sinistra
                    Console.WriteLine("------------------------------------------------------------------------------------------");
                    foreach (var i in lista_filtrata.ToList())
                    {
                        Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,8} {6,-50}", i.Cod_prodotto, i.Categoria.Trim(), i.Marca.Trim(), i.Nome.Trim(), i.Prezzo, i.Quantita, i.Descrizione.Trim());
                        Console.WriteLine("------------------------------------------------------------------------------------------");
                    }
                    int codice;
                    if (lista_filtrata.Count() == 0)
                        Console.WriteLine("La ricerca non ha prodotto alcun risultato.");
                    else
                    {
                        Console.WriteLine("Inserire il codice del prodotto interessato");
                        codice = int.Parse(Console.ReadLine());
                        foreach (var i in lista_filtrata)
                        {
                            if (i.Cod_prodotto == codice)
                            {
                                Console.WriteLine("Inserire la quantita' da aggiungere/togliere (negativa) a quella gia' presente");
                                quantita = int.Parse(Console.ReadLine());
                                completato = wcfclient.Aggiungi_quantita(quantita, codice);
                            }

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
            void Visualizza_negozio(string cod_utente)
            {
                try
                {
                    var wcfclient = new ServiceReference1.ManagerServiceClient();
                    int cat = 0;
                    string categoria = "";
                    bool errore = false;
                    List<ProdottoManager> lista = wcfclient.VisualizzaProdotti();//ottengo dal manager un array di prodotti manager

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
                            } while (errore == true);


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errore = true;
                        }
                    } while (errore == true);

                    if (cat == 1)
                    {
                        categoria = "Smartphone";
                    }
                    else if (cat == 2)
                    {
                        categoria = "PC";
                    }
                    else //cat==3
                    {
                        categoria = "Elettrodomestici";
                    }

                    var lista_filtrata = lista.Select(prod => prod);
                    if (cat == 1 || cat == 2 || cat == 3)
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)//lista filtrata per categoria
                        .Where(prod => prod.Categoria.Trim() == categoria && prod.Cod_venditore == cod_utente);
                    }
                    else
                    {
                        lista_filtrata = lista_filtrata.Select(prod => prod)
                         .Where(prod => prod.Cod_venditore == cod_utente);
                    }

                    Console.WriteLine("__________________________________________________________________________________________");
                    Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,-8} {6,-50}", "Codice", "Categoria", "Marca", "Nome", "Prezzo", "Quantità", "Descrizione");//formattazione composita con allineamento es {0,6} posiziona l'elemento 0 in uno spazio di 6 caratteri, il - posiziona a sinistra
                    Console.WriteLine("------------------------------------------------------------------------------------------");
                    foreach (var i in lista_filtrata.ToList())
                    {
                        Console.WriteLine("{0,6} {1,-16} {2,-10} {3,-25} {4,8} {5,8} {6,-50}", i.Cod_prodotto, i.Categoria.Trim(), i.Marca.Trim(), i.Nome.Trim(), i.Prezzo, i.Quantita, i.Descrizione.Trim());
                        Console.WriteLine("------------------------------------------------------------------------------------------");
                    }
                    if (lista_filtrata.Count() == 0)
                        Console.WriteLine("La ricerca non ha prodotto alcun risultato.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            bool Aggiorna_credito(string cod_utente)
            {
                bool completato = false;
                try
                {
                    double importo;
                    var wcfclient = new ServiceReference1.ManagerServiceClient();
                    Console.WriteLine("Inserisci importo da aggiungere");
                    importo = double.Parse(Console.ReadLine());
                    completato = wcfclient.Aggiungi_credito(importo, cod_utente);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    completato = false;
                }
                return completato;
            }
            void Visualizza_dati(string cod_utente)
            {
                try
                {
                    var wcfclient = new ServiceReference1.ManagerServiceClient();
                    UtenteManager um = new UtenteManager();
                    um = wcfclient.Visualizza_dati(cod_utente);
                    Console.WriteLine("Codice Utente: " + um.Codice);
                    Console.WriteLine("Nome: " + um.Nome);
                    Console.WriteLine("Cognome: " + um.Cognome);
                    Console.WriteLine("E-mail: " + um.Email);
                    Console.WriteLine("Credito residuo: " + um.Credito);
                    Console.WriteLine("Città: " + um.Citta);
                    Console.WriteLine("Indirizzo: " + um.Indirizzo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            bool Rimuovi_utente(string cod_admin)
            {
                bool completato = false;
                try
                {
                    var wcfclient = new ServiceReference1.ManagerServiceClient();

                    int tip = 0;
                    bool errore = true;
                    List<UtenteManager> lista = wcfclient.VisualizzaUtenti();//ottengo dal manager una lista di utenti manager

                    do
                    {
                        try
                        {
                            Console.WriteLine("----Impostazione filtri di ricerca----");
                            do
                            {
                                errore = false;
                                Console.WriteLine("Tipologia: 0-Tutti, 1-Clienti, 2-Venditori");
                                tip = int.Parse(Console.ReadLine());
                                if (tip != 0 && tip != 1 && tip != 2)
                                {
                                    errore = true;
                                    Console.WriteLine("Valore tipologia errato!");
                                }
                            } while (errore == true);


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errore = true;
                        }
                    } while (errore == true);

                    var lista_filtrata = lista.Select(prod => prod);
                    if (tip == 1)
                    {
                        lista_filtrata = lista_filtrata.Select(utente => utente)
                        .Where(utente => utente.Codice.Trim().Length == 16);
                    }
                    else if (tip == 2)
                    {
                        lista_filtrata = lista_filtrata.Select(utente => utente)
                        .Where(utente => utente.Codice.Trim().Length == 11);
                    }
                    else
                    {
                        lista_filtrata = lista_filtrata.Select(utente => utente);
                    }
                    Console.WriteLine("_____________________________________");

                    foreach (var i in lista_filtrata.ToList())
                    {
                        Console.WriteLine("Codice Utente: " + i.Codice);
                        Console.WriteLine("Nome: " + i.Nome);
                        Console.WriteLine("Cognome: " + i.Cognome);
                        Console.WriteLine("E-mail: " + i.Email);
                        Console.WriteLine("Indirizzo: " + i.Indirizzo);
                        Console.WriteLine("Città: " + i.Citta);
                        Console.WriteLine("Credito : " + i.Credito);
                        Console.WriteLine("-------------------------------------");
                    }
                    string codice_utente;
                    char risposta = 'Y';

                    if (lista_filtrata.Count() == 0)
                        Console.WriteLine("La ricerca non ha prodotto alcun risultato.");
                    else
                    {
                        Console.WriteLine("Procedura di rimozione di un utente");

                        Console.WriteLine("Inserisci codice utente");
                        codice_utente = Console.ReadLine();


                        foreach (var i in lista_filtrata.ToList())
                        {
                            if (codice_utente == i.Codice)
                            {
                                Console.WriteLine("Procedere con la rimozione? Y/N");
                                risposta = Convert.ToChar(Console.ReadLine());
                                while(risposta != 'N' && risposta !='n' && risposta != 'Y' && risposta !='y')
                                {
                                    Console.WriteLine("Tasto non corretto! Procedere con la rimozione? Y/N");
                                    risposta = Convert.ToChar(Console.ReadLine());
                                }


                                if ((risposta == 'Y' || risposta =='y') && codice_utente != "" && codice_utente != cod_admin)
                                {
                                    completato = wcfclient.Rimozione_utente(codice_utente);
                                }
                                else completato = false;
                            }
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
            void Visualizza_utenti()
            {
                try
                {
                    var wcfclient = new ServiceReference1.ManagerServiceClient();
                    int tip = 0;
                    bool errore = true;
                    List<UtenteManager> lista = wcfclient.VisualizzaUtenti();//ottengo dal manager una lista di utenti manager

                    do
                    {
                        try
                        {
                            Console.WriteLine("----Impostazione filtri di ricerca----");
                            do
                            {
                                errore = false;
                                Console.WriteLine("Tipologia: 0-Tutti, 1-Clienti, 2-Venditori");
                                tip = int.Parse(Console.ReadLine());
                                if (tip != 0 && tip != 1 && tip != 2 && tip != 3)
                                {
                                    errore = true;
                                    Console.WriteLine("Valore tipologia errato!");
                                }
                            } while (errore == true);


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errore = true;
                        }
                    } while (errore == true);

                    var lista_filtrata = lista.Select(prod => prod);
                    if (tip == 1)
                    {
                        lista_filtrata = lista_filtrata.Select(utente => utente)//seleziona i clienti
                        .Where(utente => utente.Codice.Trim().Length == 16);
                    }
                    else if (tip == 2)
                    {
                        lista_filtrata = lista_filtrata.Select(utente => utente)//seleziona i venditori
                        .Where(utente => utente.Codice.Trim().Length == 11);
                    }
                    else
                    {
                        lista_filtrata = lista_filtrata.Select(utente => utente);//seleziona tutti gli utenti
                    }

                    Console.WriteLine("_____________________________________");

                    foreach (var i in lista_filtrata.ToList())
                    {
                        Console.WriteLine("Codice Utente: " + i.Codice);
                        Console.WriteLine("Nome: " + i.Nome);
                        Console.WriteLine("Cognome: " + i.Cognome);
                        Console.WriteLine("E-mail: " + i.Email);
                        Console.WriteLine("Indirizzo: " + i.Indirizzo);
                        Console.WriteLine("Città: " + i.Citta);
                        Console.WriteLine("Credito : " + i.Credito);
                        Console.WriteLine("-------------------------------------");
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            //AREE RISERVATE
            void Area_riservata_cliente(UtenteManager um)
            {
                Console.WriteLine("Benvenuto " + um.Nome.Trim() + " " + um.Cognome.Trim());//trim rimuove tutti gli spazi iniziali e finali dell'oggetto string (nel db essendoci più caratteri nei vari campi si visualizzerebbero degli spazi vuoti)
                int attivita = 0;
                do
                {
                    Console.WriteLine("\nScegli una attività:");
                    Console.WriteLine("1-Visualizza e acquista prodotti");
                    Console.WriteLine("2-Visualizza dati account");
                    Console.WriteLine("3-Aggiungi credito");
                    Console.WriteLine("4-Visualizza storico ordini");
                    Console.WriteLine("5-Logout\n");
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
                            Visualizza_Acquista_prodotti();
                            break;
                        case 2:
                            Visualizza_dati(um.Codice);
                            break;
                        case 3:
                            if (Aggiorna_credito(um.Codice))
                                Console.WriteLine("Credito aggiunto correttamente");
                            else Console.WriteLine("Impossibile aggiungere credito!");
                            break;
                        case 4:
                            Storico_ordini(um.Codice);
                            break;
                        case 5:
                            Console.WriteLine("Logout effettuato correttamente");

                            break;
                        default:
                            Console.WriteLine("Valore non consentito!\n");
                            break;
                    }

                } while (attivita != 5);
            }
            void Area_riservata_venditore(UtenteManager um)
            {
                Console.WriteLine("Benvenuto " + um.Nome.Trim() + " " + um.Cognome.Trim());//trim rimuove tutti gli spazi iniziali e finali dell'oggetto string (nel db essendoci più caratteri nei vari campi si visualizzerebbero degli spazi vuoti)
                int attivita = 0;
                do
                {
                    Console.WriteLine("\nScegli una attività:");
                    Console.WriteLine("1-Aggiungi nuovo prodotto");
                    Console.WriteLine("2-Rimuovi un prodotto");
                    Console.WriteLine("3-Aggiorna quantità");
                    Console.WriteLine("4-Visualizza storico ordini");
                    Console.WriteLine("5-Visualizza dati account");
                    Console.WriteLine("6-Il mio negozio");
                    Console.WriteLine("7-Logout\n");
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
                        case 1:
                            if (Aggiungi_prodotto())
                                Console.WriteLine("Prodotto aggiunto correttamente");
                            else Console.WriteLine("Errore: prodotto non inserito!");

                            break;
                        case 2:
                            if (Rimuovi_prodotto(um.Codice))
                                Console.WriteLine("Prodotto rimosso correttamente");
                            else Console.WriteLine("Errore: prodotto non rimosso!");
                            break;
                        case 3:
                            if (Aggiorna_quantita(um.Codice))
                                Console.WriteLine("Quantità aggiornata correttamente");
                            else Console.WriteLine("Quantità non aggiornata!");
                            break;
                        case 4:
                            Storico_ordini_venditore(um.Codice);
                            break;
                        case 5:
                            Visualizza_dati(um.Codice);
                            break;
                        case 6:
                            Visualizza_negozio(um.Codice);
                            break;
                        case 7:
                            Console.WriteLine("Logout effettuato correttamente");

                            break;
                        default:
                            Console.WriteLine("Valore non consentito!\n");
                            break;
                    }

                } while (attivita != 7);
            }
            void Area_riservata_admin(UtenteManager um)
            {
                Console.WriteLine("Benvenuto utente ADMIN");
                int attivita = 0;
                do
                {
                    Console.WriteLine("\nScegli una attività:");
                    Console.WriteLine("1-Aggiungi utente");
                    Console.WriteLine("2-Rimuovi utente");
                    Console.WriteLine("3-Rimuovi prodotto");
                    Console.WriteLine("4-Visualizza utenti");
                    Console.WriteLine("5-Logout\n");
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
                        case 1:
                            Registrazione();
                            break;
                        case 2: //rimuovi utente
                            if (Rimuovi_utente(um.Codice))
                                Console.WriteLine("Utente rimosso correttamente");
                            else Console.WriteLine("Errore: utente non rimosso!");
                            break;
                        case 3: //rimuovi prodotto
                            if (Rimuovi_prodotto_admin())
                                Console.WriteLine("Prodotto rimosso correttamente");
                            else Console.WriteLine("Errore: prodotto non rimosso!");
                            break;
                        case 4:
                            Visualizza_utenti();
                            break;
                        case 5:
                            Console.WriteLine("Logout effettuato correttamente");

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
