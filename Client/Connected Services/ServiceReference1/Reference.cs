﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Persona", Namespace="http://schemas.datacontract.org/2004/07/Manager")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.ServiceReference1.UtenteManager))]
    public partial class Persona : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CittaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodiceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CognomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IndirizzoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Citta {
            get {
                return this.CittaField;
            }
            set {
                if ((object.ReferenceEquals(this.CittaField, value) != true)) {
                    this.CittaField = value;
                    this.RaisePropertyChanged("Citta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Codice {
            get {
                return this.CodiceField;
            }
            set {
                if ((object.ReferenceEquals(this.CodiceField, value) != true)) {
                    this.CodiceField = value;
                    this.RaisePropertyChanged("Codice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cognome {
            get {
                return this.CognomeField;
            }
            set {
                if ((object.ReferenceEquals(this.CognomeField, value) != true)) {
                    this.CognomeField = value;
                    this.RaisePropertyChanged("Cognome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Indirizzo {
            get {
                return this.IndirizzoField;
            }
            set {
                if ((object.ReferenceEquals(this.IndirizzoField, value) != true)) {
                    this.IndirizzoField = value;
                    this.RaisePropertyChanged("Indirizzo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nome {
            get {
                return this.NomeField;
            }
            set {
                if ((object.ReferenceEquals(this.NomeField, value) != true)) {
                    this.NomeField = value;
                    this.RaisePropertyChanged("Nome");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UtenteManager", Namespace="http://schemas.datacontract.org/2004/07/Manager")]
    [System.SerializableAttribute()]
    public partial class UtenteManager : Client.ServiceReference1.Persona {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal CreditoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TipologiaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Credito {
            get {
                return this.CreditoField;
            }
            set {
                if ((this.CreditoField.Equals(value) != true)) {
                    this.CreditoField = value;
                    this.RaisePropertyChanged("Credito");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Tipologia {
            get {
                return this.TipologiaField;
            }
            set {
                if ((this.TipologiaField.Equals(value) != true)) {
                    this.TipologiaField = value;
                    this.RaisePropertyChanged("Tipologia");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProdottoManager", Namespace="http://schemas.datacontract.org/2004/07/Manager")]
    [System.SerializableAttribute()]
    public partial class ProdottoManager : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Cod_prodottoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Cod_venditoreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescrizioneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MarcaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PrezzoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantitaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Categoria {
            get {
                return this.CategoriaField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoriaField, value) != true)) {
                    this.CategoriaField = value;
                    this.RaisePropertyChanged("Categoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Cod_prodotto {
            get {
                return this.Cod_prodottoField;
            }
            set {
                if ((this.Cod_prodottoField.Equals(value) != true)) {
                    this.Cod_prodottoField = value;
                    this.RaisePropertyChanged("Cod_prodotto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cod_venditore {
            get {
                return this.Cod_venditoreField;
            }
            set {
                if ((object.ReferenceEquals(this.Cod_venditoreField, value) != true)) {
                    this.Cod_venditoreField = value;
                    this.RaisePropertyChanged("Cod_venditore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descrizione {
            get {
                return this.DescrizioneField;
            }
            set {
                if ((object.ReferenceEquals(this.DescrizioneField, value) != true)) {
                    this.DescrizioneField = value;
                    this.RaisePropertyChanged("Descrizione");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Marca {
            get {
                return this.MarcaField;
            }
            set {
                if ((object.ReferenceEquals(this.MarcaField, value) != true)) {
                    this.MarcaField = value;
                    this.RaisePropertyChanged("Marca");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nome {
            get {
                return this.NomeField;
            }
            set {
                if ((object.ReferenceEquals(this.NomeField, value) != true)) {
                    this.NomeField = value;
                    this.RaisePropertyChanged("Nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Prezzo {
            get {
                return this.PrezzoField;
            }
            set {
                if ((this.PrezzoField.Equals(value) != true)) {
                    this.PrezzoField = value;
                    this.RaisePropertyChanged("Prezzo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantita {
            get {
                return this.QuantitaField;
            }
            set {
                if ((this.QuantitaField.Equals(value) != true)) {
                    this.QuantitaField = value;
                    this.RaisePropertyChanged("Quantita");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VenditeManager", Namespace="http://schemas.datacontract.org/2004/07/Manager")]
    [System.SerializableAttribute()]
    public partial class VenditeManager : Client.ServiceReference1.OrdineManager {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Cognome_utenteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Id_articoloField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Nome_articoloField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Nome_utenteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantitaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cognome_utente {
            get {
                return this.Cognome_utenteField;
            }
            set {
                if ((object.ReferenceEquals(this.Cognome_utenteField, value) != true)) {
                    this.Cognome_utenteField = value;
                    this.RaisePropertyChanged("Cognome_utente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id_articolo {
            get {
                return this.Id_articoloField;
            }
            set {
                if ((this.Id_articoloField.Equals(value) != true)) {
                    this.Id_articoloField = value;
                    this.RaisePropertyChanged("Id_articolo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nome_articolo {
            get {
                return this.Nome_articoloField;
            }
            set {
                if ((object.ReferenceEquals(this.Nome_articoloField, value) != true)) {
                    this.Nome_articoloField = value;
                    this.RaisePropertyChanged("Nome_articolo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nome_utente {
            get {
                return this.Nome_utenteField;
            }
            set {
                if ((object.ReferenceEquals(this.Nome_utenteField, value) != true)) {
                    this.Nome_utenteField = value;
                    this.RaisePropertyChanged("Nome_utente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantita {
            get {
                return this.QuantitaField;
            }
            set {
                if ((this.QuantitaField.Equals(value) != true)) {
                    this.QuantitaField = value;
                    this.RaisePropertyChanged("Quantita");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrdineManager", Namespace="http://schemas.datacontract.org/2004/07/Manager")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.ServiceReference1.VenditeManager))]
    public partial class OrdineManager : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Codice_utenteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Id_ordineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TotaleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Codice_utente {
            get {
                return this.Codice_utenteField;
            }
            set {
                if ((object.ReferenceEquals(this.Codice_utenteField, value) != true)) {
                    this.Codice_utenteField = value;
                    this.RaisePropertyChanged("Codice_utente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Data {
            get {
                return this.DataField;
            }
            set {
                if ((this.DataField.Equals(value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id_ordine {
            get {
                return this.Id_ordineField;
            }
            set {
                if ((this.Id_ordineField.Equals(value) != true)) {
                    this.Id_ordineField = value;
                    this.RaisePropertyChanged("Id_ordine");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Totale {
            get {
                return this.TotaleField;
            }
            set {
                if ((this.TotaleField.Equals(value) != true)) {
                    this.TotaleField = value;
                    this.RaisePropertyChanged("Totale");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IManagerService")]
    public interface IManagerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/DoWork", ReplyAction="http://tempuri.org/IManagerService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/DoWork", ReplyAction="http://tempuri.org/IManagerService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Registra", ReplyAction="http://tempuri.org/IManagerService/RegistraResponse")]
        bool Registra(Client.ServiceReference1.UtenteManager u1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Registra", ReplyAction="http://tempuri.org/IManagerService/RegistraResponse")]
        System.Threading.Tasks.Task<bool> RegistraAsync(Client.ServiceReference1.UtenteManager u1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Controlla_credenziali", ReplyAction="http://tempuri.org/IManagerService/Controlla_credenzialiResponse")]
        bool Controlla_credenziali(string e, string p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Controlla_credenziali", ReplyAction="http://tempuri.org/IManagerService/Controlla_credenzialiResponse")]
        System.Threading.Tasks.Task<bool> Controlla_credenzialiAsync(string e, string p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Accedi", ReplyAction="http://tempuri.org/IManagerService/AccediResponse")]
        Client.ServiceReference1.UtenteManager Accedi(string e, string p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Accedi", ReplyAction="http://tempuri.org/IManagerService/AccediResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.UtenteManager> AccediAsync(string e, string p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/VisualizzaProdotti", ReplyAction="http://tempuri.org/IManagerService/VisualizzaProdottiResponse")]
        System.Collections.Generic.List<Client.ServiceReference1.ProdottoManager> VisualizzaProdotti();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/VisualizzaProdotti", ReplyAction="http://tempuri.org/IManagerService/VisualizzaProdottiResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Client.ServiceReference1.ProdottoManager>> VisualizzaProdottiAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Stato_ordine", ReplyAction="http://tempuri.org/IManagerService/Stato_ordineResponse")]
        bool Stato_ordine(System.Collections.Generic.List<System.ValueTuple<Client.ServiceReference1.ProdottoManager, int>> carrello, string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Stato_ordine", ReplyAction="http://tempuri.org/IManagerService/Stato_ordineResponse")]
        System.Threading.Tasks.Task<bool> Stato_ordineAsync(System.Collections.Generic.List<System.ValueTuple<Client.ServiceReference1.ProdottoManager, int>> carrello, string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Aggiungi_credito", ReplyAction="http://tempuri.org/IManagerService/Aggiungi_creditoResponse")]
        bool Aggiungi_credito(double importo, string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Aggiungi_credito", ReplyAction="http://tempuri.org/IManagerService/Aggiungi_creditoResponse")]
        System.Threading.Tasks.Task<bool> Aggiungi_creditoAsync(double importo, string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Storico_ordini", ReplyAction="http://tempuri.org/IManagerService/Storico_ordiniResponse")]
        System.Collections.Generic.List<Client.ServiceReference1.VenditeManager> Storico_ordini(string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Storico_ordini", ReplyAction="http://tempuri.org/IManagerService/Storico_ordiniResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Client.ServiceReference1.VenditeManager>> Storico_ordiniAsync(string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Aggiungi_prodotto", ReplyAction="http://tempuri.org/IManagerService/Aggiungi_prodottoResponse")]
        bool Aggiungi_prodotto(Client.ServiceReference1.ProdottoManager p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Aggiungi_prodotto", ReplyAction="http://tempuri.org/IManagerService/Aggiungi_prodottoResponse")]
        System.Threading.Tasks.Task<bool> Aggiungi_prodottoAsync(Client.ServiceReference1.ProdottoManager p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Rimozione_prodotto", ReplyAction="http://tempuri.org/IManagerService/Rimozione_prodottoResponse")]
        bool Rimozione_prodotto(Client.ServiceReference1.ProdottoManager p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Rimozione_prodotto", ReplyAction="http://tempuri.org/IManagerService/Rimozione_prodottoResponse")]
        System.Threading.Tasks.Task<bool> Rimozione_prodottoAsync(Client.ServiceReference1.ProdottoManager p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Storico_vendite", ReplyAction="http://tempuri.org/IManagerService/Storico_venditeResponse")]
        System.Collections.Generic.List<Client.ServiceReference1.VenditeManager> Storico_vendite(string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Storico_vendite", ReplyAction="http://tempuri.org/IManagerService/Storico_venditeResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Client.ServiceReference1.VenditeManager>> Storico_venditeAsync(string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Aggiungi_quantita", ReplyAction="http://tempuri.org/IManagerService/Aggiungi_quantitaResponse")]
        bool Aggiungi_quantita(int quantita, int codice);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Aggiungi_quantita", ReplyAction="http://tempuri.org/IManagerService/Aggiungi_quantitaResponse")]
        System.Threading.Tasks.Task<bool> Aggiungi_quantitaAsync(int quantita, int codice);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Visualizza_dati", ReplyAction="http://tempuri.org/IManagerService/Visualizza_datiResponse")]
        Client.ServiceReference1.UtenteManager Visualizza_dati(string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Visualizza_dati", ReplyAction="http://tempuri.org/IManagerService/Visualizza_datiResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.UtenteManager> Visualizza_datiAsync(string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/VisualizzaUtenti", ReplyAction="http://tempuri.org/IManagerService/VisualizzaUtentiResponse")]
        System.Collections.Generic.List<Client.ServiceReference1.UtenteManager> VisualizzaUtenti();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/VisualizzaUtenti", ReplyAction="http://tempuri.org/IManagerService/VisualizzaUtentiResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Client.ServiceReference1.UtenteManager>> VisualizzaUtentiAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Rimozione_utente", ReplyAction="http://tempuri.org/IManagerService/Rimozione_utenteResponse")]
        bool Rimozione_utente(string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/Rimozione_utente", ReplyAction="http://tempuri.org/IManagerService/Rimozione_utenteResponse")]
        System.Threading.Tasks.Task<bool> Rimozione_utenteAsync(string cod_utente);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IManagerServiceChannel : Client.ServiceReference1.IManagerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManagerServiceClient : System.ServiceModel.ClientBase<Client.ServiceReference1.IManagerService>, Client.ServiceReference1.IManagerService {
        
        public ManagerServiceClient() {
        }
        
        public ManagerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ManagerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManagerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManagerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public bool Registra(Client.ServiceReference1.UtenteManager u1) {
            return base.Channel.Registra(u1);
        }
        
        public System.Threading.Tasks.Task<bool> RegistraAsync(Client.ServiceReference1.UtenteManager u1) {
            return base.Channel.RegistraAsync(u1);
        }
        
        public bool Controlla_credenziali(string e, string p) {
            return base.Channel.Controlla_credenziali(e, p);
        }
        
        public System.Threading.Tasks.Task<bool> Controlla_credenzialiAsync(string e, string p) {
            return base.Channel.Controlla_credenzialiAsync(e, p);
        }
        
        public Client.ServiceReference1.UtenteManager Accedi(string e, string p) {
            return base.Channel.Accedi(e, p);
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.UtenteManager> AccediAsync(string e, string p) {
            return base.Channel.AccediAsync(e, p);
        }
        
        public System.Collections.Generic.List<Client.ServiceReference1.ProdottoManager> VisualizzaProdotti() {
            return base.Channel.VisualizzaProdotti();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Client.ServiceReference1.ProdottoManager>> VisualizzaProdottiAsync() {
            return base.Channel.VisualizzaProdottiAsync();
        }
        
        public bool Stato_ordine(System.Collections.Generic.List<System.ValueTuple<Client.ServiceReference1.ProdottoManager, int>> carrello, string cod_utente) {
            return base.Channel.Stato_ordine(carrello, cod_utente);
        }
        
        public System.Threading.Tasks.Task<bool> Stato_ordineAsync(System.Collections.Generic.List<System.ValueTuple<Client.ServiceReference1.ProdottoManager, int>> carrello, string cod_utente) {
            return base.Channel.Stato_ordineAsync(carrello, cod_utente);
        }
        
        public bool Aggiungi_credito(double importo, string cod_utente) {
            return base.Channel.Aggiungi_credito(importo, cod_utente);
        }
        
        public System.Threading.Tasks.Task<bool> Aggiungi_creditoAsync(double importo, string cod_utente) {
            return base.Channel.Aggiungi_creditoAsync(importo, cod_utente);
        }
        
        public System.Collections.Generic.List<Client.ServiceReference1.VenditeManager> Storico_ordini(string cod_utente) {
            return base.Channel.Storico_ordini(cod_utente);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Client.ServiceReference1.VenditeManager>> Storico_ordiniAsync(string cod_utente) {
            return base.Channel.Storico_ordiniAsync(cod_utente);
        }
        
        public bool Aggiungi_prodotto(Client.ServiceReference1.ProdottoManager p) {
            return base.Channel.Aggiungi_prodotto(p);
        }
        
        public System.Threading.Tasks.Task<bool> Aggiungi_prodottoAsync(Client.ServiceReference1.ProdottoManager p) {
            return base.Channel.Aggiungi_prodottoAsync(p);
        }
        
        public bool Rimozione_prodotto(Client.ServiceReference1.ProdottoManager p) {
            return base.Channel.Rimozione_prodotto(p);
        }
        
        public System.Threading.Tasks.Task<bool> Rimozione_prodottoAsync(Client.ServiceReference1.ProdottoManager p) {
            return base.Channel.Rimozione_prodottoAsync(p);
        }
        
        public System.Collections.Generic.List<Client.ServiceReference1.VenditeManager> Storico_vendite(string cod_utente) {
            return base.Channel.Storico_vendite(cod_utente);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Client.ServiceReference1.VenditeManager>> Storico_venditeAsync(string cod_utente) {
            return base.Channel.Storico_venditeAsync(cod_utente);
        }
        
        public bool Aggiungi_quantita(int quantita, int codice) {
            return base.Channel.Aggiungi_quantita(quantita, codice);
        }
        
        public System.Threading.Tasks.Task<bool> Aggiungi_quantitaAsync(int quantita, int codice) {
            return base.Channel.Aggiungi_quantitaAsync(quantita, codice);
        }
        
        public Client.ServiceReference1.UtenteManager Visualizza_dati(string cod_utente) {
            return base.Channel.Visualizza_dati(cod_utente);
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.UtenteManager> Visualizza_datiAsync(string cod_utente) {
            return base.Channel.Visualizza_datiAsync(cod_utente);
        }
        
        public System.Collections.Generic.List<Client.ServiceReference1.UtenteManager> VisualizzaUtenti() {
            return base.Channel.VisualizzaUtenti();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Client.ServiceReference1.UtenteManager>> VisualizzaUtentiAsync() {
            return base.Channel.VisualizzaUtentiAsync();
        }
        
        public bool Rimozione_utente(string cod_utente) {
            return base.Channel.Rimozione_utente(cod_utente);
        }
        
        public System.Threading.Tasks.Task<bool> Rimozione_utenteAsync(string cod_utente) {
            return base.Channel.Rimozione_utenteAsync(cod_utente);
        }
    }
}
