using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace OperacionBiometrica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOperacioBiometrica
    {
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]        
        Respuesta Identifiacion(byte[] datos,OperacionesComunes.FormatoArchivo fomatoimagen,OperacionesComunes.TipoArchivo tipoImagen);
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        Respuesta Verificar(byte[] datos, string datosBasicosJson, OperacionesComunes.FormatoArchivo fomatoimagen, OperacionesComunes.TipoArchivo tipoImagen);
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        Respuesta Enrollar(byte[] datos, string datosBasicosJson, OperacionesComunes.FormatoArchivo fomatoimagen, OperacionesComunes.TipoArchivo tipoImagen);
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, Method ="POST")]
        [OperationContract]
        Respuesta test();


        // TODO: agregue aquí sus operaciones de servicio
    }


   
}
