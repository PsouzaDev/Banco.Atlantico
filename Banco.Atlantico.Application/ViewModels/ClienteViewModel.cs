using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Banco.Atlantico.Application.ViewModels
{
    public class ClienteViewModel
    {
        [JsonProperty("Id")]
        [Required]
        public string Id { get; set; }
        [JsonProperty("Nome")]
        public string Nome { get; set; }
    }
}