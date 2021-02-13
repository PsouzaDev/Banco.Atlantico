using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Banco.Atlantico.Application.ViewModels
{
    public class SaqueViewModel
    {
        [Required]
        [JsonProperty("Valor")]
        public int Valor { get; set; }
        [Required]
        [JsonProperty("IdCaixa")]
        public string IdCaixa { get; set; }
        [JsonProperty("Cliente")]
        public ClienteViewModel Cliente { get; set; }
    }
}
