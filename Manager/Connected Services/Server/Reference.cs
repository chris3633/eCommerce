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
    [System.Runtime.Serialization.DataContractAttribute(Name="UtenteServer", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    public partial class UtenteServer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cittaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string codiceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cognomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal creditoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string indirizzoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int tipologiaField;
        
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
        public string citta {
            get {
                return this.cittaField;
            }
            set {
                if ((object.ReferenceEquals(this.cittaField, value) != true)) {
                    this.cittaField = value;
                    this.RaisePropertyChanged("citta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string codice {
            get {
                return this.codiceField;
            }
            set {
                if ((object.ReferenceEquals(this.codiceField, value) != true)) {
                    this.codiceField = value;
                    this.RaisePropertyChanged("codice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string cognome {
            get {
                return this.cognomeField;
            }
            set {
                if ((object.ReferenceEquals(this.cognomeField, value) != true)) {
                    this.cognomeField = value;
                    this.RaisePropertyChanged("cognome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal credito {
            get {
                return this.creditoField;
            }
            set {
                if ((this.creditoField.Equals(value) != true)) {
                    this.creditoField = value;
                    this.RaisePropertyChanged("credito");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string indirizzo {
            get {
                return this.indirizzoField;
            }
            set {
                if ((object.ReferenceEquals(this.indirizzoField, value) != true)) {
                    this.indirizzoField = value;
                    this.RaisePropertyChanged("indirizzo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nome {
            get {
                return this.nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.nomeField, value) != true)) {
                    this.nomeField = value;
                    this.RaisePropertyChanged("nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int tipologia {
            get {
                return this.tipologiaField;
            }
            set {
                if ((this.tipologiaField.Equals(value) != true)) {
                    this.tipologiaField = value;
                    this.RaisePropertyChanged("tipologia");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ProdottoServer", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    public partial class ProdottoServer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string categoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int cod_prodottoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cod_venditoreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descrizioneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string marcaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal prezzoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantitaField;
        
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
        public string categoria {
            get {
                return this.categoriaField;
            }
            set {
                if ((object.ReferenceEquals(this.categoriaField, value) != true)) {
                    this.categoriaField = value;
                    this.RaisePropertyChanged("categoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int cod_prodotto {
            get {
                return this.cod_prodottoField;
            }
            set {
                if ((this.cod_prodottoField.Equals(value) != true)) {
                    this.cod_prodottoField = value;
                    this.RaisePropertyChanged("cod_prodotto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string cod_venditore {
            get {
                return this.cod_venditoreField;
            }
            set {
                if ((object.ReferenceEquals(this.cod_venditoreField, value) != true)) {
                    this.cod_venditoreField = value;
                    this.RaisePropertyChanged("cod_venditore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string descrizione {
            get {
                return this.descrizioneField;
            }
            set {
                if ((object.ReferenceEquals(this.descrizioneField, value) != true)) {
                    this.descrizioneField = value;
                    this.RaisePropertyChanged("descrizione");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string marca {
            get {
                return this.marcaField;
            }
            set {
                if ((object.ReferenceEquals(this.marcaField, value) != true)) {
                    this.marcaField = value;
                    this.RaisePropertyChanged("marca");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nome {
            get {
                return this.nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.nomeField, value) != true)) {
                    this.nomeField = value;
                    this.RaisePropertyChanged("nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal prezzo {
            get {
                return this.prezzoField;
            }
            set {
                if ((this.prezzoField.Equals(value) != true)) {
                    this.prezzoField = value;
                    this.RaisePropertyChanged("prezzo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int quantita {
            get {
                return this.quantitaField;
            }
            set {
                if ((this.quantitaField.Equals(value) != true)) {
                    this.quantitaField = value;
                    this.RaisePropertyChanged("quantita");
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
        Manager.Server.ProdottoServer[] VisualizzaProdotti();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/VisualizzaProdotti", ReplyAction="http://tempuri.org/IServerService/VisualizzaProdottiResponse")]
        System.Threading.Tasks.Task<Manager.Server.ProdottoServer[]> VisualizzaProdottiAsync();
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
        
        public Manager.Server.ProdottoServer[] VisualizzaProdotti() {
            return base.Channel.VisualizzaProdotti();
        }
        
        public System.Threading.Tasks.Task<Manager.Server.ProdottoServer[]> VisualizzaProdottiAsync() {
            return base.Channel.VisualizzaProdottiAsync();
        }
    }
}
