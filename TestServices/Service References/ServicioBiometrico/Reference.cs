﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestServices.ServicioBiometrico {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OperacionesComunes.FormatoArchivo", Namespace="http://schemas.datacontract.org/2004/07/OperacionBiometrica")]
    public enum OperacionesComunesFormatoArchivo : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PLANTILLA = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BMP = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        JPG = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PNG = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TIFF = 4,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OperacionesComunes.TipoArchivo", Namespace="http://schemas.datacontract.org/2004/07/OperacionBiometrica")]
    public enum OperacionesComunesTipoArchivo : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ROSTRO = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IRIS_IZ = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IRIS_ID = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Respuesta", Namespace="http://schemas.datacontract.org/2004/07/OperacionBiometrica")]
    [System.SerializableAttribute()]
    public partial class Respuesta : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ErroresField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ResultadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestServices.ServicioBiometrico.mSujeto SujetoField;
        
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
        public string[] Errores {
            get {
                return this.ErroresField;
            }
            set {
                if ((object.ReferenceEquals(this.ErroresField, value) != true)) {
                    this.ErroresField = value;
                    this.RaisePropertyChanged("Errores");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Resultado {
            get {
                return this.ResultadoField;
            }
            set {
                if ((this.ResultadoField.Equals(value) != true)) {
                    this.ResultadoField = value;
                    this.RaisePropertyChanged("Resultado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TestServices.ServicioBiometrico.mSujeto Sujeto {
            get {
                return this.SujetoField;
            }
            set {
                if ((object.ReferenceEquals(this.SujetoField, value) != true)) {
                    this.SujetoField = value;
                    this.RaisePropertyChanged("Sujeto");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="mSujeto", Namespace="http://schemas.datacontract.org/2004/07/OperacionBiometrica")]
    [System.SerializableAttribute()]
    public partial class mSujeto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EdadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdNeuroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NoIdentificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SexoField;
        
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
        public string Apellido {
            get {
                return this.ApellidoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoField, value) != true)) {
                    this.ApellidoField = value;
                    this.RaisePropertyChanged("Apellido");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Edad {
            get {
                return this.EdadField;
            }
            set {
                if ((object.ReferenceEquals(this.EdadField, value) != true)) {
                    this.EdadField = value;
                    this.RaisePropertyChanged("Edad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IdNeuro {
            get {
                return this.IdNeuroField;
            }
            set {
                if ((object.ReferenceEquals(this.IdNeuroField, value) != true)) {
                    this.IdNeuroField = value;
                    this.RaisePropertyChanged("IdNeuro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NoIdentificacion {
            get {
                return this.NoIdentificacionField;
            }
            set {
                if ((object.ReferenceEquals(this.NoIdentificacionField, value) != true)) {
                    this.NoIdentificacionField = value;
                    this.RaisePropertyChanged("NoIdentificacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sexo {
            get {
                return this.SexoField;
            }
            set {
                if ((object.ReferenceEquals(this.SexoField, value) != true)) {
                    this.SexoField = value;
                    this.RaisePropertyChanged("Sexo");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioBiometrico.IOperacioBiometrica")]
    public interface IOperacioBiometrica {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperacioBiometrica/Identifiacion", ReplyAction="http://tempuri.org/IOperacioBiometrica/IdentifiacionResponse")]
        TestServices.ServicioBiometrico.Respuesta Identifiacion(byte[] datos, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperacioBiometrica/Identifiacion", ReplyAction="http://tempuri.org/IOperacioBiometrica/IdentifiacionResponse")]
        System.Threading.Tasks.Task<TestServices.ServicioBiometrico.Respuesta> IdentifiacionAsync(byte[] datos, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperacioBiometrica/Verificar", ReplyAction="http://tempuri.org/IOperacioBiometrica/VerificarResponse")]
        TestServices.ServicioBiometrico.Respuesta Verificar(byte[] datos, string datosBasicosJson, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperacioBiometrica/Verificar", ReplyAction="http://tempuri.org/IOperacioBiometrica/VerificarResponse")]
        System.Threading.Tasks.Task<TestServices.ServicioBiometrico.Respuesta> VerificarAsync(byte[] datos, string datosBasicosJson, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperacioBiometrica/Enrollar", ReplyAction="http://tempuri.org/IOperacioBiometrica/EnrollarResponse")]
        TestServices.ServicioBiometrico.Respuesta Enrollar(byte[] datos, string datosBasicosJson, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperacioBiometrica/Enrollar", ReplyAction="http://tempuri.org/IOperacioBiometrica/EnrollarResponse")]
        System.Threading.Tasks.Task<TestServices.ServicioBiometrico.Respuesta> EnrollarAsync(byte[] datos, string datosBasicosJson, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperacioBiometrica/test", ReplyAction="http://tempuri.org/IOperacioBiometrica/testResponse")]
        TestServices.ServicioBiometrico.Respuesta test();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperacioBiometrica/test", ReplyAction="http://tempuri.org/IOperacioBiometrica/testResponse")]
        System.Threading.Tasks.Task<TestServices.ServicioBiometrico.Respuesta> testAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOperacioBiometricaChannel : TestServices.ServicioBiometrico.IOperacioBiometrica, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OperacioBiometricaClient : System.ServiceModel.ClientBase<TestServices.ServicioBiometrico.IOperacioBiometrica>, TestServices.ServicioBiometrico.IOperacioBiometrica {
        
        public OperacioBiometricaClient() {
        }
        
        public OperacioBiometricaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OperacioBiometricaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperacioBiometricaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperacioBiometricaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TestServices.ServicioBiometrico.Respuesta Identifiacion(byte[] datos, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen) {
            return base.Channel.Identifiacion(datos, fomatoimagen, tipoImagen);
        }
        
        public System.Threading.Tasks.Task<TestServices.ServicioBiometrico.Respuesta> IdentifiacionAsync(byte[] datos, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen) {
            return base.Channel.IdentifiacionAsync(datos, fomatoimagen, tipoImagen);
        }
        
        public TestServices.ServicioBiometrico.Respuesta Verificar(byte[] datos, string datosBasicosJson, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen) {
            return base.Channel.Verificar(datos, datosBasicosJson, fomatoimagen, tipoImagen);
        }
        
        public System.Threading.Tasks.Task<TestServices.ServicioBiometrico.Respuesta> VerificarAsync(byte[] datos, string datosBasicosJson, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen) {
            return base.Channel.VerificarAsync(datos, datosBasicosJson, fomatoimagen, tipoImagen);
        }
        
        public TestServices.ServicioBiometrico.Respuesta Enrollar(byte[] datos, string datosBasicosJson, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen) {
            return base.Channel.Enrollar(datos, datosBasicosJson, fomatoimagen, tipoImagen);
        }
        
        public System.Threading.Tasks.Task<TestServices.ServicioBiometrico.Respuesta> EnrollarAsync(byte[] datos, string datosBasicosJson, TestServices.ServicioBiometrico.OperacionesComunesFormatoArchivo fomatoimagen, TestServices.ServicioBiometrico.OperacionesComunesTipoArchivo tipoImagen) {
            return base.Channel.EnrollarAsync(datos, datosBasicosJson, fomatoimagen, tipoImagen);
        }
        
        public TestServices.ServicioBiometrico.Respuesta test() {
            return base.Channel.test();
        }
        
        public System.Threading.Tasks.Task<TestServices.ServicioBiometrico.Respuesta> testAsync() {
            return base.Channel.testAsync();
        }
    }
}