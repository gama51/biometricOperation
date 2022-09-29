using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiometricRest.Models
{
    public class BiometricRequest
    {
        [JsonProperty("template1")]
        public string SubjectTemplate1 { get; set; }

        [JsonProperty("template2")]
        public string SubjectTemplate2 { get; set; }

        [JsonProperty("umbral")]
        public int umbral { get; set; }
    }
}