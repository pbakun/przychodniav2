﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoctorsView.QueueSystemServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/QueueSystem.Contract.Models")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] RolesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool isActiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool isSendingDataField;
        
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
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
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
        public string[] Roles {
            get {
                return this.RolesField;
            }
            set {
                if ((object.ReferenceEquals(this.RolesField, value) != true)) {
                    this.RolesField = value;
                    this.RaisePropertyChanged("Roles");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool isActive {
            get {
                return this.isActiveField;
            }
            set {
                if ((this.isActiveField.Equals(value) != true)) {
                    this.isActiveField = value;
                    this.RaisePropertyChanged("isActive");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool isSendingData {
            get {
                return this.isSendingDataField;
            }
            set {
                if ((this.isSendingDataField.Equals(value) != true)) {
                    this.isSendingDataField = value;
                    this.RaisePropertyChanged("isSendingData");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="QueueData", Namespace="http://schemas.datacontract.org/2004/07/QueueSystem.Contract")]
    [System.SerializableAttribute()]
    public partial class QueueData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AdditionalMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OwnerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QueueNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string QueueNoMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoomNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimestampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserInitialsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool isBreakField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool isSenderActiveField;
        
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
        public string AdditionalMessage {
            get {
                return this.AdditionalMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.AdditionalMessageField, value) != true)) {
                    this.AdditionalMessageField = value;
                    this.RaisePropertyChanged("AdditionalMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Owner {
            get {
                return this.OwnerField;
            }
            set {
                if ((object.ReferenceEquals(this.OwnerField, value) != true)) {
                    this.OwnerField = value;
                    this.RaisePropertyChanged("Owner");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QueueNo {
            get {
                return this.QueueNoField;
            }
            set {
                if ((this.QueueNoField.Equals(value) != true)) {
                    this.QueueNoField = value;
                    this.RaisePropertyChanged("QueueNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string QueueNoMessage {
            get {
                return this.QueueNoMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.QueueNoMessageField, value) != true)) {
                    this.QueueNoMessageField = value;
                    this.RaisePropertyChanged("QueueNoMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoomNo {
            get {
                return this.RoomNoField;
            }
            set {
                if ((this.RoomNoField.Equals(value) != true)) {
                    this.RoomNoField = value;
                    this.RaisePropertyChanged("RoomNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Timestamp {
            get {
                return this.TimestampField;
            }
            set {
                if ((this.TimestampField.Equals(value) != true)) {
                    this.TimestampField = value;
                    this.RaisePropertyChanged("Timestamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserInitials {
            get {
                return this.UserInitialsField;
            }
            set {
                if ((object.ReferenceEquals(this.UserInitialsField, value) != true)) {
                    this.UserInitialsField = value;
                    this.RaisePropertyChanged("UserInitials");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool isBreak {
            get {
                return this.isBreakField;
            }
            set {
                if ((this.isBreakField.Equals(value) != true)) {
                    this.isBreakField = value;
                    this.RaisePropertyChanged("isBreak");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool isSenderActive {
            get {
                return this.isSenderActiveField;
            }
            set {
                if ((this.isSenderActiveField.Equals(value) != true)) {
                    this.isSenderActiveField = value;
                    this.RaisePropertyChanged("isSenderActive");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="QueueSystem.Contract", ConfigurationName="QueueSystemServiceReference.Contract", CallbackContract=typeof(DoctorsView.QueueSystemServiceReference.ContractCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface Contract {
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/Connect", ReplyAction="QueueSystem.Contract/Contract/ConnectResponse")]
        int Connect(int userId, int roomNo, string userName, bool isSender);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/Connect", ReplyAction="QueueSystem.Contract/Contract/ConnectResponse")]
        System.Threading.Tasks.Task<int> ConnectAsync(int userId, int roomNo, string userName, bool isSender);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="QueueSystem.Contract/Contract/ReceiveQueueNo")]
        void ReceiveQueueNo(int userId, int queueNo, string userInitials);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="QueueSystem.Contract/Contract/ReceiveQueueNo")]
        System.Threading.Tasks.Task ReceiveQueueNoAsync(int userId, int queueNo, string userInitials);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="QueueSystem.Contract/Contract/ReceiveAdditionalMessage")]
        void ReceiveAdditionalMessage(int userId, string additionalMessage);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="QueueSystem.Contract/Contract/ReceiveAdditionalMessage")]
        System.Threading.Tasks.Task ReceiveAdditionalMessageAsync(int userId, string additionalMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/Disconnect", ReplyAction="QueueSystem.Contract/Contract/DisconnectResponse")]
        int Disconnect(int userId, string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/Disconnect", ReplyAction="QueueSystem.Contract/Contract/DisconnectResponse")]
        System.Threading.Tasks.Task<int> DisconnectAsync(int userId, string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/GetQueueData", ReplyAction="QueueSystem.Contract/Contract/GetQueueDataResponse")]
        void GetQueueData(System.Nullable<int> userId, System.Nullable<int> roomNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/GetQueueData", ReplyAction="QueueSystem.Contract/Contract/GetQueueDataResponse")]
        System.Threading.Tasks.Task GetQueueDataAsync(System.Nullable<int> userId, System.Nullable<int> roomNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/Livebit", ReplyAction="QueueSystem.Contract/Contract/LivebitResponse")]
        void Livebit(bool bit);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/Livebit", ReplyAction="QueueSystem.Contract/Contract/LivebitResponse")]
        System.Threading.Tasks.Task LivebitAsync(bool bit);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/CheckUser", ReplyAction="QueueSystem.Contract/Contract/CheckUserResponse")]
        DoctorsView.QueueSystemServiceReference.User CheckUser(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/CheckUser", ReplyAction="QueueSystem.Contract/Contract/CheckUserResponse")]
        System.Threading.Tasks.Task<DoctorsView.QueueSystemServiceReference.User> CheckUserAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/RegisterUser", ReplyAction="QueueSystem.Contract/Contract/RegisterUserResponse")]
        bool RegisterUser(DoctorsView.QueueSystemServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="QueueSystem.Contract/Contract/RegisterUser", ReplyAction="QueueSystem.Contract/Contract/RegisterUserResponse")]
        System.Threading.Tasks.Task<bool> RegisterUserAsync(DoctorsView.QueueSystemServiceReference.User user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ContractCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="QueueSystem.Contract/Contract/NotifyOfEstablishedConnection")]
        void NotifyOfEstablishedConnection(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="QueueSystem.Contract/Contract/NotifyOfReceivedQueueNo")]
        void NotifyOfReceivedQueueNo(string queueNo);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="QueueSystem.Contract/Contract/NotifyOfReceivedAdditionalMessage")]
        void NotifyOfReceivedAdditionalMessage(string additionalMessage);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="QueueSystem.Contract/Contract/NotifyClientDisconnected")]
        void NotifyClientDisconnected(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="QueueSystem.Contract/Contract/NotifyClientWithQueueData")]
        void NotifyClientWithQueueData(DoctorsView.QueueSystemServiceReference.QueueData queue);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="QueueSystem.Contract/Contract/NotifyServerAlive")]
        void NotifyServerAlive();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ContractChannel : DoctorsView.QueueSystemServiceReference.Contract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ContractClient : System.ServiceModel.DuplexClientBase<DoctorsView.QueueSystemServiceReference.Contract>, DoctorsView.QueueSystemServiceReference.Contract {
        
        public ContractClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ContractClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int Connect(int userId, int roomNo, string userName, bool isSender) {
            return base.Channel.Connect(userId, roomNo, userName, isSender);
        }
        
        public System.Threading.Tasks.Task<int> ConnectAsync(int userId, int roomNo, string userName, bool isSender) {
            return base.Channel.ConnectAsync(userId, roomNo, userName, isSender);
        }
        
        public void ReceiveQueueNo(int userId, int queueNo, string userInitials) {
            base.Channel.ReceiveQueueNo(userId, queueNo, userInitials);
        }
        
        public System.Threading.Tasks.Task ReceiveQueueNoAsync(int userId, int queueNo, string userInitials) {
            return base.Channel.ReceiveQueueNoAsync(userId, queueNo, userInitials);
        }
        
        public void ReceiveAdditionalMessage(int userId, string additionalMessage) {
            base.Channel.ReceiveAdditionalMessage(userId, additionalMessage);
        }
        
        public System.Threading.Tasks.Task ReceiveAdditionalMessageAsync(int userId, string additionalMessage) {
            return base.Channel.ReceiveAdditionalMessageAsync(userId, additionalMessage);
        }
        
        public int Disconnect(int userId, string userName) {
            return base.Channel.Disconnect(userId, userName);
        }
        
        public System.Threading.Tasks.Task<int> DisconnectAsync(int userId, string userName) {
            return base.Channel.DisconnectAsync(userId, userName);
        }
        
        public void GetQueueData(System.Nullable<int> userId, System.Nullable<int> roomNo) {
            base.Channel.GetQueueData(userId, roomNo);
        }
        
        public System.Threading.Tasks.Task GetQueueDataAsync(System.Nullable<int> userId, System.Nullable<int> roomNo) {
            return base.Channel.GetQueueDataAsync(userId, roomNo);
        }
        
        public void Livebit(bool bit) {
            base.Channel.Livebit(bit);
        }
        
        public System.Threading.Tasks.Task LivebitAsync(bool bit) {
            return base.Channel.LivebitAsync(bit);
        }
        
        public DoctorsView.QueueSystemServiceReference.User CheckUser(string username, string password) {
            return base.Channel.CheckUser(username, password);
        }
        
        public System.Threading.Tasks.Task<DoctorsView.QueueSystemServiceReference.User> CheckUserAsync(string username, string password) {
            return base.Channel.CheckUserAsync(username, password);
        }
        
        public bool RegisterUser(DoctorsView.QueueSystemServiceReference.User user) {
            return base.Channel.RegisterUser(user);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterUserAsync(DoctorsView.QueueSystemServiceReference.User user) {
            return base.Channel.RegisterUserAsync(user);
        }
    }
}
