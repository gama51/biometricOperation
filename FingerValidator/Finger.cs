using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

namespace FingerValidator
{
    [DataContract]
    public class Finger
    {
        private int _idFinger;
        [DataMember]
        public int IdFinger
        {
            get { return _idFinger; }
            set { _idFinger = value; }
        }
        private string template;
        [DataMember]
        public string Template
        {
            get { return template; }
            set { template = value; }
        }

    }
}