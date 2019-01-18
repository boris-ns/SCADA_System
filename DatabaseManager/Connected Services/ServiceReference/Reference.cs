﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseManager.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Alarm", Namespace="http://schemas.datacontract.org/2004/07/SCADA_Core")]
    [System.SerializableAttribute()]
    public partial class Alarm : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime alarmDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int alarmIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string alarmNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string alarmTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float highLimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float lowLimitField;
        
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
        public System.DateTime alarmDateTime {
            get {
                return this.alarmDateTimeField;
            }
            set {
                if ((this.alarmDateTimeField.Equals(value) != true)) {
                    this.alarmDateTimeField = value;
                    this.RaisePropertyChanged("alarmDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int alarmId {
            get {
                return this.alarmIdField;
            }
            set {
                if ((this.alarmIdField.Equals(value) != true)) {
                    this.alarmIdField = value;
                    this.RaisePropertyChanged("alarmId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string alarmName {
            get {
                return this.alarmNameField;
            }
            set {
                if ((object.ReferenceEquals(this.alarmNameField, value) != true)) {
                    this.alarmNameField = value;
                    this.RaisePropertyChanged("alarmName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string alarmType {
            get {
                return this.alarmTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.alarmTypeField, value) != true)) {
                    this.alarmTypeField = value;
                    this.RaisePropertyChanged("alarmType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float highLimit {
            get {
                return this.highLimitField;
            }
            set {
                if ((this.highLimitField.Equals(value) != true)) {
                    this.highLimitField = value;
                    this.RaisePropertyChanged("highLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float lowLimit {
            get {
                return this.lowLimitField;
            }
            set {
                if ((this.lowLimitField.Equals(value) != true)) {
                    this.lowLimitField = value;
                    this.RaisePropertyChanged("lowLimit");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ListOfTags", Namespace="http://schemas.datacontract.org/2004/07/SCADA_Core")]
    [System.SerializableAttribute()]
    public partial class ListOfTags : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DatabaseManager.ServiceReference.AnalogInput[] analogInputTagsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DatabaseManager.ServiceReference.AnalogOutput[] analogOutputTagsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DatabaseManager.ServiceReference.DigitalInput[] digitalInputTagsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DatabaseManager.ServiceReference.DigitalOutput[] digitalOutputTagsField;
        
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
        public DatabaseManager.ServiceReference.AnalogInput[] analogInputTags {
            get {
                return this.analogInputTagsField;
            }
            set {
                if ((object.ReferenceEquals(this.analogInputTagsField, value) != true)) {
                    this.analogInputTagsField = value;
                    this.RaisePropertyChanged("analogInputTags");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DatabaseManager.ServiceReference.AnalogOutput[] analogOutputTags {
            get {
                return this.analogOutputTagsField;
            }
            set {
                if ((object.ReferenceEquals(this.analogOutputTagsField, value) != true)) {
                    this.analogOutputTagsField = value;
                    this.RaisePropertyChanged("analogOutputTags");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DatabaseManager.ServiceReference.DigitalInput[] digitalInputTags {
            get {
                return this.digitalInputTagsField;
            }
            set {
                if ((object.ReferenceEquals(this.digitalInputTagsField, value) != true)) {
                    this.digitalInputTagsField = value;
                    this.RaisePropertyChanged("digitalInputTags");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DatabaseManager.ServiceReference.DigitalOutput[] digitalOutputTags {
            get {
                return this.digitalOutputTagsField;
            }
            set {
                if ((object.ReferenceEquals(this.digitalOutputTagsField, value) != true)) {
                    this.digitalOutputTagsField = value;
                    this.RaisePropertyChanged("digitalOutputTags");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="AnalogInput", Namespace="http://schemas.datacontract.org/2004/07/SCADA_Core")]
    [System.SerializableAttribute()]
    public partial class AnalogInput : DatabaseManager.ServiceReference.InputTag {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float highLimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float lowLimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string unitsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float highLimit {
            get {
                return this.highLimitField;
            }
            set {
                if ((this.highLimitField.Equals(value) != true)) {
                    this.highLimitField = value;
                    this.RaisePropertyChanged("highLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float lowLimit {
            get {
                return this.lowLimitField;
            }
            set {
                if ((this.lowLimitField.Equals(value) != true)) {
                    this.lowLimitField = value;
                    this.RaisePropertyChanged("lowLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string units {
            get {
                return this.unitsField;
            }
            set {
                if ((object.ReferenceEquals(this.unitsField, value) != true)) {
                    this.unitsField = value;
                    this.RaisePropertyChanged("units");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AnalogOutput", Namespace="http://schemas.datacontract.org/2004/07/SCADA_Core")]
    [System.SerializableAttribute()]
    public partial class AnalogOutput : DatabaseManager.ServiceReference.OutputTag {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float highLimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float lowLimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string unitsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float highLimit {
            get {
                return this.highLimitField;
            }
            set {
                if ((this.highLimitField.Equals(value) != true)) {
                    this.highLimitField = value;
                    this.RaisePropertyChanged("highLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float lowLimit {
            get {
                return this.lowLimitField;
            }
            set {
                if ((this.lowLimitField.Equals(value) != true)) {
                    this.lowLimitField = value;
                    this.RaisePropertyChanged("lowLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string units {
            get {
                return this.unitsField;
            }
            set {
                if ((object.ReferenceEquals(this.unitsField, value) != true)) {
                    this.unitsField = value;
                    this.RaisePropertyChanged("units");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DigitalInput", Namespace="http://schemas.datacontract.org/2004/07/SCADA_Core")]
    [System.SerializableAttribute()]
    public partial class DigitalInput : DatabaseManager.ServiceReference.InputTag {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DigitalOutput", Namespace="http://schemas.datacontract.org/2004/07/SCADA_Core")]
    [System.SerializableAttribute()]
    public partial class DigitalOutput : DatabaseManager.ServiceReference.OutputTag {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tag", Namespace="http://schemas.datacontract.org/2004/07/SCADA_Core")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DatabaseManager.ServiceReference.OutputTag))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DatabaseManager.ServiceReference.AnalogOutput))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DatabaseManager.ServiceReference.DigitalOutput))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DatabaseManager.ServiceReference.InputTag))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DatabaseManager.ServiceReference.DigitalInput))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DatabaseManager.ServiceReference.AnalogInput))]
    public partial class Tag : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string driverField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ioAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tagNameField;
        
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
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.descriptionField, value) != true)) {
                    this.descriptionField = value;
                    this.RaisePropertyChanged("description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string driver {
            get {
                return this.driverField;
            }
            set {
                if ((object.ReferenceEquals(this.driverField, value) != true)) {
                    this.driverField = value;
                    this.RaisePropertyChanged("driver");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ioAddress {
            get {
                return this.ioAddressField;
            }
            set {
                if ((this.ioAddressField.Equals(value) != true)) {
                    this.ioAddressField = value;
                    this.RaisePropertyChanged("ioAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tagName {
            get {
                return this.tagNameField;
            }
            set {
                if ((object.ReferenceEquals(this.tagNameField, value) != true)) {
                    this.tagNameField = value;
                    this.RaisePropertyChanged("tagName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="OutputTag", Namespace="http://schemas.datacontract.org/2004/07/SCADA_Core")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DatabaseManager.ServiceReference.AnalogOutput))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DatabaseManager.ServiceReference.DigitalOutput))]
    public partial class OutputTag : DatabaseManager.ServiceReference.Tag {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float initValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float initValue {
            get {
                return this.initValueField;
            }
            set {
                if ((this.initValueField.Equals(value) != true)) {
                    this.initValueField = value;
                    this.RaisePropertyChanged("initValue");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InputTag", Namespace="http://schemas.datacontract.org/2004/07/SCADA_Core")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DatabaseManager.ServiceReference.DigitalInput))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DatabaseManager.ServiceReference.AnalogInput))]
    public partial class InputTag : DatabaseManager.ServiceReference.Tag {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DatabaseManager.ServiceReference.Alarm[] alarmsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool enableScanField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool manualModeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float scanTimeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DatabaseManager.ServiceReference.Alarm[] alarms {
            get {
                return this.alarmsField;
            }
            set {
                if ((object.ReferenceEquals(this.alarmsField, value) != true)) {
                    this.alarmsField = value;
                    this.RaisePropertyChanged("alarms");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool enableScan {
            get {
                return this.enableScanField;
            }
            set {
                if ((this.enableScanField.Equals(value) != true)) {
                    this.enableScanField = value;
                    this.RaisePropertyChanged("enableScan");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool manualMode {
            get {
                return this.manualModeField;
            }
            set {
                if ((this.manualModeField.Equals(value) != true)) {
                    this.manualModeField = value;
                    this.RaisePropertyChanged("manualMode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float scanTime {
            get {
                return this.scanTimeField;
            }
            set {
                if ((this.scanTimeField.Equals(value) != true)) {
                    this.scanTimeField = value;
                    this.RaisePropertyChanged("scanTime");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IRealTimeUnit")]
    public interface IRealTimeUnit {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRealTimeUnit/IsRTUNameAvailable", ReplyAction="http://tempuri.org/IRealTimeUnit/IsRTUNameAvailableResponse")]
        bool IsRTUNameAvailable(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRealTimeUnit/IsRTUNameAvailable", ReplyAction="http://tempuri.org/IRealTimeUnit/IsRTUNameAvailableResponse")]
        System.Threading.Tasks.Task<bool> IsRTUNameAvailableAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRealTimeUnit/IsIOAddressAvailable", ReplyAction="http://tempuri.org/IRealTimeUnit/IsIOAddressAvailableResponse")]
        bool IsIOAddressAvailable(int address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRealTimeUnit/IsIOAddressAvailable", ReplyAction="http://tempuri.org/IRealTimeUnit/IsIOAddressAvailableResponse")]
        System.Threading.Tasks.Task<bool> IsIOAddressAvailableAsync(int address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRealTimeUnit/InitRealTimeUnit", ReplyAction="http://tempuri.org/IRealTimeUnit/InitRealTimeUnitResponse")]
        void InitRealTimeUnit(string rtuName, int address, string publicKeyPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRealTimeUnit/InitRealTimeUnit", ReplyAction="http://tempuri.org/IRealTimeUnit/InitRealTimeUnitResponse")]
        System.Threading.Tasks.Task InitRealTimeUnitAsync(string rtuName, int address, string publicKeyPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRealTimeUnit/SendValue", ReplyAction="http://tempuri.org/IRealTimeUnit/SendValueResponse")]
        bool SendValue(string rtuName, string message, byte[] signature);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRealTimeUnit/SendValue", ReplyAction="http://tempuri.org/IRealTimeUnit/SendValueResponse")]
        System.Threading.Tasks.Task<bool> SendValueAsync(string rtuName, string message, byte[] signature);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRealTimeUnitChannel : DatabaseManager.ServiceReference.IRealTimeUnit, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RealTimeUnitClient : System.ServiceModel.ClientBase<DatabaseManager.ServiceReference.IRealTimeUnit>, DatabaseManager.ServiceReference.IRealTimeUnit {
        
        public RealTimeUnitClient() {
        }
        
        public RealTimeUnitClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RealTimeUnitClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RealTimeUnitClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RealTimeUnitClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsRTUNameAvailable(string name) {
            return base.Channel.IsRTUNameAvailable(name);
        }
        
        public System.Threading.Tasks.Task<bool> IsRTUNameAvailableAsync(string name) {
            return base.Channel.IsRTUNameAvailableAsync(name);
        }
        
        public bool IsIOAddressAvailable(int address) {
            return base.Channel.IsIOAddressAvailable(address);
        }
        
        public System.Threading.Tasks.Task<bool> IsIOAddressAvailableAsync(int address) {
            return base.Channel.IsIOAddressAvailableAsync(address);
        }
        
        public void InitRealTimeUnit(string rtuName, int address, string publicKeyPath) {
            base.Channel.InitRealTimeUnit(rtuName, address, publicKeyPath);
        }
        
        public System.Threading.Tasks.Task InitRealTimeUnitAsync(string rtuName, int address, string publicKeyPath) {
            return base.Channel.InitRealTimeUnitAsync(rtuName, address, publicKeyPath);
        }
        
        public bool SendValue(string rtuName, string message, byte[] signature) {
            return base.Channel.SendValue(rtuName, message, signature);
        }
        
        public System.Threading.Tasks.Task<bool> SendValueAsync(string rtuName, string message, byte[] signature) {
            return base.Channel.SendValueAsync(rtuName, message, signature);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IAlarmDisplay", CallbackContract=typeof(DatabaseManager.ServiceReference.IAlarmDisplayCallback))]
    public interface IAlarmDisplay {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlarmDisplay/AlarmDisplayClientInit", ReplyAction="http://tempuri.org/IAlarmDisplay/AlarmDisplayClientInitResponse")]
        void AlarmDisplayClientInit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlarmDisplay/AlarmDisplayClientInit", ReplyAction="http://tempuri.org/IAlarmDisplay/AlarmDisplayClientInitResponse")]
        System.Threading.Tasks.Task AlarmDisplayClientInitAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlarmDisplayCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlarmDisplay/PrintAlarmsInfo", ReplyAction="http://tempuri.org/IAlarmDisplay/PrintAlarmsInfoResponse")]
        void PrintAlarmsInfo(DatabaseManager.ServiceReference.Alarm[] alarms);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlarmDisplayChannel : DatabaseManager.ServiceReference.IAlarmDisplay, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlarmDisplayClient : System.ServiceModel.DuplexClientBase<DatabaseManager.ServiceReference.IAlarmDisplay>, DatabaseManager.ServiceReference.IAlarmDisplay {
        
        public AlarmDisplayClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public AlarmDisplayClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public AlarmDisplayClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AlarmDisplayClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AlarmDisplayClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void AlarmDisplayClientInit() {
            base.Channel.AlarmDisplayClientInit();
        }
        
        public System.Threading.Tasks.Task AlarmDisplayClientInitAsync() {
            return base.Channel.AlarmDisplayClientInitAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IDatabaseManager")]
    public interface IDatabaseManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetTags", ReplyAction="http://tempuri.org/IDatabaseManager/GetTagsResponse")]
        DatabaseManager.ServiceReference.ListOfTags GetTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetTags", ReplyAction="http://tempuri.org/IDatabaseManager/GetTagsResponse")]
        System.Threading.Tasks.Task<DatabaseManager.ServiceReference.ListOfTags> GetTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDigitalInput", ReplyAction="http://tempuri.org/IDatabaseManager/AddDigitalInputResponse")]
        void AddDigitalInput(string tagName, string description, string driver, int ioAddress, float scanTime, bool enableScan, bool manualMode, DatabaseManager.ServiceReference.Alarm[] alarms);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDigitalInput", ReplyAction="http://tempuri.org/IDatabaseManager/AddDigitalInputResponse")]
        System.Threading.Tasks.Task AddDigitalInputAsync(string tagName, string description, string driver, int ioAddress, float scanTime, bool enableScan, bool manualMode, DatabaseManager.ServiceReference.Alarm[] alarms);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDigitalOutput", ReplyAction="http://tempuri.org/IDatabaseManager/AddDigitalOutputResponse")]
        void AddDigitalOutput(string tagName, string description, string driver, int ioAddress, float initValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDigitalOutput", ReplyAction="http://tempuri.org/IDatabaseManager/AddDigitalOutputResponse")]
        System.Threading.Tasks.Task AddDigitalOutputAsync(string tagName, string description, string driver, int ioAddress, float initValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAnalogInput", ReplyAction="http://tempuri.org/IDatabaseManager/AddAnalogInputResponse")]
        void AddAnalogInput(string tagName, string description, string driver, int ioAddress, float scanTime, bool enableScan, bool manualMode, float lowLimit, float highLimit, string units, DatabaseManager.ServiceReference.Alarm[] alarms);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAnalogInput", ReplyAction="http://tempuri.org/IDatabaseManager/AddAnalogInputResponse")]
        System.Threading.Tasks.Task AddAnalogInputAsync(string tagName, string description, string driver, int ioAddress, float scanTime, bool enableScan, bool manualMode, float lowLimit, float highLimit, string units, DatabaseManager.ServiceReference.Alarm[] alarms);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAnalogOutput", ReplyAction="http://tempuri.org/IDatabaseManager/AddAnalogOutputResponse")]
        void AddAnalogOutput(string tagName, string description, string driver, int ioAddress, float initValue, float lowLimit, float highLimit, string units);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAnalogOutput", ReplyAction="http://tempuri.org/IDatabaseManager/AddAnalogOutputResponse")]
        System.Threading.Tasks.Task AddAnalogOutputAsync(string tagName, string description, string driver, int ioAddress, float initValue, float lowLimit, float highLimit, string units);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/RemoveTag", ReplyAction="http://tempuri.org/IDatabaseManager/RemoveTagResponse")]
        void RemoveTag(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/RemoveTag", ReplyAction="http://tempuri.org/IDatabaseManager/RemoveTagResponse")]
        System.Threading.Tasks.Task RemoveTagAsync(string tagName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDatabaseManagerChannel : DatabaseManager.ServiceReference.IDatabaseManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DatabaseManagerClient : System.ServiceModel.ClientBase<DatabaseManager.ServiceReference.IDatabaseManager>, DatabaseManager.ServiceReference.IDatabaseManager {
        
        public DatabaseManagerClient() {
        }
        
        public DatabaseManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DatabaseManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DatabaseManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DatabaseManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DatabaseManager.ServiceReference.ListOfTags GetTags() {
            return base.Channel.GetTags();
        }
        
        public System.Threading.Tasks.Task<DatabaseManager.ServiceReference.ListOfTags> GetTagsAsync() {
            return base.Channel.GetTagsAsync();
        }
        
        public void AddDigitalInput(string tagName, string description, string driver, int ioAddress, float scanTime, bool enableScan, bool manualMode, DatabaseManager.ServiceReference.Alarm[] alarms) {
            base.Channel.AddDigitalInput(tagName, description, driver, ioAddress, scanTime, enableScan, manualMode, alarms);
        }
        
        public System.Threading.Tasks.Task AddDigitalInputAsync(string tagName, string description, string driver, int ioAddress, float scanTime, bool enableScan, bool manualMode, DatabaseManager.ServiceReference.Alarm[] alarms) {
            return base.Channel.AddDigitalInputAsync(tagName, description, driver, ioAddress, scanTime, enableScan, manualMode, alarms);
        }
        
        public void AddDigitalOutput(string tagName, string description, string driver, int ioAddress, float initValue) {
            base.Channel.AddDigitalOutput(tagName, description, driver, ioAddress, initValue);
        }
        
        public System.Threading.Tasks.Task AddDigitalOutputAsync(string tagName, string description, string driver, int ioAddress, float initValue) {
            return base.Channel.AddDigitalOutputAsync(tagName, description, driver, ioAddress, initValue);
        }
        
        public void AddAnalogInput(string tagName, string description, string driver, int ioAddress, float scanTime, bool enableScan, bool manualMode, float lowLimit, float highLimit, string units, DatabaseManager.ServiceReference.Alarm[] alarms) {
            base.Channel.AddAnalogInput(tagName, description, driver, ioAddress, scanTime, enableScan, manualMode, lowLimit, highLimit, units, alarms);
        }
        
        public System.Threading.Tasks.Task AddAnalogInputAsync(string tagName, string description, string driver, int ioAddress, float scanTime, bool enableScan, bool manualMode, float lowLimit, float highLimit, string units, DatabaseManager.ServiceReference.Alarm[] alarms) {
            return base.Channel.AddAnalogInputAsync(tagName, description, driver, ioAddress, scanTime, enableScan, manualMode, lowLimit, highLimit, units, alarms);
        }
        
        public void AddAnalogOutput(string tagName, string description, string driver, int ioAddress, float initValue, float lowLimit, float highLimit, string units) {
            base.Channel.AddAnalogOutput(tagName, description, driver, ioAddress, initValue, lowLimit, highLimit, units);
        }
        
        public System.Threading.Tasks.Task AddAnalogOutputAsync(string tagName, string description, string driver, int ioAddress, float initValue, float lowLimit, float highLimit, string units) {
            return base.Channel.AddAnalogOutputAsync(tagName, description, driver, ioAddress, initValue, lowLimit, highLimit, units);
        }
        
        public void RemoveTag(string tagName) {
            base.Channel.RemoveTag(tagName);
        }
        
        public System.Threading.Tasks.Task RemoveTagAsync(string tagName) {
            return base.Channel.RemoveTagAsync(tagName);
        }
    }
}
