using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LDWebApp.Model
{
    public class Evangelho
    {
        [JsonProperty("referencia")]
        public string Reference { get; set; }
        [JsonProperty("titulo")]
        public string Title { get; set; }
        [JsonProperty("texto")]
        public string Text { get; set; }
    }
}