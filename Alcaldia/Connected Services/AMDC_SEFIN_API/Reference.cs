﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alcaldia.AMDC_SEFIN_API {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AMDC_SEFIN_API.AMDC_SEFINSoap")]
    public interface AMDC_SEFINSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento token del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Enviar_SEFIN", ReplyAction="*")]
        Alcaldia.AMDC_SEFIN_API.Enviar_SEFINResponse Enviar_SEFIN(Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Enviar_SEFIN", ReplyAction="*")]
        System.Threading.Tasks.Task<Alcaldia.AMDC_SEFIN_API.Enviar_SEFINResponse> Enviar_SEFINAsync(Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Enviar_SEFINRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Enviar_SEFIN", Namespace="http://tempuri.org/", Order=0)]
        public Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequestBody Body;
        
        public Enviar_SEFINRequest() {
        }
        
        public Enviar_SEFINRequest(Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Enviar_SEFINRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string token;
        
        public Enviar_SEFINRequestBody() {
        }
        
        public Enviar_SEFINRequestBody(string token) {
            this.token = token;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Enviar_SEFINResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Enviar_SEFINResponse", Namespace="http://tempuri.org/", Order=0)]
        public Alcaldia.AMDC_SEFIN_API.Enviar_SEFINResponseBody Body;
        
        public Enviar_SEFINResponse() {
        }
        
        public Enviar_SEFINResponse(Alcaldia.AMDC_SEFIN_API.Enviar_SEFINResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Enviar_SEFINResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string Enviar_SEFINResult;
        
        public Enviar_SEFINResponseBody() {
        }
        
        public Enviar_SEFINResponseBody(string Enviar_SEFINResult) {
            this.Enviar_SEFINResult = Enviar_SEFINResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AMDC_SEFINSoapChannel : Alcaldia.AMDC_SEFIN_API.AMDC_SEFINSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AMDC_SEFINSoapClient : System.ServiceModel.ClientBase<Alcaldia.AMDC_SEFIN_API.AMDC_SEFINSoap>, Alcaldia.AMDC_SEFIN_API.AMDC_SEFINSoap {
        
        public AMDC_SEFINSoapClient() {
        }
        
        public AMDC_SEFINSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AMDC_SEFINSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AMDC_SEFINSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AMDC_SEFINSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Alcaldia.AMDC_SEFIN_API.Enviar_SEFINResponse Alcaldia.AMDC_SEFIN_API.AMDC_SEFINSoap.Enviar_SEFIN(Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequest request) {
            return base.Channel.Enviar_SEFIN(request);
        }
        
        public string Enviar_SEFIN(string token) {
            Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequest inValue = new Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequest();
            inValue.Body = new Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequestBody();
            inValue.Body.token = token;
            Alcaldia.AMDC_SEFIN_API.Enviar_SEFINResponse retVal = ((Alcaldia.AMDC_SEFIN_API.AMDC_SEFINSoap)(this)).Enviar_SEFIN(inValue);
            return retVal.Body.Enviar_SEFINResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Alcaldia.AMDC_SEFIN_API.Enviar_SEFINResponse> Alcaldia.AMDC_SEFIN_API.AMDC_SEFINSoap.Enviar_SEFINAsync(Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequest request) {
            return base.Channel.Enviar_SEFINAsync(request);
        }
        
        public System.Threading.Tasks.Task<Alcaldia.AMDC_SEFIN_API.Enviar_SEFINResponse> Enviar_SEFINAsync(string token) {
            Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequest inValue = new Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequest();
            inValue.Body = new Alcaldia.AMDC_SEFIN_API.Enviar_SEFINRequestBody();
            inValue.Body.token = token;
            return ((Alcaldia.AMDC_SEFIN_API.AMDC_SEFINSoap)(this)).Enviar_SEFINAsync(inValue);
        }
    }
}
