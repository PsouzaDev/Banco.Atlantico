using Newtonsoft.Json;
using System;

namespace Banco.Atlantico.Application.ViewModels
{
    public class ReciboSaqueViewModel
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Saldo")]
        public decimal Saldo { get; set; }
        

    }
}