﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment_4_5.EncryptDecryptServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/EncryptDecryptService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EncryptDecryptServiceRef.IEncryptDecryptService")]
    public interface IEncryptDecryptService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEncryptDecryptService/decryptString", ReplyAction="http://tempuri.org/IEncryptDecryptService/decryptStringResponse")]
        string decryptString(string data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEncryptDecryptService/decryptString", ReplyAction="http://tempuri.org/IEncryptDecryptService/decryptStringResponse")]
        System.Threading.Tasks.Task<string> decryptStringAsync(string data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEncryptDecryptService/encryptString", ReplyAction="http://tempuri.org/IEncryptDecryptService/encryptStringResponse")]
        string encryptString(string data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEncryptDecryptService/encryptString", ReplyAction="http://tempuri.org/IEncryptDecryptService/encryptStringResponse")]
        System.Threading.Tasks.Task<string> encryptStringAsync(string data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEncryptDecryptService/GetData", ReplyAction="http://tempuri.org/IEncryptDecryptService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEncryptDecryptService/GetData", ReplyAction="http://tempuri.org/IEncryptDecryptService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEncryptDecryptService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IEncryptDecryptService/GetDataUsingDataContractResponse")]
        Assignment_4_5.EncryptDecryptServiceRef.CompositeType GetDataUsingDataContract(Assignment_4_5.EncryptDecryptServiceRef.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEncryptDecryptService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IEncryptDecryptService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<Assignment_4_5.EncryptDecryptServiceRef.CompositeType> GetDataUsingDataContractAsync(Assignment_4_5.EncryptDecryptServiceRef.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEncryptDecryptServiceChannel : Assignment_4_5.EncryptDecryptServiceRef.IEncryptDecryptService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EncryptDecryptServiceClient : System.ServiceModel.ClientBase<Assignment_4_5.EncryptDecryptServiceRef.IEncryptDecryptService>, Assignment_4_5.EncryptDecryptServiceRef.IEncryptDecryptService {
        
        public EncryptDecryptServiceClient() {
        }
        
        public EncryptDecryptServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EncryptDecryptServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EncryptDecryptServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EncryptDecryptServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string decryptString(string data) {
            return base.Channel.decryptString(data);
        }
        
        public System.Threading.Tasks.Task<string> decryptStringAsync(string data) {
            return base.Channel.decryptStringAsync(data);
        }
        
        public string encryptString(string data) {
            return base.Channel.encryptString(data);
        }
        
        public System.Threading.Tasks.Task<string> encryptStringAsync(string data) {
            return base.Channel.encryptStringAsync(data);
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public Assignment_4_5.EncryptDecryptServiceRef.CompositeType GetDataUsingDataContract(Assignment_4_5.EncryptDecryptServiceRef.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<Assignment_4_5.EncryptDecryptServiceRef.CompositeType> GetDataUsingDataContractAsync(Assignment_4_5.EncryptDecryptServiceRef.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}
