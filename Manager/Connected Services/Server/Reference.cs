﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Manager.Server {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Persona", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Manager.Server.UtenteServer))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="UtenteServer", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    public partial class UtenteServer : Manager.Server.Persona {
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ProdottoServer", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    public partial class ProdottoServer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Server.IServerService")]
    public interface IServerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/DoWork", ReplyAction="http://tempuri.org/IServerService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/DoWork", ReplyAction="http://tempuri.org/IServerService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/Registra", ReplyAction="http://tempuri.org/IServerService/RegistraResponse")]
        bool Registra(Manager.Server.UtenteServer u2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/Registra", ReplyAction="http://tempuri.org/IServerService/RegistraResponse")]
        System.Threading.Tasks.Task<bool> RegistraAsync(Manager.Server.UtenteServer u2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/Controlla_credenziali", ReplyAction="http://tempuri.org/IServerService/Controlla_credenzialiResponse")]
        bool Controlla_credenziali(string e, string p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/Controlla_credenziali", ReplyAction="http://tempuri.org/IServerService/Controlla_credenzialiResponse")]
        System.Threading.Tasks.Task<bool> Controlla_credenzialiAsync(string e, string p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/Accedi", ReplyAction="http://tempuri.org/IServerService/AccediResponse")]
        Manager.Server.UtenteServer Accedi(string e, string p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/Accedi", ReplyAction="http://tempuri.org/IServerService/AccediResponse")]
        System.Threading.Tasks.Task<Manager.Server.UtenteServer> AccediAsync(string e, string p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/VisualizzaProdotti", ReplyAction="http://tempuri.org/IServerService/VisualizzaProdottiResponse")]
        System.Collections.Generic.List<Manager.Server.ProdottoServer> VisualizzaProdotti();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/VisualizzaProdotti", ReplyAction="http://tempuri.org/IServerService/VisualizzaProdottiResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Manager.Server.ProdottoServer>> VisualizzaProdottiAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/Stato_ordine", ReplyAction="http://tempuri.org/IServerService/Stato_ordineResponse")]
        bool Stato_ordine(System.Collections.Generic.Dictionary<int, Manager.Server.ProdottoServer> carrello, string cod_utente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/Stato_ordine", ReplyAction="http://tempuri.org/IServerService/Stato_ordineResponse")]
        System.Threading.Tasks.Task<bool> Stato_ordineAsync(System.Collections.Generic.Dictionary<int, Manager.Server.ProdottoServer> carrello, string cod_utente);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerServiceChannel : Manager.Server.IServerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerServiceClient : System.ServiceModel.ClientBase<Manager.Server.IServerService>, Manager.Server.IServerService {
        
        public ServerServiceClient() {
        }
        
        public ServerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public bool Registra(Manager.Server.UtenteServer u2) {
            return base.Channel.Registra(u2);
        }
        
        public System.Threading.Tasks.Task<bool> RegistraAsync(Manager.Server.UtenteServer u2) {
            return base.Channel.RegistraAsync(u2);
        }
        
        public bool Controlla_credenziali(string e, string p) {
            return base.Channel.Controlla_credenziali(e, p);
        }
        
        public System.Threading.Tasks.Task<bool> Controlla_credenzialiAsync(string e, string p) {
            return base.Channel.Controlla_credenzialiAsync(e, p);
        }
        
        public Manager.Server.UtenteServer Accedi(string e, string p) {
            return base.Channel.Accedi(e, p);
        }
        
        public System.Threading.Tasks.Task<Manager.Server.UtenteServer> AccediAsync(string e, string p) {
            return base.Channel.AccediAsync(e, p);
        }
        
        public System.Collections.Generic.List<Manager.Server.ProdottoServer> VisualizzaProdotti() {
            return base.Channel.VisualizzaProdotti();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Manager.Server.ProdottoServer>> VisualizzaProdottiAsync() {
            return base.Channel.VisualizzaProdottiAsync();
        }
        
        public bool Stato_ordine(System.Collections.Generic.Dictionary<int, Manager.Server.ProdottoServer> carrello, string cod_utente) {
            return base.Channel.Stato_ordine(carrello, cod_utente);
        }
        
        public System.Threading.Tasks.Task<bool> Stato_ordineAsync(System.Collections.Generic.Dictionary<int, Manager.Server.ProdottoServer> carrello, string cod_utente) {
            return base.Channel.Stato_ordineAsync(carrello, cod_utente);
        }
    }
}
