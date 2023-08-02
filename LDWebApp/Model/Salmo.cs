using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LDWebApp.Model
{
    public class Salmo
    {
        [JsonProperty("referencia")]
        public string Reference { get; set; }
        [JsonProperty("refrao")]
        public string Chorus { get; set; }
        [JsonProperty("texto")]
        public string Text { get; set; }
    }
}