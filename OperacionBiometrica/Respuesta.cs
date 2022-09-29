using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace OperacionBiometrica
{
    [DataContract]
    public class Respuesta
    {
        private bool _resultado;
        private mSujeto _Sujeto;
        private List<string> _errores;

        public Respuesta()
        {
            _errores = new List<string>();

        }
        /// <summary>
        /// Resultado de una operación
        /// </summary>
        [DataMember]
        public bool Resultado
        {
            get
            {
                return _resultado;
            }

            set
            {
                _resultado = value;
            }
        }
        [DataMember]
        public mSujeto Sujeto
        {
            get
            {
                return _Sujeto;
            }

            set
            {
                _Sujeto = value;
            }
        }
        [DataMember]
        public List<string> Errores
        {
            get
            {
                
                return _errores;
            }
       }
       

        

    }
}