using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Atlantico.Application.ViewModels
{
    public class SaqueViewModel
    {
        [JsonProperty("Valor")]
        public int Valor { get; set; }
        [JsonProperty("Cliente")]
        public ClienteViewModel Cliente { get; set; }
    }
}
