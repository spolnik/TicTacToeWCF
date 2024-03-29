﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CircleCrossGame.TicTacToeServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/TicTacToeEngine.Game")]
    [System.SerializableAttribute()]
    public partial class Player : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CircleCrossGame.TicTacToeServiceReference.Sign PlayerSignField;
        
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CircleCrossGame.TicTacToeServiceReference.Sign PlayerSign {
            get {
                return this.PlayerSignField;
            }
            set {
                if ((this.PlayerSignField.Equals(value) != true)) {
                    this.PlayerSignField = value;
                    this.RaisePropertyChanged("PlayerSign");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Sign", Namespace="http://schemas.datacontract.org/2004/07/TicTacToeEngine.Utility")]
    public enum Sign : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        X = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        O = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Field", Namespace="http://schemas.datacontract.org/2004/07/TicTacToeEngine.Utility")]
    public enum Field : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        A1 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        A2 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        A3 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        B1 = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        B2 = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        B3 = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        C1 = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        C2 = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        C3 = 8,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TurnResult", Namespace="http://schemas.datacontract.org/2004/07/TicTacToeEngine.Utility")]
    public enum TurnResult : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Wrong = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Next = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Win = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TicTacToeServiceReference.ITicTacToeService", CallbackContract=typeof(CircleCrossGame.TicTacToeServiceReference.ITicTacToeServiceCallback))]
    public interface ITicTacToeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToeService/Join", ReplyAction="http://tempuri.org/ITicTacToeService/JoinResponse")]
        CircleCrossGame.TicTacToeServiceReference.Player Join();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ITicTacToeService/MakeTurn")]
        void MakeTurn(CircleCrossGame.TicTacToeServiceReference.Sign sign, CircleCrossGame.TicTacToeServiceReference.Field field);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToeService/Subscribe", ReplyAction="http://tempuri.org/ITicTacToeService/SubscribeResponse")]
        bool Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToeService/Unsubscribe", ReplyAction="http://tempuri.org/ITicTacToeService/UnsubscribeResponse")]
        bool Unsubscribe();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITicTacToeServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ITicTacToeService/OnTurnEnd")]
        void OnTurnEnd(CircleCrossGame.TicTacToeServiceReference.TurnResult turnResult, CircleCrossGame.TicTacToeServiceReference.Sign sign, CircleCrossGame.TicTacToeServiceReference.Field field);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITicTacToeServiceChannel : CircleCrossGame.TicTacToeServiceReference.ITicTacToeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TicTacToeServiceClient : System.ServiceModel.DuplexClientBase<CircleCrossGame.TicTacToeServiceReference.ITicTacToeService>, CircleCrossGame.TicTacToeServiceReference.ITicTacToeService {
        
        public TicTacToeServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public TicTacToeServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public TicTacToeServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public TicTacToeServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public TicTacToeServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public CircleCrossGame.TicTacToeServiceReference.Player Join() {
            return base.Channel.Join();
        }
        
        public void MakeTurn(CircleCrossGame.TicTacToeServiceReference.Sign sign, CircleCrossGame.TicTacToeServiceReference.Field field) {
            base.Channel.MakeTurn(sign, field);
        }
        
        public bool Subscribe() {
            return base.Channel.Subscribe();
        }
        
        public bool Unsubscribe() {
            return base.Channel.Unsubscribe();
        }
    }
}
