using Banco.Atlantico.Application.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Atlantico.Application.ViewModels
{
    public class CaixaViewModel
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Status")]
        public bool Status { get; set; }
        [JsonProperty("Saldo")]
        public long Saldo { get; set; }
        [JsonProperty("Notas de Dois Reais")]
        public int Dois { get; set; }
        [JsonProperty("Notas de Cinco Reais")]
        public int Cinco { get; set; }
        [JsonProperty("Notas de Dez Reais")]
        public int Dez { get; set; }
        [JsonProperty("Notas de Vinte Reais")]
        public int Vinte { get; set; }
        [JsonProperty("Notas de Cinquenta Reais")]
        public int Cinquenta { get; set; }



    }
}
