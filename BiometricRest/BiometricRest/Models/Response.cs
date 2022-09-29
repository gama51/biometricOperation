using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiometricRest.Models
{
    public class Response
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("score")]
        public int score { get; set; }

        [JsonProperty("error",NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

    }
}