using Banco.Atlantico.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Atlantico.Domain.Models
{
    public class Caixa
    {
        public string Id { get; set; }
        public long Saldo { get; set; }
        public TiposStatus Status { get; set; }
        public int Dois { get; set; }
        public int Cinco { get; set; }
        public int Dez { get; set; }
        public int Vinte { get; set; }
        public int Cinquenta { get; set; }
    }
}
