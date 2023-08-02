using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LDWebApp.Model
{
    public class JsonApiLiturgia
    {
        [JsonProperty("data")]
        public string Date { get; set; }
        [JsonProperty("liturgia")]
        public string Liturgy { get; set; }
        [JsonProperty("cor")]
        public string Color { get; set; }
        [JsonProperty("dia")]
        public string Day { get; set; }
        [JsonProperty("oferendas")]
        public string Offers { get; set; }
        [JsonProperty("comunhao")]
        public string Communion { get; set; }
        [JsonProperty("primeiraleitura")]
        public PrimeiraLeitura FirstLecture { get; set; }
        public string segundaLeitura { get; set; }
        public SegundaLeitura SegundaLeitura { get; set; }
        [JsonProperty("salmo")]
        public Salmo Psalm { get; set; }
        [JsonProperty("evangelho")]
        public Evangelho Gospel { get; set; }
    }
}