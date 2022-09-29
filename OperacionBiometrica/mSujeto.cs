using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace OperacionBiometrica
{
    [DataContract]
    public class mSujeto
    {
        private string _idNeuro;
        private string _Nombre;
        private string _Apellido;
        private string _Identificacion;
        private string _Edad;        
        private string _Sexo;
        [DataMember]
        public string IdNeuro
        {
            get
            {
                return _idNeuro;
            }

            set
            {
                _idNeuro = value;
            }
        }
        [DataMember]
        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }
        [DataMember]
        public string Apellido
        {
            get
            {
                return _Apellido;
            }

            set
            {
                _Apellido = value;
            }
        }
        [DataMember]
        public string NoIdentificacion
        {
            get
            {
                return _Identificacion;
            }

            set
            {
                _Identificacion = value;
            }
        }
        [DataMember]
        public string Edad
        {
            get
            {
                return _Edad;
            }

            set
            {
                _Edad = value;
            }
        }
        [DataMember]
        public string Sexo
        {
            get
            {
                return _Sexo;
            }

            set
            {
                _Sexo = value;
            }
        }

        public mSujeto(string idneuro)
        {
            _idNeuro = idneuro;
            _Identificacion = idneuro.Substring(0, idneuro.LastIndexOf("+"));
        }

    }
}