using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Atlantico.Domain.Models
{
    public class Saque
    {
        
        public int Valor { get; set; }
        
        public string IdCaixa { get; set; }
        public Cliente Cliente { get; set; }
    }
}
