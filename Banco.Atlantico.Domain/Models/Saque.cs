using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Atlantico.Domain.Models
{
    public class Saque
    {
        
        public decimal Valor { get; set; }
        public string IdCaixa { get; set; }
        public string ClienteId { get; set; }
    }
}
