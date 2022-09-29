using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Json;

namespace OperacionBiometrica
{

    

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class OperacionBiometrica : IOperacioBiometrica
    {
        static OperacionesNeuro _operacionesNeuro;

        public Respuesta Enrollar(byte[] imagen, string datosBasicosJson, OperacionesComunes.FormatoArchivo fomratoimagen, OperacionesComunes.TipoArchivo tipoImagen)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(mSujeto));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(datosBasicosJson));
            mSujeto datosBasicos = (mSujeto)ser.ReadObject(ms);            
            _operacionesNeuro = OperacionesNeuro.Instancia;
            return _operacionesNeuro.Enrolar(datosBasicos, fomratoimagen, imagen,tipoImagen);

        }

        public Respuesta Identifiacion(byte[] imagen, OperacionesComunes.FormatoArchivo fomatoimagen, OperacionesComunes.TipoArchivo tipoImagen)
        {
            _operacionesNeuro = OperacionesNeuro.Instancia;
            List<mSujeto> sujetos = null;
            return _operacionesNeuro.Identificar(fomatoimagen, imagen,tipoImagen, out sujetos);
        
        }

        public Respuesta test()
        {
            Respuesta r = new Respuesta();
            return r;
        }

        public Respuesta Verificar(byte[] datos, string datosBasicosJson, OperacionesComunes.FormatoArchivo fomatoimagen, OperacionesComunes.TipoArchivo tipoImagen)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(mSujeto));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(datosBasicosJson));
            mSujeto datosBasicos = (mSujeto)ser.ReadObject(ms);
            _operacionesNeuro = OperacionesNeuro.Instancia;
            return _operacionesNeuro.Verify(datosBasicos, fomatoimagen, datos, tipoImagen);
        }
    }
}
