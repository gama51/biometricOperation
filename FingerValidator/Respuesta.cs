using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace FingerValidator
{
    [DataContract]
    public class Respuesta
    {
        private bool _state;
        int _codeStatusRequest;
        string _codeDescriptionRequest;
        int _codeComparation;
        string _codeDescription;
        int _score = 0;
        string _operation;

        [DataMember]
        public string Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        [DataMember]
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        [DataMember]
        public int CodeComparation
        {
            get { return _codeComparation; }
            set { _codeComparation = value; }
        }
        
        [DataMember]
        public string CodeComparationDescription
        {
            get { return _codeDescription; }
            set { _codeDescription = value; }
        }
        [DataMember]
        public string CodeDescriptionRequest
        {
            get { return _codeDescriptionRequest; }
            set { _codeDescriptionRequest = value; }
        }
        [DataMember]
        public int CodeStatusRequest
        {
            get { return _codeStatusRequest; }
            set { _codeStatusRequest = value; }
        }
        [DataMember]
        public bool State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}